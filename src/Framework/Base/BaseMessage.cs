using Milimoe.OneBot.Framework.Interface;
using Milimoe.OneBot.Model.Data;

namespace Milimoe.OneBot.Framework.Base
{
    public abstract class BaseMessage : IMessage
    {
        public abstract string type { get; }

        public virtual IData data { get; set; } = new TextData("");
    }
}
