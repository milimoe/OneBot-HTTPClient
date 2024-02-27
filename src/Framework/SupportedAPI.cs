namespace Milimoe.OneBot.Framework
{
    public class SupportedAPI
    {
        /// <summary>
        /// 获取登录号信息
        /// </summary>
        public const string get_login_info = "get_login_info";

        /// <summary>
        /// 发送消息
        /// </summary>
        public const string send_msg = "send_msg";

        /// <summary>
        /// 发送群消息
        /// </summary>
        public const string send_group_msg = "send_group_msg";

        /// <summary>
        /// 发送私聊消息
        /// </summary>
        public const string send_private_msg = "send_private_msg";

        /// <summary>
        /// 撤回消息
        /// </summary>
        public const string delete_msg = "delete_msg";

        /// <summary>
        /// 获取群列表
        /// </summary>
        public const string get_group_list = "get_group_list";

        /// <summary>
        /// 获取群信息
        /// </summary>
        public const string get_group_info = "get_group_info";

        /// <summary>
        /// 获取群成员列表
        /// </summary>
        public const string get_group_member_list = "get_group_member_list";

        /// <summary>
        /// 获取群成员信息
        /// </summary>
        public const string get_group_member_info = "get_group_member_info";

        /// <summary>
        /// 获取好友列表
        /// </summary>
        public const string get_friend_list = "get_friend_list";

        /// <summary>
        /// 获取消息
        /// </summary>
        public const string get_msg = "get_msg";

        /// <summary>
        /// 发送好友赞
        /// </summary>
        public const string send_like = "send_like";
        
        /// <summary>
        /// 群组全员禁言
        /// </summary>
        public const string set_group_whole_ban = "set_group_whole_ban";
        
        /// <summary>
        /// 群组单人禁言
        /// </summary>
        public const string set_group_ban = "set_group_ban";
        
        /// <summary>
        /// 群组踢人
        /// </summary>
        public const string set_group_kick = "set_group_kick";

        /// <summary>
        /// 群组设置管理员
        /// </summary>
        public const string set_group_admin = "set_group_admin";

        /// <summary>
        /// 设置群名片（群备注）
        /// </summary>
        public const string set_group_card = "set_group_card";

        /// <summary>
        /// 设置群名
        /// </summary>
        public const string set_group_name = "set_group_name";
        
        /// <summary>
        /// 获取版本信息
        /// </summary>
        public const string get_version_info = "get_version_info";

        /// <summary>
        /// 获取运行状态
        /// </summary>
        public const string get_status = "get_status";

        /// <summary>
        /// 检查是否可以发送图片
        /// </summary>
        public const string can_send_image = "can_send_image";

        /// <summary>
        /// 检查是否可以发送语音
        /// </summary>
        public const string can_send_record = "can_send_record";
    }
}