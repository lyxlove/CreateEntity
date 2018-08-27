using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CreateEntity
{
    public interface ICreate
    {
        List<string> GetDataBaseList();

        List<string> GetTableList(string strDBName);

        string CreateEntity(string strDBName, string strTableName,string strNameSpace);

        void InitConn(string strServer,string strUser,string strPwd);
    }
}
