using System.Net;
using System.Text;
using Milimoe.FunGame.Core.Api.Utility;
using Milimoe.OneBot.Framework.Interface;
using Milimoe.OneBot.Framework.Utility;
using Milimoe.OneBot.Model.Event;
using Milimoe.OneBot.Model.QuickReply;

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

        public async Task GetContext()
        {
            if (listener is null) return;

            HttpListenerContext ctx = listener.GetContext();
            ctx.Response.StatusCode = 200;

            Stream stream = ctx.Request.InputStream;
            StreamReader reader = new(stream, Encoding.UTF8);
            string body = reader.ReadToEnd();

            GroupMsgEventQuickReply? group_quick_reply = null;
            FriendMsgEventQuickReply? friend_quick_reply = null;

            // 广播到具体监听事件中，处理POST数据
            try
            {
                Task<GroupMsgEventQuickReply?> task_groupmsg = OnGroupMessageHandle(body);
                Task task_groupban = OnGroupBanNoticeHandle(body);
                Task task_grouprecall = OnGroupRecallNoticeHandle(body);
                Task<FriendMsgEventQuickReply?> task_friendmsg = OnFriendMessageHandle(body);

                await Task.WhenAll(task_groupmsg, task_groupban, task_grouprecall, task_friendmsg);

                group_quick_reply = await task_groupmsg;
                friend_quick_reply = await task_friendmsg;
            }
            catch (Exception e)
            {
                TXTHelper.AppendErrorLog(e.ToString());
            }

            // 处理快速操作
            string json = "{}";
            if (group_quick_reply != null || friend_quick_reply != null)
            {
                json = group_quick_reply != null ? JsonTools.GetString(group_quick_reply) : (friend_quick_reply != null ? JsonTools.GetString(friend_quick_reply) : "");
            }

            // 回复HTTP请求
            byte[] buffer = Encoding.UTF8.GetBytes(json);
            HttpListenerResponse response = ctx.Response;
            response.ContentType = "application/json";
            response.ContentLength64 = buffer.Length;
            response.OutputStream.Write(buffer);
        }

        public delegate Task<GroupMsgEventQuickReply?> GroupMessageListeningTask(GroupMessageEvent event_group);
        public event GroupMessageListeningTask? GroupMessageListening;
        public async Task<GroupMsgEventQuickReply?> OnGroupMessageHandle(string msg)
        {
            IEvent e = HTTPHelper.ParseMsgToEvent<GroupMessageEvent>(msg);
            if (e.post_type == "message" && e.post_sub_type == "group" && GroupMessageListening != null) return await GroupMessageListening.Invoke((GroupMessageEvent)e);
            return null;
        }

        public delegate Task GroupBanNoticeListeningTask(GroupBanEvent event_groupban);
        public event GroupBanNoticeListeningTask? GroupBanNoticeListening;
        public async Task OnGroupBanNoticeHandle(string msg)
        {
            IEvent e = HTTPHelper.ParseMsgToEvent<GroupBanEvent>(msg);
            if (e.post_type == "notice" && e.post_sub_type == "group_ban" && GroupBanNoticeListening != null) await GroupBanNoticeListening.Invoke((GroupBanEvent)e);
        }

        public delegate Task GroupRecallNoticeListeningTask(GroupRecallEvent event_grouprecall);
        public event GroupRecallNoticeListeningTask? GroupRecallNoticeListening;
        public async Task OnGroupRecallNoticeHandle(string msg)
        {
            IEvent e = HTTPHelper.ParseMsgToEvent<GroupRecallEvent>(msg);
            if (e.post_type == "notice" && e.post_sub_type == "group_recall" && GroupRecallNoticeListening != null) await GroupRecallNoticeListening.Invoke((GroupRecallEvent)e);
        }

        public delegate Task<FriendMsgEventQuickReply?> FriendMessageListeningTask(FriendMessageEvent event_friend);
        public event FriendMessageListeningTask? FriendMessageListening;
        public async Task<FriendMsgEventQuickReply?> OnFriendMessageHandle(string msg)
        {
            IEvent e = HTTPHelper.ParseMsgToEvent<FriendMessageEvent>(msg);
            if (e.post_type == "message" && e.post_sub_type == "private" && FriendMessageListening != null) return await FriendMessageListening.Invoke((FriendMessageEvent)e);
            return null;
        }
    }
}
