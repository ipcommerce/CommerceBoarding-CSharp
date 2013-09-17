using System.Windows.Forms;

namespace CommerceBoarding
{
    partial class CommerceBoarding
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CommerceBoarding));
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.Status = new System.Windows.Forms.ToolStripStatusLabel();
            this.Qualification = new System.Windows.Forms.TabPage();
            this.btnSaveCreditReport = new System.Windows.Forms.Button();
            this.qualResultsGrpBox = new System.Windows.Forms.GroupBox();
            this.creditScoreLbl = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.identityResultLbl = new System.Windows.Forms.Label();
            this.qlfyDecisionLbl = new System.Windows.Forms.Label();
            this.appStatusLbl = new System.Windows.Forms.Label();
            this.decisionLbl = new System.Windows.Forms.Label();
            this.identResultLabel = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label43 = new System.Windows.Forms.Label();
            this.applicationResultTxtBox = new System.Windows.Forms.RichTextBox();
            this.btnSaveAppResultDetail = new System.Windows.Forms.Button();
            this.qualResultBtn = new System.Windows.Forms.Button();
            this.qualBtn = new System.Windows.Forms.Button();
            this.appGuidQual = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.lblQualification = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.CreateApp = new System.Windows.Forms.TabPage();
            this.resetApplicationBtn = new System.Windows.Forms.Button();
            this.lblCreateApplication = new System.Windows.Forms.Label();
            this.showValidationErrors = new System.Windows.Forms.Button();
            this.createBtn = new System.Windows.Forms.Button();
            this.defaultValues = new System.Windows.Forms.Button();
            this.appProfileIdLbl = new System.Windows.Forms.Label();
            this.appProfileId = new System.Windows.Forms.TextBox();
            this.InputFields = new System.Windows.Forms.DataGridView();
            this.Key = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Value = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.Authentication = new System.Windows.Forms.TabPage();
            this.SignOn = new System.Windows.Forms.Button();
            this.label15 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.txtIdentityToken = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.IdentityVerification = new System.Windows.Forms.TabPage();
            this.answerQuestions = new System.Windows.Forms.Button();
            this.questionsPanel = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.question3 = new System.Windows.Forms.Label();
            this.q3ans3 = new System.Windows.Forms.RadioButton();
            this.q3ans2 = new System.Windows.Forms.RadioButton();
            this.q3ans1 = new System.Windows.Forms.RadioButton();
            this.label19 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.question2 = new System.Windows.Forms.Label();
            this.q2ans3 = new System.Windows.Forms.RadioButton();
            this.q2ans2 = new System.Windows.Forms.RadioButton();
            this.q2ans1 = new System.Windows.Forms.RadioButton();
            this.label16 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.question1 = new System.Windows.Forms.Label();
            this.q1ans3 = new System.Windows.Forms.RadioButton();
            this.q1ans2 = new System.Windows.Forms.RadioButton();
            this.q1ans1 = new System.Windows.Forms.RadioButton();
            this.getIdentityQuestions = new System.Windows.Forms.Button();
            this.appGuidIdent = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.Administration = new System.Windows.Forms.TabPage();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.saveToLogChkBx = new System.Windows.Forms.CheckBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.searchLastName = new System.Windows.Forms.TextBox();
            this.label21 = new System.Windows.Forms.Label();
            this.label22 = new System.Windows.Forms.Label();
            this.label23 = new System.Windows.Forms.Label();
            this.searchDates = new System.Windows.Forms.CheckBox();
            this.searchDateThrough = new System.Windows.Forms.DateTimePicker();
            this.searchFirstName = new System.Windows.Forms.TextBox();
            this.searchDateFrom = new System.Windows.Forms.DateTimePicker();
            this.searchEmail = new System.Windows.Forms.TextBox();
            this.label27 = new System.Windows.Forms.Label();
            this.searchIdentityStatus = new System.Windows.Forms.ComboBox();
            this.label28 = new System.Windows.Forms.Label();
            this.label26 = new System.Windows.Forms.Label();
            this.label25 = new System.Windows.Forms.Label();
            this.searchQualificationStatus = new System.Windows.Forms.ComboBox();
            this.label24 = new System.Windows.Forms.Label();
            this.searchAppStatus = new System.Windows.Forms.ComboBox();
            this.getAppBtn = new System.Windows.Forms.Button();
            this.label29 = new System.Windows.Forms.Label();
            this.adminAppGuidTxt = new System.Windows.Forms.TextBox();
            this.listApps = new System.Windows.Forms.DataGridView();
            this.ApplicationDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ApplicationGuid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MerchantName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ApplicationStatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ViewDetail = new System.Windows.Forms.DataGridViewButtonColumn();
            this.ViewApplication = new System.Windows.Forms.DataGridViewButtonColumn();
            this.listAppsBtn = new System.Windows.Forms.Button();
            this.label12 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.environmentLbl = new System.Windows.Forms.Label();
            this.sfdSaveToFile = new System.Windows.Forms.SaveFileDialog();
            this.statusStrip1.SuspendLayout();
            this.Qualification.SuspendLayout();
            this.qualResultsGrpBox.SuspendLayout();
            this.CreateApp.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.InputFields)).BeginInit();
            this.Authentication.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.IdentityVerification.SuspendLayout();
            this.questionsPanel.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.Administration.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.listApps)).BeginInit();
            this.SuspendLayout();
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Status});
            this.statusStrip1.Location = new System.Drawing.Point(0, 615);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1063, 22);
            this.statusStrip1.TabIndex = 11;
            // 
            // Status
            // 
            this.Status.Name = "Status";
            this.Status.Size = new System.Drawing.Size(39, 17);
            this.Status.Text = "Ready";
            // 
            // Qualification
            // 
            this.Qualification.Controls.Add(this.btnSaveCreditReport);
            this.Qualification.Controls.Add(this.qualResultsGrpBox);
            this.Qualification.Controls.Add(this.applicationResultTxtBox);
            this.Qualification.Controls.Add(this.btnSaveAppResultDetail);
            this.Qualification.Controls.Add(this.qualResultBtn);
            this.Qualification.Controls.Add(this.qualBtn);
            this.Qualification.Controls.Add(this.appGuidQual);
            this.Qualification.Controls.Add(this.label11);
            this.Qualification.Controls.Add(this.lblQualification);
            this.Qualification.Controls.Add(this.label5);
            this.Qualification.Location = new System.Drawing.Point(4, 22);
            this.Qualification.Name = "Qualification";
            this.Qualification.Size = new System.Drawing.Size(1055, 574);
            this.Qualification.TabIndex = 2;
            this.Qualification.Text = "Qualification";
            this.Qualification.UseVisualStyleBackColor = true;
            // 
            // btnSaveCreditReport
            // 
            this.btnSaveCreditReport.Location = new System.Drawing.Point(310, 184);
            this.btnSaveCreditReport.Name = "btnSaveCreditReport";
            this.btnSaveCreditReport.Size = new System.Drawing.Size(142, 23);
            this.btnSaveCreditReport.TabIndex = 37;
            this.btnSaveCreditReport.Text = "Save Credit Report";
            this.btnSaveCreditReport.UseVisualStyleBackColor = true;
            this.btnSaveCreditReport.Visible = false;
            this.btnSaveCreditReport.Click += new System.EventHandler(this.btnSaveCreditReport_Click);
            // 
            // qualResultsGrpBox
            // 
            this.qualResultsGrpBox.Controls.Add(this.creditScoreLbl);
            this.qualResultsGrpBox.Controls.Add(this.label6);
            this.qualResultsGrpBox.Controls.Add(this.identityResultLbl);
            this.qualResultsGrpBox.Controls.Add(this.qlfyDecisionLbl);
            this.qualResultsGrpBox.Controls.Add(this.appStatusLbl);
            this.qualResultsGrpBox.Controls.Add(this.decisionLbl);
            this.qualResultsGrpBox.Controls.Add(this.identResultLabel);
            this.qualResultsGrpBox.Controls.Add(this.label4);
            this.qualResultsGrpBox.Controls.Add(this.label3);
            this.qualResultsGrpBox.Controls.Add(this.label43);
            this.qualResultsGrpBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.qualResultsGrpBox.Location = new System.Drawing.Point(466, 21);
            this.qualResultsGrpBox.Name = "qualResultsGrpBox";
            this.qualResultsGrpBox.Size = new System.Drawing.Size(581, 186);
            this.qualResultsGrpBox.TabIndex = 36;
            this.qualResultsGrpBox.TabStop = false;
            this.qualResultsGrpBox.Text = "Qualification Results:";
            // 
            // creditScoreLbl
            // 
            this.creditScoreLbl.AutoSize = true;
            this.creditScoreLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.creditScoreLbl.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.creditScoreLbl.Location = new System.Drawing.Point(159, 127);
            this.creditScoreLbl.Name = "creditScoreLbl";
            this.creditScoreLbl.Size = new System.Drawing.Size(0, 17);
            this.creditScoreLbl.TabIndex = 42;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(6, 125);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(108, 18);
            this.label6.TabIndex = 41;
            this.label6.Text = "Credit Score:";
            // 
            // identityResultLbl
            // 
            this.identityResultLbl.AutoSize = true;
            this.identityResultLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.identityResultLbl.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.identityResultLbl.Location = new System.Drawing.Point(159, 154);
            this.identityResultLbl.Name = "identityResultLbl";
            this.identityResultLbl.Size = new System.Drawing.Size(0, 17);
            this.identityResultLbl.TabIndex = 40;
            // 
            // qlfyDecisionLbl
            // 
            this.qlfyDecisionLbl.AutoSize = true;
            this.qlfyDecisionLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.qlfyDecisionLbl.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.qlfyDecisionLbl.Location = new System.Drawing.Point(159, 100);
            this.qlfyDecisionLbl.Name = "qlfyDecisionLbl";
            this.qlfyDecisionLbl.Size = new System.Drawing.Size(0, 17);
            this.qlfyDecisionLbl.TabIndex = 39;
            // 
            // appStatusLbl
            // 
            this.appStatusLbl.AutoSize = true;
            this.appStatusLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.appStatusLbl.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.appStatusLbl.Location = new System.Drawing.Point(159, 68);
            this.appStatusLbl.Name = "appStatusLbl";
            this.appStatusLbl.Size = new System.Drawing.Size(0, 17);
            this.appStatusLbl.TabIndex = 38;
            // 
            // decisionLbl
            // 
            this.decisionLbl.AutoSize = true;
            this.decisionLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.decisionLbl.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.decisionLbl.Location = new System.Drawing.Point(159, 37);
            this.decisionLbl.Name = "decisionLbl";
            this.decisionLbl.Size = new System.Drawing.Size(0, 17);
            this.decisionLbl.TabIndex = 37;
            // 
            // identResultLabel
            // 
            this.identResultLabel.AutoSize = true;
            this.identResultLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.identResultLabel.Location = new System.Drawing.Point(6, 152);
            this.identResultLabel.Name = "identResultLabel";
            this.identResultLabel.Size = new System.Drawing.Size(119, 18);
            this.identResultLabel.TabIndex = 36;
            this.identResultLabel.Text = "Identity Result:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(6, 97);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(141, 18);
            this.label4.TabIndex = 35;
            this.label4.Text = "Qualify Decision: ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(6, 68);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(144, 17);
            this.label3.TabIndex = 34;
            this.label3.Text = "Application Status:";
            // 
            // label43
            // 
            this.label43.AutoSize = true;
            this.label43.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label43.Location = new System.Drawing.Point(6, 37);
            this.label43.Name = "label43";
            this.label43.Size = new System.Drawing.Size(80, 17);
            this.label43.TabIndex = 33;
            this.label43.Text = "Decision: ";
            // 
            // applicationResultTxtBox
            // 
            this.applicationResultTxtBox.Location = new System.Drawing.Point(8, 213);
            this.applicationResultTxtBox.Name = "applicationResultTxtBox";
            this.applicationResultTxtBox.Size = new System.Drawing.Size(1039, 370);
            this.applicationResultTxtBox.TabIndex = 31;
            this.applicationResultTxtBox.Text = "";
            // 
            // btnSaveAppResultDetail
            // 
            this.btnSaveAppResultDetail.Location = new System.Drawing.Point(155, 184);
            this.btnSaveAppResultDetail.Name = "btnSaveAppResultDetail";
            this.btnSaveAppResultDetail.Size = new System.Drawing.Size(149, 23);
            this.btnSaveAppResultDetail.TabIndex = 29;
            this.btnSaveAppResultDetail.Text = "Save Application To Disk";
            this.btnSaveAppResultDetail.UseVisualStyleBackColor = true;
            this.btnSaveAppResultDetail.Visible = false;
            this.btnSaveAppResultDetail.Click += new System.EventHandler(this.btnSaveAppResultDetail_Click);
            // 
            // qualResultBtn
            // 
            this.qualResultBtn.Location = new System.Drawing.Point(8, 184);
            this.qualResultBtn.Name = "qualResultBtn";
            this.qualResultBtn.Size = new System.Drawing.Size(140, 23);
            this.qualResultBtn.TabIndex = 27;
            this.qualResultBtn.Text = "View Qualification Result";
            this.qualResultBtn.UseVisualStyleBackColor = true;
            this.qualResultBtn.Visible = false;
            this.qualResultBtn.Click += new System.EventHandler(this.qualResultBtn_Click);
            // 
            // qualBtn
            // 
            this.qualBtn.Location = new System.Drawing.Point(7, 155);
            this.qualBtn.Name = "qualBtn";
            this.qualBtn.Size = new System.Drawing.Size(140, 23);
            this.qualBtn.TabIndex = 26;
            this.qualBtn.Text = "Begin Qualification";
            this.qualBtn.UseVisualStyleBackColor = true;
            this.qualBtn.Click += new System.EventHandler(this.qualBtn_Click);
            // 
            // appGuidQual
            // 
            this.appGuidQual.Location = new System.Drawing.Point(99, 123);
            this.appGuidQual.Name = "appGuidQual";
            this.appGuidQual.ReadOnly = true;
            this.appGuidQual.Size = new System.Drawing.Size(223, 20);
            this.appGuidQual.TabIndex = 25;
            this.appGuidQual.UseWaitCursor = true;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(5, 123);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(76, 13);
            this.label11.TabIndex = 24;
            this.label11.Text = "Application ID:";
            // 
            // lblQualification
            // 
            this.lblQualification.Location = new System.Drawing.Point(4, 48);
            this.lblQualification.Name = "lblQualification";
            this.lblQualification.Size = new System.Drawing.Size(463, 73);
            this.lblQualification.TabIndex = 19;
            this.lblQualification.Text = resources.GetString("lblQualification.Text");
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.CadetBlue;
            this.label5.Location = new System.Drawing.Point(3, 17);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(96, 20);
            this.label5.TabIndex = 11;
            this.label5.Text = "Qualification";
            // 
            // CreateApp
            // 
            this.CreateApp.Controls.Add(this.resetApplicationBtn);
            this.CreateApp.Controls.Add(this.lblCreateApplication);
            this.CreateApp.Controls.Add(this.showValidationErrors);
            this.CreateApp.Controls.Add(this.createBtn);
            this.CreateApp.Controls.Add(this.defaultValues);
            this.CreateApp.Controls.Add(this.appProfileIdLbl);
            this.CreateApp.Controls.Add(this.appProfileId);
            this.CreateApp.Controls.Add(this.InputFields);
            this.CreateApp.Controls.Add(this.label1);
            this.CreateApp.Controls.Add(this.label2);
            this.CreateApp.Location = new System.Drawing.Point(4, 22);
            this.CreateApp.Name = "CreateApp";
            this.CreateApp.Padding = new System.Windows.Forms.Padding(3);
            this.CreateApp.Size = new System.Drawing.Size(1055, 574);
            this.CreateApp.TabIndex = 1;
            this.CreateApp.Text = "Create Application";
            this.CreateApp.UseVisualStyleBackColor = true;
            // 
            // resetApplicationBtn
            // 
            this.resetApplicationBtn.Location = new System.Drawing.Point(848, 160);
            this.resetApplicationBtn.Name = "resetApplicationBtn";
            this.resetApplicationBtn.Size = new System.Drawing.Size(167, 23);
            this.resetApplicationBtn.TabIndex = 19;
            this.resetApplicationBtn.Text = "Clear Application Values";
            this.resetApplicationBtn.UseVisualStyleBackColor = true;
            this.resetApplicationBtn.Click += new System.EventHandler(this.resetApplicationBtn_Click);
            // 
            // lblCreateApplication
            // 
            this.lblCreateApplication.Location = new System.Drawing.Point(9, 45);
            this.lblCreateApplication.Name = "lblCreateApplication";
            this.lblCreateApplication.Size = new System.Drawing.Size(814, 73);
            this.lblCreateApplication.TabIndex = 18;
            this.lblCreateApplication.Text = resources.GetString("lblCreateApplication.Text");
            // 
            // showValidationErrors
            // 
            this.showValidationErrors.Location = new System.Drawing.Point(129, 557);
            this.showValidationErrors.Name = "showValidationErrors";
            this.showValidationErrors.Size = new System.Drawing.Size(130, 23);
            this.showValidationErrors.TabIndex = 17;
            this.showValidationErrors.Text = "Show Validation Errors";
            this.showValidationErrors.UseVisualStyleBackColor = true;
            this.showValidationErrors.Visible = false;
            this.showValidationErrors.Click += new System.EventHandler(this.showValidationErrors_Click);
            // 
            // createBtn
            // 
            this.createBtn.Location = new System.Drawing.Point(6, 557);
            this.createBtn.Name = "createBtn";
            this.createBtn.Size = new System.Drawing.Size(117, 23);
            this.createBtn.TabIndex = 16;
            this.createBtn.Text = "Create Applicaton";
            this.createBtn.UseVisualStyleBackColor = true;
            this.createBtn.Click += new System.EventHandler(this.createBtn_Click);
            // 
            // defaultValues
            // 
            this.defaultValues.Location = new System.Drawing.Point(675, 160);
            this.defaultValues.Name = "defaultValues";
            this.defaultValues.Size = new System.Drawing.Size(167, 23);
            this.defaultValues.TabIndex = 15;
            this.defaultValues.Text = "Set Sample Values";
            this.defaultValues.UseVisualStyleBackColor = true;
            this.defaultValues.Click += new System.EventHandler(this.defaultValues_Click);
            // 
            // appProfileIdLbl
            // 
            this.appProfileIdLbl.Location = new System.Drawing.Point(12, 128);
            this.appProfileIdLbl.Name = "appProfileIdLbl";
            this.appProfileIdLbl.Size = new System.Drawing.Size(113, 17);
            this.appProfileIdLbl.TabIndex = 14;
            this.appProfileIdLbl.Text = "Application Profile Id:";
            // 
            // appProfileId
            // 
            this.appProfileId.Location = new System.Drawing.Point(126, 125);
            this.appProfileId.Name = "appProfileId";
            this.appProfileId.Size = new System.Drawing.Size(212, 20);
            this.appProfileId.TabIndex = 13;
            // 
            // InputFields
            // 
            this.InputFields.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.InputFields.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.InputFields.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.InputFields.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Key,
            this.Value});
            this.InputFields.Location = new System.Drawing.Point(10, 189);
            this.InputFields.Name = "InputFields";
            this.InputFields.Size = new System.Drawing.Size(1005, 362);
            this.InputFields.TabIndex = 12;
            // 
            // Key
            // 
            this.Key.HeaderText = "Key";
            this.Key.Name = "Key";
            this.Key.ReadOnly = true;
            // 
            // Value
            // 
            this.Value.HeaderText = "Value";
            this.Value.Name = "Value";
            // 
            // label1
            // 
            this.label1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label1.Location = new System.Drawing.Point(12, 165);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(349, 23);
            this.label1.TabIndex = 11;
            this.label1.Text = "Enter the application data in the table below and click \'Create\'.  \r\n";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.CadetBlue;
            this.label2.Location = new System.Drawing.Point(6, 18);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(139, 20);
            this.label2.TabIndex = 10;
            this.label2.Text = "Create Application";
            // 
            // Authentication
            // 
            this.Authentication.Controls.Add(this.SignOn);
            this.Authentication.Controls.Add(this.label15);
            this.Authentication.Controls.Add(this.label14);
            this.Authentication.Controls.Add(this.txtIdentityToken);
            this.Authentication.Controls.Add(this.label13);
            this.Authentication.Controls.Add(this.label17);
            this.Authentication.Location = new System.Drawing.Point(4, 22);
            this.Authentication.Name = "Authentication";
            this.Authentication.Padding = new System.Windows.Forms.Padding(3);
            this.Authentication.Size = new System.Drawing.Size(1055, 574);
            this.Authentication.TabIndex = 0;
            this.Authentication.Text = "Authentication";
            // 
            // SignOn
            // 
            this.SignOn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.SignOn.Location = new System.Drawing.Point(14, 542);
            this.SignOn.Name = "SignOn";
            this.SignOn.Size = new System.Drawing.Size(75, 23);
            this.SignOn.TabIndex = 13;
            this.SignOn.Text = "Sign On";
            this.SignOn.UseVisualStyleBackColor = true;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(9, 71);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(490, 13);
            this.label15.TabIndex = 12;
            this.label15.Text = "Either copy your Identity Token into the text box, or place it in the app.config," +
                " and then click \'Sign On\'. ";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(11, 105);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(75, 13);
            this.label14.TabIndex = 11;
            this.label14.Text = "Identity Token";
            // 
            // txtIdentityToken
            // 
            this.txtIdentityToken.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtIdentityToken.Location = new System.Drawing.Point(12, 124);
            this.txtIdentityToken.Multiline = true;
            this.txtIdentityToken.Name = "txtIdentityToken";
            this.txtIdentityToken.Size = new System.Drawing.Size(1035, 412);
            this.txtIdentityToken.TabIndex = 10;
            // 
            // label13
            // 
            this.label13.Location = new System.Drawing.Point(7, 45);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(627, 46);
            this.label13.TabIndex = 9;
            this.label13.Text = "Before calling the Commerce Boarding API, you must authenticate and obtain a sess" +
                "ion token. ";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label17.ForeColor = System.Drawing.Color.CadetBlue;
            this.label17.Location = new System.Drawing.Point(6, 18);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(112, 20);
            this.label17.TabIndex = 8;
            this.label17.Text = "Authentication";
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.Authentication);
            this.tabControl1.Controls.Add(this.CreateApp);
            this.tabControl1.Controls.Add(this.IdentityVerification);
            this.tabControl1.Controls.Add(this.Qualification);
            this.tabControl1.Controls.Add(this.Administration);
            this.tabControl1.Location = new System.Drawing.Point(0, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1063, 600);
            this.tabControl1.TabIndex = 0;
            // 
            // IdentityVerification
            // 
            this.IdentityVerification.Controls.Add(this.answerQuestions);
            this.IdentityVerification.Controls.Add(this.questionsPanel);
            this.IdentityVerification.Controls.Add(this.getIdentityQuestions);
            this.IdentityVerification.Controls.Add(this.appGuidIdent);
            this.IdentityVerification.Controls.Add(this.label9);
            this.IdentityVerification.Controls.Add(this.label7);
            this.IdentityVerification.Controls.Add(this.label8);
            this.IdentityVerification.Location = new System.Drawing.Point(4, 22);
            this.IdentityVerification.Name = "IdentityVerification";
            this.IdentityVerification.Size = new System.Drawing.Size(1055, 574);
            this.IdentityVerification.TabIndex = 4;
            this.IdentityVerification.Text = "Identity Verification";
            this.IdentityVerification.UseVisualStyleBackColor = true;
            // 
            // answerQuestions
            // 
            this.answerQuestions.Enabled = false;
            this.answerQuestions.Location = new System.Drawing.Point(599, 462);
            this.answerQuestions.Name = "answerQuestions";
            this.answerQuestions.Size = new System.Drawing.Size(121, 23);
            this.answerQuestions.TabIndex = 37;
            this.answerQuestions.Text = "Submit Answers";
            this.answerQuestions.UseVisualStyleBackColor = true;
            this.answerQuestions.Click += new System.EventHandler(this.answerQuestions_Click);
            // 
            // questionsPanel
            // 
            this.questionsPanel.Controls.Add(this.panel3);
            this.questionsPanel.Controls.Add(this.label19);
            this.questionsPanel.Controls.Add(this.panel2);
            this.questionsPanel.Controls.Add(this.label16);
            this.questionsPanel.Controls.Add(this.label10);
            this.questionsPanel.Controls.Add(this.panel1);
            this.questionsPanel.Location = new System.Drawing.Point(13, 146);
            this.questionsPanel.Name = "questionsPanel";
            this.questionsPanel.Size = new System.Drawing.Size(511, 353);
            this.questionsPanel.TabIndex = 36;
            this.questionsPanel.Visible = false;
            // 
            // panel3
            // 
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.question3);
            this.panel3.Controls.Add(this.q3ans3);
            this.panel3.Controls.Add(this.q3ans2);
            this.panel3.Controls.Add(this.q3ans1);
            this.panel3.Location = new System.Drawing.Point(10, 251);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(446, 88);
            this.panel3.TabIndex = 34;
            // 
            // question3
            // 
            this.question3.Location = new System.Drawing.Point(3, 12);
            this.question3.Name = "question3";
            this.question3.Size = new System.Drawing.Size(207, 65);
            this.question3.TabIndex = 33;
            this.question3.Text = "<question 3>";
            // 
            // q3ans3
            // 
            this.q3ans3.AutoSize = true;
            this.q3ans3.Location = new System.Drawing.Point(229, 60);
            this.q3ans3.Name = "q3ans3";
            this.q3ans3.Size = new System.Drawing.Size(85, 17);
            this.q3ans3.TabIndex = 32;
            this.q3ans3.TabStop = true;
            this.q3ans3.Text = "radioButton3";
            this.q3ans3.UseVisualStyleBackColor = true;
            // 
            // q3ans2
            // 
            this.q3ans2.AutoSize = true;
            this.q3ans2.Location = new System.Drawing.Point(229, 36);
            this.q3ans2.Name = "q3ans2";
            this.q3ans2.Size = new System.Drawing.Size(85, 17);
            this.q3ans2.TabIndex = 31;
            this.q3ans2.TabStop = true;
            this.q3ans2.Text = "radioButton2";
            this.q3ans2.UseVisualStyleBackColor = true;
            // 
            // q3ans1
            // 
            this.q3ans1.AutoSize = true;
            this.q3ans1.Location = new System.Drawing.Point(229, 12);
            this.q3ans1.Name = "q3ans1";
            this.q3ans1.Size = new System.Drawing.Size(85, 17);
            this.q3ans1.TabIndex = 30;
            this.q3ans1.TabStop = true;
            this.q3ans1.Text = "radioButton1";
            this.q3ans1.UseVisualStyleBackColor = true;
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(13, 236);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(65, 13);
            this.label19.TabIndex = 35;
            this.label19.Text = "Question #3";
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.question2);
            this.panel2.Controls.Add(this.q2ans3);
            this.panel2.Controls.Add(this.q2ans2);
            this.panel2.Controls.Add(this.q2ans1);
            this.panel2.Location = new System.Drawing.Point(10, 140);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(446, 88);
            this.panel2.TabIndex = 34;
            // 
            // question2
            // 
            this.question2.Location = new System.Drawing.Point(3, 11);
            this.question2.Name = "question2";
            this.question2.Size = new System.Drawing.Size(207, 65);
            this.question2.TabIndex = 33;
            this.question2.Text = "<question 2>";
            // 
            // q2ans3
            // 
            this.q2ans3.AutoSize = true;
            this.q2ans3.Location = new System.Drawing.Point(229, 60);
            this.q2ans3.Name = "q2ans3";
            this.q2ans3.Size = new System.Drawing.Size(85, 17);
            this.q2ans3.TabIndex = 32;
            this.q2ans3.TabStop = true;
            this.q2ans3.Text = "radioButton3";
            this.q2ans3.UseVisualStyleBackColor = true;
            // 
            // q2ans2
            // 
            this.q2ans2.AutoSize = true;
            this.q2ans2.Location = new System.Drawing.Point(229, 36);
            this.q2ans2.Name = "q2ans2";
            this.q2ans2.Size = new System.Drawing.Size(85, 17);
            this.q2ans2.TabIndex = 31;
            this.q2ans2.TabStop = true;
            this.q2ans2.Text = "radioButton2";
            this.q2ans2.UseVisualStyleBackColor = true;
            // 
            // q2ans1
            // 
            this.q2ans1.AutoSize = true;
            this.q2ans1.Location = new System.Drawing.Point(229, 12);
            this.q2ans1.Name = "q2ans1";
            this.q2ans1.Size = new System.Drawing.Size(85, 17);
            this.q2ans1.TabIndex = 30;
            this.q2ans1.TabStop = true;
            this.q2ans1.Text = "radioButton1";
            this.q2ans1.UseVisualStyleBackColor = true;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(11, 124);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(65, 13);
            this.label16.TabIndex = 35;
            this.label16.Text = "Question #2";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(11, 11);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(65, 13);
            this.label10.TabIndex = 31;
            this.label10.Text = "Question #1";
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.question1);
            this.panel1.Controls.Add(this.q1ans3);
            this.panel1.Controls.Add(this.q1ans2);
            this.panel1.Controls.Add(this.q1ans1);
            this.panel1.Location = new System.Drawing.Point(10, 27);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(446, 88);
            this.panel1.TabIndex = 30;
            // 
            // question1
            // 
            this.question1.Location = new System.Drawing.Point(3, 12);
            this.question1.Name = "question1";
            this.question1.Size = new System.Drawing.Size(207, 65);
            this.question1.TabIndex = 33;
            this.question1.Text = "<question 1>";
            // 
            // q1ans3
            // 
            this.q1ans3.AutoSize = true;
            this.q1ans3.Location = new System.Drawing.Point(229, 60);
            this.q1ans3.Name = "q1ans3";
            this.q1ans3.Size = new System.Drawing.Size(85, 17);
            this.q1ans3.TabIndex = 32;
            this.q1ans3.TabStop = true;
            this.q1ans3.Text = "radioButton3";
            this.q1ans3.UseVisualStyleBackColor = true;
            // 
            // q1ans2
            // 
            this.q1ans2.AutoSize = true;
            this.q1ans2.Location = new System.Drawing.Point(229, 36);
            this.q1ans2.Name = "q1ans2";
            this.q1ans2.Size = new System.Drawing.Size(85, 17);
            this.q1ans2.TabIndex = 31;
            this.q1ans2.TabStop = true;
            this.q1ans2.Text = "radioButton2";
            this.q1ans2.UseVisualStyleBackColor = true;
            // 
            // q1ans1
            // 
            this.q1ans1.AutoSize = true;
            this.q1ans1.Location = new System.Drawing.Point(229, 12);
            this.q1ans1.Name = "q1ans1";
            this.q1ans1.Size = new System.Drawing.Size(85, 17);
            this.q1ans1.TabIndex = 30;
            this.q1ans1.TabStop = true;
            this.q1ans1.Text = "radioButton1";
            this.q1ans1.UseVisualStyleBackColor = true;
            // 
            // getIdentityQuestions
            // 
            this.getIdentityQuestions.Location = new System.Drawing.Point(11, 119);
            this.getIdentityQuestions.Name = "getIdentityQuestions";
            this.getIdentityQuestions.Size = new System.Drawing.Size(121, 23);
            this.getIdentityQuestions.TabIndex = 23;
            this.getIdentityQuestions.Text = "Get Identity Questions";
            this.getIdentityQuestions.UseVisualStyleBackColor = true;
            this.getIdentityQuestions.Click += new System.EventHandler(this.getIdentityQuestions_Click);
            // 
            // appGuidIdent
            // 
            this.appGuidIdent.Location = new System.Drawing.Point(103, 87);
            this.appGuidIdent.Name = "appGuidIdent";
            this.appGuidIdent.ReadOnly = true;
            this.appGuidIdent.Size = new System.Drawing.Size(223, 20);
            this.appGuidIdent.TabIndex = 22;
            this.appGuidIdent.UseWaitCursor = true;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(9, 87);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(76, 13);
            this.label9.TabIndex = 21;
            this.label9.Text = "Application ID:";
            // 
            // label7
            // 
            this.label7.Location = new System.Drawing.Point(6, 40);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(814, 37);
            this.label7.TabIndex = 20;
            this.label7.Text = resources.GetString("label7.Text");
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.CadetBlue;
            this.label8.Location = new System.Drawing.Point(3, 13);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(144, 20);
            this.label8.TabIndex = 19;
            this.label8.Text = "Identity Verification";
            // 
            // Administration
            // 
            this.Administration.Controls.Add(this.checkBox1);
            this.Administration.Controls.Add(this.saveToLogChkBx);
            this.Administration.Controls.Add(this.groupBox1);
            this.Administration.Controls.Add(this.getAppBtn);
            this.Administration.Controls.Add(this.label29);
            this.Administration.Controls.Add(this.adminAppGuidTxt);
            this.Administration.Controls.Add(this.listApps);
            this.Administration.Controls.Add(this.listAppsBtn);
            this.Administration.Controls.Add(this.label12);
            this.Administration.Controls.Add(this.label18);
            this.Administration.Location = new System.Drawing.Point(4, 22);
            this.Administration.Name = "Administration";
            this.Administration.Size = new System.Drawing.Size(1055, 574);
            this.Administration.TabIndex = 3;
            this.Administration.Text = "Administration";
            this.Administration.UseVisualStyleBackColor = true;
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(390, 175);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(100, 17);
            this.checkBox1.TabIndex = 47;
            this.checkBox1.Text = "Display Log File";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // saveToLogChkBx
            // 
            this.saveToLogChkBx.AutoSize = true;
            this.saveToLogChkBx.Location = new System.Drawing.Point(281, 176);
            this.saveToLogChkBx.Name = "saveToLogChkBx";
            this.saveToLogChkBx.Size = new System.Drawing.Size(103, 17);
            this.saveToLogChkBx.TabIndex = 46;
            this.saveToLogChkBx.Text = "Save Log to File";
            this.saveToLogChkBx.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.searchLastName);
            this.groupBox1.Controls.Add(this.label21);
            this.groupBox1.Controls.Add(this.label22);
            this.groupBox1.Controls.Add(this.label23);
            this.groupBox1.Controls.Add(this.searchDates);
            this.groupBox1.Controls.Add(this.searchDateThrough);
            this.groupBox1.Controls.Add(this.searchFirstName);
            this.groupBox1.Controls.Add(this.searchDateFrom);
            this.groupBox1.Controls.Add(this.searchEmail);
            this.groupBox1.Controls.Add(this.label27);
            this.groupBox1.Controls.Add(this.searchIdentityStatus);
            this.groupBox1.Controls.Add(this.label28);
            this.groupBox1.Controls.Add(this.label26);
            this.groupBox1.Controls.Add(this.label25);
            this.groupBox1.Controls.Add(this.searchQualificationStatus);
            this.groupBox1.Controls.Add(this.label24);
            this.groupBox1.Controls.Add(this.searchAppStatus);
            this.groupBox1.Location = new System.Drawing.Point(64, 66);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(788, 100);
            this.groupBox1.TabIndex = 45;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Enter one or more search parameters and click \'List Applications\'";
            // 
            // searchLastName
            // 
            this.searchLastName.Location = new System.Drawing.Point(76, 45);
            this.searchLastName.Name = "searchLastName";
            this.searchLastName.Size = new System.Drawing.Size(174, 20);
            this.searchLastName.TabIndex = 29;
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(9, 48);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(61, 13);
            this.label21.TabIndex = 25;
            this.label21.Text = "Last Name:";
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Location = new System.Drawing.Point(10, 69);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(35, 13);
            this.label22.TabIndex = 26;
            this.label22.Text = "Email:";
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Location = new System.Drawing.Point(9, 27);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(60, 13);
            this.label23.TabIndex = 27;
            this.label23.Text = "First Name:";
            // 
            // searchDates
            // 
            this.searchDates.AutoSize = true;
            this.searchDates.Location = new System.Drawing.Point(515, 64);
            this.searchDates.Name = "searchDates";
            this.searchDates.Size = new System.Drawing.Size(121, 17);
            this.searchDates.TabIndex = 41;
            this.searchDates.Text = "Search Date Range";
            this.searchDates.UseVisualStyleBackColor = true;
            // 
            // searchDateThrough
            // 
            this.searchDateThrough.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.searchDateThrough.Location = new System.Drawing.Point(644, 46);
            this.searchDateThrough.Name = "searchDateThrough";
            this.searchDateThrough.Size = new System.Drawing.Size(99, 20);
            this.searchDateThrough.TabIndex = 40;
            // 
            // searchFirstName
            // 
            this.searchFirstName.Location = new System.Drawing.Point(76, 24);
            this.searchFirstName.Name = "searchFirstName";
            this.searchFirstName.Size = new System.Drawing.Size(174, 20);
            this.searchFirstName.TabIndex = 28;
            // 
            // searchDateFrom
            // 
            this.searchDateFrom.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.searchDateFrom.Location = new System.Drawing.Point(644, 25);
            this.searchDateFrom.Name = "searchDateFrom";
            this.searchDateFrom.Size = new System.Drawing.Size(99, 20);
            this.searchDateFrom.TabIndex = 39;
            // 
            // searchEmail
            // 
            this.searchEmail.Location = new System.Drawing.Point(76, 65);
            this.searchEmail.Name = "searchEmail";
            this.searchEmail.Size = new System.Drawing.Size(174, 20);
            this.searchEmail.TabIndex = 30;
            // 
            // label27
            // 
            this.label27.AutoSize = true;
            this.label27.Location = new System.Drawing.Point(512, 28);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(96, 13);
            this.label27.TabIndex = 38;
            this.label27.Text = "Search From Date:";
            // 
            // searchIdentityStatus
            // 
            this.searchIdentityStatus.FormattingEnabled = true;
            this.searchIdentityStatus.Items.AddRange(new object[] {
            "--",
            "Pass",
            "Fail",
            "NotStarted",
            "QuestionsProvided"});
            this.searchIdentityStatus.Location = new System.Drawing.Point(369, 42);
            this.searchIdentityStatus.Name = "searchIdentityStatus";
            this.searchIdentityStatus.Size = new System.Drawing.Size(121, 21);
            this.searchIdentityStatus.TabIndex = 35;
            // 
            // label28
            // 
            this.label28.AutoSize = true;
            this.label28.Location = new System.Drawing.Point(512, 46);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(113, 13);
            this.label28.TabIndex = 37;
            this.label28.Text = "Search Through Date:";
            // 
            // label26
            // 
            this.label26.AutoSize = true;
            this.label26.Location = new System.Drawing.Point(260, 47);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(77, 13);
            this.label26.TabIndex = 31;
            this.label26.Text = "Identity Status:";
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.Location = new System.Drawing.Point(261, 69);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(101, 13);
            this.label25.TabIndex = 32;
            this.label25.Text = "Qualification Status:";
            // 
            // searchQualificationStatus
            // 
            this.searchQualificationStatus.FormattingEnabled = true;
            this.searchQualificationStatus.Items.AddRange(new object[] {
            "--",
            "Approved",
            "Declined",
            "NotStarted",
            "Pended"});
            this.searchQualificationStatus.Location = new System.Drawing.Point(369, 64);
            this.searchQualificationStatus.Name = "searchQualificationStatus";
            this.searchQualificationStatus.Size = new System.Drawing.Size(121, 21);
            this.searchQualificationStatus.TabIndex = 36;
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Location = new System.Drawing.Point(259, 25);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(95, 13);
            this.label24.TabIndex = 33;
            this.label24.Text = "Application Status:";
            // 
            // searchAppStatus
            // 
            this.searchAppStatus.FormattingEnabled = true;
            this.searchAppStatus.Items.AddRange(new object[] {
            "--",
            "Saved",
            "InQualification",
            "QualificationComplete"});
            this.searchAppStatus.Location = new System.Drawing.Point(369, 23);
            this.searchAppStatus.Name = "searchAppStatus";
            this.searchAppStatus.Size = new System.Drawing.Size(121, 21);
            this.searchAppStatus.TabIndex = 34;
            // 
            // getAppBtn
            // 
            this.getAppBtn.Location = new System.Drawing.Point(856, 174);
            this.getAppBtn.Name = "getAppBtn";
            this.getAppBtn.Size = new System.Drawing.Size(122, 23);
            this.getAppBtn.TabIndex = 44;
            this.getAppBtn.Text = "Get Application";
            this.getAppBtn.UseVisualStyleBackColor = true;
            this.getAppBtn.Click += new System.EventHandler(this.getAppBtn_Click);
            // 
            // label29
            // 
            this.label29.AutoSize = true;
            this.label29.Location = new System.Drawing.Point(505, 179);
            this.label29.Name = "label29";
            this.label29.Size = new System.Drawing.Size(95, 13);
            this.label29.TabIndex = 43;
            this.label29.Text = "Application GUID: ";
            // 
            // adminAppGuidTxt
            // 
            this.adminAppGuidTxt.Location = new System.Drawing.Point(601, 176);
            this.adminAppGuidTxt.Name = "adminAppGuidTxt";
            this.adminAppGuidTxt.Size = new System.Drawing.Size(249, 20);
            this.adminAppGuidTxt.TabIndex = 42;
            // 
            // listApps
            // 
            this.listApps.AllowUserToAddRows = false;
            this.listApps.AllowUserToDeleteRows = false;
            this.listApps.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.listApps.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.listApps.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ApplicationDate,
            this.ApplicationGuid,
            this.MerchantName,
            this.ApplicationStatus,
            this.ViewDetail,
            this.ViewApplication});
            this.listApps.Location = new System.Drawing.Point(5, 203);
            this.listApps.Name = "listApps";
            this.listApps.ReadOnly = true;
            this.listApps.Size = new System.Drawing.Size(1047, 380);
            this.listApps.TabIndex = 23;
            this.listApps.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.listApps_CellClick);
            // 
            // ApplicationDate
            // 
            this.ApplicationDate.HeaderText = "Date in UTC";
            this.ApplicationDate.Name = "ApplicationDate";
            this.ApplicationDate.ReadOnly = true;
            this.ApplicationDate.Width = 84;
            // 
            // ApplicationGuid
            // 
            this.ApplicationGuid.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ApplicationGuid.HeaderText = "Application ID";
            this.ApplicationGuid.Name = "ApplicationGuid";
            this.ApplicationGuid.ReadOnly = true;
            // 
            // MerchantName
            // 
            this.MerchantName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.MerchantName.HeaderText = "Merchant Name";
            this.MerchantName.Name = "MerchantName";
            this.MerchantName.ReadOnly = true;
            // 
            // ApplicationStatus
            // 
            this.ApplicationStatus.HeaderText = "Application Status";
            this.ApplicationStatus.Name = "ApplicationStatus";
            this.ApplicationStatus.ReadOnly = true;
            this.ApplicationStatus.Width = 107;
            // 
            // ViewDetail
            // 
            this.ViewDetail.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ViewDetail.HeaderText = "View Application Results";
            this.ViewDetail.Name = "ViewDetail";
            this.ViewDetail.ReadOnly = true;
            // 
            // ViewApplication
            // 
            this.ViewApplication.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ViewApplication.HeaderText = "View Application Inputs";
            this.ViewApplication.Name = "ViewApplication";
            this.ViewApplication.ReadOnly = true;
            this.ViewApplication.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.ViewApplication.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // listAppsBtn
            // 
            this.listAppsBtn.Location = new System.Drawing.Point(64, 172);
            this.listAppsBtn.Name = "listAppsBtn";
            this.listAppsBtn.Size = new System.Drawing.Size(211, 23);
            this.listAppsBtn.TabIndex = 22;
            this.listAppsBtn.Text = "List Applications";
            this.listAppsBtn.UseVisualStyleBackColor = true;
            this.listAppsBtn.Click += new System.EventHandler(this.listAppsBtn_Click);
            // 
            // label12
            // 
            this.label12.Location = new System.Drawing.Point(4, 36);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(814, 33);
            this.label12.TabIndex = 21;
            this.label12.Text = "For administrative and trouble-shooting purposes, the Commerce Boarding API offer" +
                "s several methods to view additional details on the applications you have create" +
                "d.\r\n";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label18.ForeColor = System.Drawing.Color.CadetBlue;
            this.label18.Location = new System.Drawing.Point(3, 16);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(110, 20);
            this.label18.TabIndex = 20;
            this.label18.Text = "Administration";
            // 
            // environmentLbl
            // 
            this.environmentLbl.AutoSize = true;
            this.environmentLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.environmentLbl.ForeColor = System.Drawing.Color.DodgerBlue;
            this.environmentLbl.Location = new System.Drawing.Point(756, 2);
            this.environmentLbl.Name = "environmentLbl";
            this.environmentLbl.Size = new System.Drawing.Size(0, 29);
            this.environmentLbl.TabIndex = 32;
            this.environmentLbl.UseMnemonic = false;
            // 
            // CommerceBoarding
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1063, 637);
            this.Controls.Add(this.environmentLbl);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.tabControl1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "CommerceBoarding";
            this.Text = "Commerce Boarding ";
            this.Load += new System.EventHandler(this.Form_Load);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.Qualification.ResumeLayout(false);
            this.Qualification.PerformLayout();
            this.qualResultsGrpBox.ResumeLayout(false);
            this.qualResultsGrpBox.PerformLayout();
            this.CreateApp.ResumeLayout(false);
            this.CreateApp.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.InputFields)).EndInit();
            this.Authentication.ResumeLayout(false);
            this.Authentication.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.IdentityVerification.ResumeLayout(false);
            this.IdentityVerification.PerformLayout();
            this.questionsPanel.ResumeLayout(false);
            this.questionsPanel.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.Administration.ResumeLayout(false);
            this.Administration.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.listApps)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        
        #endregion

        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel Status;
        private System.Windows.Forms.TabPage Qualification;
        private System.Windows.Forms.TabPage CreateApp;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TabPage Authentication;
        private System.Windows.Forms.Button SignOn;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label14;
        public System.Windows.Forms.TextBox txtIdentityToken;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.Label appProfileIdLbl;
        private System.Windows.Forms.TextBox appProfileId;
        private System.Windows.Forms.DataGridView InputFields;
        private System.Windows.Forms.DataGridViewTextBoxColumn Key;
        private System.Windows.Forms.DataGridViewTextBoxColumn Value;
        private System.Windows.Forms.Button defaultValues;
        private System.Windows.Forms.Button createBtn;
        private System.Windows.Forms.Button showValidationErrors;
        private System.Windows.Forms.Label lblCreateApplication;
        private System.Windows.Forms.Label lblQualification;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TabPage Administration;
        private System.Windows.Forms.TabPage IdentityVerification;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox appGuidIdent;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button getIdentityQuestions;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.RadioButton q1ans3;
        private System.Windows.Forms.RadioButton q1ans2;
        private System.Windows.Forms.RadioButton q1ans1;
        private System.Windows.Forms.Label question1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label question3;
        private System.Windows.Forms.RadioButton q3ans3;
        private System.Windows.Forms.RadioButton q3ans2;
        private System.Windows.Forms.RadioButton q3ans1;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label question2;
        private System.Windows.Forms.RadioButton q2ans3;
        private System.Windows.Forms.RadioButton q2ans2;
        private System.Windows.Forms.RadioButton q2ans1;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Button answerQuestions;
        private System.Windows.Forms.Panel questionsPanel;
        private System.Windows.Forms.Button qualBtn;
        private System.Windows.Forms.TextBox appGuidQual;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Button qualResultBtn;
        private System.Windows.Forms.DataGridView listApps;
        private System.Windows.Forms.Button listAppsBtn;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.TextBox searchEmail;
        private System.Windows.Forms.TextBox searchLastName;
        private System.Windows.Forms.TextBox searchFirstName;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.Label label25;
        private System.Windows.Forms.Label label26;
        private System.Windows.Forms.ComboBox searchQualificationStatus;
        private System.Windows.Forms.ComboBox searchIdentityStatus;
        private System.Windows.Forms.ComboBox searchAppStatus;
        private System.Windows.Forms.CheckBox searchDates;
        private System.Windows.Forms.DateTimePicker searchDateThrough;
        private System.Windows.Forms.DateTimePicker searchDateFrom;
        private System.Windows.Forms.Label label27;
        private System.Windows.Forms.Label label28;
        private Button btnSaveAppResultDetail;
        private Button resetApplicationBtn;
        private Label environmentLbl;
        private RichTextBox applicationResultTxtBox;
        private SaveFileDialog sfdSaveToFile;
        private GroupBox qualResultsGrpBox;
        private Label label43;
        private Label identResultLabel;
        private Label label4;
        private Label label3;
        private Label identityResultLbl;
        private Label qlfyDecisionLbl;
        private Label appStatusLbl;
        private Label decisionLbl;
        private Label creditScoreLbl;
        private Label label6;
        private Button btnSaveCreditReport;
        private Button getAppBtn;
        private Label label29;
        private TextBox adminAppGuidTxt;
        private GroupBox groupBox1;
        private DataGridViewTextBoxColumn ApplicationDate;
        private DataGridViewTextBoxColumn ApplicationGuid;
        private DataGridViewTextBoxColumn MerchantName;
        private DataGridViewTextBoxColumn ApplicationStatus;
        private DataGridViewButtonColumn ViewDetail;
        private DataGridViewButtonColumn ViewApplication;
        private CheckBox saveToLogChkBx;
        private CheckBox checkBox1;
    }
}

