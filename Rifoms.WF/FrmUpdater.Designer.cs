
namespace Rifoms.WF
{
    partial class FrmUpdater
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnMysql = new System.Windows.Forms.Button();
            this.btnConvertImage = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tbpAddContent = new System.Windows.Forms.TabPage();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.rcbDescription = new System.Windows.Forms.RichTextBox();
            this.txbTitle = new System.Windows.Forms.TextBox();
            this.rcbContent = new System.Windows.Forms.RichTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnAddContent = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.chbIsArhive = new System.Windows.Forms.CheckBox();
            this.chbComments = new System.Windows.Forms.CheckBox();
            this.chbShowPath = new System.Windows.Forms.CheckBox();
            this.chbShowTitle = new System.Windows.Forms.CheckBox();
            this.chbShowLatest = new System.Windows.Forms.CheckBox();
            this.chbShowDate = new System.Windows.Forms.CheckBox();
            this.chbIsEnd = new System.Windows.Forms.CheckBox();
            this.dtpEndDate = new System.Windows.Forms.DateTimePicker();
            this.label5 = new System.Windows.Forms.Label();
            this.dtpPubDate = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.rcbTranslitResult = new System.Windows.Forms.RichTextBox();
            this.rcbTranslit = new System.Windows.Forms.RichTextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.chbPublished = new System.Windows.Forms.CheckBox();
            this.tabControl1.SuspendLayout();
            this.tbpAddContent.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnMysql
            // 
            this.btnMysql.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnMysql.Location = new System.Drawing.Point(19, 120);
            this.btnMysql.Name = "btnMysql";
            this.btnMysql.Size = new System.Drawing.Size(129, 35);
            this.btnMysql.TabIndex = 0;
            this.btnMysql.Text = "MySql";
            this.btnMysql.UseVisualStyleBackColor = true;
            this.btnMysql.Click += new System.EventHandler(this.btnMysql_Click);
            // 
            // btnConvertImage
            // 
            this.btnConvertImage.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnConvertImage.Location = new System.Drawing.Point(19, 79);
            this.btnConvertImage.Name = "btnConvertImage";
            this.btnConvertImage.Size = new System.Drawing.Size(129, 35);
            this.btnConvertImage.TabIndex = 1;
            this.btnConvertImage.Text = "Convert Images";
            this.btnConvertImage.UseVisualStyleBackColor = true;
            this.btnConvertImage.Click += new System.EventHandler(this.btnConvertImage_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tbpAddContent);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(12, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1069, 544);
            this.tabControl1.TabIndex = 2;
            // 
            // tbpAddContent
            // 
            this.tbpAddContent.Controls.Add(this.groupBox3);
            this.tbpAddContent.Controls.Add(this.groupBox2);
            this.tbpAddContent.Controls.Add(this.btnAddContent);
            this.tbpAddContent.Controls.Add(this.groupBox1);
            this.tbpAddContent.Location = new System.Drawing.Point(4, 24);
            this.tbpAddContent.Name = "tbpAddContent";
            this.tbpAddContent.Padding = new System.Windows.Forms.Padding(3);
            this.tbpAddContent.Size = new System.Drawing.Size(1061, 516);
            this.tbpAddContent.TabIndex = 0;
            this.tbpAddContent.Text = "Add Content";
            this.tbpAddContent.UseVisualStyleBackColor = true;
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox3.Controls.Add(this.rcbDescription);
            this.groupBox3.Controls.Add(this.txbTitle);
            this.groupBox3.Controls.Add(this.rcbContent);
            this.groupBox3.Controls.Add(this.label1);
            this.groupBox3.Controls.Add(this.label3);
            this.groupBox3.Controls.Add(this.label2);
            this.groupBox3.Location = new System.Drawing.Point(156, 6);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(683, 504);
            this.groupBox3.TabIndex = 10;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "CONTENT";
            // 
            // rcbDescription
            // 
            this.rcbDescription.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.rcbDescription.Location = new System.Drawing.Point(90, 45);
            this.rcbDescription.Name = "rcbDescription";
            this.rcbDescription.Size = new System.Drawing.Size(586, 78);
            this.rcbDescription.TabIndex = 4;
            this.rcbDescription.Text = "";
            // 
            // txbTitle
            // 
            this.txbTitle.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txbTitle.Location = new System.Drawing.Point(90, 16);
            this.txbTitle.Name = "txbTitle";
            this.txbTitle.Size = new System.Drawing.Size(586, 23);
            this.txbTitle.TabIndex = 0;
            // 
            // rcbContent
            // 
            this.rcbContent.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.rcbContent.Location = new System.Drawing.Point(91, 129);
            this.rcbContent.Name = "rcbContent";
            this.rcbContent.Size = new System.Drawing.Size(586, 369);
            this.rcbContent.TabIndex = 1;
            this.rcbContent.Text = "";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(34, 15);
            this.label1.TabIndex = 2;
            this.label1.Text = "TITLE";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 48);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(79, 15);
            this.label3.TabIndex = 5;
            this.label3.Text = "DESCRIPTION";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 132);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(60, 15);
            this.label2.TabIndex = 3;
            this.label2.Text = "CONTENT";
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.groupBox2.Location = new System.Drawing.Point(6, 6);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(144, 504);
            this.groupBox2.TabIndex = 9;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "CONTENT TYPE";
            // 
            // btnAddContent
            // 
            this.btnAddContent.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAddContent.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnAddContent.Location = new System.Drawing.Point(845, 331);
            this.btnAddContent.Name = "btnAddContent";
            this.btnAddContent.Size = new System.Drawing.Size(210, 57);
            this.btnAddContent.TabIndex = 7;
            this.btnAddContent.Text = "Add Content";
            this.btnAddContent.UseVisualStyleBackColor = true;
            this.btnAddContent.Click += new System.EventHandler(this.btnAddContent_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.chbPublished);
            this.groupBox1.Controls.Add(this.chbIsArhive);
            this.groupBox1.Controls.Add(this.chbComments);
            this.groupBox1.Controls.Add(this.chbShowPath);
            this.groupBox1.Controls.Add(this.chbShowTitle);
            this.groupBox1.Controls.Add(this.chbShowLatest);
            this.groupBox1.Controls.Add(this.chbShowDate);
            this.groupBox1.Controls.Add(this.chbIsEnd);
            this.groupBox1.Controls.Add(this.dtpEndDate);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.dtpPubDate);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Location = new System.Drawing.Point(845, 6);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(210, 319);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "PARAMETER\'S";
            // 
            // chbIsArhive
            // 
            this.chbIsArhive.AutoSize = true;
            this.chbIsArhive.Location = new System.Drawing.Point(74, 245);
            this.chbIsArhive.Name = "chbIsArhive";
            this.chbIsArhive.Size = new System.Drawing.Size(80, 19);
            this.chbIsArhive.TabIndex = 11;
            this.chbIsArhive.Text = "IS_ARHIVE";
            this.chbIsArhive.UseVisualStyleBackColor = true;
            // 
            // chbComments
            // 
            this.chbComments.AutoSize = true;
            this.chbComments.Location = new System.Drawing.Point(74, 222);
            this.chbComments.Name = "chbComments";
            this.chbComments.Size = new System.Drawing.Size(95, 19);
            this.chbComments.TabIndex = 10;
            this.chbComments.Text = "COMMENT\'S";
            this.chbComments.UseVisualStyleBackColor = true;
            // 
            // chbShowPath
            // 
            this.chbShowPath.AutoSize = true;
            this.chbShowPath.Location = new System.Drawing.Point(74, 199);
            this.chbShowPath.Name = "chbShowPath";
            this.chbShowPath.Size = new System.Drawing.Size(89, 19);
            this.chbShowPath.TabIndex = 9;
            this.chbShowPath.Text = "SHOWPATH";
            this.chbShowPath.UseVisualStyleBackColor = true;
            // 
            // chbShowTitle
            // 
            this.chbShowTitle.AutoSize = true;
            this.chbShowTitle.Location = new System.Drawing.Point(74, 107);
            this.chbShowTitle.Name = "chbShowTitle";
            this.chbShowTitle.Size = new System.Drawing.Size(88, 19);
            this.chbShowTitle.TabIndex = 8;
            this.chbShowTitle.Text = "SHOWTITLE";
            this.chbShowTitle.UseVisualStyleBackColor = true;
            // 
            // chbShowLatest
            // 
            this.chbShowLatest.AutoSize = true;
            this.chbShowLatest.Location = new System.Drawing.Point(74, 176);
            this.chbShowLatest.Name = "chbShowLatest";
            this.chbShowLatest.Size = new System.Drawing.Size(98, 19);
            this.chbShowLatest.TabIndex = 7;
            this.chbShowLatest.Text = "SHOWLATEST";
            this.chbShowLatest.UseVisualStyleBackColor = true;
            // 
            // chbShowDate
            // 
            this.chbShowDate.AutoSize = true;
            this.chbShowDate.Location = new System.Drawing.Point(74, 153);
            this.chbShowDate.Name = "chbShowDate";
            this.chbShowDate.Size = new System.Drawing.Size(88, 19);
            this.chbShowDate.TabIndex = 6;
            this.chbShowDate.Text = "SHOWDATE";
            this.chbShowDate.UseVisualStyleBackColor = true;
            // 
            // chbIsEnd
            // 
            this.chbIsEnd.AutoSize = true;
            this.chbIsEnd.Location = new System.Drawing.Point(74, 84);
            this.chbIsEnd.Name = "chbIsEnd";
            this.chbIsEnd.Size = new System.Drawing.Size(63, 19);
            this.chbIsEnd.TabIndex = 5;
            this.chbIsEnd.Text = "IS_END";
            this.chbIsEnd.UseVisualStyleBackColor = true;
            // 
            // dtpEndDate
            // 
            this.dtpEndDate.Location = new System.Drawing.Point(74, 52);
            this.dtpEndDate.Name = "dtpEndDate";
            this.dtpEndDate.Size = new System.Drawing.Size(125, 23);
            this.dtpEndDate.TabIndex = 3;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(11, 53);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(57, 15);
            this.label5.TabIndex = 2;
            this.label5.Text = "ENDDATE";
            // 
            // dtpPubDate
            // 
            this.dtpPubDate.Location = new System.Drawing.Point(74, 24);
            this.dtpPubDate.Name = "dtpPubDate";
            this.dtpPubDate.Size = new System.Drawing.Size(125, 23);
            this.dtpPubDate.TabIndex = 1;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(11, 24);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(56, 15);
            this.label4.TabIndex = 0;
            this.label4.Text = "PUBDATE";
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.rcbTranslitResult);
            this.tabPage2.Controls.Add(this.rcbTranslit);
            this.tabPage2.Controls.Add(this.button1);
            this.tabPage2.Controls.Add(this.btnMysql);
            this.tabPage2.Controls.Add(this.btnConvertImage);
            this.tabPage2.Location = new System.Drawing.Point(4, 24);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(1061, 516);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "tabPage2";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // rcbTranslitResult
            // 
            this.rcbTranslitResult.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.rcbTranslitResult.Location = new System.Drawing.Point(154, 161);
            this.rcbTranslitResult.Name = "rcbTranslitResult";
            this.rcbTranslitResult.Size = new System.Drawing.Size(901, 117);
            this.rcbTranslitResult.TabIndex = 4;
            this.rcbTranslitResult.Text = "";
            // 
            // rcbTranslit
            // 
            this.rcbTranslit.Location = new System.Drawing.Point(154, 38);
            this.rcbTranslit.Name = "rcbTranslit";
            this.rcbTranslit.Size = new System.Drawing.Size(901, 117);
            this.rcbTranslit.TabIndex = 3;
            this.rcbTranslit.Text = "";
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.Location = new System.Drawing.Point(19, 38);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(129, 35);
            this.button1.TabIndex = 2;
            this.button1.Text = "ТРАНСЛИТ";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // chbPublished
            // 
            this.chbPublished.AutoSize = true;
            this.chbPublished.Location = new System.Drawing.Point(74, 130);
            this.chbPublished.Name = "chbPublished";
            this.chbPublished.Size = new System.Drawing.Size(86, 19);
            this.chbPublished.TabIndex = 12;
            this.chbPublished.Text = "PUBLISHED";
            this.chbPublished.UseVisualStyleBackColor = true;
            // 
            // FrmUpdater
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1087, 568);
            this.Controls.Add(this.tabControl1);
            this.Name = "FrmUpdater";
            this.Text = "Form1";
            this.tabControl1.ResumeLayout(false);
            this.tbpAddContent.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnMysql;
        private System.Windows.Forms.Button btnConvertImage;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tbpAddContent;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RichTextBox rcbContent;
        private System.Windows.Forms.TextBox txbTitle;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.RichTextBox rcbDescription;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DateTimePicker dtpEndDate;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DateTimePicker dtpPubDate;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnAddContent;
        private System.Windows.Forms.CheckBox chbIsEnd;
        private System.Windows.Forms.CheckBox chbShowPath;
        private System.Windows.Forms.CheckBox chbShowTitle;
        private System.Windows.Forms.CheckBox chbShowLatest;
        private System.Windows.Forms.CheckBox chbShowDate;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.CheckBox chbComments;
        private System.Windows.Forms.CheckBox chbIsArhive;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.RichTextBox rcbTranslit;
        private System.Windows.Forms.RichTextBox rcbTranslitResult;
        private System.Windows.Forms.CheckBox chbPublished;
    }
}

