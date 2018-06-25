using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CreateEntity
{
    public partial class Form1 : Form
    {
        private ICreate create = null;

        public Form1()
        {
            InitializeComponent();
            LoadDefaultMsg();
            create = new MSSQLCreate();
        }

        private void LoadDefaultMsg()
        {
            rtbUsing.AppendText("using System;\n");
            rtbUsing.AppendText("using System.Data;\n");

            txtServer.Text = ".";
            txtUer.Text = "sa";
            txtPwd.Text = "123456";

            txtNS.Text = "yzslz";

        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            ConnectDB();
            LoadDataBase();
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            string strTableName = combTableList.Text;
            string strDBName = combDB.Text;
            string strNameSpace = txtNS.Text.ToString();


            if (!string.IsNullOrEmpty(strDBName) && !string.IsNullOrEmpty(strTableName))
            {
                string str = create.CreateEntity(strDBName,strTableName, strNameSpace);
                //EntityCreator.SaveStrToFile(str, strTableName);
                rtbResult.Text = str;
            }
        }

        private void ConnectDB()
        {
            try
            {
                string strServer = txtServer.Text.Trim();
                string strUser = txtUer.Text.Trim();
                string strPwd = txtPwd.Text.Trim();

                create.InitConn(strServer, strUser, strPwd);
                MessageBox.Show("数据库连接成功！");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }

        private void LoadDataBase()
        {
            try
            {
                List<string> list = create.GetDataBaseList();
                combDB.Items.Clear();
                combDB.Items.AddRange(list.ToArray());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void LoadTable()
        {
            try
            {
                string strDBName = combDB.Text.ToString();
                if (!string.IsNullOrEmpty(strDBName))
                {
                    List<string> list = create.GetTableList(strDBName);
                    combTableList.Items.Clear();
                    combTableList.Items.AddRange(list.ToArray());
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        private void SaveXML()
        {
            string str = rtbUsing.Text.Trim().Replace('\n',' ');
            if (str.Substring(str.Length - 1, 1) == ";")
            {
                str = str.Substring(0, str.Length - 1);
            }

            string[] s = str.Split(';');
            if(s.Length > 0)
            {

            }
        }

        private void WriteXML(string[] s)
        {


        }


        private void combDB_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadTable();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                SaveXML();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

 
    }
}
