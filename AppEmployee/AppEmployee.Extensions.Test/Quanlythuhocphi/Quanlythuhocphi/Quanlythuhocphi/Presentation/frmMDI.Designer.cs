namespace Quanlythuhocphi.Presentation
{
    partial class frmMDI
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
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.btnSetting = new System.Windows.Forms.ToolStripButton();
            this.mnuClass = new System.Windows.Forms.ToolStripButton();
            this.btnLevel = new System.Windows.Forms.ToolStripButton();
            this.btnStudent = new System.Windows.Forms.ToolStripButton();
            this.btnEmployee = new System.Windows.Forms.ToolStripButton();
            this.btnReason = new System.Windows.Forms.ToolStripButton();
            this.btnSearch = new System.Windows.Forms.ToolStripButton();
            this.btnThuhocphi = new System.Windows.Forms.ToolStripButton();
            this.btnClose = new System.Windows.Forms.ToolStripButton();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.lblNV = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnSetting,
            this.mnuClass,
            this.btnLevel,
            this.btnStudent,
            this.btnEmployee,
            this.btnReason,
            this.btnSearch,
            this.btnThuhocphi,
            this.btnClose});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(660, 39);
            this.toolStrip1.TabIndex = 3;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // btnSetting
            // 
            this.btnSetting.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnSetting.Image = global::Quanlythuhocphi.Properties.Resources.setting;
            this.btnSetting.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnSetting.Name = "btnSetting";
            this.btnSetting.Size = new System.Drawing.Size(36, 36);
            this.btnSetting.Text = "Thiết lập hệ thống";
            this.btnSetting.Click += new System.EventHandler(this.btnSetting_Click);
            // 
            // mnuClass
            // 
            this.mnuClass.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.mnuClass.Image = global::Quanlythuhocphi.Properties.Resources._class;
            this.mnuClass.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.mnuClass.Name = "mnuClass";
            this.mnuClass.Size = new System.Drawing.Size(36, 36);
            this.mnuClass.Text = "Thông tin lớp học";
            this.mnuClass.Click += new System.EventHandler(this.mnuClass_Click);
            // 
            // btnLevel
            // 
            this.btnLevel.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnLevel.Image = global::Quanlythuhocphi.Properties.Resources.document_graph;
            this.btnLevel.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnLevel.Name = "btnLevel";
            this.btnLevel.Size = new System.Drawing.Size(36, 36);
            this.btnLevel.Text = "Chế độ chính sách";
            this.btnLevel.Click += new System.EventHandler(this.btnLevel_Click);
            // 
            // btnStudent
            // 
            this.btnStudent.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnStudent.Image = global::Quanlythuhocphi.Properties.Resources.users_mixed_gender;
            this.btnStudent.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnStudent.Name = "btnStudent";
            this.btnStudent.Size = new System.Drawing.Size(36, 36);
            this.btnStudent.Text = "Thông tin sinh viên";
            this.btnStudent.Click += new System.EventHandler(this.btnStudent_Click);
            // 
            // btnEmployee
            // 
            this.btnEmployee.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnEmployee.Image = global::Quanlythuhocphi.Properties.Resources.employee;
            this.btnEmployee.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnEmployee.Name = "btnEmployee";
            this.btnEmployee.Size = new System.Drawing.Size(36, 36);
            this.btnEmployee.Text = "Thông tin nhân viên";
            this.btnEmployee.Click += new System.EventHandler(this.btnEmployee_Click);
            // 
            // btnReason
            // 
            this.btnReason.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnReason.Image = global::Quanlythuhocphi.Properties.Resources.txt_file;
            this.btnReason.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnReason.Name = "btnReason";
            this.btnReason.Size = new System.Drawing.Size(36, 36);
            this.btnReason.Text = "Lý do thu";
            this.btnReason.Click += new System.EventHandler(this.btnReason_Click);
            // 
            // btnSearch
            // 
            this.btnSearch.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnSearch.Image = global::Quanlythuhocphi.Properties.Resources.find;
            this.btnSearch.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(36, 36);
            this.btnSearch.Text = "Tìm kiếm sinh viên";
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // btnThuhocphi
            // 
            this.btnThuhocphi.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnThuhocphi.Image = global::Quanlythuhocphi.Properties.Resources.emblem_library;
            this.btnThuhocphi.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnThuhocphi.Name = "btnThuhocphi";
            this.btnThuhocphi.Size = new System.Drawing.Size(36, 36);
            this.btnThuhocphi.Text = "Thu học phí";
            this.btnThuhocphi.Click += new System.EventHandler(this.btnThuhocphi_Click);
            // 
            // btnClose
            // 
            this.btnClose.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnClose.Image = global::Quanlythuhocphi.Properties.Resources.exit__1_;
            this.btnClose.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(36, 36);
            this.btnClose.Text = "Đóng cửa sổ hiện tại";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblNV});
            this.statusStrip1.Location = new System.Drawing.Point(0, 376);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(660, 22);
            this.statusStrip1.TabIndex = 4;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // lblNV
            // 
            this.lblNV.Name = "lblNV";
            this.lblNV.Size = new System.Drawing.Size(213, 17);
            this.lblNV.Text = "Hệ thống quản lý thu học phí sinh viên";
            // 
            // frmMDI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(660, 398);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.toolStrip1);
            this.IsMdiContainer = true;
            this.Name = "frmMDI";
            this.Text = "Hệ thống quản lý thu học phí [...]";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmMDI_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        public System.Windows.Forms.ToolStripButton btnSetting;
        public System.Windows.Forms.ToolStripButton mnuClass;
        public System.Windows.Forms.ToolStripButton btnLevel;
        public System.Windows.Forms.ToolStripButton btnStudent;
        public System.Windows.Forms.ToolStripButton btnEmployee;
        public System.Windows.Forms.ToolStripButton btnReason;
        public System.Windows.Forms.ToolStripButton btnSearch;
        public System.Windows.Forms.ToolStripButton btnThuhocphi;
        private System.Windows.Forms.ToolStripButton btnClose;
        private System.Windows.Forms.StatusStrip statusStrip1;
        public System.Windows.Forms.ToolStripStatusLabel lblNV;


    }
}