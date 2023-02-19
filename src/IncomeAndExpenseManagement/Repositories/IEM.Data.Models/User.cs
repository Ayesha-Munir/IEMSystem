namespace IEM.Data.Models
{
    public class User : BaseEntity
    {
        public string Username { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;

        // Navigation Properties
        public virtual HashSet<Income>? Incomes { get; set; }
        public virtual HashSet<Expenditure>? Expenditures { get; set; }
    }
}
