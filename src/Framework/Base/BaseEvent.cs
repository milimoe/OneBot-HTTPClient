﻿using Milimoe.OneBot.Framework.Interface;

namespace Milimoe.OneBot.Framework.Base
{
    public class BaseEvent() : IEvent
    {
        public string original_msg { get; set; } = "";

        public bool CheckThrow(long lesserthan, out long dice)
        {
            dice = new Random().NextInt64(100);
            return dice < lesserthan;
        }
    }
}
