using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Configuration;

namespace CreateEntity
{
    public class MSSQLCreate : ICreate
    {
        private string Conntr = string.Empty;
        private SqlConnection sqlConnection = null;
        /// <summary>
        /// 链接数据库
        /// </summary>
        public void ConnDB()
        {
            InitConn();
            sqlConnection = new SqlConnection(Conntr);
            sqlConnection.Open();
        }

        public string CreateEntity(string strTableName)
        {
            string strSql =string.Format( "Select systypes.name AS TypeName,SysColumns.name AS ColName,ISNULL(sys.extended_properties.value,'') as Remark From SysColumns" +
            " LEFT JOIN systypes ON SysColumns.xtype = systypes.xtype"+
            " LEFT JOIN sys.extended_properties ON sys.extended_properties.major_id = SysColumns.id AND sys.extended_properties.minor_id = SysColumns.colorder"+
            " Where id = Object_Id('{0}')",strTableName);
            SqlCommand sqlCommand = new SqlCommand(strSql, sqlConnection);
            if (sqlConnection.State == System.Data.ConnectionState.Closed)
            {
                sqlConnection.Open();
            }
            SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
            List<string> listColName = new List<string>();
            List<string> listColRemark = new List<string>();
            List<string> listType = new List<string>();
            while(sqlDataReader.Read())
            {
                listColName.Add(sqlDataReader["ColName"].ToString());
                listColRemark.Add(sqlDataReader["Remark"].ToString());
                listType.Add(GetCSharpDataType(sqlDataReader["TypeName"].ToString()));
            }
            sqlDataReader.Close();

            return EntityCreator.CreateEntity(strTableName, listColName, listType, listColRemark);

        }

        public List<string> GetTableList()
        {
            List<string> list = new List<string>();
            string strSql = "Select Name From SysObjects Where XType='U' order By Name";
            SqlCommand sqlCommand = new SqlCommand(strSql, sqlConnection);
            if(sqlConnection.State == System.Data.ConnectionState.Closed)
            {
                sqlConnection.Open();
            }
            SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
            while (sqlDataReader.Read())
            {
                list.Add(sqlDataReader[0].ToString());
            }
            return list;
        }

        public void InitConn()
        {
            Conntr = ConfigurationManager.ConnectionStrings["MSSQLConnect"].ConnectionString;
        }

        private string GetCSharpDataType(string strType)
        {
            switch(strType.ToLower())
            {
                case "int":
                case "tinyint":
                case "smallint":
                    return "int";

                case "varchar":
                case "nvarchar":
                case "text":
                case "xml":
                case "nchar":
                    return "string";

                case "float":
                case "decimal":
                    return "double";

                case "date":
                case "datetime":
                case "time":
                case "datetime2":
                    return "DateTime";  
                    
                case "image":
                    return "byte[]";

                default:
                    return "string";
            }
        }
    }
}
