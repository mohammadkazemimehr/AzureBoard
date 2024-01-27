using Azure.ToDo.Domain.Entities;
using Azure.ToDo.Repository.Implimation;
using Azure.ToDo.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Azure.ToDo.TDD.MockRepository
{
    public class BoardMockRepository : IBoardRepository
    {
        public BoardMockRepository()
        {
            
        }

        public Task<bool> AnyAsync(Expression<Func<Board, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public Task<Guid> CreateBoard(string name, User user)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Board>> FindAsync(Expression<Func<Board, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public Task<Board> FirstOrDefaultAsync(Expression<Func<Board, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public ValueTask<Board> GetByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<Board> GetFirstWithIncludeAsync(string includeProperties, Expression<Func<Board, bool>> filter = null)
        {
            throw new NotImplementedException();
        }
    }
}
