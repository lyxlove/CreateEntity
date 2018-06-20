using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CreateEntity
{
    public interface ICreate
    {
        void InitConn();

        void ConnDB();

        List<string> GetTableList();

        string CreateEntity(string strTableName);
    }
}
