using System.IO;
using System.Threading.Tasks;
using Waybill.Models;

namespace Waybill.Helpers
{
    class SettingsReader
    {
        static public async Task<SenderSettings> GetSenderSettings(string senderSettingsPath)
        {
            using (StreamReader sr = File.OpenText(senderSettingsPath)) // to be changed to not be hardcoded
            {
                return Newtonsoft.Json.JsonConvert.DeserializeObject<SenderSettings>(await sr.ReadToEndAsync());
            }
        }
    }
}
    