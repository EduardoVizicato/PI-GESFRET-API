using TMS.Domain.ValueObjects;

namespace PI_TMS.API.Models.ViewModel
{
    public class EnterpriseViewModel
    {
        public EnterpriseViewModel(string name, string email, TaxIdVO taxId)
        {
            Name = name;
            Email = email;
            TaxId = taxId;
        }

        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public TaxIdVO TaxId { get; set; }
    }
}
