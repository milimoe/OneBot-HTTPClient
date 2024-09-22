using System.Text;
using Milimoe.FunGame.Core.Api.Utility;
using Milimoe.OneBot.Framework.Interface;
using Milimoe.OneBot.Utility;

namespace Milimoe.OneBot.Framework
{
    public class HTTPPost
    {
        public static string Address { get; set; } = "";
        public static string Port { get; set; } = "";
        public static bool Enable_SSL { get; set; } = false;
        public static string Token { get; set; } = "";

        private static bool _first = true;

        public static void GetSettings()
        {
            HTTPHelper.CheckExistsINI();
            Address = INIHelper.ReadINI("Post", "address", "config.ini");
            Port = INIHelper.ReadINI("Post", "port", "config.ini");
            Enable_SSL = Convert.ToBoolean(INIHelper.ReadINI("Post", "ssl", "config.ini").ToLower());
            Token = INIHelper.ReadINI("Post", "token", "config.ini").ToLower();
        }

        public static async Task<HttpResponseMessage> Post(string post_type, IContent content, string referrer = "", bool reget_settings = false)
        {
            if (_first || reget_settings)
            {
                _first = false;
                GetSettings();
            }

            HttpClient client = new()
            {
                BaseAddress = new Uri(Enable_SSL ? "https://" : "http://" + Address + ":" + Port + "/" + post_type)
            };
            client.DefaultRequestHeaders.Add("Authorization", "Bearer " + Token);
            if (referrer.Trim() != "") client.DefaultRequestHeaders.Referrer = new Uri(referrer);

            string json = HTTPHelper.GetJsonString(post_type, content);
            using StringContent json_content = new(json, Encoding.UTF8, "application/json");

            HttpResponseMessage msg = await client.PostAsync(client.BaseAddress, json_content);
            client.Dispose();
            return msg;
        }

        public static async Task<List<HttpResponseMessage>> Post(string post_type, IEnumerable<IContent> contents, string referrer = "", bool reget_settings = false)
        {
            if (_first || reget_settings)
            {
                _first = false;
                GetSettings();
            }

            HttpClient client = new()
            {
                BaseAddress = new Uri(Enable_SSL ? "https://" : "http://" + Address + ":" + Port + "/" + post_type)
            };
            client.DefaultRequestHeaders.Add("Authorization", "Bearer " + Token);
            if (referrer.Trim() != "") client.DefaultRequestHeaders.Referrer = new Uri(referrer);

            List<Task<HttpResponseMessage>> tasks = [];
            List<HttpResponseMessage> responses = [];

            foreach (IContent content in contents)
            {
                string json = HTTPHelper.GetJsonString(post_type, content);
                StringContent json_content = new(json, Encoding.UTF8, "application/json");
                tasks.Add(client.PostAsync(client.BaseAddress, json_content));
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
