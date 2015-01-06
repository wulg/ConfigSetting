using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConfigSetting.Data
{
    public class DbProvider
    {
        private static IDataProvider _instance = null;
        private static object lockHelper = new object();
              
        public static IDataProvider Instance
        {
            get
            {
                if (_instance == null)
                {
                    lock (lockHelper)
                    {
                        GetProvider();
                    }
                }
                return _instance;
            }
        }

        private static void GetProvider()
        {
            try
            {
                _instance = (IDataProvider)Activator.CreateInstance(Type.GetType(string.Format("ConfigSetting.Data.{0}.DataProvider, ConfigSetting.Data.{0}", "SqlServer"), false, true));
            }
            catch
            {
                throw new Exception("请检查Config中Dbtype节点数据库类型是否正确，例如：SqlServer、Access、MySql");
            }
        }

    }
}
