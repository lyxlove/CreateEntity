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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            string[] sVal = rtbValue.Text.Trim().Split(',');
            string[] sName = rtbName.Text.Trim().Split(',');
            string[] sType = rtbType.Text.Trim().Split(',');
            string s = string.Empty;
            if (!string.IsNullOrEmpty(rtbType.Text.Trim()))
            {
                if (sVal.Length == sName.Length && sVal.Length == sType.Length)
                {
                  
                    s = EntityCreator.CreateEntity(sVal, sName, sType);

                }
                else
                {

                    if (sVal.Length != sName.Length)
                    {
                        MessageBox.Show("字段名称总数不对");
                    }
                    else
                    {
                        if (sVal.Length != sType.Length)
                        {
                            MessageBox.Show("字段类型总数不对");
                        }
                    }
                }

            }
            else
            {
                if (sVal.Length == sName.Length)
                {
                    s = EntityCreator.CreateEntity(rtbValue.Text.Trim(), rtbName.Text.Trim());
                    rtbResult.Text = s;
                }
                else
                {
                    MessageBox.Show("字段名称总数不对");
                }
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            string s = EntityCreator.MergeSpace(richTextBox1.Text);
            richTextBox1.Text = s;
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {
            richTextBox1.Font = new Font(richTextBox1.Font.FontFamily, 9, richTextBox1.Font.Style); ;
        }
    }
}
