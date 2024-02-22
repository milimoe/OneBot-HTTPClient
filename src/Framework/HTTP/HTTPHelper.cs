using Milimoe.FunGame.Core.Api.Utility;
using Milimoe.FunGame.Core.Library.Constant;
using Milimoe.OneBot.Framework;
using Milimoe.OneBot.Framework.Interface;
using Milimoe.OneBot.Model.Content;
using Milimoe.OneBot.Model.Event;

namespace Milimoe.OneBot.Api
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
                INIHelper.WriteINI("Post", "address", "127.0.0.1", "config.ini");
                INIHelper.WriteINI("Post", "port", "33330", "config.ini");
            }
        }

        internal static IEvent ParsingMsgToEvent<T>(string response_msg)
        {
            IEvent result = new EmptyEvent(response_msg);
            try
            {
                // TODO
                if (typeof(T) == typeof(GroupMessageEvent))
                {
                    //result = NetworkUtility.JsonDeserialize<GroupMessageEvent>(response_msg) ?? new GroupMessageEvent(response_msg);
                    result = new GroupMessageEvent(response_msg);
                }
                if (typeof(T) == typeof(FriendMessageEvent))
                {
                    //result = NetworkUtility.JsonDeserialize<FriendMessageEvent>(response_msg) ?? new FriendMessageEvent(response_msg);
                    result = new FriendMessageEvent(response_msg);
                }
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
                return post_type switch
                {
                    SupportedAPI.send_group_msg => NetworkUtility.JsonSerialize((GroupMessageContent)content),
                    _ => NetworkUtility.JsonSerialize(content),
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
