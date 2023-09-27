namespace Azure.ToDo.Service.Implimentation.Implimentation
{
    internal class ColumnItemService : IColumnItemService
    {
        private readonly IUnitOfWork _unitOfWork;
        public ColumnItemService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<ResponseMessage> ChangeColumn(ChangeColumnCommand command)
        {
            var column = await _unitOfWork.ColumnRepository.FirstOrDefaultAsync(c => c.Id == command.ColumnId && c.IsActive);
            column.CheckShouldThrowNotFoundException("column not found");

            var columnItem = await _unitOfWork.ColumnItemRepository.FirstOrDefaultAsync(c => c.Id == command.Id && c.IsActive);

            columnItem.Column = column;

            return ResponseHandler.OkResult("Column Changed");
        }

        public async Task<ResponseMessage> Delete(Guid id)
        {
            var columnItem = await _unitOfWork.ColumnItemRepository.FirstOrDefaultAsync(c => c.Id == id);
            columnItem.CheckShouldThrowNotFoundException("column Item not found");

            columnItem.IsActive = false;

            await _unitOfWork.CommitAsync();

            return ResponseHandler.OkResult("Deleted successfully");
        }

        public async Task<ResponseMessage> GetDetail(Guid id)
        {
            var columnItem = await _unitOfWork.ColumnItemRepository.FirstOrDefaultAsync(c => c.Id == id && c.IsActive);

            var result = new
            {
                Title = columnItem.Title,
                Type = columnItem.Type,
                Description = columnItem.Description,
            };

            return ResponseHandler.OkResult("Column Item Detail", result);
        }

        public async Task<ResponseMessage> Post(AddColumnItemCommand command)
        {
            var board = await _unitOfWork.BoardRepository.FirstOrDefaultAsync(c => c.IsActive && c.Id == command.BoardId);
            board.CheckShouldThrowNotFoundException("Board not found");

            var firstColumn = await _unitOfWork.ColumnRepository.FirstOrDefaultAsync(c => c.Bord == board && c.Title == "New");
            firstColumn.CheckShouldThrowNotFoundException("Column not found");

            var itemId = _unitOfWork.ColumnItemRepository.Create(firstColumn, command.Title, command.Type, command.Description);

            await _unitOfWork.CommitAsync();

            return ResponseHandler.OkResult("item created successfully", itemId);
        }

        public async Task<ResponseMessage> Put(UpdateColumnItemCommand command)
        {
            var columnItem = await _unitOfWork.ColumnItemRepository.FirstOrDefaultAsync(c => c.Id == command.Id);
            columnItem.CheckShouldThrowNotFoundException("column Item not found");


            columnItem.Type = command.Type;
            columnItem.Description = command.Description;
            columnItem.Title = command.Title;

            await _unitOfWork.CommitAsync();

            return ResponseHandler.OkResult("item updated successfully", columnItem.Id);
        }
    }
}
