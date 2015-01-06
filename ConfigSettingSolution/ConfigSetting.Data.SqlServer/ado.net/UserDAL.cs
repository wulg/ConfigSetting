using ConfigSetting.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConfigSetting.Data.SqlServer
{
    public partial class DataProvider : IDataProvider
    {
        private User GetUserByDataReader(string strSql, params SqlParameter[] paras)
        {
            User user = null;
            var sdr = DbHelper.ExceuteReader(strSql, paras);
            while (sdr.Read())
            {
                user = new User();
                user.ApplicationID = sdr["ApplicationID"].ToString();
                user.ID = sdr["ID"].ToString();
                user.UserName = sdr["username"].ToString();
                user.Password = sdr["password"].ToString();
                user.LastPassword = sdr["lastPassword"].ToString();
                user.LastLoginDate = Convert.ToDateTime(sdr["lastlogindate"]);
                user.CreateTime = Convert.ToDateTime(sdr["createtime"]);
            }
            sdr.Close();
            return user;
        }

        private List<User> GetListByUser(string strSql)
        {
            List<User> list = null;
            var dataSet = DbHelper.ExecuteDataSet(strSql);
            if (dataSet != null && dataSet.Tables[0].Rows.Count > 0)
            {
                var result = dataSet.Tables[0].Rows.OfType<DataRow>().Select(row => new User
                {
                    ID = row["id"].ToString(),
                    ApplicationID = row["ApplicationID"].ToString(),
                    UserName = row["UserName"].ToString(),
                    Password = row["Password"].ToString(),
                    LastPassword = row["LastPassword"].ToString(),
                    LastLoginDate = Convert.ToDateTime(row["LastLoginDate"]),
                    CreateTime = Convert.ToDateTime(row["createtime"])
                });
                list = result.ToList();
            }

            return list;
        }

        public User GetUserById(string Id)
        {
            string strSql = string.Format("select {0} from user where id='{1}'", DbFields.USER, Id);
            return GetUserByDataReader(strSql);
        }

        public User GetUser(string userName)
        {
            string strSql = string.Format("select {0} from user where username='{1}'", DbFields.USER, userName);
            return GetUserByDataReader(strSql);
        }

        public User GetUser(string userName, string pwd)
        {
            string strSql = string.Format("select {0} from user where username='{1}' and password='{2}'", DbFields.USER, userName, pwd);
            return GetUserByDataReader(strSql);
        }

        public IList<User> GetUserList()
        {
            string strSql = string.Format("select {0} from user", DbFields.USER);
            return GetListByUser(strSql);
        }

        public bool AddUser(User entity)
        {
            string strSql = string.Format("insert into user({0}) values(@ID,@ApplicationId,@UserName,@Password,@LastPassword,@LastLoginDate,@CreateTime)", DbFields.USER);
            SqlParameter[] paras = new SqlParameter[]{
                         new SqlParameter("@ID",entity.ID),
                         new SqlParameter("@ApplicationId",entity.ApplicationID),
                         new SqlParameter("@UserName",entity.UserName),
                         new SqlParameter("@Password",entity.Password),
                         new SqlParameter("@LastPassword",entity.LastPassword),
                         new SqlParameter("@LastLoginDate",entity.LastLoginDate),
                         new SqlParameter("@CreateTime",entity.CreateTime)
                      };
            return DbHelper.ExecteNonQuery(strSql, paras) > 0;
        }

        public bool UpdateLastLoginDate(User entity)
        {
            string strSql = "update user set lastlogindate=@LastLoginDate where username=@UserName";
            SqlParameter[] paras = { 
                                   new SqlParameter("@LastLoginDate",entity.LastLoginDate),
                                   new SqlParameter("@UserName",entity.UserName)
                                   };
            return DbHelper.ExecteNonQuery(strSql, paras) > 0;
        }

        public bool RemoveUser(string id)
        {
            string strSql = string.Format("delete from user where id='{0}'", id);
            return DbHelper.ExecteNonQuery(strSql) > 0;
        }

    }
}
