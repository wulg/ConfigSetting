using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConfigSetting.Data
{
    public class DbFields
    {
        public const string SETTING = "[id],[applicationid],[md5],[key],[value],[version],[isunique],[description],[lastoperator],[createtime],[updatetime]";

        public const string APPLICATION = "[id],[appid],[name],[licensekey],[parentid],[status],[createtime],[updatetime]";

        public const string USER = "[id],[applicationid],[username],[password],[lastpassword],[lastlogindate],[createtime]";

        public const string USERACTION = "[id],[applicationid],[username],[type],[details],[createtime]";      
    }
}
