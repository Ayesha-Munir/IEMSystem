using IEM.Data.Interfaces;
using IEM.Data.Models;

namespace IEM.Data
{
    public class ExpenditureRepository : Respository<Expenditure>, IExpenditureRepository
    {
        public ExpenditureRepository(IEM_DbContext context) : base(context)
        { }
    }
}
