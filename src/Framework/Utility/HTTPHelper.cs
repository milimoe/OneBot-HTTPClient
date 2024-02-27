using Milimoe.FunGame.Core.Api.Utility;
using Milimoe.FunGame.Core.Library.Constant;
using Milimoe.OneBot.Framework;
using Milimoe.OneBot.Framework.Interface;
using Milimoe.OneBot.Framework.Utility;
using Milimoe.OneBot.Model.Content;
using Milimoe.OneBot.Model.Event;
using Milimoe.OneBot.Model.Message;

namespace Milimoe.OneBot.Utility
{
    internal class HTTPHelper
    {
        internal static void CheckExistsINI()
        {
            if (!INIHelper.ExistINIFile("config.ini"))
            {
                // 不存在则创建
                StreamWriter writer = new("config.ini", false, General.DefaultEncoding);
                writer.Write("[Listener]");
                writer.Close();
                INIHelper.WriteINI("Listener", "address", "127.0.0.1", "config.ini");
                INIHelper.WriteINI("Listener", "port", "33300", "config.ini");
                INIHelper.WriteINI("Listener", "ssl", "false", "config.ini");
                INIHelper.WriteINI("Post", "address", "127.0.0.1", "config.ini");
                INIHelper.WriteINI("Post", "port", "33330", "config.ini");
                INIHelper.WriteINI("Post", "ssl", "false", "config.ini");
            }
        }

        internal static IEvent ParsingMsgToEvent<T>(string response_msg)
        {
            IEvent result = new EmptyEvent(response_msg);
            try
            {
                if (typeof(T) == typeof(GroupMessageEvent))
                {
                    result = JsonTools.GetObject<GroupMessageEvent>(response_msg) ?? new GroupMessageEvent(response_msg);
                }
                //if (typeof(T) == typeof(FriendMessageEvent))
                //{
                //    result = JsonTools.GetObject<FriendMessageEvent>(response_msg) ?? new FriendMessageEvent(response_msg);
                //}
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            return result;
        }

        internal static string GetJsonString(string post_type, IContent content)
        {
            try
            {
                // 检查content是否存在at，有at需要在后面添加一个空白的text
                if (content is GroupMessageContent msg_content)
                {
                    List<IMessage> newlist = [];
                    newlist.AddRange(msg_content.message);
                    foreach (var item in msg_content.message.Select((m, i) => new { message = m, index = i }).Where(item => item.message.type == "at"))
                    {
                        newlist.Insert(item.index + 1, new TextMessage(" "));
                    }
                    msg_content.message.Clear();
                    msg_content.message.AddRange(newlist);
                }

                return post_type switch
                {
                    SupportedAPI.set_group_admin => JsonTools.GetString((SetGroupAdminContent)content),
                    SupportedAPI.set_group_ban => JsonTools.GetString((SetGroupBanContent)content),
                    SupportedAPI.set_group_kick => JsonTools.GetString((SetGroupKickContent)content),
                    SupportedAPI.set_group_name => JsonTools.GetString((SetGroupNameContent)content),
                    SupportedAPI.send_group_msg => JsonTools.GetString((GroupMessageContent)content),
                    _ => JsonTools.GetString(content),
                };
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            return "";
        }
    }
}
