using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConfigSetting.Model
{
    /// <summary>
    /// 配置数据
    /// </summary>
    public class Setting
    {
        /// <summary>
        /// 主键
        /// </summary>
        public string ID { get; set; }

        /// <summary>
        /// 所属者
        /// </summary>
        public string ApplicationID { get; set; }
        /// <summary>
        /// 加密串
        /// </summary>
        public string MD5 { get; set; }
        /// <summary>
        /// 配置的关键字
        /// </summary>
        public string Key { get; set; }

        /// <summary>
        /// 配置的值
        /// </summary>
        public string Value { get; set; }

        /// <summary>
        /// 版本号
        /// </summary>
        public string Version { get; set; }

        /// <summary>
        /// 只读为true的行数据 默认只有唯一true其余都false
        /// </summary>
        public bool IsUnique { get; set; }

        /// <summary>
        /// 参数说明
        /// </summary>
        public string Description { get; set; }
        /// <summary>
        /// 最后操作人
        /// </summary>
        public string LastOperator { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CreateTime { get; set; }

        /// <summary>
        /// 更新时间
        /// </summary>
        public DateTime UpdateTime { get; set; }
    }
}
