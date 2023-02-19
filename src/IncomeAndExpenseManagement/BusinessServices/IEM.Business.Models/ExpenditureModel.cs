using IEM.Data.Models;

namespace IEM.Business.Models
{
    public class ExpenditureModel
    {
        public int ExpID { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Category { get; set; } = string.Empty;
        public int Amount { get; set; }
        public int UserID { get; set; }
        public virtual User? User { get; set; }
    }
}
