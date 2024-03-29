﻿using System.Net;
using System.Text;
using Milimoe.FunGame.Core.Api.Utility;
using Milimoe.OneBot.Framework.Interface;
using Milimoe.OneBot.Framework.Utility;
using Milimoe.OneBot.Model.Event;
using Milimoe.OneBot.Model.QuickReply;
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
            List<Task> tasks = [];
            GroupMsgEventQuickReply? group_quick_reply = null;
            FriendMsgEventQuickReply? friend_quick_reply = null;

            tasks.Add(Task.Run(() =>
            {
                try
                {
                    OnGroupBanNoticeHandle(body);
                }
                catch (Exception e)
                {
                    TXTHelper.AppendErrorLog(e.ToString() + "\r\nSource Message:\r\n" + body);
                }
            }));
            tasks.Add(Task.Run(() =>
            {
                try
                {
                    OnGroupMessageHandle(body, out group_quick_reply);
                }
                catch (Exception e)
                {
                    TXTHelper.AppendErrorLog(e.ToString() + "\r\nSource Message:\r\n" + body);
                }
            }));
            tasks.Add(Task.Run(() =>
            {
                try
                {
                    OnFriendMessageHandle(body, out friend_quick_reply);
                }
                catch (Exception e)
                {
                    TXTHelper.AppendErrorLog(e.ToString() + "\r\nSource Message:\r\n" + body);
                }
            }));

            Task.WaitAll([.. tasks]);

            // 处理快速操作
            if (group_quick_reply != null || friend_quick_reply != null)
            {
                string json = group_quick_reply != null ? JsonTools.GetString(group_quick_reply) : (friend_quick_reply != null ? JsonTools.GetString(friend_quick_reply) : "");
                byte[] buffer = Encoding.UTF8.GetBytes(json);
                HttpListenerResponse response = ctx.Response;
                response.ContentType = "application/json";
                response.ContentLength64 = buffer.Length;
                response.OutputStream.Write(buffer);
            }
        }

        public delegate void GroupMessageListeningTask(GroupMessageEvent event_group, out GroupMsgEventQuickReply? quick_reply);
        public event GroupMessageListeningTask? GroupMessageListening;
        public void OnGroupMessageHandle(string msg, out GroupMsgEventQuickReply? quick_reply)
        {
            quick_reply = null;
            IEvent e = HTTPHelper.ParseMsgToEvent<GroupMessageEvent>(msg);
            if (e.post_type == "message" && e.post_sub_type == "group") GroupMessageListening?.Invoke((GroupMessageEvent)e, out quick_reply);
        }

        public delegate void GroupBanNoticeListeningTask(GroupBanEvent event_groupban);
        public event GroupBanNoticeListeningTask? GroupBanNoticeListening;
        public void OnGroupBanNoticeHandle(string msg)
        {
            IEvent e = HTTPHelper.ParseMsgToEvent<GroupBanEvent>(msg);
            if (e.post_type == "notice" && e.post_sub_type == "group_ban") GroupBanNoticeListening?.Invoke((GroupBanEvent)e);
        }

        public delegate void FriendMessageListeningTask(FriendMessageEvent event_friend, out FriendMsgEventQuickReply? quick_reply);
        public event FriendMessageListeningTask? FriendMessageListening;
        public void OnFriendMessageHandle(string msg, out FriendMsgEventQuickReply? quick_reply)
        {
            quick_reply = null;
            IEvent e = HTTPHelper.ParseMsgToEvent<FriendMessageEvent>(msg);
            if (e.post_type == "message" && e.post_sub_type == "private") FriendMessageListening?.Invoke((FriendMessageEvent)e, out quick_reply);
        }
    }
}
