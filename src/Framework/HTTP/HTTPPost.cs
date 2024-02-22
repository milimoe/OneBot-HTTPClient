using System.Text;
using Milimoe.FunGame.Core.Api.Utility;
using Milimoe.OneBot.Framework.Interface;

namespace Milimoe.OneBot.Api
{
    public class HTTPPost
    {
        public static async Task Post(string post_type, IContent content, bool enable_ssl = false)
        {
            try
            {
                HttpClient client = new();

                HTTPHelper.CheckExistsINI();
                string address = INIHelper.ReadINI("Post", "address", "config.ini");
                string port = INIHelper.ReadINI("Post", "port", "config.ini");

                client.BaseAddress = new Uri(enable_ssl ? "https://" : "http://" + address + ":" + port + "/" + post_type);

                string json = HTTPHelper.GetJsonString(post_type, content);
                using StringContent jsonContent = new(json, Encoding.UTF8, "application/json");

                HttpResponseMessage msg = await client.PostAsync(client.BaseAddress, jsonContent);
                client.Dispose();
                Console.WriteLine("Post -> " + "" + " " + msg.ReasonPhrase ?? "");
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }
    }
}
