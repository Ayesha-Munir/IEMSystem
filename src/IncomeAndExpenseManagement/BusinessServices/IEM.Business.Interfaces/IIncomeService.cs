using IEM.Business.Models;

namespace IEM.Business.Interfaces
{
    public interface IIncomeService : IGenericService<IncomeModel>
    {
        public List<IncomeModel> IncomeForUser(int userID);
    }
}
