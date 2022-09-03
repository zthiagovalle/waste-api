using WebApi.Models;

namespace WebApi.IBll
{
    public interface IWaste
    {
        Task<List<WasteInfo>> GetWasteByGoogleSheetAsync();
    }
}