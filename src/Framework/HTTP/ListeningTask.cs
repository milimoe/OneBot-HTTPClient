using Milimoe.OneBot.Framework.Interface;
using Milimoe.OneBot.Model.Event;

namespace Milimoe.OneBot.Api
{
    public class ListeningTask
    {
        public delegate void GroupMessageListeningTask(GroupMessageEvent event_group);
        public static event GroupMessageListeningTask? GroupMessageTasks;
        public static void OnGroupMessageHandle(string msg) => GroupMessageTasks?.Invoke(CheckObject<GroupMessageEvent>((GroupMessageEvent)HTTPHelper.ParsingMsgToEvent<GroupMessageEvent>(msg)));

        public delegate void FriendMessageListeningTask(FriendMessageEvent event_friend);
        public static event FriendMessageListeningTask? FriendMessageTasks;
        public static void OnFriendMessageHandle(string msg) => FriendMessageTasks?.Invoke(CheckObject<FriendMessageEvent>((FriendMessageEvent)HTTPHelper.ParsingMsgToEvent<FriendMessageEvent>(msg)));

        private static T CheckObject<T>(IEvent obj_event)
        {
            if (typeof(T) != obj_event.GetType())
            {
                throw new InvalidCastException(obj_event.GetType().FullName + "不是" + typeof(T).FullName + "。");
            }
            return (T)obj_event;
        }
    }
}
