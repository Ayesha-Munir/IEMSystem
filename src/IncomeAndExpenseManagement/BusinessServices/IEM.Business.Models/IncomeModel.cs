using IEM.Data.Models;

namespace IEM.Business.Models
{
    public class IncomeModel
    {
        public int IncomeID { get; set; }
        public int Amount { get; set; }
        public int UserID { get; set; }
        public virtual User? User { get; set; }
    }
}
