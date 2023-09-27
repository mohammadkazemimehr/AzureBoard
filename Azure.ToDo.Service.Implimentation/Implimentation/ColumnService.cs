namespace Azure.ToDo.Service.Implimentation.Implimentation
{
    public class ColumnService : IColumnService
    {
        private readonly IUnitOfWork _unitOfWork;
        public ColumnService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<ResponseMessage> Post(CreateColumnCommand command)
        {
            var board = await _unitOfWork.BoardRepository.GetByIdAsync(command.BoardId);
            board.CheckShouldThrowNotFoundException("Board not found");

            var checkColumnTitle = await _unitOfWork.ColumnRepository.AnyAsync(c => c.Bord == board && c.Title == command.Title && c.IsActive);
            if (checkColumnTitle)
                ResponseHandler.NotFound("The column title is duplicated.");

            var columnId = _unitOfWork.ColumnRepository.Create(board, command.Title, command.Limit);

            await _unitOfWork.CommitAsync();

            return ResponseHandler.OkResult("Column created successfully", columnId);
        }
        public async Task<ResponseMessage> Put(UpdateColumnCommand command)
        {
            var column = await _unitOfWork.ColumnRepository.FirstOrDefaultAsync(c => c.Id == command.Id && c.IsActive);
            column.CheckShouldThrowNotFoundException("Column not found");

            var checkColumnTitle = await _unitOfWork.ColumnRepository.AnyAsync(c => c.Bord.Id == command.BoardId && c.Id != command.Id && c.Title == command.Title && c.IsActive);
            if (checkColumnTitle)
                ResponseHandler.NotFound("The column title is duplicated.");

            column.Title = command.Title;
            column.Limit = command.Limit;

            await _unitOfWork.CommitAsync();

            return ResponseHandler.OkResult("Column updated successfully", column.Id);
        }

        public async Task<ResponseMessage> GetDetail(Guid id)
        {
            var column = await _unitOfWork.ColumnRepository.FirstOrDefaultAsync(c => c.Id == id && c.IsActive);
            column.CheckShouldThrowNotFoundException("Column not found");

            var result = new
            {
                id = id,
                title = column.Title,
                limit = column.Limit
            };

            return ResponseHandler.OkResult("column detail", result);
        }

        public async Task<ResponseMessage> Delete(Guid id)
        {
            var column = await _unitOfWork.ColumnRepository.FirstOrDefaultAsync(c => c.Id == id && c.IsActive);
            column.CheckShouldThrowNotFoundException("Column not found");

            column.IsActive = false;

            await _unitOfWork.CommitAsync();

            return ResponseHandler.OkResult("Column delete successfully");
        }
    }
}
