namespace WebApi.Models
{
    public class WasteInfo
    {
        public WasteInfo()
        {
            Address = new List<AddresInfo>();
        }

        public string Name { get; set; }

        public List<AddresInfo> Address { get; set; }
    }
}
