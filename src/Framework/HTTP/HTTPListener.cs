using System.Net;
using System.Text;
using Milimoe.FunGame.Core.Api.Utility;
using Milimoe.OneBot.Framework.Interface;
using Milimoe.OneBot.Model.Event;
using Milimoe.OneBot.Utility;

namespace Milimoe.OneBot.Framework
{
    public class HTTPListener
    {
        protected HttpListener? listener { get; set; } = default;

        public HTTPListener()
        {
            listener = new()
            {
                AuthenticationSchemes = AuthenticationSchemes.Anonymous
            };

            HTTPHelper.CheckExistsINI();
            string address = INIHelper.ReadINI("Listener", "address", "config.ini");
            string port = INIHelper.ReadINI("Listener", "port", "config.ini");
            bool enable_ssl = Convert.ToBoolean(INIHelper.ReadINI("Listener", "ssl", "config.ini").ToLower());

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
            if (listener is null) return;

            HttpListenerContext ctx = listener.GetContext();
            ctx.Response.StatusCode = 200;

            Stream stream = ctx.Request.InputStream;
            StreamReader reader = new(stream, Encoding.UTF8);
            string body = reader.ReadToEnd();

            // 广播到具体监听事件中，处理POST数据
            OnGroupMessageHandle(body);
            OnFriendMessageHandle(body);
        }

        public delegate void GroupMessageListeningTask(GroupMessageEvent event_group);
        public event GroupMessageListeningTask? GroupMessageListening;
        public void OnGroupMessageHandle(string msg) => GroupMessageListening?.Invoke(CheckObject<GroupMessageEvent>((GroupMessageEvent)HTTPHelper.ParsingMsgToEvent<GroupMessageEvent>(msg)));

        public delegate void FriendMessageListeningTask(FriendMessageEvent event_friend);
        public event FriendMessageListeningTask? FriendMessageListening;
        public void OnFriendMessageHandle(string msg) => FriendMessageListening?.Invoke(CheckObject<FriendMessageEvent>((FriendMessageEvent)HTTPHelper.ParsingMsgToEvent<FriendMessageEvent>(msg)));
        
        private T CheckObject<T>(IEvent obj_event)
        {
            if (typeof(T) != obj_event.GetType())
            {
                throw new InvalidCastException(obj_event.GetType().FullName + "不是" + typeof(T).FullName + "。");
            }
            return (T)obj_event;
        }
    }
}
