using RestSharp;
using WebApi.Models;

namespace WebApi.Bll
{
    public class Waste
    {
        public async Task<List<WasteInfo>> GetWasteByGoogleSheetAsync(string endPoint)
        {
            try
            {
                var lstWasteInfo = new List<WasteInfo>();
                var client = new RestClient();
                var request = new RestRequest(endPoint);
                var response = await client.GetAsync(request);
                var rows = response.Content.Split("\n");


                foreach (var row in rows)
                {
                    var wasteInfo = new WasteInfo();
                    row.Trim();
                    var blocks = row.Split(",");

                    wasteInfo.Name = blocks[0].Trim();

                    var addresses = blocks[1].Split("|");
                    var coordinates = blocks[2].Split("|");

                    for (int i = 0; i < addresses.Length; i++)
                    {
                        var addressInfo = new AddresInfo { Street = addresses[i].Trim() };
                        addressInfo.Lat = coordinates[i].Split(" ")[0].Trim();
                        addressInfo.Lng = coordinates[i].Split(" ")[1].Trim();
                        wasteInfo.Address.Add(addressInfo);   
                    }
                    lstWasteInfo.Add(wasteInfo);
                }

                return lstWasteInfo;
            }
            catch
            {
                return new List<WasteInfo>();
            }
        }
    }
}
