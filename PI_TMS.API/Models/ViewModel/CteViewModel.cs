namespace PI_TMS.API.Models.ViewModel
{
    public class CteViewModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public IFormFile File { get; set; }
    }
}
