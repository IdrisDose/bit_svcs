﻿namespace BITServices.Interface_Layer
{
    partial class NewJob
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NewJob));
            this.cmbPriority = new System.Windows.Forms.ComboBox();
            this.cmbContractor = new System.Windows.Forms.ComboBox();
            this.cmbClient = new System.Windows.Forms.ComboBox();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnNew = new System.Windows.Forms.Button();
            this.label24 = new System.Windows.Forms.Label();
            this.label35 = new System.Windows.Forms.Label();
            this.txtJobLoc = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label29 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtJobDetails = new System.Windows.Forms.TextBox();
            this.txtJobName = new System.Windows.Forms.TextBox();
            this.chkActive = new System.Windows.Forms.CheckBox();
            this.lblError = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // cmbPriority
            // 
            this.cmbPriority.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbPriority.FormattingEnabled = true;
            this.cmbPriority.Location = new System.Drawing.Point(12, 148);
            this.cmbPriority.Name = "cmbPriority";
            this.cmbPriority.Size = new System.Drawing.Size(100, 26);
            this.cmbPriority.TabIndex = 171;
            // 
            // cmbContractor
            // 
            this.cmbContractor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbContractor.FormattingEnabled = true;
            this.cmbContractor.Location = new System.Drawing.Point(292, 148);
            this.cmbContractor.Name = "cmbContractor";
            this.cmbContractor.Size = new System.Drawing.Size(158, 26);
            this.cmbContractor.TabIndex = 170;
            // 
            // cmbClient
            // 
            this.cmbClient.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbClient.FormattingEnabled = true;
            this.cmbClient.Location = new System.Drawing.Point(128, 148);
            this.cmbClient.Name = "cmbClient";
            this.cmbClient.Size = new System.Drawing.Size(158, 26);
            this.cmbClient.TabIndex = 169;
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(263, 263);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(78, 27);
            this.btnCancel.TabIndex = 168;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnNew
            // 
            this.btnNew.Location = new System.Drawing.Point(128, 263);
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(78, 27);
            this.btnNew.TabIndex = 167;
            this.btnNew.Text = "Request";
            this.btnNew.UseVisualStyleBackColor = true;
            this.btnNew.Click += new System.EventHandler(this.btnNew_Click);
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Font = new System.Drawing.Font("Arial", 14F);
            this.label24.Location = new System.Drawing.Point(128, 11);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(198, 22);
            this.label24.TabIndex = 166;
            this.label24.Text = "Job Managment - New";
            // 
            // label35
            // 
            this.label35.AutoSize = true;
            this.label35.Location = new System.Drawing.Point(129, 186);
            this.label35.Name = "label35";
            this.label35.Size = new System.Drawing.Size(102, 18);
            this.label35.TabIndex = 165;
            this.label35.Text = "Job Location:";
            // 
            // txtJobLoc
            // 
            this.txtJobLoc.Location = new System.Drawing.Point(128, 207);
            this.txtJobLoc.Name = "txtJobLoc";
            this.txtJobLoc.Size = new System.Drawing.Size(322, 26);
            this.txtJobLoc.TabIndex = 164;
            this.txtJobLoc.Validating += new System.ComponentModel.CancelEventHandler(this.validateText);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(13, 127);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(61, 18);
            this.label5.TabIndex = 163;
            this.label5.Text = "Priority:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(289, 127);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(85, 18);
            this.label4.TabIndex = 162;
            this.label4.Text = "Contractor:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(129, 127);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(52, 18);
            this.label3.TabIndex = 161;
            this.label3.Text = "Client:";
            // 
            // label29
            // 
            this.label29.AutoSize = true;
            this.label29.Location = new System.Drawing.Point(26, 35);
            this.label29.Name = "label29";
            this.label29.Size = new System.Drawing.Size(426, 18);
            this.label29.TabIndex = 160;
            this.label29.Text = "To make a new job, fill out the fields below and click Request.";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(129, 65);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(91, 18);
            this.label2.TabIndex = 159;
            this.label2.Text = "Job Details:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 65);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(84, 18);
            this.label1.TabIndex = 158;
            this.label1.Text = "Job Name:";
            // 
            // txtJobDetails
            // 
            this.txtJobDetails.Location = new System.Drawing.Point(128, 86);
            this.txtJobDetails.Name = "txtJobDetails";
            this.txtJobDetails.Size = new System.Drawing.Size(322, 26);
            this.txtJobDetails.TabIndex = 157;
            this.txtJobDetails.Validating += new System.ComponentModel.CancelEventHandler(this.validateText);
            // 
            // txtJobName
            // 
            this.txtJobName.Location = new System.Drawing.Point(12, 86);
            this.txtJobName.Name = "txtJobName";
            this.txtJobName.Size = new System.Drawing.Size(100, 26);
            this.txtJobName.TabIndex = 156;
            this.txtJobName.Validating += new System.ComponentModel.CancelEventHandler(this.validateText);
            // 
            // chkActive
            // 
            this.chkActive.AutoSize = true;
            this.chkActive.Location = new System.Drawing.Point(12, 209);
            this.chkActive.Name = "chkActive";
            this.chkActive.Size = new System.Drawing.Size(70, 22);
            this.chkActive.TabIndex = 172;
            this.chkActive.Text = "Active";
            this.chkActive.UseVisualStyleBackColor = true;
            // 
            // lblError
            // 
            this.lblError.AutoSize = true;
            this.lblError.Font = new System.Drawing.Font("Arial", 10F);
            this.lblError.ForeColor = System.Drawing.Color.Red;
            this.lblError.Location = new System.Drawing.Point(129, 242);
            this.lblError.Name = "lblError";
            this.lblError.Size = new System.Drawing.Size(0, 16);
            this.lblError.TabIndex = 173;
            // 
            // NewJob
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(465, 300);
            this.Controls.Add(this.lblError);
            this.Controls.Add(this.chkActive);
            this.Controls.Add(this.cmbPriority);
            this.Controls.Add(this.cmbContractor);
            this.Controls.Add(this.cmbClient);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnNew);
            this.Controls.Add(this.label24);
            this.Controls.Add(this.label35);
            this.Controls.Add(this.txtJobLoc);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label29);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtJobDetails);
            this.Controls.Add(this.txtJobName);
            this.Font = new System.Drawing.Font("Arial", 12F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "NewJob";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Bit Services - New Job";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cmbPriority;
        private System.Windows.Forms.ComboBox cmbContractor;
        private System.Windows.Forms.ComboBox cmbClient;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnNew;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.Label label35;
        private System.Windows.Forms.TextBox txtJobLoc;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label29;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtJobDetails;
        private System.Windows.Forms.TextBox txtJobName;
        private System.Windows.Forms.CheckBox chkActive;
        private System.Windows.Forms.Label lblError;

    }
}