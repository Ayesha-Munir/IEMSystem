using IEM.Data.Interfaces;
using IEM.Data.Models;

namespace IEM.Data
{
    public class IncomeRepository : Respository<Income>, IIncomeRepository
    {
        public IncomeRepository(IEM_DbContext context) : base(context)
        { }
    }
}
