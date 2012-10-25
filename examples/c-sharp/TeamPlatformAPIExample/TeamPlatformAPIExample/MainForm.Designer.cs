namespace TeamPlatformAPIExample
{
    partial class MainForm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.signin_Box = new System.Windows.Forms.GroupBox();
            this.profile_image = new System.Windows.Forms.PictureBox();
            this.label3 = new System.Windows.Forms.Label();
            this.profile_box = new System.Windows.Forms.ListBox();
            this.signout_btn = new System.Windows.Forms.Button();
            this.signin_btn = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.pwd_text = new System.Windows.Forms.TextBox();
            this.email_text = new System.Windows.Forms.TextBox();
            this.help_label1 = new System.Windows.Forms.LinkLabel();
            this.client_secret_text = new System.Windows.Forms.TextBox();
            this.client_id_text = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.ouput_box = new System.Windows.Forms.GroupBox();
            this.label7 = new System.Windows.Forms.Label();
            this.api_task_btn = new System.Windows.Forms.Button();
            this.api_file_btn = new System.Windows.Forms.Button();
            this.tp_datagridview = new System.Windows.Forms.DataGridView();
            this.api_ws_btn = new System.Windows.Forms.Button();
            this.help_label2 = new System.Windows.Forms.LinkLabel();
            this.status_strip = new System.Windows.Forms.StatusStrip();
            this.msg_box = new System.Windows.Forms.ToolStripStatusLabel();
            this.client_box = new System.Windows.Forms.GroupBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.signin_Box.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.profile_image)).BeginInit();
            this.ouput_box.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tp_datagridview)).BeginInit();
            this.status_strip.SuspendLayout();
            this.client_box.SuspendLayout();
            this.SuspendLayout();
            // 
            // signin_Box
            // 
            this.signin_Box.Controls.Add(this.profile_image);
            this.signin_Box.Controls.Add(this.label3);
            this.signin_Box.Controls.Add(this.profile_box);
            this.signin_Box.Controls.Add(this.signout_btn);
            this.signin_Box.Controls.Add(this.signin_btn);
            this.signin_Box.Controls.Add(this.label2);
            this.signin_Box.Controls.Add(this.label1);
            this.signin_Box.Controls.Add(this.pwd_text);
            this.signin_Box.Controls.Add(this.email_text);
            this.signin_Box.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.signin_Box.Location = new System.Drawing.Point(375, 33);
            this.signin_Box.Name = "signin_Box";
            this.signin_Box.Size = new System.Drawing.Size(346, 185);
            this.signin_Box.TabIndex = 0;
            this.signin_Box.TabStop = false;
            this.signin_Box.Text = "Step 2 - Sign in";
            // 
            // profile_image
            // 
            this.profile_image.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.profile_image.Location = new System.Drawing.Point(15, 119);
            this.profile_image.Name = "profile_image";
            this.profile_image.Size = new System.Drawing.Size(60, 60);
            this.profile_image.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.profile_image.TabIndex = 14;
            this.profile_image.TabStop = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(13, 104);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(305, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "Account info will be displayed below, when sign-in is successful";
            // 
            // profile_box
            // 
            this.profile_box.BackColor = System.Drawing.SystemColors.Window;
            this.profile_box.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.profile_box.FormattingEnabled = true;
            this.profile_box.Location = new System.Drawing.Point(81, 121);
            this.profile_box.Name = "profile_box";
            this.profile_box.Size = new System.Drawing.Size(248, 56);
            this.profile_box.TabIndex = 7;
            // 
            // signout_btn
            // 
            this.signout_btn.Enabled = false;
            this.signout_btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.signout_btn.Location = new System.Drawing.Point(269, 74);
            this.signout_btn.Name = "signout_btn";
            this.signout_btn.Size = new System.Drawing.Size(64, 25);
            this.signout_btn.TabIndex = 5;
            this.signout_btn.Text = "Sign Out";
            this.signout_btn.UseVisualStyleBackColor = true;
            this.signout_btn.Click += new System.EventHandler(this.signout_btn_Click);
            // 
            // signin_btn
            // 
            this.signin_btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.signin_btn.Location = new System.Drawing.Point(199, 74);
            this.signin_btn.Name = "signin_btn";
            this.signin_btn.Size = new System.Drawing.Size(64, 25);
            this.signin_btn.TabIndex = 4;
            this.signin_btn.Text = "Sign In";
            this.signin_btn.UseVisualStyleBackColor = true;
            this.signin_btn.Click += new System.EventHandler(this.signin_btn_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(19, 53);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Password:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(40, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Email:";
            // 
            // pwd_text
            // 
            this.pwd_text.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pwd_text.Location = new System.Drawing.Point(83, 49);
            this.pwd_text.Name = "pwd_text";
            this.pwd_text.PasswordChar = '*';
            this.pwd_text.Size = new System.Drawing.Size(250, 20);
            this.pwd_text.TabIndex = 3;
            // 
            // email_text
            // 
            this.email_text.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.email_text.Location = new System.Drawing.Point(83, 22);
            this.email_text.Name = "email_text";
            this.email_text.Size = new System.Drawing.Size(250, 20);
            this.email_text.TabIndex = 2;
            // 
            // help_label1
            // 
            this.help_label1.AutoSize = true;
            this.help_label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.help_label1.Location = new System.Drawing.Point(526, 16);
            this.help_label1.Name = "help_label1";
            this.help_label1.Size = new System.Drawing.Size(172, 13);
            this.help_label1.TabIndex = 17;
            this.help_label1.TabStop = true;
            this.help_label1.Tag = "";
            this.help_label1.Text = "TeamPlatform API Documentations";
            this.help_label1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.help_label1_LinkClicked);
            // 
            // client_secret_text
            // 
            this.client_secret_text.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.client_secret_text.Location = new System.Drawing.Point(87, 49);
            this.client_secret_text.Name = "client_secret_text";
            this.client_secret_text.Size = new System.Drawing.Size(250, 20);
            this.client_secret_text.TabIndex = 1;
            // 
            // client_id_text
            // 
            this.client_id_text.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.client_id_text.Location = new System.Drawing.Point(87, 22);
            this.client_id_text.Name = "client_id_text";
            this.client_id_text.Size = new System.Drawing.Size(250, 20);
            this.client_id_text.TabIndex = 0;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(9, 53);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(70, 13);
            this.label5.TabIndex = 10;
            this.label5.Text = "Client Secret:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(29, 26);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(50, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "Client ID:";
            // 
            // ouput_box
            // 
            this.ouput_box.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.ouput_box.Controls.Add(this.label7);
            this.ouput_box.Controls.Add(this.help_label1);
            this.ouput_box.Controls.Add(this.api_task_btn);
            this.ouput_box.Controls.Add(this.api_file_btn);
            this.ouput_box.Controls.Add(this.tp_datagridview);
            this.ouput_box.Controls.Add(this.api_ws_btn);
            this.ouput_box.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ouput_box.Location = new System.Drawing.Point(10, 234);
            this.ouput_box.Name = "ouput_box";
            this.ouput_box.Size = new System.Drawing.Size(711, 372);
            this.ouput_box.TabIndex = 1;
            this.ouput_box.TabStop = false;
            this.ouput_box.Text = "Step 3 - Call Sample API functions";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(8, 24);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(211, 13);
            this.label7.TabIndex = 6;
            this.label7.Text = "Each API call fetches up to recent 30 items";
            // 
            // api_task_btn
            // 
            this.api_task_btn.Enabled = false;
            this.api_task_btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.api_task_btn.Location = new System.Drawing.Point(350, 43);
            this.api_task_btn.Name = "api_task_btn";
            this.api_task_btn.Size = new System.Drawing.Size(151, 25);
            this.api_task_btn.TabIndex = 5;
            this.api_task_btn.Text = "List Finished Tasks";
            this.api_task_btn.UseVisualStyleBackColor = true;
            this.api_task_btn.Click += new System.EventHandler(this.api_task_btn_Click);
            // 
            // api_file_btn
            // 
            this.api_file_btn.Enabled = false;
            this.api_file_btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.api_file_btn.Location = new System.Drawing.Point(179, 43);
            this.api_file_btn.Name = "api_file_btn";
            this.api_file_btn.Size = new System.Drawing.Size(151, 25);
            this.api_file_btn.TabIndex = 3;
            this.api_file_btn.Text = "List Recent Files";
            this.api_file_btn.UseVisualStyleBackColor = true;
            this.api_file_btn.Click += new System.EventHandler(this.api_file_btn_Click);
            // 
            // tp_datagridview
            // 
            this.tp_datagridview.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tp_datagridview.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.tp_datagridview.DefaultCellStyle = dataGridViewCellStyle4;
            this.tp_datagridview.Location = new System.Drawing.Point(9, 74);
            this.tp_datagridview.Name = "tp_datagridview";
            this.tp_datagridview.RowTemplate.Height = 23;
            this.tp_datagridview.Size = new System.Drawing.Size(689, 291);
            this.tp_datagridview.TabIndex = 2;
            // 
            // api_ws_btn
            // 
            this.api_ws_btn.Enabled = false;
            this.api_ws_btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.api_ws_btn.Location = new System.Drawing.Point(8, 43);
            this.api_ws_btn.Name = "api_ws_btn";
            this.api_ws_btn.Size = new System.Drawing.Size(151, 25);
            this.api_ws_btn.TabIndex = 0;
            this.api_ws_btn.Text = "List Active Workspaces";
            this.api_ws_btn.UseVisualStyleBackColor = true;
            this.api_ws_btn.Click += new System.EventHandler(this.api_ws_btn_Click);
            // 
            // help_label2
            // 
            this.help_label2.AutoSize = true;
            this.help_label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.help_label2.Location = new System.Drawing.Point(11, 141);
            this.help_label2.Name = "help_label2";
            this.help_label2.Size = new System.Drawing.Size(323, 13);
            this.help_label2.TabIndex = 18;
            this.help_label2.TabStop = true;
            this.help_label2.Text = "2. Click here or go to Settings->API tab to register a new client app.";
            this.help_label2.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.help_label2_LinkClicked);
            // 
            // status_strip
            // 
            this.status_strip.BackColor = System.Drawing.Color.LightYellow;
            this.status_strip.Dock = System.Windows.Forms.DockStyle.Top;
            this.status_strip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.msg_box});
            this.status_strip.Location = new System.Drawing.Point(0, 0);
            this.status_strip.Name = "status_strip";
            this.status_strip.Size = new System.Drawing.Size(729, 22);
            this.status_strip.TabIndex = 2;
            // 
            // msg_box
            // 
            this.msg_box.Name = "msg_box";
            this.msg_box.Size = new System.Drawing.Size(87, 17);
            this.msg_box.Text = "Pleasae sign in.";
            // 
            // client_box
            // 
            this.client_box.Controls.Add(this.label10);
            this.client_box.Controls.Add(this.label9);
            this.client_box.Controls.Add(this.label6);
            this.client_box.Controls.Add(this.label4);
            this.client_box.Controls.Add(this.client_id_text);
            this.client_box.Controls.Add(this.help_label2);
            this.client_box.Controls.Add(this.label5);
            this.client_box.Controls.Add(this.client_secret_text);
            this.client_box.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.client_box.Location = new System.Drawing.Point(10, 33);
            this.client_box.Name = "client_box";
            this.client_box.Size = new System.Drawing.Size(346, 185);
            this.client_box.TabIndex = 19;
            this.client_box.TabStop = false;
            this.client_box.Text = "Step 1 - Enter OAuth2 Client App Info";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(11, 125);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(258, 13);
            this.label6.TabIndex = 19;
            this.label6.Text = "1. Sign in to your TeamPlatform account on the Web.";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(11, 106);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(250, 13);
            this.label9.TabIndex = 20;
            this.label9.Text = "No Cliente ID Yet? Follow the steps below.";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(11, 159);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(287, 13);
            this.label10.TabIndex = 21;
            this.label10.Text = "3. Copy and paste client ID/Secret in the text boxes above.";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(729, 619);
            this.Controls.Add(this.client_box);
            this.Controls.Add(this.status_strip);
            this.Controls.Add(this.ouput_box);
            this.Controls.Add(this.signin_Box);
            this.Name = "MainForm";
            this.Text = "TeamPlatform API Sample";
            this.signin_Box.ResumeLayout(false);
            this.signin_Box.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.profile_image)).EndInit();
            this.ouput_box.ResumeLayout(false);
            this.ouput_box.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tp_datagridview)).EndInit();
            this.status_strip.ResumeLayout(false);
            this.status_strip.PerformLayout();
            this.client_box.ResumeLayout(false);
            this.client_box.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox signin_Box;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox pwd_text;
        private System.Windows.Forms.TextBox email_text;
        private System.Windows.Forms.Button signout_btn;
        private System.Windows.Forms.Button signin_btn;
        private System.Windows.Forms.GroupBox ouput_box;
        private System.Windows.Forms.Button api_ws_btn;
        private System.Windows.Forms.ListBox profile_box;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox client_secret_text;
        private System.Windows.Forms.TextBox client_id_text;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.PictureBox profile_image;
        private System.Windows.Forms.DataGridView tp_datagridview;
        private System.Windows.Forms.Button api_file_btn;
        private System.Windows.Forms.LinkLabel help_label1;
        private System.Windows.Forms.Button api_task_btn;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.LinkLabel help_label2;
        private System.Windows.Forms.StatusStrip status_strip;
        private System.Windows.Forms.ToolStripStatusLabel msg_box;
        private System.Windows.Forms.GroupBox client_box;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
    }
}

