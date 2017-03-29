using Microsoft.EntityFrameworkCore;

namespace Repository.EF.Core
{
    public class TodoRepository : Repository<Todo>
    {
        public TodoRepository(DbContext context) : base(context)
        {
        }
    }
}
