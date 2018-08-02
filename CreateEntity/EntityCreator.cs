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

        public static string CreateEntity(string strVal,string strName)
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("using System;");
            sb.AppendLine("using System.Data;");
            sb.AppendLine();

            sb.AppendLine("namespace gfVehicleLibraryAJ");
            sb.AppendLine("{");

            sb.AppendLine("    public class Vehicle_18M18_Para");
            sb.AppendLine("    {");
            sb.AppendLine();

            try
            {
            
                string[] sVal = strVal.Split(',');
                string[] sName = strName.Split(',');

                for (int i = 0; i < sVal.Length; i++)
                {
                    sb.AppendLine("        /// <summary>");
                    sb.AppendLine("        /// 获取或设置" + sName[i]);
                    sb.AppendLine("        /// </summary>");
                    sb.AppendLine("        public string " + sVal[i]);
                    sb.AppendLine("        {");
                    sb.AppendLine("            get;");
                    sb.AppendLine("            set;");
                    sb.AppendLine("        }");
                    sb.AppendLine();
                }
                sb.AppendLine();

                sb.AppendLine("    }");
                sb.AppendLine("}");
                return sb.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return sb.ToString();
        }


        public static string CreateEntity(string strVal)
        {
            StringBuilder sb = new StringBuilder();

            //sb.AppendLine("using System;");
            //sb.AppendLine("using System.Data;");
            //sb.AppendLine();

            //sb.AppendLine("namespace gfVehicleLibraryAJ");
            //sb.AppendLine("{");

            //sb.AppendLine("    public class Vehicle_18M18_Para");
            //sb.AppendLine("    {");
            //sb.AppendLine();

            try
            {

                string[] sVal = strVal.Split(',');
                for (int i = 0; i < sVal.Length; i++)
                {
                    sb.AppendLine("        public double " + sVal[i]);
                    sb.AppendLine("        {");
                    sb.AppendLine("            get;");
                    sb.AppendLine("            set;");
                    sb.AppendLine("        }");
                    sb.AppendLine();
                }
                sb.AppendLine();

                //sb.AppendLine("    }");
                //sb.AppendLine("}");
                return sb.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return sb.ToString();
        }


        public static string ChangeType(string s)
        {
            switch (s)
            {
                case "varchar2":
                case "char":
                case "date":
                    return "string";
                case "number":
                    return "int?";                   
            }
            return "string";

        }

        public static string CreateEntity(string[] sVal, string[] sName, string[] sType)
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("using System;");
            sb.AppendLine("using System.Data;");
            sb.AppendLine();

            sb.AppendLine("namespace gfVehicleLibraryAJ");
            sb.AppendLine("{");

            sb.AppendLine("    public class Vehicle_18M18_Para");
            sb.AppendLine("    {");
            sb.AppendLine();
            try
            {
                for (int i = 0; i < sVal.Length; i++)
                {
                    sb.AppendLine("        /// <summary>");
                    sb.AppendLine("        /// 获取或设置" + sName[i]);
                    sb.AppendLine("        /// </summary>");
                    sb.AppendLine("        public " + EntityCreator.ChangeType(sType[i]) + " " + sVal[i]);
                    sb.AppendLine("        {");
                    sb.AppendLine("            get;");
                    sb.AppendLine("            set;");
                    sb.AppendLine("        }");
                    sb.AppendLine();
                }
                sb.AppendLine();

                sb.AppendLine("    }");
                sb.AppendLine("}");
           
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message); 
            }
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

        #region 字符串中多个连续空格转为,
        /// <summary>
        /// 字符串中多个连续空格转为一个空格
        /// </summary>
        /// <param name="str">待处理的字符串</param>
        /// <returns>合并空格后的字符串</returns>
        public static string MergeSpace(string str)
        {
            if (str != string.Empty &&
                str != null &&
                str.Length > 0
                )
            {
                str = new System.Text.RegularExpressions.Regex("[\\s]+").Replace(str, ",");
            }
            return str;
        }


        #endregion

    }
}
