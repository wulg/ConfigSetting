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
        private List<Application> GetListByApplication(string strSql)
        {
            List<Application> list = null;
            var dataSet = DbHelper.ExecuteDataSet(strSql);
            if (dataSet != null && dataSet.Tables[0].Rows.Count > 0)
            {
                var result = dataSet.Tables[0].Rows.OfType<DataRow>().Select(row => new Application
                {
                    ID = row["id"].ToString(),
                    AppID = row["appId"].ToString(),
                    Name = row["name"].ToString(),
                    Licensekey = row["licensekey"].ToString(),
                    ParentID = row["parentId"].ToString(),
                    Status = Convert.ToInt32(row["status"]),
                    CreateTime = Convert.ToDateTime(row["createtime"]),
                    UpdateTime = Convert.ToDateTime(row["updatetime"])
                });
                list = result.ToList();
            }
            return list;
        }

        private Application GetApplicationModel(string strSql)
        {
            Application entity = null;
            var sdr = DbHelper.ExceuteReader(strSql);
            while (sdr.Read())
            {
                entity = new Application();
                entity.ID = sdr["id"].ToString();
                entity.AppID = sdr["appId"].ToString();
                entity.Name = sdr["name"].ToString();
                entity.Licensekey = sdr["licensekey"].ToString();
                entity.ParentID = sdr["parentId"].ToString();
                entity.Status = Convert.ToInt32(sdr["status"]);
                entity.CreateTime = Convert.ToDateTime(sdr["createtime"]);
                entity.UpdateTime = Convert.ToDateTime(sdr["updatetime"]);
            }
            sdr.Close();
            return entity;
        }

        public IList<Application> GetApplicationList()
        {
            string strSql = string.Format("select {0} from application", DbFields.APPLICATION);
            return GetListByApplication(strSql);
        }

        public Application GetApplicationById(string id)
        {
            string strSql = string.Format("select {0} from application where id='{1}'", DbFields.APPLICATION, id);
            return GetApplicationModel(strSql);
        }

        public Application GetApplicationByAppID(string appId)
        {
            string strSql = string.Format("select {0} from application where appId='{1}'", DbFields.APPLICATION, appId);
            return GetApplicationModel(strSql);
        }

        public bool IsExistChildApp(string applicationId, string childId)
        {
            string strSql = string.Format("select count(id) from application where appId='{0}' and parentId='{1}'", applicationId, childId);
            return (int)DbHelper.ExecuteScalar(strSql) > 0;
        }

        public Application GetApplicationByName(string name)
        {
            string strSql = string.Format("select {0} from application where name='{1}'", DbFields.APPLICATION, name);
            return GetApplicationModel(strSql);
        }

        public bool AddApplication(Model.Application entity)
        {
            string strSql = string.Format("insert into application({0}) values('{1}','{2}','{3'},'{4}','{5}','{6}','{7}','{8}')", DbFields.APPLICATION,
                entity.ID, entity.AppID, entity.Name, entity.Licensekey, entity.ParentID, entity.Status, entity.CreateTime, entity.UpdateTime);
            return DbHelper.ExecteNonQuery(strSql) > 0;
        }

        public bool UpdateApplication(Model.Application entity)
        {
            throw new NotImplementedException();
        }

        public bool RemoveApplication(string Id)
        {
            string strSql = string.Format("delete from application where id='{0}'", DbFields.APPLICATION, Id);
            return DbHelper.ExecteNonQuery(strSql) > 0;
        }
    }
}
