using ConfigSetting.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConfigSetting.Data.SqlServer
{
    public partial class DataProvider : IDataProvider
    {

        public IList<UserAction> GetUserActionList()
        {
            throw new NotImplementedException();
        }

        public IList<UserAction> GetUserActionListByAppId(string applicationId)
        {
            throw new NotImplementedException();
        }

        public IList<UserAction> GetUserActionListByAppId(string applicationId, string username, string type)
        {
            throw new NotImplementedException();
        }
    }
}
