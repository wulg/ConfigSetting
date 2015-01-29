using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConfigSetting.Service
{
    public interface ISettingService
    {       
        T GetValue<T>(string applicationId, string key);
        T GetChildValue<T>(string applicationId, string childId, string key);
        
    }
}
