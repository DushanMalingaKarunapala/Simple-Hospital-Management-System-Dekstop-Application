
namespace HMS
{
    partial class LabTechnician
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.guna2Elipse1 = new Guna.UI2.WinForms.Guna2Elipse(this.components);
            this.guna2DragControl1 = new Guna.UI2.WinForms.Guna2DragControl(this.components);
            this.guna2Elipse2 = new Guna.UI2.WinForms.Guna2Elipse(this.components);
            this.guna2Elipse3 = new Guna.UI2.WinForms.Guna2Elipse(this.components);
            this.paneluploadLabResults = new Guna.UI2.WinForms.Guna2Panel();
            this.guna2Panel1 = new Guna.UI2.WinForms.Guna2Panel();
            this.btnUploadLabResult = new Guna.UI2.WinForms.Guna2Button();
            this.txtboxlabResultDescription = new Guna.UI2.WinForms.Guna2TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.textBoxImagePath = new Guna.UI2.WinForms.Guna2TextBox();
            this.pictureBoxResultPreview = new Guna.UI2.WinForms.Guna2PictureBox();
            this.btnBrowse = new Guna.UI2.WinForms.Guna2Button();
            this.label2 = new System.Windows.Forms.Label();
            this.panelviewScheduledScans = new Guna.UI2.WinForms.Guna2Panel();
            this.label6 = new System.Windows.Forms.Label();
            this.lbldoubleclickvalue = new System.Windows.Forms.Label();
            this.gridviewScheduledScans = new Guna.UI2.WinForms.Guna2DataGridView();
            this.label3 = new System.Windows.Forms.Label();
            this.guna2Separator1 = new Guna.UI2.WinForms.Guna2Separator();
            this.guna2CirclePictureBox1 = new Guna.UI2.WinForms.Guna2CirclePictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnlabViewRequestedScans = new Guna.UI2.WinForms.Guna2Button();
            this.btnlabUploadLabResults = new Guna.UI2.WinForms.Guna2Button();
            this.panelLabSideMenu = new Guna.UI2.WinForms.Guna2Panel();
            this.btndocLogoutlab = new Guna.UI2.WinForms.Guna2Button();
            this.paneluploadLabResults.SuspendLayout();
            this.guna2Panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxResultPreview)).BeginInit();
            this.panelviewScheduledScans.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridviewScheduledScans)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.guna2CirclePictureBox1)).BeginInit();
            this.panelLabSideMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // guna2Elipse1
            // 
            this.guna2Elipse1.TargetControl = this;
            // 
            // guna2DragControl1
            // 
            this.guna2DragControl1.DockIndicatorTransparencyValue = 0.6D;
            this.guna2DragControl1.TargetControl = this;
            this.guna2DragControl1.UseTransparentDrag = true;
            // 
            // guna2Elipse2
            // 
            this.guna2Elipse2.TargetControl = this.panelLabSideMenu;
            // 
            // paneluploadLabResults
            // 
            this.paneluploadLabResults.BackColor = System.Drawing.Color.WhiteSmoke;
            this.paneluploadLabResults.BorderRadius = 20;
            this.paneluploadLabResults.BorderThickness = 1;
            this.paneluploadLabResults.Controls.Add(this.guna2Panel1);
            this.paneluploadLabResults.Controls.Add(this.label2);
            this.paneluploadLabResults.Location = new System.Drawing.Point(328, 12);
            this.paneluploadLabResults.Name = "paneluploadLabResults";
            this.paneluploadLabResults.ShadowDecoration.Color = System.Drawing.Color.DarkGray;
            this.paneluploadLabResults.Size = new System.Drawing.Size(847, 728);
            this.paneluploadLabResults.TabIndex = 2;
            // 
            // guna2Panel1
            // 
            this.guna2Panel1.Controls.Add(this.btnUploadLabResult);
            this.guna2Panel1.Controls.Add(this.txtboxlabResultDescription);
            this.guna2Panel1.Controls.Add(this.label5);
            this.guna2Panel1.Controls.Add(this.label4);
            this.guna2Panel1.Controls.Add(this.textBoxImagePath);
            this.guna2Panel1.Controls.Add(this.pictureBoxResultPreview);
            this.guna2Panel1.Controls.Add(this.btnBrowse);
            this.guna2Panel1.Location = new System.Drawing.Point(50, 83);
            this.guna2Panel1.Name = "guna2Panel1";
            this.guna2Panel1.Size = new System.Drawing.Size(748, 616);
            this.guna2Panel1.TabIndex = 2;
            // 
            // btnUploadLabResult
            // 
            this.btnUploadLabResult.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnUploadLabResult.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnUploadLabResult.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnUploadLabResult.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnUploadLabResult.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnUploadLabResult.ForeColor = System.Drawing.Color.White;
            this.btnUploadLabResult.Location = new System.Drawing.Point(281, 539);
            this.btnUploadLabResult.Name = "btnUploadLabResult";
            this.btnUploadLabResult.Size = new System.Drawing.Size(180, 45);
            this.btnUploadLabResult.TabIndex = 6;
            this.btnUploadLabResult.Text = "Upload";
            this.btnUploadLabResult.Click += new System.EventHandler(this.btnUploadLabResult_Click);
            // 
            // txtboxlabResultDescription
            // 
            this.txtboxlabResultDescription.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtboxlabResultDescription.DefaultText = "";
            this.txtboxlabResultDescription.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtboxlabResultDescription.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtboxlabResultDescription.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtboxlabResultDescription.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtboxlabResultDescription.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtboxlabResultDescription.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtboxlabResultDescription.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtboxlabResultDescription.Location = new System.Drawing.Point(342, 399);
            this.txtboxlabResultDescription.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtboxlabResultDescription.Name = "txtboxlabResultDescription";
            this.txtboxlabResultDescription.PasswordChar = '\0';
            this.txtboxlabResultDescription.PlaceholderText = "";
            this.txtboxlabResultDescription.SelectedText = "";
            this.txtboxlabResultDescription.Size = new System.Drawing.Size(300, 108);
            this.txtboxlabResultDescription.TabIndex = 5;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(70, 399);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(186, 17);
            this.label5.TabIndex = 4;
            this.label5.Text = "Result Description(Optional)";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(70, 122);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(311, 17);
            this.label4.TabIndex = 3;
            this.label4.Text = "Please Upload the selected Patient\'s Lab Result";
            // 
            // textBoxImagePath
            // 
            this.textBoxImagePath.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.textBoxImagePath.DefaultText = "";
            this.textBoxImagePath.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.textBoxImagePath.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.textBoxImagePath.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.textBoxImagePath.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.textBoxImagePath.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.textBoxImagePath.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.textBoxImagePath.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.textBoxImagePath.Location = new System.Drawing.Point(73, 155);
            this.textBoxImagePath.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.textBoxImagePath.Name = "textBoxImagePath";
            this.textBoxImagePath.PasswordChar = '\0';
            this.textBoxImagePath.PlaceholderText = "";
            this.textBoxImagePath.SelectedText = "";
            this.textBoxImagePath.Size = new System.Drawing.Size(229, 35);
            this.textBoxImagePath.TabIndex = 2;
            // 
            // pictureBoxResultPreview
            // 
            this.pictureBoxResultPreview.ImageRotate = 0F;
            this.pictureBoxResultPreview.Location = new System.Drawing.Point(342, 155);
            this.pictureBoxResultPreview.Name = "pictureBoxResultPreview";
            this.pictureBoxResultPreview.Size = new System.Drawing.Size(300, 200);
            this.pictureBoxResultPreview.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxResultPreview.TabIndex = 1;
            this.pictureBoxResultPreview.TabStop = false;
            // 
            // btnBrowse
            // 
            this.btnBrowse.Animated = true;
            this.btnBrowse.AutoRoundedCorners = true;
            this.btnBrowse.BorderRadius = 17;
            this.btnBrowse.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnBrowse.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnBrowse.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnBrowse.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnBrowse.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnBrowse.ForeColor = System.Drawing.Color.White;
            this.btnBrowse.Location = new System.Drawing.Point(423, 112);
            this.btnBrowse.Name = "btnBrowse";
            this.btnBrowse.Size = new System.Drawing.Size(127, 37);
            this.btnBrowse.TabIndex = 0;
            this.btnBrowse.Text = "Upload File";
            this.btnBrowse.Click += new System.EventHandler(this.btnBrowse_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(315, 34);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(216, 32);
            this.label2.TabIndex = 1;
            this.label2.Text = "Upload Lab Results";
            // 
            // panelviewScheduledScans
            // 
            this.panelviewScheduledScans.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panelviewScheduledScans.BorderRadius = 20;
            this.panelviewScheduledScans.BorderThickness = 1;
            this.panelviewScheduledScans.Controls.Add(this.label6);
            this.panelviewScheduledScans.Controls.Add(this.lbldoubleclickvalue);
            this.panelviewScheduledScans.Controls.Add(this.gridviewScheduledScans);
            this.panelviewScheduledScans.Controls.Add(this.label3);
            this.panelviewScheduledScans.Location = new System.Drawing.Point(328, 12);
            this.panelviewScheduledScans.Name = "panelviewScheduledScans";
            this.panelviewScheduledScans.ShadowDecoration.Color = System.Drawing.Color.DarkGray;
            this.panelviewScheduledScans.Size = new System.Drawing.Size(847, 728);
            this.panelviewScheduledScans.TabIndex = 3;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(275, 499);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(123, 17);
            this.label6.TabIndex = 5;
            this.label6.Text = "Selected Patient : ";
            // 
            // lbldoubleclickvalue
            // 
            this.lbldoubleclickvalue.AutoSize = true;
            this.lbldoubleclickvalue.Location = new System.Drawing.Point(415, 499);
            this.lbldoubleclickvalue.Name = "lbldoubleclickvalue";
            this.lbldoubleclickvalue.Size = new System.Drawing.Size(16, 17);
            this.lbldoubleclickvalue.TabIndex = 4;
            this.lbldoubleclickvalue.Text = "0";
            // 
            // gridviewScheduledScans
            // 
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(185)))), ((int)(((byte)(226)))), ((int)(((byte)(218)))));
            this.gridviewScheduledScans.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(160)))), ((int)(((byte)(133)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gridviewScheduledScans.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.gridviewScheduledScans.ColumnHeadersHeight = 40;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(235)))), ((int)(((byte)(230)))));
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(191)))), ((int)(((byte)(173)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.gridviewScheduledScans.DefaultCellStyle = dataGridViewCellStyle3;
            this.gridviewScheduledScans.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(182)))), ((int)(((byte)(224)))), ((int)(((byte)(216)))));
            this.gridviewScheduledScans.Location = new System.Drawing.Point(17, 125);
            this.gridviewScheduledScans.MultiSelect = false;
            this.gridviewScheduledScans.Name = "gridviewScheduledScans";
            this.gridviewScheduledScans.RowHeadersVisible = false;
            this.gridviewScheduledScans.RowHeadersWidth = 51;
            this.gridviewScheduledScans.RowTemplate.Height = 24;
            this.gridviewScheduledScans.Size = new System.Drawing.Size(813, 313);
            this.gridviewScheduledScans.TabIndex = 3;
            this.gridviewScheduledScans.Theme = Guna.UI2.WinForms.Enums.DataGridViewPresetThemes.GreenSea;
            this.gridviewScheduledScans.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(185)))), ((int)(((byte)(226)))), ((int)(((byte)(218)))));
            this.gridviewScheduledScans.ThemeStyle.AlternatingRowsStyle.Font = null;
            this.gridviewScheduledScans.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Empty;
            this.gridviewScheduledScans.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.Empty;
            this.gridviewScheduledScans.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Empty;
            this.gridviewScheduledScans.ThemeStyle.BackColor = System.Drawing.Color.White;
            this.gridviewScheduledScans.ThemeStyle.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(182)))), ((int)(((byte)(224)))), ((int)(((byte)(216)))));
            this.gridviewScheduledScans.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(160)))), ((int)(((byte)(133)))));
            this.gridviewScheduledScans.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.gridviewScheduledScans.ThemeStyle.HeaderStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridviewScheduledScans.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.White;
            this.gridviewScheduledScans.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.gridviewScheduledScans.ThemeStyle.HeaderStyle.Height = 40;
            this.gridviewScheduledScans.ThemeStyle.ReadOnly = false;
            this.gridviewScheduledScans.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(235)))), ((int)(((byte)(230)))));
            this.gridviewScheduledScans.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.gridviewScheduledScans.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridviewScheduledScans.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.Black;
            this.gridviewScheduledScans.ThemeStyle.RowsStyle.Height = 24;
            this.gridviewScheduledScans.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(191)))), ((int)(((byte)(173)))));
            this.gridviewScheduledScans.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.Black;
            this.gridviewScheduledScans.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridviewScheduledScans_CellDoubleClick);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(350, 34);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(194, 32);
            this.label3.TabIndex = 2;
            this.label3.Text = "Scheduled Scans";
            // 
            // guna2Separator1
            // 
            this.guna2Separator1.Location = new System.Drawing.Point(27, 125);
            this.guna2Separator1.Name = "guna2Separator1";
            this.guna2Separator1.Size = new System.Drawing.Size(236, 10);
            this.guna2Separator1.TabIndex = 0;
            // 
            // guna2CirclePictureBox1
            // 
            this.guna2CirclePictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.guna2CirclePictureBox1.FillColor = System.Drawing.Color.Transparent;
            this.guna2CirclePictureBox1.Image = global::HMS.Properties.Resources.Male_User1;
            this.guna2CirclePictureBox1.ImageRotate = 0F;
            this.guna2CirclePictureBox1.Location = new System.Drawing.Point(106, 14);
            this.guna2CirclePictureBox1.Name = "guna2CirclePictureBox1";
            this.guna2CirclePictureBox1.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle;
            this.guna2CirclePictureBox1.Size = new System.Drawing.Size(59, 53);
            this.guna2CirclePictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.guna2CirclePictureBox1.TabIndex = 1;
            this.guna2CirclePictureBox1.TabStop = false;
            this.guna2CirclePictureBox1.UseTransparentBackground = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label1.Location = new System.Drawing.Point(74, 70);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(137, 28);
            this.label1.TabIndex = 2;
            this.label1.Text = "Welcome User";
            // 
            // btnlabViewRequestedScans
            // 
            this.btnlabViewRequestedScans.BorderColor = System.Drawing.Color.Transparent;
            this.btnlabViewRequestedScans.BorderThickness = 1;
            this.btnlabViewRequestedScans.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnlabViewRequestedScans.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnlabViewRequestedScans.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnlabViewRequestedScans.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnlabViewRequestedScans.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(57)))), ((int)(((byte)(61)))));
            this.btnlabViewRequestedScans.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnlabViewRequestedScans.ForeColor = System.Drawing.Color.White;
            this.btnlabViewRequestedScans.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.btnlabViewRequestedScans.HoverState.FillColor = System.Drawing.Color.DodgerBlue;
            this.btnlabViewRequestedScans.Location = new System.Drawing.Point(27, 205);
            this.btnlabViewRequestedScans.Name = "btnlabViewRequestedScans";
            this.btnlabViewRequestedScans.Size = new System.Drawing.Size(236, 45);
            this.btnlabViewRequestedScans.TabIndex = 3;
            this.btnlabViewRequestedScans.Text = "View Scheduled Scans";
            this.btnlabViewRequestedScans.Click += new System.EventHandler(this.btnlabViewRequestedScans_Click);
            // 
            // btnlabUploadLabResults
            // 
            this.btnlabUploadLabResults.BorderColor = System.Drawing.Color.Transparent;
            this.btnlabUploadLabResults.BorderThickness = 1;
            this.btnlabUploadLabResults.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnlabUploadLabResults.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnlabUploadLabResults.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnlabUploadLabResults.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnlabUploadLabResults.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(57)))), ((int)(((byte)(61)))));
            this.btnlabUploadLabResults.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnlabUploadLabResults.ForeColor = System.Drawing.Color.White;
            this.btnlabUploadLabResults.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.btnlabUploadLabResults.HoverState.FillColor = System.Drawing.Color.DodgerBlue;
            this.btnlabUploadLabResults.Location = new System.Drawing.Point(27, 310);
            this.btnlabUploadLabResults.Name = "btnlabUploadLabResults";
            this.btnlabUploadLabResults.Size = new System.Drawing.Size(236, 45);
            this.btnlabUploadLabResults.TabIndex = 4;
            this.btnlabUploadLabResults.Text = "Upload Results";
            this.btnlabUploadLabResults.Click += new System.EventHandler(this.btnlabUploadLabResults_Click);
            // 
            // panelLabSideMenu
            // 
            this.panelLabSideMenu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(57)))), ((int)(((byte)(61)))));
            this.panelLabSideMenu.BorderRadius = 20;
            this.panelLabSideMenu.BorderThickness = 1;
            this.panelLabSideMenu.Controls.Add(this.btndocLogoutlab);
            this.panelLabSideMenu.Controls.Add(this.btnlabUploadLabResults);
            this.panelLabSideMenu.Controls.Add(this.btnlabViewRequestedScans);
            this.panelLabSideMenu.Controls.Add(this.label1);
            this.panelLabSideMenu.Controls.Add(this.guna2CirclePictureBox1);
            this.panelLabSideMenu.Controls.Add(this.guna2Separator1);
            this.panelLabSideMenu.Location = new System.Drawing.Point(12, 12);
            this.panelLabSideMenu.Name = "panelLabSideMenu";
            this.panelLabSideMenu.Size = new System.Drawing.Size(297, 728);
            this.panelLabSideMenu.TabIndex = 0;
            // 
            // btndocLogoutlab
            // 
            this.btndocLogoutlab.Animated = true;
            this.btndocLogoutlab.AutoRoundedCorners = true;
            this.btndocLogoutlab.BorderColor = System.Drawing.Color.Transparent;
            this.btndocLogoutlab.BorderRadius = 21;
            this.btndocLogoutlab.BorderThickness = 1;
            this.btndocLogoutlab.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btndocLogoutlab.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btndocLogoutlab.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btndocLogoutlab.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btndocLogoutlab.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.btndocLogoutlab.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btndocLogoutlab.ForeColor = System.Drawing.Color.White;
            this.btndocLogoutlab.HoverState.BorderColor = System.Drawing.Color.Red;
            this.btndocLogoutlab.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.btndocLogoutlab.Image = global::HMS.Properties.Resources.Logout1;
            this.btndocLogoutlab.Location = new System.Drawing.Point(56, 654);
            this.btndocLogoutlab.Name = "btndocLogoutlab";
            this.btndocLogoutlab.Size = new System.Drawing.Size(180, 45);
            this.btndocLogoutlab.TabIndex = 13;
            this.btndocLogoutlab.Text = "Logout";
            this.btndocLogoutlab.Click += new System.EventHandler(this.btndocLogoutlab_Click);
            // 
            // LabTechnician
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1196, 752);
            this.Controls.Add(this.panelLabSideMenu);
            this.Controls.Add(this.panelviewScheduledScans);
            this.Controls.Add(this.paneluploadLabResults);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "LabTechnician";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "LabTechnician";
            this.paneluploadLabResults.ResumeLayout(false);
            this.paneluploadLabResults.PerformLayout();
            this.guna2Panel1.ResumeLayout(false);
            this.guna2Panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxResultPreview)).EndInit();
            this.panelviewScheduledScans.ResumeLayout(false);
            this.panelviewScheduledScans.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridviewScheduledScans)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.guna2CirclePictureBox1)).EndInit();
            this.panelLabSideMenu.ResumeLayout(false);
            this.panelLabSideMenu.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI2.WinForms.Guna2Elipse guna2Elipse1;
        private Guna.UI2.WinForms.Guna2DragControl guna2DragControl1;
        private Guna.UI2.WinForms.Guna2Elipse guna2Elipse2;
        private Guna.UI2.WinForms.Guna2Panel paneluploadLabResults;
        private Guna.UI2.WinForms.Guna2Elipse guna2Elipse3;
        private Guna.UI2.WinForms.Guna2Panel panelviewScheduledScans;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private Guna.UI2.WinForms.Guna2DataGridView gridviewScheduledScans;
        private Guna.UI2.WinForms.Guna2Panel guna2Panel1;
        private System.Windows.Forms.Label lbldoubleclickvalue;
        private Guna.UI2.WinForms.Guna2Button btnBrowse;
        private Guna.UI2.WinForms.Guna2TextBox textBoxImagePath;
        private Guna.UI2.WinForms.Guna2PictureBox pictureBoxResultPreview;
        private System.Windows.Forms.Label label4;
        private Guna.UI2.WinForms.Guna2Button btnUploadLabResult;
        private Guna.UI2.WinForms.Guna2TextBox txtboxlabResultDescription;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private Guna.UI2.WinForms.Guna2Panel panelLabSideMenu;
        private Guna.UI2.WinForms.Guna2Button btndocLogoutlab;
        private Guna.UI2.WinForms.Guna2Button btnlabUploadLabResults;
        private Guna.UI2.WinForms.Guna2Button btnlabViewRequestedScans;
        private System.Windows.Forms.Label label1;
        private Guna.UI2.WinForms.Guna2CirclePictureBox guna2CirclePictureBox1;
        private Guna.UI2.WinForms.Guna2Separator guna2Separator1;
    }
}