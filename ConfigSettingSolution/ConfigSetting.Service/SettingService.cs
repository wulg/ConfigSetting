using ConfigSetting.Common;
using ConfigSetting.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConfigSetting.Service
{
    public class SettingService : ISettingService
    {
        public T GetValue<T>(string applicationId, string key)
        {
            var data = DbProvider.Instance.GetSettingValue(applicationId, key);
            if (!string.IsNullOrEmpty(data))
            {
                return ConvertHelper.ConvertSimpleType<T>(data);
            }
            return default(T);
        }

        public T GetChildValue<T>(string applicationId, string childId, string key)
        {
            //判断是否是子节点
            if (DbProvider.Instance.IsExistChildApp(applicationId, childId))
            {
                //查询子节点数据
                var data = DbProvider.Instance.GetSettingValue(childId, key);
                if (!string.IsNullOrEmpty(data))
                {
                    return ConvertHelper.ConvertSimpleType<T>(data);
                }
            }
            return default(T);
        }
    }
}
