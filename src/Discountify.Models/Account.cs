namespace Discountify.Models
{
    public class Account : BaseAuditedEntity
    {
        public string FirstName { get; set; }

        public string SecondName { get; set; }

        public string LastName { get; set; }

        public int Age { get; set; }

        public string Email { get; set; }
    }
}
