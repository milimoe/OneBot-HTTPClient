using Util = Milimoe.FunGame.Core.Api.Utility.TaskUtility;

namespace Milimoe.OneBot.Framework.Utility
{
    public class TaskUtility
    {
        public static void NewTask(Action action) => Util.NewTask(action);
        public static void NewTask(Func<Task> task) => Util.NewTask(task);
        public static void RunTimer(Action action, int milliseconds) => Util.RunTimer(action, milliseconds);
    }
}
