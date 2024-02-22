namespace Milimoe.OneBot.Framework
{
    public class SupportedAPI
    {
        public const string get_login_info = "get_login_info"; // 获取登录号信息
        public const string send_msg = "send_msg"; // 发送消息
        public const string send_group_msg = "send_group_msg"; // 发送群消息
        public const string send_private_msg = "send_private_msg"; // 发送私聊消息
        public const string delete_msg = "delete_msg"; // 撤回消息
        public const string get_group_list = "get_group_list"; // 获取群列表
        public const string get_group_info = "get_group_info"; // 获取群信息
        public const string get_group_member_list = "get_group_member_list"; // 获取群成员列表
        public const string get_group_member_info = "get_group_member_info"; // 获取群成员信息
        public const string get_friend_list = "get_friend_list"; // 获取好友列表
        public const string get_msg = "get_msg"; // 获取消息
        public const string send_like = "send_like"; // 发送好友赞
        public const string get_version_info = "get_version_info"; // 获取版本信息
        public const string get_status = "get_status"; // 获取运行状态
        public const string can_send_image = "can_send_image"; // 检查是否可以发送图片
        public const string can_send_record = "can_send_record"; // 检查是否可以发送语音
    }
}