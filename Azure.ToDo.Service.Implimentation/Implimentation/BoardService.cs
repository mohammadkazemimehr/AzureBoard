namespace Azure.ToDo.Service.Implimentation.Implimentation
{
    public class BoardService : IBoardService
    {
        private readonly IUnitOfWork _unitOfWork;
        public BoardService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<ResponseMessage> Post(CreateBoardCommand command,Guid userId)
        {
            var boardOwner = await _unitOfWork.UserRepository.FirstOrDefaultAsync(c => c.Id == userId);

            var bordNameCheck = await _unitOfWork.BoardRepository.AnyAsync(c => c.Name == command.Name && c.Owner == boardOwner && c.IsActive);
           
            if (bordNameCheck)
                ResponseHandler.BadRequest("The bord title is duplicated.");

            var bordId = await _unitOfWork.BoardRepository.CreateBoard(command.Name, boardOwner);
            await _unitOfWork.CommitAsync();

            return ResponseHandler.OkResult("Bord created successfully", bordId);
        }

        public async Task<ResponseMessage> Put(UpdateBoardCommand command)
        {
            var board = await _unitOfWork.BoardRepository.FirstOrDefaultAsync(c => c.Id == command.Id && c.IsActive);
            if (board == null)
                ResponseHandler.NotFound("Board not found");

            board.Name = command.Name;
            await _unitOfWork.CommitAsync();

            return ResponseHandler.OkResult("Bord updated successfully");
        }
        public async Task Delete(Guid id)
        {
            var board = await _unitOfWork.BoardRepository.FirstOrDefaultAsync(c => c.Id == id && c.IsActive);
            board.CheckShouldThrowNotFoundException("Board not found");

            board.IsActive = false;
            await _unitOfWork.CommitAsync();
        }

        public async Task<ResponseMessage> GetBoards(Guid userId)
        {
            var boards = await _unitOfWork.BoardRepository.FindAsync(c => c.IsActive && c.Owner.Id == userId);

            var result = boards.Select(b => new
            {
                Id = b.Id,
                Name = b.Name
            });

            return ResponseHandler.OkResult("Boards", result, result.Count());
        }

        public async Task<ResponseMessage> GetDetail(Guid id)
        {
            var board = await _unitOfWork.BoardRepository.GetFirstWithIncludeAsync("Owner", c => c.Id == id && c.IsActive);
            board.CheckShouldThrowNotFoundException("Board not found");

            var result = new
            {
                Name = board.Name,
                Id = board.Id,
                OwnerName = board.Owner.FirstName + " " + board.Owner.LastName,
                OwnerId = board.Owner.Id
            };

            return ResponseHandler.OkResult("Bord Detail", result);
        }

        public async Task<ResponseMessage> GetBoardPage(Guid id)
        {
            var board = await _unitOfWork.BoardRepository.GetFirstWithIncludeAsync("Columns,Columns.Items,Columns.Items.Tasks", c => c.Id == id && c.IsActive);
            board.CheckShouldThrowNotFoundException("Board not found");


            board.Columns = board.Columns.Where(c => c.IsActive).ToList();
            board.Columns.Select(c => c.Items.Where(c => c.IsActive));
            board.Columns.Select(c => c.Items.Select(i => i.Tasks.Where(t => t.IsActive)));

            var result = new BoardPageDto
            {
                Name = board.Name,
                Id = board.Id,
                Columns = board.Columns.Select(c => new ColumnDto
                {
                    Id = c.Id,
                    limit = c.Limit,
                    title = c.Title,
                    itemCount = c.Items.Count,
                    Items = c.Items.Select(i => new ColumnItemDto
                    {
                        Id = i.Id,
                        title = i.Title,
                        type = i.Type,
                        Tasks = i.Tasks.Select(t => new ItemTaskDto
                        {
                            Id = t.Id,
                            Title = t.Title,
                        }).ToList(),
                    }).ToList(),
                }).ToList(),
            };

            return ResponseHandler.OkResult("Board Page", result);
        }
    }
}
