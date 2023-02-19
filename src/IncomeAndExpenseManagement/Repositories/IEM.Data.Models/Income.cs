namespace IEM.Data.Models
{
    public class Income : BaseEntity
    {
        public int Amount { get; set; }
        public int UserID { get; set; }

        // Navigation Properties
        public virtual User? User { get; set; }
    }
}
