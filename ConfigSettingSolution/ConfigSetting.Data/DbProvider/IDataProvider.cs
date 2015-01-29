using ConfigSetting.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConfigSetting.Data
{
    public interface IDataProvider
    {
        #region Setting
        IList<Setting> GetSettingList();

        IList<Setting> GetSettingListByAppId(string applicationId);

        Setting GetSetting(string id);

        Setting GetSetting(string applicationId, string key);

        string GetSettingValue(string id);

        string GetSettingValue(string applicationId, string key);

        bool AddSettingValue(Setting entity);

        bool UpdateSettingValue(Setting entity);

        bool UpdateSettingValue(string id, string value, string LastOperator);
        bool UpdateSettingValue(string applicatinId, string key, string value, string LastOperator);

        bool RemoveSettingValue(string id);

        #endregion

        #region Application

        IList<Application> GetApplicationList();
        Application GetApplicationById(string id);
        Application GetApplicationByAppID(string appId);
        Application GetApplicationByName(string name);
        bool IsExistChildApp(string applicationId, string childId);

        bool AddApplication(Application entity);

        bool UpdateApplication(Application entity);

        bool RemoveApplication(string Id);

        #endregion

        #region User

        User GetUserById(string Id);

        User GetUser(string userName);

        User GetUser(string userName, string pwd);

        IList<User> GetUserList();

        bool AddUser(User entity);

        bool UpdateLastLoginDate(User entity);

        bool RemoveUser(string Id);

        #endregion

        #region UserAction

        IList<UserAction> GetUserActionList();

        IList<UserAction> GetUserActionListByAppId(string applicationId);

        IList<UserAction> GetUserActionListByAppId(string applicationId, string username, string type);

        #endregion
    }
}
