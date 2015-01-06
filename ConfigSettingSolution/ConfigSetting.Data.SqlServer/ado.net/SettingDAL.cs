using ConfigSetting.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConfigSetting.Data.SqlServer
{
    public partial class DataProvider : IDataProvider
    {

        private List<Setting> GetListBySetting(string strSql)
        {
            List<Setting> list = null;
            var dataSet = DbHelper.ExecuteDataSet(strSql);
            if (dataSet != null && dataSet.Tables[0].Rows.Count > 0)
            {
                var result = dataSet.Tables[0].Rows.OfType<DataRow>().Select(row => new Setting
                {
                    ID = row["Id"].ToString(),
                    ApplicationID = row["ApplicationId"].ToString(),
                    MD5 = row["md5"].ToString(),
                    Key = row["key"].ToString(),
                    Value = row["value"].ToString(),
                    IsUnique = Convert.ToBoolean(row["isunique"]),
                    Description = row["description"].ToString(),
                    Version = row["version"].ToString(),
                    LastOperator = row["lastOperator"].ToString(),
                    CreateTime = Convert.ToDateTime(row["createtime"]),
                    UpdateTime = Convert.ToDateTime(row["updatetime"])
                });
                list = result.ToList();
            }
            return list;
        }

        private Setting GetSettingModel(string strSql)
        {
            Setting entity = null;
            var sdr = DbHelper.ExceuteReader(strSql);
            while (sdr.Read())
            {
                entity = new Setting
                {
                    ID = sdr["Id"].ToString(),
                    ApplicationID = sdr["ApplicationId"].ToString(),
                    MD5 = sdr["md5"].ToString(),
                    Key = sdr["key"].ToString(),
                    Value = sdr["value"].ToString(),
                    IsUnique = Convert.ToBoolean(sdr["isunique"]),
                    Description = sdr["description"].ToString(),
                    Version = sdr["version"].ToString(),
                    LastOperator = sdr["lastOperator"].ToString(),
                    CreateTime = Convert.ToDateTime(sdr["createtime"]),
                    UpdateTime = Convert.ToDateTime(sdr["updatetime"])
                };
            }
            sdr.Close();
            return entity;
        }

        public IList<Setting> GetSettingList()
        {
            string strSql = string.Format("select {0} from setting", DbFields.SETTING);
            return GetListBySetting(strSql);
        }

        public IList<Setting> GetSettingListByAppId(string applicationId)
        {
            string strSql = string.Format("select {0} from setting where applicationId='{1}'", DbFields.SETTING, applicationId);
            return GetListBySetting(strSql);
        }

        public Setting GetSetting(string id)
        {
            string strSql = string.Format("select {0} from setting where id='{1}'", DbFields.SETTING, id);
            return GetSettingModel(strSql);
        }

        public Setting GetSetting(string applicationId, string key)
        {
            string strSql = string.Format("select {0} from setting where applicationId='{1}' and key ='{2}'", DbFields.SETTING, applicationId, key);
            return GetSettingModel(strSql);
        }

        public string GetSettingValue(string id)
        {
            string strSql = string.Format("select value from setting where id='{1}'", DbFields.SETTING, id);
            return DbHelper.ExecuteScalar(strSql).ToString();
        }

        public string GetSettingValue(string applicationId, string key)
        {
            string strSql = string.Format("select value from setting where applicationId='{1}' and key ='{2}'", DbFields.SETTING, applicationId, key);
            return DbHelper.ExecuteScalar(strSql).ToString();
        }

        public bool AddSettingValue(Setting entity)
        {
            string strSql = string.Format("insert into setting ({0}) values ('{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}','{10}','{11}')", DbFields.SETTING,
                entity.ID, entity.ApplicationID, entity.MD5, entity.Key, entity.Value, entity.Version, entity.IsUnique, entity.Description, entity.LastOperator, entity.CreateTime, entity.UpdateTime);
            return DbHelper.ExecteNonQuery(strSql) > 0;
        }

        public bool UpdateSettingValue(Setting entity)
        {
            return false;
        }

        public bool UpdateSettingValue(string id, string value, string LastOperator)
        {
            string strSql = string.Format("update setting set value='{0}',lastOperator='{1}' where id='{3}'", value, LastOperator, id);
            return DbHelper.ExecteNonQuery(strSql) > 0;
        }

        public bool UpdateSettingValue(string applicatinId, string key, string value, string LastOperator)
        {
            string strSql = string.Format("update setting set value='{0}',lastOperator='{1}' where key='{3}' and applicationId='{4}'", value, LastOperator, key, applicatinId);
            return DbHelper.ExecteNonQuery(strSql) > 0;
        }

        public bool RemoveSettingValue(string id)
        {
            string strSql = string.Format("delete from setting where id='{0}'", id);
            return DbHelper.ExecteNonQuery(strSql) > 0;
        }
    }
}
