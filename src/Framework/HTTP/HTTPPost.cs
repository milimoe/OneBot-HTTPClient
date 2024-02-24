using System.Text;
using Milimoe.FunGame.Core.Api.Utility;
using Milimoe.OneBot.Framework.Interface;
using Milimoe.OneBot.Model.Content;
using Milimoe.OneBot.Utility;

namespace Milimoe.OneBot.Framework
{
    public class HTTPPost
    {
        public static async Task<string> Post(string post_type, IContent content)
        {
            try
            {
                HttpClient client = new();

                HTTPHelper.CheckExistsINI();
                string address = INIHelper.ReadINI("Post", "address", "config.ini");
                string port = INIHelper.ReadINI("Post", "port", "config.ini");
                bool enable_ssl = Convert.ToBoolean(INIHelper.ReadINI("Listener", "ssl", "config.ini").ToLower());

                client.BaseAddress = new Uri(enable_ssl ? "https://" : "http://" + address + ":" + port + "/" + post_type);

                string json = HTTPHelper.GetJsonString(post_type, content);
                using StringContent jsonContent = new(json, Encoding.UTF8, "application/json");

                HttpResponseMessage msg = await client.PostAsync(client.BaseAddress, jsonContent);
                client.Dispose();
                return msg.ReasonPhrase ?? "";
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return "";
            }
        }
    }
}
