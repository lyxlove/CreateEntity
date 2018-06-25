using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Configuration;
using System.Windows.Forms;

namespace CreateEntity
{
    public class MSSQLCreate : ICreate
    {
        private string Conntr = string.Empty;
        private SqlConnection sqlConnection = null;


        public string CreateEntity(string strDBName, string strTableName,string strNameSpace)
        {

            string strSql = string.Format("SELECT C.name AS TypeName,A.name AS ColName,ISNULL(B.value,'') as Remark From {0}.sys.SysColumns A"+
            " LEFT JOIN {1}.sys.systypes C ON A.xtype = C.xtype"+
            " LEFT JOIN {2}.sys.extended_properties B ON B.major_id = A.id AND B.minor_id = A.colorder"+
            " Where A.id = Object_Id('{3}.dbo.{4}')", strDBName, strDBName, strDBName, strDBName, strTableName);    

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

            return EntityCreator.CreateEntity(strTableName, listColName, listType, listColRemark, strNameSpace);

        }

        public List<string> GetDataBaseList()
        {
            List<string> list = new List<string>();
            try
            {
                string strSql = "SELECT Name FROM Master..SysDatabases";
                SqlCommand sqlCommand = new SqlCommand(strSql, sqlConnection);
                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                while (sqlDataReader.Read())
                {
                    list.Add(sqlDataReader[0].ToString());
                }
                sqlDataReader.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return list;
        }

        public List<string> GetTableList(string strDBName)
        {
            List<string> list = new List<string>();
            string strSql =  string.Format("Select Name From {0}..SysObjects Where XType='U' order By Name", strDBName);
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
            sqlDataReader.Close();
            return list;
        }

        public void InitConn(string strServer, string strUser, string strPwd)
        {
            Conntr = string.Format(@"server={0};User Id={1};Password={2};", strServer, strUser, strPwd);
            sqlConnection = new SqlConnection(Conntr);
            sqlConnection.Open();
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
