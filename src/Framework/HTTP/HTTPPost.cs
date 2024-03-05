using System.Collections;
using System.Text;
using Milimoe.FunGame.Core.Api.Utility;
using Milimoe.OneBot.Framework.Interface;
using Milimoe.OneBot.Framework.Utility;
using Milimoe.OneBot.Utility;

namespace Milimoe.OneBot.Framework
{
    public class HTTPPost
    {
        public static async Task<HttpResponseMessage> Post(string post_type, IContent content)
        {
            HttpClient client = new();

            HTTPHelper.CheckExistsINI();
            string address = INIHelper.ReadINI("Post", "address", "config.ini");
            string port = INIHelper.ReadINI("Post", "port", "config.ini");
            bool enable_ssl = Convert.ToBoolean(INIHelper.ReadINI("Post", "ssl", "config.ini").ToLower());
            string token = INIHelper.ReadINI("Post", "token", "config.ini").ToLower();

            client.BaseAddress = new Uri(enable_ssl ? "https://" : "http://" + address + ":" + port + "/" + post_type);
            client.DefaultRequestHeaders.Add("Authorization", "Bearer " + token);

            string json = HTTPHelper.GetJsonString(post_type, content);
            using StringContent jsonContent = new(json, Encoding.UTF8, "application/json");

            HttpResponseMessage msg = await client.PostAsync(client.BaseAddress, jsonContent);
            client.Dispose();
            return msg;
        }

        public static async Task<List<HttpResponseMessage>> Post(string post_type, IEnumerable<IContent> contents)
        {
            HttpClient client = new();

            HTTPHelper.CheckExistsINI();
            string address = INIHelper.ReadINI("Post", "address", "config.ini");
            string port = INIHelper.ReadINI("Post", "port", "config.ini");
            bool enable_ssl = Convert.ToBoolean(INIHelper.ReadINI("Post", "ssl", "config.ini").ToLower());
            string token = INIHelper.ReadINI("Post", "token", "config.ini").ToLower();

            client.BaseAddress = new Uri(enable_ssl ? "https://" : "http://" + address + ":" + port + "/" + post_type);
            client.DefaultRequestHeaders.Add("Authorization", "Bearer " + token);

            List<Task<HttpResponseMessage>> tasks = [];
            List<HttpResponseMessage> responses = [];

            foreach (IContent content in contents)
            {
                string json = HTTPHelper.GetJsonString(post_type, content);
                StringContent jsonContent = new(json, Encoding.UTF8, "application/json");
                tasks.Add(client.PostAsync(client.BaseAddress, jsonContent));
            }

            await Task.WhenAll(tasks);
            client.Dispose();

            foreach (Task<HttpResponseMessage> task in tasks)
            {
                responses.Add(task.Result);
            }

            return responses;
        }
    }
}
