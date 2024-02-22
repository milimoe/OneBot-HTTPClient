using System.Net;
using System.Text;
using System.Web;
using Milimoe.FunGame.Core.Api.Utility;

namespace Milimoe.OneBot.Api
{
    public class HTTPListener
    {
        protected HttpListener? listener { get; set; } = default;

        public HTTPListener(bool enable_ssl = false)
        {
            listener = new()
            {
                AuthenticationSchemes = AuthenticationSchemes.Anonymous
            };

            HTTPHelper.CheckExistsINI();
            string address = INIHelper.ReadINI("Listener", "address", "config.ini");
            string port = INIHelper.ReadINI("Listener", "port", "config.ini");

            if (address.Trim() == "" || port.Trim() == "" || (int.TryParse(port, out int port_number) && port_number > 0 && port_number < 65535) == false)
            {
                throw new ArgumentException("无效的服务器地址和端口号。");
            }

            listener.Prefixes.Add(enable_ssl ? "https://" : "http://" + address + ":" + port + "/");
            listener.Start();
        }

        public bool available => listener != null;

        public string address => listener?.Prefixes.FirstOrDefault() ?? "";

        public void GetContext()
        {
            try
            {
                if (listener is null) return;

                // 监听消息，没有请求则GetContext处于阻塞状态
                HttpListenerContext ctx = listener.GetContext();

                // 设置返回给客服端http状态代码
                ctx.Response.StatusCode = 200;

                // 接收数据
                Stream stream = ctx.Request.InputStream;
                StreamReader reader = new(stream, Encoding.UTF8);
                string body = reader.ReadToEnd();
                Console.WriteLine(DateTimeUtility.GetNowTime() + " 监听到POST\r\n" + HttpUtility.UrlDecode(body));

                // 广播到具体监听事件中，处理POST数据
                ListeningTask.OnGroupMessageHandle(body);
                ListeningTask.OnFriendMessageHandle(body);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }
    }
}
