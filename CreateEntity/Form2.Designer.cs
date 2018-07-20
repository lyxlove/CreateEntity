namespace CreateEntity
{
    partial class Form2
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.rtbValue = new System.Windows.Forms.RichTextBox();
            this.rtbName = new System.Windows.Forms.RichTextBox();
            this.rtbResult = new System.Windows.Forms.RichTextBox();
            this.btnCreate = new System.Windows.Forms.Button();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.rtbType = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // rtbValue
            // 
            this.rtbValue.Location = new System.Drawing.Point(58, 30);
            this.rtbValue.Name = "rtbValue";
            this.rtbValue.Size = new System.Drawing.Size(704, 96);
            this.rtbValue.TabIndex = 0;
            this.rtbValue.Text = "";
            // 
            // rtbName
            // 
            this.rtbName.Location = new System.Drawing.Point(58, 132);
            this.rtbName.Name = "rtbName";
            this.rtbName.Size = new System.Drawing.Size(704, 96);
            this.rtbName.TabIndex = 1;
            this.rtbName.Text = "";
            // 
            // rtbResult
            // 
            this.rtbResult.Location = new System.Drawing.Point(58, 361);
            this.rtbResult.Name = "rtbResult";
            this.rtbResult.Size = new System.Drawing.Size(704, 373);
            this.rtbResult.TabIndex = 2;
            this.rtbResult.Text = "";
            // 
            // btnCreate
            // 
            this.btnCreate.Location = new System.Drawing.Point(798, 30);
            this.btnCreate.Name = "btnCreate";
            this.btnCreate.Size = new System.Drawing.Size(75, 23);
            this.btnCreate.TabIndex = 3;
            this.btnCreate.Text = "生成";
            this.btnCreate.UseVisualStyleBackColor = true;
            this.btnCreate.Click += new System.EventHandler(this.btnCreate_Click);
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(798, 79);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(373, 334);
            this.richTextBox1.TabIndex = 4;
            this.richTextBox1.Text = "";
            this.richTextBox1.TextChanged += new System.EventHandler(this.richTextBox1_TextChanged);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(933, 30);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 5;
            this.button1.Text = "合并";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // rtbType
            // 
            this.rtbType.Location = new System.Drawing.Point(58, 248);
            this.rtbType.Name = "rtbType";
            this.rtbType.Size = new System.Drawing.Size(704, 96);
            this.rtbType.TabIndex = 6;
            this.rtbType.Text = "";
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1224, 670);
            this.Controls.Add(this.rtbType);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.btnCreate);
            this.Controls.Add(this.rtbResult);
            this.Controls.Add(this.rtbName);
            this.Controls.Add(this.rtbValue);
            this.Name = "Form2";
            this.Text = "Form2";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RichTextBox rtbValue;
        private System.Windows.Forms.RichTextBox rtbName;
        private System.Windows.Forms.RichTextBox rtbResult;
        private System.Windows.Forms.Button btnCreate;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.RichTextBox rtbType;
    }
}