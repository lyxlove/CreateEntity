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
        public Form1()
        {
            InitializeComponent();
            LoadDefaultMsg();
        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            ICreate create = new MSSQLCreate();
            create.ConnDB();
            List<string> list = create.GetTableList();
            combTableList.Items.Clear();
            combTableList.Items.AddRange(list.ToArray());
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            string strTableName = combTableList.Text;
            ICreate create = new MSSQLCreate();
            create.ConnDB();
            string str=  create.CreateEntity(strTableName);
            EntityCreator.SaveStrToFile(str,strTableName);
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

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
    }
}
