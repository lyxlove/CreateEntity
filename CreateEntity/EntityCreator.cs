using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CreateEntity
{
    public class EntityCreator
    {
        public static string CreateEntity(string strTableName,List<string> listColName, List<string> listColType, List<string> listColRemark,string strNameSpace)
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("using System;");
            sb.AppendLine("using System.Data;");
            sb.AppendLine();

            sb.AppendLine("namespace "+ strNameSpace);
            sb.AppendLine("{");

            sb.AppendLine("    public class " + strTableName);
            sb.AppendLine("    {");
            sb.AppendLine();

            for(int i = 0;i<listColName.Count;i++)
            {
                sb.AppendLine("       private " + listColType[i] + " m_" + listColName[i] + ";");
            }
            sb.AppendLine();

            for (int i = 0; i < listColName.Count; i++)
            {
                sb.AppendLine("        /// <summary>");
                sb.AppendLine("        /// 获取或设置" + (string.IsNullOrEmpty(listColRemark[i]) ? listColName[i] : listColRemark[i]));
                sb.AppendLine("        /// </summary>");
                sb.AppendLine("        public " + listColType[i] + " " + listColName[i]);
                sb.AppendLine("        {");
                sb.AppendLine("            get");
                sb.AppendLine("            {");
                sb.AppendLine("                return" + " m_" + listColName[i] + ";");
                sb.AppendLine("            }");
                sb.AppendLine("            set");
                sb.AppendLine("            {");
                sb.AppendLine("                " + " m_" + listColName[i] + " = value;");
                sb.AppendLine("            }");
                sb.AppendLine("        }");
                sb.AppendLine();
            }

            sb.AppendLine();

            sb.AppendLine("    }");
            sb.AppendLine("}");


            return sb.ToString();
        }

        public static void SaveStrToFile(string str,string strTableName)
        {
            string filePath = Application.StartupPath + "\\" + strTableName + ".cs";
            FileInfo info = new FileInfo(filePath);
            if (!info.Directory.Exists)
            {
                Directory.CreateDirectory(info.DirectoryName);
            }
            StreamWriter stream = null;
            //保存
            try
            {
                stream = new StreamWriter(filePath, false, Encoding.Default);
                stream.Write(str);
            }
            catch
            {
                throw;
            }
            finally
            {
                if (stream != null)
                {
                    stream.Close();
                }
            }
        }
    }
}
