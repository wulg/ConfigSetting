using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConfigSetting.Model
{
    /// <summary>
    /// 用户操作记录
    /// </summary>
    public class UserAction
    {
        /// <summary>
        /// 主键ID
        /// </summary>
        public string ID { get; set; }
        /// <summary>
        /// 所属应用程序域
        /// </summary>
        public string ApplicationID { get; set; }
        /// <summary>
        /// 操作人
        /// </summary>
        public string UserName { get; set; }
        /// <summary>
        /// 操作类型
        /// </summary>
        public string Type { get; set; }
        /// <summary>
        /// 操作内容
        /// </summary>
        public string Details { get; set; }
        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CreateTime { get; set; }
    }
}
