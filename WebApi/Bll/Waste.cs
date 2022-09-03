using RestSharp;
using WebApi.IBll;
using WebApi.Models;

namespace WebApi.Bll
{
    public class Waste : IWaste
    {
        private readonly string _endPoint = "https://docs.google.com/spreadsheets/d/e/2PACX-1vQ6LMYyIYZzsrMhVB4_dg0fADQ-hVx5y8qOPEe7eIP8rFm4sWoLtYURivnlTqKBFJ5qbfs69HlKbeXK/pub?output=csv";

        public async Task<List<WasteInfo>> GetWasteByGoogleSheetAsync()
        {
            try
            {
                var lstWasteInfo = new List<WasteInfo>();
                var client = new RestClient();
                var request = new RestRequest(_endPoint);
                var response = await client.GetAsync(request);
                var rows = response.Content.Split("\n");


                foreach (var row in rows)
                {
                    var wasteInfo = new WasteInfo();
                    row.Trim();
                    var blocks = row.Split(",");

                    wasteInfo.Name = blocks[0].Trim();
                    wasteInfo.ImageUrl = blocks[3].Trim();

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