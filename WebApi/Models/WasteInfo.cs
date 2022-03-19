namespace WebApi.Models
{
    public class WasteInfo
    {
        public WasteInfo()
        {
            Addres = new List<AddresInfo>();
        }

        public string Name { get; set; }

        public List<AddresInfo> Addres { get; set; }
    }
}
