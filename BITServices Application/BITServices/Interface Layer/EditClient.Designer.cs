namespace BITServices.Interface_Layer
{
    partial class EditClient
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EditClient));
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.label27 = new System.Windows.Forms.Label();
            this.txtClientEmail = new System.Windows.Forms.TextBox();
            this.label21 = new System.Windows.Forms.Label();
            this.txtClientAddress = new System.Windows.Forms.TextBox();
            this.label26 = new System.Windows.Forms.Label();
            this.label25 = new System.Windows.Forms.Label();
            this.txtClientPostCode = new System.Windows.Forms.TextBox();
            this.txtClientCity = new System.Windows.Forms.TextBox();
            this.txtClientMobile = new System.Windows.Forms.TextBox();
            this.label18 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.label22 = new System.Windows.Forms.Label();
            this.label23 = new System.Windows.Forms.Label();
            this.txtClientPhone = new System.Windows.Forms.TextBox();
            this.txtClientName = new System.Windows.Forms.TextBox();
            this.txtClientTitle = new System.Windows.Forms.TextBox();
            this.label24 = new System.Windows.Forms.Label();
            this.chkActive = new System.Windows.Forms.CheckBox();
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(452, 320);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 26);
            this.btnCancel.TabIndex = 142;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(165, 320);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 26);
            this.btnSave.TabIndex = 141;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // label27
            // 
            this.label27.AutoSize = true;
            this.label27.Location = new System.Drawing.Point(331, 80);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(52, 18);
            this.label27.TabIndex = 140;
            this.label27.Text = "Email:";
            // 
            // txtClientEmail
            // 
            this.txtClientEmail.Location = new System.Drawing.Point(331, 101);
            this.txtClientEmail.Name = "txtClientEmail";
            this.txtClientEmail.Size = new System.Drawing.Size(191, 26);
            this.txtClientEmail.TabIndex = 139;
            this.txtClientEmail.Validating += new System.ComponentModel.CancelEventHandler(this.txtClientEmail_Validating);
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(167, 202);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(67, 18);
            this.label21.TabIndex = 138;
            this.label21.Text = "Address";
            // 
            // txtClientAddress
            // 
            this.txtClientAddress.Location = new System.Drawing.Point(165, 223);
            this.txtClientAddress.Name = "txtClientAddress";
            this.txtClientAddress.Size = new System.Drawing.Size(362, 26);
            this.txtClientAddress.TabIndex = 137;
            // 
            // label26
            // 
            this.label26.AutoSize = true;
            this.label26.Location = new System.Drawing.Point(331, 136);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(83, 18);
            this.label26.TabIndex = 136;
            this.label26.Text = "PostCode:";
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.Location = new System.Drawing.Point(166, 136);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(39, 18);
            this.label25.TabIndex = 135;
            this.label25.Text = "City:";
            // 
            // txtClientPostCode
            // 
            this.txtClientPostCode.Location = new System.Drawing.Point(331, 157);
            this.txtClientPostCode.MaxLength = 5;
            this.txtClientPostCode.Name = "txtClientPostCode";
            this.txtClientPostCode.Size = new System.Drawing.Size(196, 26);
            this.txtClientPostCode.TabIndex = 134;
            // 
            // txtClientCity
            // 
            this.txtClientCity.Location = new System.Drawing.Point(165, 157);
            this.txtClientCity.Name = "txtClientCity";
            this.txtClientCity.Size = new System.Drawing.Size(160, 26);
            this.txtClientCity.TabIndex = 133;
            // 
            // txtClientMobile
            // 
            this.txtClientMobile.Location = new System.Drawing.Point(331, 282);
            this.txtClientMobile.MaxLength = 10;
            this.txtClientMobile.Name = "txtClientMobile";
            this.txtClientMobile.Size = new System.Drawing.Size(196, 26);
            this.txtClientMobile.TabIndex = 132;
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(188, 28);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(269, 18);
            this.label18.TabIndex = 131;
            this.label18.Text = "Enter the correct fields and click save.";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(328, 261);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(59, 18);
            this.label19.TabIndex = 129;
            this.label19.Text = "Mobile:";
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(166, 261);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(57, 18);
            this.label20.TabIndex = 128;
            this.label20.Text = "Phone:";
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Location = new System.Drawing.Point(166, 80);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(54, 18);
            this.label22.TabIndex = 127;
            this.label22.Text = "Name:";
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Location = new System.Drawing.Point(56, 80);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(40, 18);
            this.label23.TabIndex = 126;
            this.label23.Text = "Title:";
            // 
            // txtClientPhone
            // 
            this.txtClientPhone.Location = new System.Drawing.Point(165, 282);
            this.txtClientPhone.MaxLength = 10;
            this.txtClientPhone.Name = "txtClientPhone";
            this.txtClientPhone.Size = new System.Drawing.Size(160, 26);
            this.txtClientPhone.TabIndex = 125;
            // 
            // txtClientName
            // 
            this.txtClientName.Location = new System.Drawing.Point(165, 101);
            this.txtClientName.Name = "txtClientName";
            this.txtClientName.Size = new System.Drawing.Size(160, 26);
            this.txtClientName.TabIndex = 124;
            // 
            // txtClientTitle
            // 
            this.txtClientTitle.Location = new System.Drawing.Point(59, 101);
            this.txtClientTitle.MaxLength = 4;
            this.txtClientTitle.Name = "txtClientTitle";
            this.txtClientTitle.Size = new System.Drawing.Size(100, 26);
            this.txtClientTitle.TabIndex = 123;
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Font = new System.Drawing.Font("Arial", 14F);
            this.label24.Location = new System.Drawing.Point(222, 6);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(210, 22);
            this.label24.TabIndex = 122;
            this.label24.Text = "Client Managment - Edit";
            // 
            // chkActive
            // 
            this.chkActive.AutoSize = true;
            this.chkActive.Location = new System.Drawing.Point(59, 157);
            this.chkActive.Name = "chkActive";
            this.chkActive.Size = new System.Drawing.Size(70, 22);
            this.chkActive.TabIndex = 143;
            this.chkActive.Text = "Active";
            this.chkActive.UseVisualStyleBackColor = true;
            // 
            // errorProvider
            // 
            this.errorProvider.ContainerControl = this;
            // 
            // EditClient
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(633, 361);
            this.Controls.Add(this.chkActive);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.label27);
            this.Controls.Add(this.txtClientEmail);
            this.Controls.Add(this.label21);
            this.Controls.Add(this.txtClientAddress);
            this.Controls.Add(this.label26);
            this.Controls.Add(this.label25);
            this.Controls.Add(this.txtClientPostCode);
            this.Controls.Add(this.txtClientCity);
            this.Controls.Add(this.txtClientMobile);
            this.Controls.Add(this.label18);
            this.Controls.Add(this.label19);
            this.Controls.Add(this.label20);
            this.Controls.Add(this.label22);
            this.Controls.Add(this.label23);
            this.Controls.Add(this.txtClientPhone);
            this.Controls.Add(this.txtClientName);
            this.Controls.Add(this.txtClientTitle);
            this.Controls.Add(this.label24);
            this.Font = new System.Drawing.Font("Arial", 12F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "EditClient";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Bit Services - Edit Client";
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Label label27;
        private System.Windows.Forms.TextBox txtClientEmail;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.TextBox txtClientAddress;
        private System.Windows.Forms.Label label26;
        private System.Windows.Forms.Label label25;
        private System.Windows.Forms.TextBox txtClientPostCode;
        private System.Windows.Forms.TextBox txtClientCity;
        private System.Windows.Forms.TextBox txtClientMobile;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.TextBox txtClientPhone;
        private System.Windows.Forms.TextBox txtClientName;
        private System.Windows.Forms.TextBox txtClientTitle;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.CheckBox chkActive;
        private System.Windows.Forms.ErrorProvider errorProvider;

    }
}