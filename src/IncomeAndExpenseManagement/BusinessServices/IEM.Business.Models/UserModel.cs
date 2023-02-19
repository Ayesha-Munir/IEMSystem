using IEM.Data.Models;

namespace IEM.Business.Models
{
    public class UserModel
    {
        public int UserID { get; set; }
        public string Username { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public virtual HashSet<Income>? Incomes { get; set; }
        public virtual HashSet<Expenditure>? Expenditures { get; set; }
    }
}