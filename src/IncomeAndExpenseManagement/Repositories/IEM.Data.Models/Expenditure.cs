namespace IEM.Data.Models
{
    public class Expenditure : BaseEntity
    {
        public string Name { get; set; } = string.Empty;
        public string Category { get; set; } = string.Empty;
        public int Amount { get; set; }
        public int UserID { get; set; }

        // Navigation Properties
        public virtual User? User { get; set; }


    }
}
