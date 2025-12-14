namespace WpCalendar
{
	partial class FmMain
	{
		/// <summary>
		/// 必要なデザイナー変数です。
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// 使用中のリソースをすべてクリーンアップします。
		/// </summary>
		/// <param name="disposing">マネージ リソースが破棄される場合 true、破棄されない場合は false です。</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows フォーム デザイナーで生成されたコード

		/// <summary>
		/// デザイナー サポートに必要なメソッドです。このメソッドの内容を
		/// コード エディターで変更しないでください。
		/// </summary>
		private void InitializeComponent()
		{
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FmMain));
			this.btnCaDraw = new System.Windows.Forms.Button();
			this.colorDlg = new System.Windows.Forms.ColorDialog();
			this.grpColorSetting = new System.Windows.Forms.GroupBox();
			this.btnColorYearMonth = new System.Windows.Forms.Button();
			this.btnColorSpecialDay = new System.Windows.Forms.Button();
			this.btnColorSunday = new System.Windows.Forms.Button();
			this.btnColorSaturday = new System.Windows.Forms.Button();
			this.btnColorWeekday = new System.Windows.Forms.Button();
			this.btnColorTodayBg = new System.Windows.Forms.Button();
			this.btnColorShadow = new System.Windows.Forms.Button();
			this.grpCharGap = new System.Windows.Forms.GroupBox();
			this.lblDToD = new System.Windows.Forms.Label();
			this.lblDToDV = new System.Windows.Forms.Label();
			this.udWeekToDay = new System.Windows.Forms.NumericUpDown();
			this.lblWToD = new System.Windows.Forms.Label();
			this.udDayVertical = new System.Windows.Forms.NumericUpDown();
			this.udYMToWeek = new System.Windows.Forms.NumericUpDown();
			this.lblYMToW = new System.Windows.Forms.Label();
			this.lblDToDH = new System.Windows.Forms.Label();
			this.udMonthToMonth = new System.Windows.Forms.NumericUpDown();
			this.udDayHolizon = new System.Windows.Forms.NumericUpDown();
			this.lblMToM = new System.Windows.Forms.Label();
			this.tabMenu = new System.Windows.Forms.TabControl();
			this.tabLayout = new System.Windows.Forms.TabPage();
			this.grpStartWeek = new System.Windows.Forms.GroupBox();
			this.rbMondayStart = new System.Windows.Forms.RadioButton();
			this.rbSundayStart = new System.Windows.Forms.RadioButton();
			this.grpLocation = new System.Windows.Forms.GroupBox();
			this.udOriginX = new System.Windows.Forms.NumericUpDown();
			this.lblOrgX = new System.Windows.Forms.Label();
			this.udOriginY = new System.Windows.Forms.NumericUpDown();
			this.lblOrgY = new System.Windows.Forms.Label();
			this.grpMonthChange = new System.Windows.Forms.GroupBox();
			this.rbChangeMidMonth = new System.Windows.Forms.RadioButton();
			this.rbChangeFirstDay = new System.Windows.Forms.RadioButton();
			this.grpMonthOrder = new System.Windows.Forms.GroupBox();
			this.rbMonthVertical = new System.Windows.Forms.RadioButton();
			this.rbMonthHolizon = new System.Windows.Forms.RadioButton();
			this.cbMonthOrder = new System.Windows.Forms.ComboBox();
			this.tabFormat = new System.Windows.Forms.TabPage();
			this.grpFormatWeek = new System.Windows.Forms.GroupBox();
			this.cbUserFormatW = new System.Windows.Forms.ComboBox();
			this.lblYearMonthFormat = new System.Windows.Forms.Label();
			this.grpFormatYM = new System.Windows.Forms.GroupBox();
			this.lblFormatViewYM = new System.Windows.Forms.Label();
			this.lblYMCentering = new System.Windows.Forms.Label();
			this.btnFmtView = new System.Windows.Forms.Button();
			this.rbYMPosRight = new System.Windows.Forms.RadioButton();
			this.rbYMPosCenter = new System.Windows.Forms.RadioButton();
			this.rbYMPosLeft = new System.Windows.Forms.RadioButton();
			this.tbUserFormatYM = new System.Windows.Forms.TextBox();
			this.lblFmtText = new System.Windows.Forms.Label();
			this.tabColorSetting = new System.Windows.Forms.TabPage();
			this.grpCharEffect = new System.Windows.Forms.GroupBox();
			this.udShadowWidth = new System.Windows.Forms.NumericUpDown();
			this.udTodayBgWidth = new System.Windows.Forms.NumericUpDown();
			this.cbEffectShadow = new System.Windows.Forms.ComboBox();
			this.cbEffectTodayBg = new System.Windows.Forms.ComboBox();
			this.grpFontSetting = new System.Windows.Forms.GroupBox();
			this.pnlViewFontD = new System.Windows.Forms.Panel();
			this.lblViewFontDay = new System.Windows.Forms.Label();
			this.pnlViewFontW = new System.Windows.Forms.Panel();
			this.lblViewFontWeek = new System.Windows.Forms.Label();
			this.pnlViewFontYM = new System.Windows.Forms.Panel();
			this.lblViewFontYearMonth = new System.Windows.Forms.Label();
			this.btnFontDay = new System.Windows.Forms.Button();
			this.btnFontWeek = new System.Windows.Forms.Button();
			this.btnFontYearMonth = new System.Windows.Forms.Button();
			this.tabSpecialDay = new System.Windows.Forms.TabPage();
			this.grpSpdayList = new System.Windows.Forms.GroupBox();
			this.btnSpdayDelete = new System.Windows.Forms.Button();
			this.lstRegistSpecialDay = new System.Windows.Forms.ListBox();
			this.grpSpdayRegist = new System.Windows.Forms.GroupBox();
			this.pnlSpdaySetDay = new System.Windows.Forms.Panel();
			this.udSpdayMonth = new System.Windows.Forms.NumericUpDown();
			this.udSpdayDay = new System.Windows.Forms.NumericUpDown();
			this.lblSpdayRegM = new System.Windows.Forms.Label();
			this.lblSpdayRegD = new System.Windows.Forms.Label();
			this.pnlSpdaySetWeek = new System.Windows.Forms.Panel();
			this.udSpdayWMonth = new System.Windows.Forms.NumericUpDown();
			this.cbSpdayWWeek = new System.Windows.Forms.ComboBox();
			this.lblSpdayRegWC = new System.Windows.Forms.Label();
			this.lblSpdayRegWM = new System.Windows.Forms.Label();
			this.udSpdayWCount = new System.Windows.Forms.NumericUpDown();
			this.lblSpdayRegWW = new System.Windows.Forms.Label();
			this.btnSpdayRegist = new System.Windows.Forms.Button();
			this.rbSpdaySetWeek = new System.Windows.Forms.RadioButton();
			this.rbSpdaySetDay = new System.Windows.Forms.RadioButton();
			this.tabAdvanced = new System.Windows.Forms.TabPage();
			this.btnDayStrPreview = new System.Windows.Forms.Button();
			this.pnlCanvas = new System.Windows.Forms.Panel();
			this.grpDayStrOffset = new System.Windows.Forms.GroupBox();
			this.lblDayStrOffsetHeight = new System.Windows.Forms.Label();
			this.udDayStrOffsetY = new System.Windows.Forms.NumericUpDown();
			this.lblDayStrOffsetWidth = new System.Windows.Forms.Label();
			this.udDayStrOffsetX = new System.Windows.Forms.NumericUpDown();
			this.grpDayCellSize = new System.Windows.Forms.GroupBox();
			this.lblDayCellHeight = new System.Windows.Forms.Label();
			this.udDayCellHeight = new System.Windows.Forms.NumericUpDown();
			this.lblDayCellWidth = new System.Windows.Forms.Label();
			this.udDayCellWidth = new System.Windows.Forms.NumericUpDown();
			this.tabOption = new System.Windows.Forms.TabPage();
			this.grpAppClose = new System.Windows.Forms.GroupBox();
			this.lblOptAppClose = new System.Windows.Forms.Label();
			this.rbAppCloseEnd = new System.Windows.Forms.RadioButton();
			this.rbAppCloseResident = new System.Windows.Forms.RadioButton();
			this.grpOption = new System.Windows.Forms.GroupBox();
			this.btnCaClear = new System.Windows.Forms.Button();
			this.btnAbout = new System.Windows.Forms.Button();
			this.grpStartup = new System.Windows.Forms.GroupBox();
			this.rbStartupNone = new System.Windows.Forms.RadioButton();
			this.rbStartupDaily = new System.Windows.Forms.RadioButton();
			this.rbStartupOnce = new System.Windows.Forms.RadioButton();
			this.fontDlg = new System.Windows.Forms.FontDialog();
			this.pnlIcon = new System.Windows.Forms.Panel();
			this.grpColorSetting.SuspendLayout();
			this.grpCharGap.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.udWeekToDay)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.udDayVertical)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.udYMToWeek)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.udMonthToMonth)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.udDayHolizon)).BeginInit();
			this.tabMenu.SuspendLayout();
			this.tabLayout.SuspendLayout();
			this.grpStartWeek.SuspendLayout();
			this.grpLocation.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.udOriginX)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.udOriginY)).BeginInit();
			this.grpMonthChange.SuspendLayout();
			this.grpMonthOrder.SuspendLayout();
			this.tabFormat.SuspendLayout();
			this.grpFormatWeek.SuspendLayout();
			this.grpFormatYM.SuspendLayout();
			this.tabColorSetting.SuspendLayout();
			this.grpCharEffect.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.udShadowWidth)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.udTodayBgWidth)).BeginInit();
			this.grpFontSetting.SuspendLayout();
			this.pnlViewFontD.SuspendLayout();
			this.pnlViewFontW.SuspendLayout();
			this.pnlViewFontYM.SuspendLayout();
			this.tabSpecialDay.SuspendLayout();
			this.grpSpdayList.SuspendLayout();
			this.grpSpdayRegist.SuspendLayout();
			this.pnlSpdaySetDay.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.udSpdayMonth)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.udSpdayDay)).BeginInit();
			this.pnlSpdaySetWeek.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.udSpdayWMonth)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.udSpdayWCount)).BeginInit();
			this.tabAdvanced.SuspendLayout();
			this.grpDayStrOffset.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.udDayStrOffsetY)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.udDayStrOffsetX)).BeginInit();
			this.grpDayCellSize.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.udDayCellHeight)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.udDayCellWidth)).BeginInit();
			this.tabOption.SuspendLayout();
			this.grpAppClose.SuspendLayout();
			this.grpOption.SuspendLayout();
			this.grpStartup.SuspendLayout();
			this.SuspendLayout();
			// 
			// btnCaDraw
			// 
			this.btnCaDraw.Location = new System.Drawing.Point(132, 227);
			this.btnCaDraw.Name = "btnCaDraw";
			this.btnCaDraw.Size = new System.Drawing.Size(120, 23);
			this.btnCaDraw.TabIndex = 0;
			this.btnCaDraw.Text = "カレンダーを描画する";
			this.btnCaDraw.UseVisualStyleBackColor = true;
			this.btnCaDraw.Click += new System.EventHandler(this.btnDoDraw_Click);
			// 
			// grpColorSetting
			// 
			this.grpColorSetting.Controls.Add(this.btnColorYearMonth);
			this.grpColorSetting.Controls.Add(this.btnColorSpecialDay);
			this.grpColorSetting.Controls.Add(this.btnColorSunday);
			this.grpColorSetting.Controls.Add(this.btnColorSaturday);
			this.grpColorSetting.Controls.Add(this.btnColorWeekday);
			this.grpColorSetting.Location = new System.Drawing.Point(6, 6);
			this.grpColorSetting.Name = "grpColorSetting";
			this.grpColorSetting.Size = new System.Drawing.Size(88, 182);
			this.grpColorSetting.TabIndex = 1;
			this.grpColorSetting.TabStop = false;
			this.grpColorSetting.Text = "文字色";
			// 
			// btnColorYearMonth
			// 
			this.btnColorYearMonth.Location = new System.Drawing.Point(6, 18);
			this.btnColorYearMonth.Name = "btnColorYearMonth";
			this.btnColorYearMonth.Size = new System.Drawing.Size(75, 22);
			this.btnColorYearMonth.TabIndex = 4;
			this.btnColorYearMonth.Tag = "ColorYearMonth";
			this.btnColorYearMonth.Text = "年/月";
			this.btnColorYearMonth.UseVisualStyleBackColor = true;
			this.btnColorYearMonth.Click += new System.EventHandler(this.btnColorSetting_Click);
			// 
			// btnColorSpecialDay
			// 
			this.btnColorSpecialDay.Location = new System.Drawing.Point(6, 130);
			this.btnColorSpecialDay.Name = "btnColorSpecialDay";
			this.btnColorSpecialDay.Size = new System.Drawing.Size(75, 22);
			this.btnColorSpecialDay.TabIndex = 3;
			this.btnColorSpecialDay.Tag = "ColorSpecialDay";
			this.btnColorSpecialDay.Text = "特別日";
			this.btnColorSpecialDay.UseVisualStyleBackColor = true;
			this.btnColorSpecialDay.Click += new System.EventHandler(this.btnColorSetting_Click);
			// 
			// btnColorSunday
			// 
			this.btnColorSunday.Location = new System.Drawing.Point(6, 102);
			this.btnColorSunday.Name = "btnColorSunday";
			this.btnColorSunday.Size = new System.Drawing.Size(75, 22);
			this.btnColorSunday.TabIndex = 2;
			this.btnColorSunday.Tag = "ColorSunday";
			this.btnColorSunday.Text = "日曜/祝日";
			this.btnColorSunday.UseVisualStyleBackColor = true;
			this.btnColorSunday.Click += new System.EventHandler(this.btnColorSetting_Click);
			// 
			// btnColorSaturday
			// 
			this.btnColorSaturday.Location = new System.Drawing.Point(6, 74);
			this.btnColorSaturday.Name = "btnColorSaturday";
			this.btnColorSaturday.Size = new System.Drawing.Size(75, 22);
			this.btnColorSaturday.TabIndex = 1;
			this.btnColorSaturday.Tag = "ColorSaturday";
			this.btnColorSaturday.Text = "土曜";
			this.btnColorSaturday.UseVisualStyleBackColor = true;
			this.btnColorSaturday.Click += new System.EventHandler(this.btnColorSetting_Click);
			// 
			// btnColorWeekday
			// 
			this.btnColorWeekday.Location = new System.Drawing.Point(6, 46);
			this.btnColorWeekday.Name = "btnColorWeekday";
			this.btnColorWeekday.Size = new System.Drawing.Size(75, 22);
			this.btnColorWeekday.TabIndex = 0;
			this.btnColorWeekday.Tag = "ColorWeekday";
			this.btnColorWeekday.Text = "平日";
			this.btnColorWeekday.UseVisualStyleBackColor = true;
			this.btnColorWeekday.Click += new System.EventHandler(this.btnColorSetting_Click);
			// 
			// btnColorTodayBg
			// 
			this.btnColorTodayBg.Location = new System.Drawing.Point(6, 18);
			this.btnColorTodayBg.Name = "btnColorTodayBg";
			this.btnColorTodayBg.Size = new System.Drawing.Size(80, 22);
			this.btnColorTodayBg.TabIndex = 6;
			this.btnColorTodayBg.Tag = "ColorTodayBg";
			this.btnColorTodayBg.Text = "今日の背景";
			this.btnColorTodayBg.UseVisualStyleBackColor = true;
			this.btnColorTodayBg.Click += new System.EventHandler(this.btnColorSetting_Click);
			// 
			// btnColorShadow
			// 
			this.btnColorShadow.Location = new System.Drawing.Point(6, 46);
			this.btnColorShadow.Name = "btnColorShadow";
			this.btnColorShadow.Size = new System.Drawing.Size(80, 22);
			this.btnColorShadow.TabIndex = 5;
			this.btnColorShadow.Tag = "ColorShadow";
			this.btnColorShadow.Text = "影";
			this.btnColorShadow.UseVisualStyleBackColor = true;
			this.btnColorShadow.Click += new System.EventHandler(this.btnColorSetting_Click);
			// 
			// grpCharGap
			// 
			this.grpCharGap.Controls.Add(this.lblDToD);
			this.grpCharGap.Controls.Add(this.lblDToDV);
			this.grpCharGap.Controls.Add(this.udWeekToDay);
			this.grpCharGap.Controls.Add(this.lblWToD);
			this.grpCharGap.Controls.Add(this.udDayVertical);
			this.grpCharGap.Controls.Add(this.udYMToWeek);
			this.grpCharGap.Controls.Add(this.lblYMToW);
			this.grpCharGap.Controls.Add(this.lblDToDH);
			this.grpCharGap.Controls.Add(this.udMonthToMonth);
			this.grpCharGap.Controls.Add(this.udDayHolizon);
			this.grpCharGap.Controls.Add(this.lblMToM);
			this.grpCharGap.Location = new System.Drawing.Point(197, 7);
			this.grpCharGap.Name = "grpCharGap";
			this.grpCharGap.Size = new System.Drawing.Size(169, 125);
			this.grpCharGap.TabIndex = 3;
			this.grpCharGap.TabStop = false;
			this.grpCharGap.Text = "表示間隔";
			// 
			// lblDToD
			// 
			this.lblDToD.AutoSize = true;
			this.lblDToD.Location = new System.Drawing.Point(11, 80);
			this.lblDToD.Name = "lblDToD";
			this.lblDToD.Size = new System.Drawing.Size(35, 12);
			this.lblDToD.TabIndex = 16;
			this.lblDToD.Text = "日にち";
			// 
			// lblDToDV
			// 
			this.lblDToDV.AutoSize = true;
			this.lblDToDV.Location = new System.Drawing.Point(92, 97);
			this.lblDToDV.Name = "lblDToDV";
			this.lblDToDV.Size = new System.Drawing.Size(17, 12);
			this.lblDToDV.TabIndex = 15;
			this.lblDToDV.Text = "縦";
			// 
			// udWeekToDay
			// 
			this.udWeekToDay.Location = new System.Drawing.Point(84, 58);
			this.udWeekToDay.Name = "udWeekToDay";
			this.udWeekToDay.Size = new System.Drawing.Size(48, 19);
			this.udWeekToDay.TabIndex = 10;
			this.udWeekToDay.Tag = "GapWeekToDay";
			this.udWeekToDay.ValueChanged += new System.EventHandler(this.udControl_ValueChanged);
			// 
			// lblWToD
			// 
			this.lblWToD.AutoSize = true;
			this.lblWToD.Location = new System.Drawing.Point(11, 60);
			this.lblWToD.Name = "lblWToD";
			this.lblWToD.Size = new System.Drawing.Size(67, 12);
			this.lblWToD.TabIndex = 9;
			this.lblWToD.Text = "曜日と日にち";
			// 
			// udDayVertical
			// 
			this.udDayVertical.Location = new System.Drawing.Point(115, 95);
			this.udDayVertical.Name = "udDayVertical";
			this.udDayVertical.Size = new System.Drawing.Size(48, 19);
			this.udDayVertical.TabIndex = 14;
			this.udDayVertical.Tag = "GapDayVertical";
			this.udDayVertical.ValueChanged += new System.EventHandler(this.udControl_ValueChanged);
			// 
			// udYMToWeek
			// 
			this.udYMToWeek.Location = new System.Drawing.Point(84, 38);
			this.udYMToWeek.Name = "udYMToWeek";
			this.udYMToWeek.Size = new System.Drawing.Size(48, 19);
			this.udYMToWeek.TabIndex = 8;
			this.udYMToWeek.Tag = "GapYearMonthToWeek";
			this.udYMToWeek.ValueChanged += new System.EventHandler(this.udControl_ValueChanged);
			// 
			// lblYMToW
			// 
			this.lblYMToW.AutoSize = true;
			this.lblYMToW.Location = new System.Drawing.Point(11, 40);
			this.lblYMToW.Name = "lblYMToW";
			this.lblYMToW.Size = new System.Drawing.Size(67, 12);
			this.lblYMToW.TabIndex = 7;
			this.lblYMToW.Text = "年/月と曜日";
			// 
			// lblDToDH
			// 
			this.lblDToDH.AutoSize = true;
			this.lblDToDH.Location = new System.Drawing.Point(15, 97);
			this.lblDToDH.Name = "lblDToDH";
			this.lblDToDH.Size = new System.Drawing.Size(17, 12);
			this.lblDToDH.TabIndex = 13;
			this.lblDToDH.Text = "横";
			// 
			// udMonthToMonth
			// 
			this.udMonthToMonth.Location = new System.Drawing.Point(84, 18);
			this.udMonthToMonth.Name = "udMonthToMonth";
			this.udMonthToMonth.Size = new System.Drawing.Size(48, 19);
			this.udMonthToMonth.TabIndex = 6;
			this.udMonthToMonth.Tag = "GapMonthToMonth";
			this.udMonthToMonth.ValueChanged += new System.EventHandler(this.udControl_ValueChanged);
			// 
			// udDayHolizon
			// 
			this.udDayHolizon.Location = new System.Drawing.Point(38, 95);
			this.udDayHolizon.Name = "udDayHolizon";
			this.udDayHolizon.Size = new System.Drawing.Size(48, 19);
			this.udDayHolizon.TabIndex = 12;
			this.udDayHolizon.Tag = "GapDayHolizon";
			this.udDayHolizon.ValueChanged += new System.EventHandler(this.udControl_ValueChanged);
			// 
			// lblMToM
			// 
			this.lblMToM.AutoSize = true;
			this.lblMToM.Location = new System.Drawing.Point(29, 20);
			this.lblMToM.Name = "lblMToM";
			this.lblMToM.Size = new System.Drawing.Size(49, 12);
			this.lblMToM.TabIndex = 5;
			this.lblMToM.Text = "月の並び";
			// 
			// tabMenu
			// 
			this.tabMenu.Controls.Add(this.tabLayout);
			this.tabMenu.Controls.Add(this.tabFormat);
			this.tabMenu.Controls.Add(this.tabColorSetting);
			this.tabMenu.Controls.Add(this.tabSpecialDay);
			this.tabMenu.Controls.Add(this.tabAdvanced);
			this.tabMenu.Controls.Add(this.tabOption);
			this.tabMenu.Location = new System.Drawing.Point(2, 1);
			this.tabMenu.Name = "tabMenu";
			this.tabMenu.SelectedIndex = 0;
			this.tabMenu.Size = new System.Drawing.Size(380, 220);
			this.tabMenu.TabIndex = 4;
			// 
			// tabLayout
			// 
			this.tabLayout.Controls.Add(this.grpStartWeek);
			this.tabLayout.Controls.Add(this.grpLocation);
			this.tabLayout.Controls.Add(this.grpMonthChange);
			this.tabLayout.Controls.Add(this.grpMonthOrder);
			this.tabLayout.Controls.Add(this.grpCharGap);
			this.tabLayout.Location = new System.Drawing.Point(4, 22);
			this.tabLayout.Name = "tabLayout";
			this.tabLayout.Padding = new System.Windows.Forms.Padding(3);
			this.tabLayout.Size = new System.Drawing.Size(372, 194);
			this.tabLayout.TabIndex = 0;
			this.tabLayout.Text = "配置";
			this.tabLayout.UseVisualStyleBackColor = true;
			// 
			// grpStartWeek
			// 
			this.grpStartWeek.Controls.Add(this.rbMondayStart);
			this.grpStartWeek.Controls.Add(this.rbSundayStart);
			this.grpStartWeek.Location = new System.Drawing.Point(7, 142);
			this.grpStartWeek.Name = "grpStartWeek";
			this.grpStartWeek.Size = new System.Drawing.Size(184, 46);
			this.grpStartWeek.TabIndex = 7;
			this.grpStartWeek.TabStop = false;
			this.grpStartWeek.Tag = "StartWeek";
			this.grpStartWeek.Text = "週の始まり";
			// 
			// rbMondayStart
			// 
			this.rbMondayStart.AutoSize = true;
			this.rbMondayStart.Location = new System.Drawing.Point(77, 18);
			this.rbMondayStart.Name = "rbMondayStart";
			this.rbMondayStart.Size = new System.Drawing.Size(65, 16);
			this.rbMondayStart.TabIndex = 1;
			this.rbMondayStart.Tag = "1";
			this.rbMondayStart.Text = "月曜から";
			this.rbMondayStart.UseVisualStyleBackColor = true;
			this.rbMondayStart.CheckedChanged += new System.EventHandler(this.radioButtonInGroupBox_CheckedChanged);
			// 
			// rbSundayStart
			// 
			this.rbSundayStart.AutoSize = true;
			this.rbSundayStart.Checked = true;
			this.rbSundayStart.Location = new System.Drawing.Point(6, 18);
			this.rbSundayStart.Name = "rbSundayStart";
			this.rbSundayStart.Size = new System.Drawing.Size(65, 16);
			this.rbSundayStart.TabIndex = 0;
			this.rbSundayStart.TabStop = true;
			this.rbSundayStart.Tag = "0";
			this.rbSundayStart.Text = "日曜から";
			this.rbSundayStart.UseVisualStyleBackColor = true;
			this.rbSundayStart.CheckedChanged += new System.EventHandler(this.radioButtonInGroupBox_CheckedChanged);
			// 
			// grpLocation
			// 
			this.grpLocation.Controls.Add(this.udOriginX);
			this.grpLocation.Controls.Add(this.lblOrgX);
			this.grpLocation.Controls.Add(this.udOriginY);
			this.grpLocation.Controls.Add(this.lblOrgY);
			this.grpLocation.Location = new System.Drawing.Point(197, 142);
			this.grpLocation.Name = "grpLocation";
			this.grpLocation.Size = new System.Drawing.Size(169, 46);
			this.grpLocation.TabIndex = 6;
			this.grpLocation.TabStop = false;
			this.grpLocation.Text = "デスクトップ上の描画位置";
			// 
			// udOriginX
			// 
			this.udOriginX.Location = new System.Drawing.Point(38, 18);
			this.udOriginX.Name = "udOriginX";
			this.udOriginX.Size = new System.Drawing.Size(48, 19);
			this.udOriginX.TabIndex = 1;
			this.udOriginX.Tag = "OriginX";
			this.udOriginX.ValueChanged += new System.EventHandler(this.udControl_ValueChanged);
			// 
			// lblOrgX
			// 
			this.lblOrgX.AutoSize = true;
			this.lblOrgX.Location = new System.Drawing.Point(20, 20);
			this.lblOrgX.Name = "lblOrgX";
			this.lblOrgX.Size = new System.Drawing.Size(12, 12);
			this.lblOrgX.TabIndex = 2;
			this.lblOrgX.Text = "X";
			// 
			// udOriginY
			// 
			this.udOriginY.Location = new System.Drawing.Point(115, 18);
			this.udOriginY.Name = "udOriginY";
			this.udOriginY.Size = new System.Drawing.Size(48, 19);
			this.udOriginY.TabIndex = 3;
			this.udOriginY.Tag = "OriginY";
			this.udOriginY.ValueChanged += new System.EventHandler(this.udControl_ValueChanged);
			// 
			// lblOrgY
			// 
			this.lblOrgY.AutoSize = true;
			this.lblOrgY.Location = new System.Drawing.Point(97, 20);
			this.lblOrgY.Name = "lblOrgY";
			this.lblOrgY.Size = new System.Drawing.Size(12, 12);
			this.lblOrgY.TabIndex = 4;
			this.lblOrgY.Text = "Y";
			// 
			// grpMonthChange
			// 
			this.grpMonthChange.Controls.Add(this.rbChangeMidMonth);
			this.grpMonthChange.Controls.Add(this.rbChangeFirstDay);
			this.grpMonthChange.Location = new System.Drawing.Point(7, 86);
			this.grpMonthChange.Name = "grpMonthChange";
			this.grpMonthChange.Size = new System.Drawing.Size(184, 46);
			this.grpMonthChange.TabIndex = 5;
			this.grpMonthChange.TabStop = false;
			this.grpMonthChange.Tag = "MonthChange";
			this.grpMonthChange.Text = "月の切り替え";
			// 
			// rbChangeMidMonth
			// 
			this.rbChangeMidMonth.AutoSize = true;
			this.rbChangeMidMonth.Location = new System.Drawing.Point(77, 18);
			this.rbChangeMidMonth.Name = "rbChangeMidMonth";
			this.rbChangeMidMonth.Size = new System.Drawing.Size(59, 16);
			this.rbChangeMidMonth.TabIndex = 2;
			this.rbChangeMidMonth.Tag = "1";
			this.rbChangeMidMonth.Text = "15日目";
			this.rbChangeMidMonth.UseVisualStyleBackColor = true;
			this.rbChangeMidMonth.CheckedChanged += new System.EventHandler(this.radioButtonInGroupBox_CheckedChanged);
			// 
			// rbChangeFirstDay
			// 
			this.rbChangeFirstDay.AutoSize = true;
			this.rbChangeFirstDay.Checked = true;
			this.rbChangeFirstDay.Location = new System.Drawing.Point(6, 18);
			this.rbChangeFirstDay.Name = "rbChangeFirstDay";
			this.rbChangeFirstDay.Size = new System.Drawing.Size(53, 16);
			this.rbChangeFirstDay.TabIndex = 1;
			this.rbChangeFirstDay.TabStop = true;
			this.rbChangeFirstDay.Tag = "0";
			this.rbChangeFirstDay.Text = "1日目";
			this.rbChangeFirstDay.UseVisualStyleBackColor = true;
			this.rbChangeFirstDay.CheckedChanged += new System.EventHandler(this.radioButtonInGroupBox_CheckedChanged);
			// 
			// grpMonthOrder
			// 
			this.grpMonthOrder.Controls.Add(this.rbMonthVertical);
			this.grpMonthOrder.Controls.Add(this.rbMonthHolizon);
			this.grpMonthOrder.Controls.Add(this.cbMonthOrder);
			this.grpMonthOrder.Location = new System.Drawing.Point(7, 7);
			this.grpMonthOrder.Name = "grpMonthOrder";
			this.grpMonthOrder.Size = new System.Drawing.Size(184, 70);
			this.grpMonthOrder.TabIndex = 4;
			this.grpMonthOrder.TabStop = false;
			this.grpMonthOrder.Tag = "MonthDirection";
			this.grpMonthOrder.Text = "月の並び";
			// 
			// rbMonthVertical
			// 
			this.rbMonthVertical.AutoSize = true;
			this.rbMonthVertical.Location = new System.Drawing.Point(77, 44);
			this.rbMonthVertical.Name = "rbMonthVertical";
			this.rbMonthVertical.Size = new System.Drawing.Size(59, 16);
			this.rbMonthVertical.TabIndex = 2;
			this.rbMonthVertical.Tag = "1";
			this.rbMonthVertical.Text = "縦方向";
			this.rbMonthVertical.UseVisualStyleBackColor = true;
			this.rbMonthVertical.CheckedChanged += new System.EventHandler(this.radioButtonInGroupBox_CheckedChanged);
			// 
			// rbMonthHolizon
			// 
			this.rbMonthHolizon.AutoSize = true;
			this.rbMonthHolizon.Checked = true;
			this.rbMonthHolizon.Location = new System.Drawing.Point(6, 44);
			this.rbMonthHolizon.Name = "rbMonthHolizon";
			this.rbMonthHolizon.Size = new System.Drawing.Size(59, 16);
			this.rbMonthHolizon.TabIndex = 1;
			this.rbMonthHolizon.TabStop = true;
			this.rbMonthHolizon.Tag = "0";
			this.rbMonthHolizon.Text = "横方向";
			this.rbMonthHolizon.UseVisualStyleBackColor = true;
			this.rbMonthHolizon.CheckedChanged += new System.EventHandler(this.radioButtonInGroupBox_CheckedChanged);
			// 
			// cbMonthOrder
			// 
			this.cbMonthOrder.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbMonthOrder.FormattingEnabled = true;
			this.cbMonthOrder.Items.AddRange(new object[] {
            "1ヵ月 今月",
            "2ヵ月 前月 - 今月",
            "2ヵ月 今月 - 翌月",
            "3ヵ月 前々月 - 前月 - 今月",
            "3ヵ月 前月 - 今月 - 翌月",
            "3ヵ月 今月 - 翌月 - 翌々月"});
			this.cbMonthOrder.Location = new System.Drawing.Point(6, 18);
			this.cbMonthOrder.Name = "cbMonthOrder";
			this.cbMonthOrder.Size = new System.Drawing.Size(170, 20);
			this.cbMonthOrder.TabIndex = 0;
			this.cbMonthOrder.Tag = "MonthOrder";
			this.cbMonthOrder.DropDownClosed += new System.EventHandler(this.cbMonthOrder_DropDownClosed);
			// 
			// tabFormat
			// 
			this.tabFormat.Controls.Add(this.grpFormatWeek);
			this.tabFormat.Controls.Add(this.lblYearMonthFormat);
			this.tabFormat.Controls.Add(this.grpFormatYM);
			this.tabFormat.Location = new System.Drawing.Point(4, 22);
			this.tabFormat.Name = "tabFormat";
			this.tabFormat.Padding = new System.Windows.Forms.Padding(3);
			this.tabFormat.Size = new System.Drawing.Size(372, 194);
			this.tabFormat.TabIndex = 2;
			this.tabFormat.Text = "書式";
			this.tabFormat.UseVisualStyleBackColor = true;
			// 
			// grpFormatWeek
			// 
			this.grpFormatWeek.Controls.Add(this.cbUserFormatW);
			this.grpFormatWeek.Location = new System.Drawing.Point(249, 6);
			this.grpFormatWeek.Name = "grpFormatWeek";
			this.grpFormatWeek.Size = new System.Drawing.Size(117, 59);
			this.grpFormatWeek.TabIndex = 8;
			this.grpFormatWeek.TabStop = false;
			this.grpFormatWeek.Text = "曜日";
			// 
			// cbUserFormatW
			// 
			this.cbUserFormatW.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbUserFormatW.FormattingEnabled = true;
			this.cbUserFormatW.Items.AddRange(new object[] {
            "表示しない",
            "月,火,水,…",
            "Mo,Tu,We,…",
            "Mon,Tue,Wed,…"});
			this.cbUserFormatW.Location = new System.Drawing.Point(6, 20);
			this.cbUserFormatW.Name = "cbUserFormatW";
			this.cbUserFormatW.Size = new System.Drawing.Size(105, 20);
			this.cbUserFormatW.TabIndex = 0;
			this.cbUserFormatW.Tag = "WeekFormat";
			this.cbUserFormatW.DropDownClosed += new System.EventHandler(this.cbUserFormatW_DropDownClosed);
			// 
			// lblYearMonthFormat
			// 
			this.lblYearMonthFormat.AutoEllipsis = true;
			this.lblYearMonthFormat.AutoSize = true;
			this.lblYearMonthFormat.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.lblYearMonthFormat.Font = new System.Drawing.Font("ＭＳ ゴシック", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
			this.lblYearMonthFormat.Location = new System.Drawing.Point(6, 109);
			this.lblYearMonthFormat.Name = "lblYearMonthFormat";
			this.lblYearMonthFormat.Padding = new System.Windows.Forms.Padding(2);
			this.lblYearMonthFormat.Size = new System.Drawing.Size(35, 18);
			this.lblYearMonthFormat.TabIndex = 4;
			this.lblYearMonthFormat.Text = "凡例";
			// 
			// grpFormatYM
			// 
			this.grpFormatYM.Controls.Add(this.lblFormatViewYM);
			this.grpFormatYM.Controls.Add(this.lblYMCentering);
			this.grpFormatYM.Controls.Add(this.btnFmtView);
			this.grpFormatYM.Controls.Add(this.rbYMPosRight);
			this.grpFormatYM.Controls.Add(this.rbYMPosCenter);
			this.grpFormatYM.Controls.Add(this.rbYMPosLeft);
			this.grpFormatYM.Controls.Add(this.tbUserFormatYM);
			this.grpFormatYM.Controls.Add(this.lblFmtText);
			this.grpFormatYM.Location = new System.Drawing.Point(6, 6);
			this.grpFormatYM.Name = "grpFormatYM";
			this.grpFormatYM.Size = new System.Drawing.Size(237, 96);
			this.grpFormatYM.TabIndex = 3;
			this.grpFormatYM.TabStop = false;
			this.grpFormatYM.Tag = "YearMonthAlign";
			this.grpFormatYM.Text = "年/月";
			// 
			// lblFormatViewYM
			// 
			this.lblFormatViewYM.AutoSize = true;
			this.lblFormatViewYM.BackColor = System.Drawing.SystemColors.Control;
			this.lblFormatViewYM.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
			this.lblFormatViewYM.Location = new System.Drawing.Point(82, 66);
			this.lblFormatViewYM.Name = "lblFormatViewYM";
			this.lblFormatViewYM.Padding = new System.Windows.Forms.Padding(2);
			this.lblFormatViewYM.Size = new System.Drawing.Size(103, 20);
			this.lblFormatViewYM.TabIndex = 2;
			this.lblFormatViewYM.Text = "2013 January";
			// 
			// lblYMCentering
			// 
			this.lblYMCentering.AutoSize = true;
			this.lblYMCentering.Location = new System.Drawing.Point(6, 20);
			this.lblYMCentering.Name = "lblYMCentering";
			this.lblYMCentering.Size = new System.Drawing.Size(29, 12);
			this.lblYMCentering.TabIndex = 10;
			this.lblYMCentering.Text = "位置";
			// 
			// btnFmtView
			// 
			this.btnFmtView.Location = new System.Drawing.Point(6, 65);
			this.btnFmtView.Name = "btnFmtView";
			this.btnFmtView.Size = new System.Drawing.Size(70, 22);
			this.btnFmtView.TabIndex = 7;
			this.btnFmtView.Text = "表示確認";
			this.btnFmtView.UseVisualStyleBackColor = true;
			this.btnFmtView.Click += new System.EventHandler(this.btnFmtView_Click);
			// 
			// rbYMPosRight
			// 
			this.rbYMPosRight.AutoSize = true;
			this.rbYMPosRight.Location = new System.Drawing.Point(155, 18);
			this.rbYMPosRight.Name = "rbYMPosRight";
			this.rbYMPosRight.Size = new System.Drawing.Size(57, 16);
			this.rbYMPosRight.TabIndex = 9;
			this.rbYMPosRight.Tag = "2";
			this.rbYMPosRight.Text = "右寄せ";
			this.rbYMPosRight.UseVisualStyleBackColor = true;
			this.rbYMPosRight.CheckedChanged += new System.EventHandler(this.radioButtonInGroupBox_CheckedChanged);
			// 
			// rbYMPosCenter
			// 
			this.rbYMPosCenter.AutoSize = true;
			this.rbYMPosCenter.Location = new System.Drawing.Point(102, 18);
			this.rbYMPosCenter.Name = "rbYMPosCenter";
			this.rbYMPosCenter.Size = new System.Drawing.Size(47, 16);
			this.rbYMPosCenter.TabIndex = 8;
			this.rbYMPosCenter.Tag = "1";
			this.rbYMPosCenter.Text = "中央";
			this.rbYMPosCenter.UseVisualStyleBackColor = true;
			this.rbYMPosCenter.CheckedChanged += new System.EventHandler(this.radioButtonInGroupBox_CheckedChanged);
			// 
			// rbYMPosLeft
			// 
			this.rbYMPosLeft.AutoSize = true;
			this.rbYMPosLeft.Checked = true;
			this.rbYMPosLeft.Location = new System.Drawing.Point(41, 18);
			this.rbYMPosLeft.Name = "rbYMPosLeft";
			this.rbYMPosLeft.Size = new System.Drawing.Size(57, 16);
			this.rbYMPosLeft.TabIndex = 7;
			this.rbYMPosLeft.TabStop = true;
			this.rbYMPosLeft.Tag = "0";
			this.rbYMPosLeft.Text = "左寄せ";
			this.rbYMPosLeft.UseVisualStyleBackColor = true;
			this.rbYMPosLeft.CheckedChanged += new System.EventHandler(this.radioButtonInGroupBox_CheckedChanged);
			// 
			// tbUserFormatYM
			// 
			this.tbUserFormatYM.Location = new System.Drawing.Point(41, 40);
			this.tbUserFormatYM.Name = "tbUserFormatYM";
			this.tbUserFormatYM.Size = new System.Drawing.Size(190, 19);
			this.tbUserFormatYM.TabIndex = 5;
			this.tbUserFormatYM.Text = "yyyy mmmm";
			this.tbUserFormatYM.Leave += new System.EventHandler(this.tbUserFormatYM_Leave);
			// 
			// lblFmtText
			// 
			this.lblFmtText.AutoSize = true;
			this.lblFmtText.Location = new System.Drawing.Point(6, 43);
			this.lblFmtText.Name = "lblFmtText";
			this.lblFmtText.Size = new System.Drawing.Size(29, 12);
			this.lblFmtText.TabIndex = 6;
			this.lblFmtText.Text = "書式";
			// 
			// tabColorSetting
			// 
			this.tabColorSetting.Controls.Add(this.grpCharEffect);
			this.tabColorSetting.Controls.Add(this.grpFontSetting);
			this.tabColorSetting.Controls.Add(this.grpColorSetting);
			this.tabColorSetting.Location = new System.Drawing.Point(4, 22);
			this.tabColorSetting.Name = "tabColorSetting";
			this.tabColorSetting.Padding = new System.Windows.Forms.Padding(3);
			this.tabColorSetting.Size = new System.Drawing.Size(372, 194);
			this.tabColorSetting.TabIndex = 1;
			this.tabColorSetting.Text = "色/フォント";
			this.tabColorSetting.UseVisualStyleBackColor = true;
			// 
			// grpCharEffect
			// 
			this.grpCharEffect.Controls.Add(this.udShadowWidth);
			this.grpCharEffect.Controls.Add(this.udTodayBgWidth);
			this.grpCharEffect.Controls.Add(this.btnColorShadow);
			this.grpCharEffect.Controls.Add(this.btnColorTodayBg);
			this.grpCharEffect.Controls.Add(this.cbEffectShadow);
			this.grpCharEffect.Controls.Add(this.cbEffectTodayBg);
			this.grpCharEffect.Location = new System.Drawing.Point(100, 112);
			this.grpCharEffect.Name = "grpCharEffect";
			this.grpCharEffect.Size = new System.Drawing.Size(266, 76);
			this.grpCharEffect.TabIndex = 3;
			this.grpCharEffect.TabStop = false;
			this.grpCharEffect.Text = "効果の色/形/太さ";
			// 
			// udShadowWidth
			// 
			this.udShadowWidth.Location = new System.Drawing.Point(218, 48);
			this.udShadowWidth.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
			this.udShadowWidth.Name = "udShadowWidth";
			this.udShadowWidth.Size = new System.Drawing.Size(42, 19);
			this.udShadowWidth.TabIndex = 12;
			this.udShadowWidth.Tag = "EffectShadowWidth";
			this.udShadowWidth.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
			this.udShadowWidth.ValueChanged += new System.EventHandler(this.udControl_ValueChanged);
			// 
			// udTodayBgWidth
			// 
			this.udTodayBgWidth.Location = new System.Drawing.Point(218, 20);
			this.udTodayBgWidth.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
			this.udTodayBgWidth.Name = "udTodayBgWidth";
			this.udTodayBgWidth.Size = new System.Drawing.Size(42, 19);
			this.udTodayBgWidth.TabIndex = 11;
			this.udTodayBgWidth.Tag = "EffectTodayBgWidth";
			this.udTodayBgWidth.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
			this.udTodayBgWidth.ValueChanged += new System.EventHandler(this.udControl_ValueChanged);
			// 
			// cbEffectShadow
			// 
			this.cbEffectShadow.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbEffectShadow.FormattingEnabled = true;
			this.cbEffectShadow.Items.AddRange(new object[] {
            "なし",
            "右下",
            "周囲"});
			this.cbEffectShadow.Location = new System.Drawing.Point(92, 47);
			this.cbEffectShadow.Name = "cbEffectShadow";
			this.cbEffectShadow.Size = new System.Drawing.Size(120, 20);
			this.cbEffectShadow.TabIndex = 10;
			this.cbEffectShadow.Tag = "EffectShadow";
			this.cbEffectShadow.DropDownClosed += new System.EventHandler(this.cbEffectShadow_DropDownClosed);
			// 
			// cbEffectTodayBg
			// 
			this.cbEffectTodayBg.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbEffectTodayBg.FormattingEnabled = true;
			this.cbEffectTodayBg.Items.AddRange(new object[] {
            "なし",
            "円形 塗り",
            "円形 枠線",
            "四角形 塗り",
            "四角形 枠線",
            "角丸四角形 塗り",
            "角丸四角形 枠線"});
			this.cbEffectTodayBg.Location = new System.Drawing.Point(92, 19);
			this.cbEffectTodayBg.Name = "cbEffectTodayBg";
			this.cbEffectTodayBg.Size = new System.Drawing.Size(120, 20);
			this.cbEffectTodayBg.TabIndex = 9;
			this.cbEffectTodayBg.Tag = "EffectTodayBg";
			this.cbEffectTodayBg.DropDownClosed += new System.EventHandler(this.cbEffectTodayBg_DropDownClosed);
			// 
			// grpFontSetting
			// 
			this.grpFontSetting.Controls.Add(this.pnlViewFontD);
			this.grpFontSetting.Controls.Add(this.pnlViewFontW);
			this.grpFontSetting.Controls.Add(this.pnlViewFontYM);
			this.grpFontSetting.Controls.Add(this.btnFontDay);
			this.grpFontSetting.Controls.Add(this.btnFontWeek);
			this.grpFontSetting.Controls.Add(this.btnFontYearMonth);
			this.grpFontSetting.Location = new System.Drawing.Point(100, 6);
			this.grpFontSetting.Name = "grpFontSetting";
			this.grpFontSetting.Size = new System.Drawing.Size(266, 100);
			this.grpFontSetting.TabIndex = 2;
			this.grpFontSetting.TabStop = false;
			this.grpFontSetting.Text = "フォント";
			// 
			// pnlViewFontD
			// 
			this.pnlViewFontD.BackColor = System.Drawing.SystemColors.Control;
			this.pnlViewFontD.Controls.Add(this.lblViewFontDay);
			this.pnlViewFontD.Location = new System.Drawing.Point(168, 46);
			this.pnlViewFontD.Name = "pnlViewFontD";
			this.pnlViewFontD.Size = new System.Drawing.Size(75, 48);
			this.pnlViewFontD.TabIndex = 8;
			// 
			// lblViewFontDay
			// 
			this.lblViewFontDay.AutoSize = true;
			this.lblViewFontDay.BackColor = System.Drawing.Color.Transparent;
			this.lblViewFontDay.Location = new System.Drawing.Point(3, 14);
			this.lblViewFontDay.Name = "lblViewFontDay";
			this.lblViewFontDay.Size = new System.Drawing.Size(49, 12);
			this.lblViewFontDay.TabIndex = 5;
			this.lblViewFontDay.Tag = "FontDay";
			this.lblViewFontDay.Text = "12 13 14";
			// 
			// pnlViewFontW
			// 
			this.pnlViewFontW.BackColor = System.Drawing.SystemColors.Control;
			this.pnlViewFontW.Controls.Add(this.lblViewFontWeek);
			this.pnlViewFontW.Location = new System.Drawing.Point(87, 46);
			this.pnlViewFontW.Name = "pnlViewFontW";
			this.pnlViewFontW.Size = new System.Drawing.Size(75, 48);
			this.pnlViewFontW.TabIndex = 7;
			// 
			// lblViewFontWeek
			// 
			this.lblViewFontWeek.AutoSize = true;
			this.lblViewFontWeek.BackColor = System.Drawing.Color.Transparent;
			this.lblViewFontWeek.Location = new System.Drawing.Point(3, 14);
			this.lblViewFontWeek.Name = "lblViewFontWeek";
			this.lblViewFontWeek.Size = new System.Drawing.Size(42, 12);
			this.lblViewFontWeek.TabIndex = 4;
			this.lblViewFontWeek.Tag = "FontWeek";
			this.lblViewFontWeek.Text = "月 Mon";
			// 
			// pnlViewFontYM
			// 
			this.pnlViewFontYM.BackColor = System.Drawing.SystemColors.Control;
			this.pnlViewFontYM.Controls.Add(this.lblViewFontYearMonth);
			this.pnlViewFontYM.Location = new System.Drawing.Point(6, 46);
			this.pnlViewFontYM.Name = "pnlViewFontYM";
			this.pnlViewFontYM.Size = new System.Drawing.Size(75, 48);
			this.pnlViewFontYM.TabIndex = 6;
			// 
			// lblViewFontYearMonth
			// 
			this.lblViewFontYearMonth.AutoSize = true;
			this.lblViewFontYearMonth.BackColor = System.Drawing.Color.Transparent;
			this.lblViewFontYearMonth.Location = new System.Drawing.Point(3, 14);
			this.lblViewFontYearMonth.Name = "lblViewFontYearMonth";
			this.lblViewFontYearMonth.Size = new System.Drawing.Size(40, 12);
			this.lblViewFontYearMonth.TabIndex = 3;
			this.lblViewFontYearMonth.Tag = "FontYearMonth";
			this.lblViewFontYearMonth.Text = "20 Jan";
			// 
			// btnFontDay
			// 
			this.btnFontDay.Location = new System.Drawing.Point(168, 18);
			this.btnFontDay.Name = "btnFontDay";
			this.btnFontDay.Size = new System.Drawing.Size(75, 22);
			this.btnFontDay.TabIndex = 2;
			this.btnFontDay.Tag = "FontDay";
			this.btnFontDay.Text = "日にち";
			this.btnFontDay.UseVisualStyleBackColor = true;
			this.btnFontDay.Click += new System.EventHandler(this.btnFontSetting_Click);
			// 
			// btnFontWeek
			// 
			this.btnFontWeek.Location = new System.Drawing.Point(87, 18);
			this.btnFontWeek.Name = "btnFontWeek";
			this.btnFontWeek.Size = new System.Drawing.Size(75, 22);
			this.btnFontWeek.TabIndex = 1;
			this.btnFontWeek.Tag = "FontWeek";
			this.btnFontWeek.Text = "曜日";
			this.btnFontWeek.UseVisualStyleBackColor = true;
			this.btnFontWeek.Click += new System.EventHandler(this.btnFontSetting_Click);
			// 
			// btnFontYearMonth
			// 
			this.btnFontYearMonth.Location = new System.Drawing.Point(6, 18);
			this.btnFontYearMonth.Name = "btnFontYearMonth";
			this.btnFontYearMonth.Size = new System.Drawing.Size(75, 22);
			this.btnFontYearMonth.TabIndex = 0;
			this.btnFontYearMonth.Tag = "FontYearMonth";
			this.btnFontYearMonth.Text = "年/月";
			this.btnFontYearMonth.UseVisualStyleBackColor = true;
			this.btnFontYearMonth.Click += new System.EventHandler(this.btnFontSetting_Click);
			// 
			// tabSpecialDay
			// 
			this.tabSpecialDay.Controls.Add(this.grpSpdayList);
			this.tabSpecialDay.Controls.Add(this.grpSpdayRegist);
			this.tabSpecialDay.Location = new System.Drawing.Point(4, 22);
			this.tabSpecialDay.Name = "tabSpecialDay";
			this.tabSpecialDay.Padding = new System.Windows.Forms.Padding(3);
			this.tabSpecialDay.Size = new System.Drawing.Size(372, 194);
			this.tabSpecialDay.TabIndex = 3;
			this.tabSpecialDay.Text = "特別日";
			this.tabSpecialDay.UseVisualStyleBackColor = true;
			// 
			// grpSpdayList
			// 
			this.grpSpdayList.Controls.Add(this.btnSpdayDelete);
			this.grpSpdayList.Controls.Add(this.lstRegistSpecialDay);
			this.grpSpdayList.Location = new System.Drawing.Point(6, 86);
			this.grpSpdayList.Name = "grpSpdayList";
			this.grpSpdayList.Size = new System.Drawing.Size(360, 102);
			this.grpSpdayList.TabIndex = 8;
			this.grpSpdayList.TabStop = false;
			this.grpSpdayList.Text = "登録済み一覧";
			// 
			// btnSpdayDelete
			// 
			this.btnSpdayDelete.Location = new System.Drawing.Point(279, 71);
			this.btnSpdayDelete.Name = "btnSpdayDelete";
			this.btnSpdayDelete.Size = new System.Drawing.Size(75, 23);
			this.btnSpdayDelete.TabIndex = 5;
			this.btnSpdayDelete.Text = "削除";
			this.btnSpdayDelete.UseVisualStyleBackColor = true;
			this.btnSpdayDelete.Click += new System.EventHandler(this.btnSpdayDelete_Click);
			// 
			// lstRegistSpecialDay
			// 
			this.lstRegistSpecialDay.ColumnWidth = 80;
			this.lstRegistSpecialDay.FormattingEnabled = true;
			this.lstRegistSpecialDay.ItemHeight = 12;
			this.lstRegistSpecialDay.Location = new System.Drawing.Point(6, 18);
			this.lstRegistSpecialDay.MultiColumn = true;
			this.lstRegistSpecialDay.Name = "lstRegistSpecialDay";
			this.lstRegistSpecialDay.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
			this.lstRegistSpecialDay.Size = new System.Drawing.Size(265, 76);
			this.lstRegistSpecialDay.Sorted = true;
			this.lstRegistSpecialDay.TabIndex = 6;
			// 
			// grpSpdayRegist
			// 
			this.grpSpdayRegist.Controls.Add(this.pnlSpdaySetDay);
			this.grpSpdayRegist.Controls.Add(this.pnlSpdaySetWeek);
			this.grpSpdayRegist.Controls.Add(this.btnSpdayRegist);
			this.grpSpdayRegist.Controls.Add(this.rbSpdaySetWeek);
			this.grpSpdayRegist.Controls.Add(this.rbSpdaySetDay);
			this.grpSpdayRegist.Location = new System.Drawing.Point(6, 6);
			this.grpSpdayRegist.Name = "grpSpdayRegist";
			this.grpSpdayRegist.Size = new System.Drawing.Size(360, 74);
			this.grpSpdayRegist.TabIndex = 7;
			this.grpSpdayRegist.TabStop = false;
			this.grpSpdayRegist.Text = "登録";
			// 
			// pnlSpdaySetDay
			// 
			this.pnlSpdaySetDay.Controls.Add(this.udSpdayMonth);
			this.pnlSpdaySetDay.Controls.Add(this.udSpdayDay);
			this.pnlSpdaySetDay.Controls.Add(this.lblSpdayRegM);
			this.pnlSpdaySetDay.Controls.Add(this.lblSpdayRegD);
			this.pnlSpdaySetDay.Location = new System.Drawing.Point(93, 41);
			this.pnlSpdaySetDay.Name = "pnlSpdaySetDay";
			this.pnlSpdaySetDay.Size = new System.Drawing.Size(150, 24);
			this.pnlSpdaySetDay.TabIndex = 15;
			// 
			// udSpdayMonth
			// 
			this.udSpdayMonth.Location = new System.Drawing.Point(3, 3);
			this.udSpdayMonth.Maximum = new decimal(new int[] {
            12,
            0,
            0,
            0});
			this.udSpdayMonth.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
			this.udSpdayMonth.Name = "udSpdayMonth";
			this.udSpdayMonth.Size = new System.Drawing.Size(44, 19);
			this.udSpdayMonth.TabIndex = 0;
			this.udSpdayMonth.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
			// 
			// udSpdayDay
			// 
			this.udSpdayDay.Location = new System.Drawing.Point(72, 3);
			this.udSpdayDay.Maximum = new decimal(new int[] {
            31,
            0,
            0,
            0});
			this.udSpdayDay.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
			this.udSpdayDay.Name = "udSpdayDay";
			this.udSpdayDay.Size = new System.Drawing.Size(44, 19);
			this.udSpdayDay.TabIndex = 1;
			this.udSpdayDay.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
			// 
			// lblSpdayRegM
			// 
			this.lblSpdayRegM.AutoSize = true;
			this.lblSpdayRegM.Location = new System.Drawing.Point(49, 5);
			this.lblSpdayRegM.Name = "lblSpdayRegM";
			this.lblSpdayRegM.Size = new System.Drawing.Size(17, 12);
			this.lblSpdayRegM.TabIndex = 2;
			this.lblSpdayRegM.Text = "月";
			// 
			// lblSpdayRegD
			// 
			this.lblSpdayRegD.AutoSize = true;
			this.lblSpdayRegD.Location = new System.Drawing.Point(118, 5);
			this.lblSpdayRegD.Name = "lblSpdayRegD";
			this.lblSpdayRegD.Size = new System.Drawing.Size(17, 12);
			this.lblSpdayRegD.TabIndex = 3;
			this.lblSpdayRegD.Text = "日";
			// 
			// pnlSpdaySetWeek
			// 
			this.pnlSpdaySetWeek.Controls.Add(this.udSpdayWMonth);
			this.pnlSpdaySetWeek.Controls.Add(this.cbSpdayWWeek);
			this.pnlSpdaySetWeek.Controls.Add(this.lblSpdayRegWC);
			this.pnlSpdaySetWeek.Controls.Add(this.lblSpdayRegWM);
			this.pnlSpdaySetWeek.Controls.Add(this.udSpdayWCount);
			this.pnlSpdaySetWeek.Controls.Add(this.lblSpdayRegWW);
			this.pnlSpdaySetWeek.Enabled = false;
			this.pnlSpdaySetWeek.Location = new System.Drawing.Point(93, 14);
			this.pnlSpdaySetWeek.Name = "pnlSpdaySetWeek";
			this.pnlSpdaySetWeek.Size = new System.Drawing.Size(210, 24);
			this.pnlSpdaySetWeek.TabIndex = 14;
			// 
			// udSpdayWMonth
			// 
			this.udSpdayWMonth.Location = new System.Drawing.Point(3, 3);
			this.udSpdayWMonth.Maximum = new decimal(new int[] {
            12,
            0,
            0,
            0});
			this.udSpdayWMonth.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
			this.udSpdayWMonth.Name = "udSpdayWMonth";
			this.udSpdayWMonth.Size = new System.Drawing.Size(44, 19);
			this.udSpdayWMonth.TabIndex = 9;
			this.udSpdayWMonth.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
			// 
			// cbSpdayWWeek
			// 
			this.cbSpdayWWeek.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbSpdayWWeek.FormattingEnabled = true;
			this.cbSpdayWWeek.Items.AddRange(new object[] {
            "日",
            "月",
            "火",
            "水",
            "木",
            "金",
            "土"});
			this.cbSpdayWWeek.Location = new System.Drawing.Point(141, 2);
			this.cbSpdayWWeek.Name = "cbSpdayWWeek";
			this.cbSpdayWWeek.Size = new System.Drawing.Size(40, 20);
			this.cbSpdayWWeek.TabIndex = 13;
			// 
			// lblSpdayRegWC
			// 
			this.lblSpdayRegWC.AutoSize = true;
			this.lblSpdayRegWC.Location = new System.Drawing.Point(72, 5);
			this.lblSpdayRegWC.Name = "lblSpdayRegWC";
			this.lblSpdayRegWC.Size = new System.Drawing.Size(17, 12);
			this.lblSpdayRegWC.TabIndex = 12;
			this.lblSpdayRegWC.Text = "第";
			// 
			// lblSpdayRegWM
			// 
			this.lblSpdayRegWM.AutoSize = true;
			this.lblSpdayRegWM.Location = new System.Drawing.Point(49, 5);
			this.lblSpdayRegWM.Name = "lblSpdayRegWM";
			this.lblSpdayRegWM.Size = new System.Drawing.Size(17, 12);
			this.lblSpdayRegWM.TabIndex = 11;
			this.lblSpdayRegWM.Text = "月";
			// 
			// udSpdayWCount
			// 
			this.udSpdayWCount.Location = new System.Drawing.Point(91, 3);
			this.udSpdayWCount.Maximum = new decimal(new int[] {
            5,
            0,
            0,
            0});
			this.udSpdayWCount.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
			this.udSpdayWCount.Name = "udSpdayWCount";
			this.udSpdayWCount.Size = new System.Drawing.Size(44, 19);
			this.udSpdayWCount.TabIndex = 10;
			this.udSpdayWCount.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
			// 
			// lblSpdayRegWW
			// 
			this.lblSpdayRegWW.AutoSize = true;
			this.lblSpdayRegWW.Location = new System.Drawing.Point(184, 5);
			this.lblSpdayRegWW.Name = "lblSpdayRegWW";
			this.lblSpdayRegWW.Size = new System.Drawing.Size(17, 12);
			this.lblSpdayRegWW.TabIndex = 8;
			this.lblSpdayRegWW.Text = "曜";
			// 
			// btnSpdayRegist
			// 
			this.btnSpdayRegist.Location = new System.Drawing.Point(279, 45);
			this.btnSpdayRegist.Name = "btnSpdayRegist";
			this.btnSpdayRegist.Size = new System.Drawing.Size(75, 23);
			this.btnSpdayRegist.TabIndex = 4;
			this.btnSpdayRegist.Text = "登録";
			this.btnSpdayRegist.UseVisualStyleBackColor = true;
			this.btnSpdayRegist.Click += new System.EventHandler(this.btnSpdayRegist_Click);
			// 
			// rbSpdaySetWeek
			// 
			this.rbSpdaySetWeek.AutoSize = true;
			this.rbSpdaySetWeek.Location = new System.Drawing.Point(6, 17);
			this.rbSpdaySetWeek.Name = "rbSpdaySetWeek";
			this.rbSpdaySetWeek.Size = new System.Drawing.Size(81, 16);
			this.rbSpdaySetWeek.TabIndex = 6;
			this.rbSpdaySetWeek.Text = "曜日で指定";
			this.rbSpdaySetWeek.UseVisualStyleBackColor = true;
			this.rbSpdaySetWeek.CheckedChanged += new System.EventHandler(this.rbSpdaySetWeek_CheckedChanged);
			// 
			// rbSpdaySetDay
			// 
			this.rbSpdaySetDay.AutoSize = true;
			this.rbSpdaySetDay.Checked = true;
			this.rbSpdaySetDay.Location = new System.Drawing.Point(6, 44);
			this.rbSpdaySetDay.Name = "rbSpdaySetDay";
			this.rbSpdaySetDay.Size = new System.Drawing.Size(81, 16);
			this.rbSpdaySetDay.TabIndex = 5;
			this.rbSpdaySetDay.TabStop = true;
			this.rbSpdaySetDay.Text = "日付で指定";
			this.rbSpdaySetDay.UseVisualStyleBackColor = true;
			this.rbSpdaySetDay.CheckedChanged += new System.EventHandler(this.rbSpdaySetDay_CheckedChanged);
			// 
			// tabAdvanced
			// 
			this.tabAdvanced.Controls.Add(this.btnDayStrPreview);
			this.tabAdvanced.Controls.Add(this.pnlCanvas);
			this.tabAdvanced.Controls.Add(this.grpDayStrOffset);
			this.tabAdvanced.Controls.Add(this.grpDayCellSize);
			this.tabAdvanced.Location = new System.Drawing.Point(4, 22);
			this.tabAdvanced.Name = "tabAdvanced";
			this.tabAdvanced.Size = new System.Drawing.Size(372, 194);
			this.tabAdvanced.TabIndex = 5;
			this.tabAdvanced.Text = "高度な設定";
			this.tabAdvanced.UseVisualStyleBackColor = true;
			// 
			// btnDayStrPreview
			// 
			this.btnDayStrPreview.Location = new System.Drawing.Point(264, 161);
			this.btnDayStrPreview.Name = "btnDayStrPreview";
			this.btnDayStrPreview.Size = new System.Drawing.Size(92, 23);
			this.btnDayStrPreview.TabIndex = 4;
			this.btnDayStrPreview.Text = "確認";
			this.btnDayStrPreview.UseVisualStyleBackColor = true;
			this.btnDayStrPreview.Click += new System.EventHandler(this.btnPreviewDayStr_Click);
			// 
			// pnlCanvas
			// 
			this.pnlCanvas.BackColor = System.Drawing.Color.Transparent;
			this.pnlCanvas.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.pnlCanvas.Location = new System.Drawing.Point(6, 5);
			this.pnlCanvas.Name = "pnlCanvas";
			this.pnlCanvas.Size = new System.Drawing.Size(244, 186);
			this.pnlCanvas.TabIndex = 3;
			this.pnlCanvas.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlCanvas_Paint);
			// 
			// grpDayStrOffset
			// 
			this.grpDayStrOffset.Controls.Add(this.lblDayStrOffsetHeight);
			this.grpDayStrOffset.Controls.Add(this.udDayStrOffsetY);
			this.grpDayStrOffset.Controls.Add(this.lblDayStrOffsetWidth);
			this.grpDayStrOffset.Controls.Add(this.udDayStrOffsetX);
			this.grpDayStrOffset.Location = new System.Drawing.Point(256, 83);
			this.grpDayStrOffset.Name = "grpDayStrOffset";
			this.grpDayStrOffset.Size = new System.Drawing.Size(110, 72);
			this.grpDayStrOffset.TabIndex = 2;
			this.grpDayStrOffset.TabStop = false;
			this.grpDayStrOffset.Text = "文字の位置";
			// 
			// lblDayStrOffsetHeight
			// 
			this.lblDayStrOffsetHeight.AutoSize = true;
			this.lblDayStrOffsetHeight.Location = new System.Drawing.Point(6, 45);
			this.lblDayStrOffsetHeight.Name = "lblDayStrOffsetHeight";
			this.lblDayStrOffsetHeight.Size = new System.Drawing.Size(29, 12);
			this.lblDayStrOffsetHeight.TabIndex = 7;
			this.lblDayStrOffsetHeight.Text = "垂直";
			// 
			// udDayStrOffsetY
			// 
			this.udDayStrOffsetY.Location = new System.Drawing.Point(38, 43);
			this.udDayStrOffsetY.Name = "udDayStrOffsetY";
			this.udDayStrOffsetY.Size = new System.Drawing.Size(62, 19);
			this.udDayStrOffsetY.TabIndex = 6;
			this.udDayStrOffsetY.Tag = "DayStrOffsetY";
			this.udDayStrOffsetY.ValueChanged += new System.EventHandler(this.udControl_ValueChanged);
			// 
			// lblDayStrOffsetWidth
			// 
			this.lblDayStrOffsetWidth.AutoSize = true;
			this.lblDayStrOffsetWidth.Location = new System.Drawing.Point(6, 20);
			this.lblDayStrOffsetWidth.Name = "lblDayStrOffsetWidth";
			this.lblDayStrOffsetWidth.Size = new System.Drawing.Size(29, 12);
			this.lblDayStrOffsetWidth.TabIndex = 5;
			this.lblDayStrOffsetWidth.Text = "水平";
			// 
			// udDayStrOffsetX
			// 
			this.udDayStrOffsetX.Location = new System.Drawing.Point(38, 18);
			this.udDayStrOffsetX.Name = "udDayStrOffsetX";
			this.udDayStrOffsetX.Size = new System.Drawing.Size(62, 19);
			this.udDayStrOffsetX.TabIndex = 4;
			this.udDayStrOffsetX.Tag = "DayStrOffsetX";
			this.udDayStrOffsetX.ValueChanged += new System.EventHandler(this.udControl_ValueChanged);
			// 
			// grpDayCellSize
			// 
			this.grpDayCellSize.Controls.Add(this.lblDayCellHeight);
			this.grpDayCellSize.Controls.Add(this.udDayCellHeight);
			this.grpDayCellSize.Controls.Add(this.lblDayCellWidth);
			this.grpDayCellSize.Controls.Add(this.udDayCellWidth);
			this.grpDayCellSize.Location = new System.Drawing.Point(256, 5);
			this.grpDayCellSize.Name = "grpDayCellSize";
			this.grpDayCellSize.Size = new System.Drawing.Size(110, 72);
			this.grpDayCellSize.TabIndex = 1;
			this.grpDayCellSize.TabStop = false;
			this.grpDayCellSize.Text = "マスの大きさ";
			// 
			// lblDayCellHeight
			// 
			this.lblDayCellHeight.AutoSize = true;
			this.lblDayCellHeight.Location = new System.Drawing.Point(6, 45);
			this.lblDayCellHeight.Name = "lblDayCellHeight";
			this.lblDayCellHeight.Size = new System.Drawing.Size(25, 12);
			this.lblDayCellHeight.TabIndex = 3;
			this.lblDayCellHeight.Text = "高さ";
			// 
			// udDayCellHeight
			// 
			this.udDayCellHeight.Location = new System.Drawing.Point(38, 43);
			this.udDayCellHeight.Name = "udDayCellHeight";
			this.udDayCellHeight.Size = new System.Drawing.Size(62, 19);
			this.udDayCellHeight.TabIndex = 2;
			this.udDayCellHeight.Tag = "DayCellHeight";
			this.udDayCellHeight.ValueChanged += new System.EventHandler(this.udControl_ValueChanged);
			// 
			// lblDayCellWidth
			// 
			this.lblDayCellWidth.AutoSize = true;
			this.lblDayCellWidth.Location = new System.Drawing.Point(6, 20);
			this.lblDayCellWidth.Name = "lblDayCellWidth";
			this.lblDayCellWidth.Size = new System.Drawing.Size(17, 12);
			this.lblDayCellWidth.TabIndex = 1;
			this.lblDayCellWidth.Text = "幅";
			// 
			// udDayCellWidth
			// 
			this.udDayCellWidth.Location = new System.Drawing.Point(38, 18);
			this.udDayCellWidth.Name = "udDayCellWidth";
			this.udDayCellWidth.Size = new System.Drawing.Size(62, 19);
			this.udDayCellWidth.TabIndex = 0;
			this.udDayCellWidth.Tag = "DayCellWidth";
			this.udDayCellWidth.ValueChanged += new System.EventHandler(this.udControl_ValueChanged);
			// 
			// tabOption
			// 
			this.tabOption.Controls.Add(this.grpAppClose);
			this.tabOption.Controls.Add(this.grpOption);
			this.tabOption.Controls.Add(this.grpStartup);
			this.tabOption.Location = new System.Drawing.Point(4, 22);
			this.tabOption.Name = "tabOption";
			this.tabOption.Padding = new System.Windows.Forms.Padding(3);
			this.tabOption.Size = new System.Drawing.Size(372, 194);
			this.tabOption.TabIndex = 4;
			this.tabOption.Text = "オプション";
			this.tabOption.UseVisualStyleBackColor = true;
			// 
			// grpAppClose
			// 
			this.grpAppClose.Controls.Add(this.lblOptAppClose);
			this.grpAppClose.Controls.Add(this.rbAppCloseEnd);
			this.grpAppClose.Controls.Add(this.rbAppCloseResident);
			this.grpAppClose.Enabled = false;
			this.grpAppClose.Location = new System.Drawing.Point(6, 98);
			this.grpAppClose.Name = "grpAppClose";
			this.grpAppClose.Size = new System.Drawing.Size(224, 90);
			this.grpAppClose.TabIndex = 3;
			this.grpAppClose.TabStop = false;
			this.grpAppClose.Tag = "RbAppCloseState";
			this.grpAppClose.Text = "アプリ終了/[X]ボタン押下時";
			// 
			// lblOptAppClose
			// 
			this.lblOptAppClose.AutoSize = true;
			this.lblOptAppClose.Location = new System.Drawing.Point(6, 19);
			this.lblOptAppClose.Name = "lblOptAppClose";
			this.lblOptAppClose.Size = new System.Drawing.Size(156, 12);
			this.lblOptAppClose.TabIndex = 2;
			this.lblOptAppClose.Text = "スタートアップの設定に関係なく、";
			// 
			// rbAppCloseEnd
			// 
			this.rbAppCloseEnd.AutoSize = true;
			this.rbAppCloseEnd.Checked = true;
			this.rbAppCloseEnd.Location = new System.Drawing.Point(6, 58);
			this.rbAppCloseEnd.Name = "rbAppCloseEnd";
			this.rbAppCloseEnd.Size = new System.Drawing.Size(210, 16);
			this.rbAppCloseEnd.TabIndex = 1;
			this.rbAppCloseEnd.TabStop = true;
			this.rbAppCloseEnd.Tag = "1";
			this.rbAppCloseEnd.Text = "終了する (カレンダーを自動更新しない)";
			this.rbAppCloseEnd.UseVisualStyleBackColor = true;
			// 
			// rbAppCloseResident
			// 
			this.rbAppCloseResident.AutoSize = true;
			this.rbAppCloseResident.Location = new System.Drawing.Point(6, 36);
			this.rbAppCloseResident.Name = "rbAppCloseResident";
			this.rbAppCloseResident.Size = new System.Drawing.Size(200, 16);
			this.rbAppCloseResident.TabIndex = 0;
			this.rbAppCloseResident.Tag = "0";
			this.rbAppCloseResident.Text = "常駐する (カレンダーを自動更新する)";
			this.rbAppCloseResident.UseVisualStyleBackColor = true;
			// 
			// grpOption
			// 
			this.grpOption.Controls.Add(this.btnCaClear);
			this.grpOption.Controls.Add(this.btnAbout);
			this.grpOption.Location = new System.Drawing.Point(236, 98);
			this.grpOption.Name = "grpOption";
			this.grpOption.Size = new System.Drawing.Size(130, 90);
			this.grpOption.TabIndex = 2;
			this.grpOption.TabStop = false;
			this.grpOption.Text = "その他";
			// 
			// btnCaClear
			// 
			this.btnCaClear.Location = new System.Drawing.Point(6, 18);
			this.btnCaClear.Name = "btnCaClear";
			this.btnCaClear.Size = new System.Drawing.Size(118, 23);
			this.btnCaClear.TabIndex = 2;
			this.btnCaClear.Text = "カレンダーを消去する";
			this.btnCaClear.UseVisualStyleBackColor = true;
			this.btnCaClear.Click += new System.EventHandler(this.btnCaClear_Click);
			// 
			// btnAbout
			// 
			this.btnAbout.Location = new System.Drawing.Point(6, 47);
			this.btnAbout.Name = "btnAbout";
			this.btnAbout.Size = new System.Drawing.Size(118, 23);
			this.btnAbout.TabIndex = 1;
			this.btnAbout.Text = "バージョン情報";
			this.btnAbout.UseVisualStyleBackColor = true;
			this.btnAbout.Click += new System.EventHandler(this.btnAbout_Click);
			// 
			// grpStartup
			// 
			this.grpStartup.Controls.Add(this.rbStartupNone);
			this.grpStartup.Controls.Add(this.rbStartupDaily);
			this.grpStartup.Controls.Add(this.rbStartupOnce);
			this.grpStartup.Enabled = false;
			this.grpStartup.Location = new System.Drawing.Point(6, 6);
			this.grpStartup.Name = "grpStartup";
			this.grpStartup.Size = new System.Drawing.Size(360, 86);
			this.grpStartup.TabIndex = 1;
			this.grpStartup.TabStop = false;
			this.grpStartup.Tag = "RbStartupParam";
			this.grpStartup.Text = "スタートアップ登録";
			// 
			// rbStartupNone
			// 
			this.rbStartupNone.AutoSize = true;
			this.rbStartupNone.Checked = true;
			this.rbStartupNone.Location = new System.Drawing.Point(6, 62);
			this.rbStartupNone.Name = "rbStartupNone";
			this.rbStartupNone.Size = new System.Drawing.Size(234, 16);
			this.rbStartupNone.TabIndex = 2;
			this.rbStartupNone.TabStop = true;
			this.rbStartupNone.Tag = "2";
			this.rbStartupNone.Text = "スタートアップに登録しない / 登録を取り消す";
			this.rbStartupNone.UseVisualStyleBackColor = true;
			// 
			// rbStartupDaily
			// 
			this.rbStartupDaily.AutoSize = true;
			this.rbStartupDaily.Location = new System.Drawing.Point(6, 18);
			this.rbStartupDaily.Name = "rbStartupDaily";
			this.rbStartupDaily.Size = new System.Drawing.Size(288, 16);
			this.rbStartupDaily.TabIndex = 0;
			this.rbStartupDaily.Tag = "0";
			this.rbStartupDaily.Text = "深夜０時にカレンダーを自動更新する (アプリは常駐する)";
			this.rbStartupDaily.UseVisualStyleBackColor = true;
			// 
			// rbStartupOnce
			// 
			this.rbStartupOnce.AutoSize = true;
			this.rbStartupOnce.Location = new System.Drawing.Point(6, 40);
			this.rbStartupOnce.Name = "rbStartupOnce";
			this.rbStartupOnce.Size = new System.Drawing.Size(300, 16);
			this.rbStartupOnce.TabIndex = 1;
			this.rbStartupOnce.Tag = "1";
			this.rbStartupOnce.Text = "PC起動時にだけカレンダーを更新する (アプリは常駐しない)";
			this.rbStartupOnce.UseVisualStyleBackColor = true;
			// 
			// fontDlg
			// 
			this.fontDlg.AllowVerticalFonts = false;
			// 
			// pnlIcon
			// 
			this.pnlIcon.BackColor = System.Drawing.Color.Transparent;
			this.pnlIcon.Location = new System.Drawing.Point(6, 227);
			this.pnlIcon.Name = "pnlIcon";
			this.pnlIcon.Size = new System.Drawing.Size(32, 32);
			this.pnlIcon.TabIndex = 5;
			// 
			// FmMain
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(384, 262);
			this.Controls.Add(this.pnlIcon);
			this.Controls.Add(this.tabMenu);
			this.Controls.Add(this.btnCaDraw);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "FmMain";
			this.Text = "FmMain";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FmMain_FormClosing);
			this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FmMain_FormClosed);
			this.Load += new System.EventHandler(this.FmMain_Load);
			this.grpColorSetting.ResumeLayout(false);
			this.grpCharGap.ResumeLayout(false);
			this.grpCharGap.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.udWeekToDay)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.udDayVertical)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.udYMToWeek)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.udMonthToMonth)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.udDayHolizon)).EndInit();
			this.tabMenu.ResumeLayout(false);
			this.tabLayout.ResumeLayout(false);
			this.grpStartWeek.ResumeLayout(false);
			this.grpStartWeek.PerformLayout();
			this.grpLocation.ResumeLayout(false);
			this.grpLocation.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.udOriginX)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.udOriginY)).EndInit();
			this.grpMonthChange.ResumeLayout(false);
			this.grpMonthChange.PerformLayout();
			this.grpMonthOrder.ResumeLayout(false);
			this.grpMonthOrder.PerformLayout();
			this.tabFormat.ResumeLayout(false);
			this.tabFormat.PerformLayout();
			this.grpFormatWeek.ResumeLayout(false);
			this.grpFormatYM.ResumeLayout(false);
			this.grpFormatYM.PerformLayout();
			this.tabColorSetting.ResumeLayout(false);
			this.grpCharEffect.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.udShadowWidth)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.udTodayBgWidth)).EndInit();
			this.grpFontSetting.ResumeLayout(false);
			this.pnlViewFontD.ResumeLayout(false);
			this.pnlViewFontD.PerformLayout();
			this.pnlViewFontW.ResumeLayout(false);
			this.pnlViewFontW.PerformLayout();
			this.pnlViewFontYM.ResumeLayout(false);
			this.pnlViewFontYM.PerformLayout();
			this.tabSpecialDay.ResumeLayout(false);
			this.grpSpdayList.ResumeLayout(false);
			this.grpSpdayRegist.ResumeLayout(false);
			this.grpSpdayRegist.PerformLayout();
			this.pnlSpdaySetDay.ResumeLayout(false);
			this.pnlSpdaySetDay.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.udSpdayMonth)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.udSpdayDay)).EndInit();
			this.pnlSpdaySetWeek.ResumeLayout(false);
			this.pnlSpdaySetWeek.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.udSpdayWMonth)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.udSpdayWCount)).EndInit();
			this.tabAdvanced.ResumeLayout(false);
			this.grpDayStrOffset.ResumeLayout(false);
			this.grpDayStrOffset.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.udDayStrOffsetY)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.udDayStrOffsetX)).EndInit();
			this.grpDayCellSize.ResumeLayout(false);
			this.grpDayCellSize.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.udDayCellHeight)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.udDayCellWidth)).EndInit();
			this.tabOption.ResumeLayout(false);
			this.grpAppClose.ResumeLayout(false);
			this.grpAppClose.PerformLayout();
			this.grpOption.ResumeLayout(false);
			this.grpStartup.ResumeLayout(false);
			this.grpStartup.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Button btnCaDraw;
		private System.Windows.Forms.ColorDialog colorDlg;
		private System.Windows.Forms.GroupBox grpColorSetting;
		private System.Windows.Forms.Button btnColorSpecialDay;
		private System.Windows.Forms.Button btnColorSunday;
		private System.Windows.Forms.Button btnColorSaturday;
		private System.Windows.Forms.Button btnColorWeekday;
		private System.Windows.Forms.Button btnColorShadow;
		private System.Windows.Forms.Button btnColorYearMonth;
		private System.Windows.Forms.Button btnColorTodayBg;
		private System.Windows.Forms.GroupBox grpCharGap;
		private System.Windows.Forms.TabControl tabMenu;
		private System.Windows.Forms.TabPage tabLayout;
		private System.Windows.Forms.TabPage tabColorSetting;
		private System.Windows.Forms.GroupBox grpMonthOrder;
		private System.Windows.Forms.ComboBox cbMonthOrder;
		private System.Windows.Forms.RadioButton rbChangeMidMonth;
		private System.Windows.Forms.RadioButton rbChangeFirstDay;
		private System.Windows.Forms.GroupBox grpMonthChange;
		private System.Windows.Forms.RadioButton rbMonthVertical;
		private System.Windows.Forms.RadioButton rbMonthHolizon;
		private System.Windows.Forms.Label lblOrgY;
		private System.Windows.Forms.NumericUpDown udOriginY;
		private System.Windows.Forms.Label lblOrgX;
		private System.Windows.Forms.NumericUpDown udOriginX;
		private System.Windows.Forms.NumericUpDown udMonthToMonth;
		private System.Windows.Forms.Label lblMToM;
		private System.Windows.Forms.NumericUpDown udWeekToDay;
		private System.Windows.Forms.Label lblWToD;
		private System.Windows.Forms.NumericUpDown udYMToWeek;
		private System.Windows.Forms.Label lblYMToW;
		private System.Windows.Forms.Label lblDToDV;
		private System.Windows.Forms.NumericUpDown udDayVertical;
		private System.Windows.Forms.Label lblDToDH;
		private System.Windows.Forms.NumericUpDown udDayHolizon;
		private System.Windows.Forms.GroupBox grpFontSetting;
		private System.Windows.Forms.Button btnFontYearMonth;
		private System.Windows.Forms.Button btnFontDay;
		private System.Windows.Forms.Button btnFontWeek;
		private System.Windows.Forms.Label lblViewFontDay;
		private System.Windows.Forms.Label lblViewFontWeek;
		private System.Windows.Forms.Label lblViewFontYearMonth;
		private System.Windows.Forms.TabPage tabFormat;
		private System.Windows.Forms.GroupBox grpFormatYM;
		private System.Windows.Forms.GroupBox grpLocation;
		private System.Windows.Forms.Label lblYearMonthFormat;
		private System.Windows.Forms.Label lblFormatViewYM;
		private System.Windows.Forms.TextBox tbUserFormatYM;
		private System.Windows.Forms.Label lblDToD;
		private System.Windows.Forms.GroupBox grpStartWeek;
		private System.Windows.Forms.RadioButton rbMondayStart;
		private System.Windows.Forms.RadioButton rbSundayStart;
		private System.Windows.Forms.Label lblFmtText;
		private System.Windows.Forms.Button btnFmtView;
		private System.Windows.Forms.FontDialog fontDlg;
		private System.Windows.Forms.GroupBox grpFormatWeek;
		private System.Windows.Forms.ComboBox cbUserFormatW;
		private System.Windows.Forms.TabPage tabSpecialDay;
		private System.Windows.Forms.ListBox lstRegistSpecialDay;
		private System.Windows.Forms.Button btnSpdayDelete;
		private System.Windows.Forms.Button btnSpdayRegist;
		private System.Windows.Forms.Label lblSpdayRegD;
		private System.Windows.Forms.Label lblSpdayRegM;
		private System.Windows.Forms.NumericUpDown udSpdayDay;
		private System.Windows.Forms.NumericUpDown udSpdayMonth;
		private System.Windows.Forms.GroupBox grpSpdayRegist;
		private System.Windows.Forms.Panel pnlViewFontYM;
		private System.Windows.Forms.Label lblYMCentering;
		private System.Windows.Forms.RadioButton rbYMPosRight;
		private System.Windows.Forms.RadioButton rbYMPosCenter;
		private System.Windows.Forms.RadioButton rbYMPosLeft;
		private System.Windows.Forms.GroupBox grpSpdayList;
		private System.Windows.Forms.NumericUpDown udSpdayWCount;
		private System.Windows.Forms.NumericUpDown udSpdayWMonth;
		private System.Windows.Forms.Label lblSpdayRegWM;
		private System.Windows.Forms.Label lblSpdayRegWC;
		private System.Windows.Forms.Label lblSpdayRegWW;
		private System.Windows.Forms.RadioButton rbSpdaySetWeek;
		private System.Windows.Forms.RadioButton rbSpdaySetDay;
		private System.Windows.Forms.ComboBox cbSpdayWWeek;
		private System.Windows.Forms.Panel pnlSpdaySetDay;
		private System.Windows.Forms.Panel pnlSpdaySetWeek;
		private System.Windows.Forms.TabPage tabOption;
		private System.Windows.Forms.GroupBox grpOption;
		private System.Windows.Forms.GroupBox grpStartup;
		private System.Windows.Forms.RadioButton rbStartupNone;
		private System.Windows.Forms.RadioButton rbStartupDaily;
		private System.Windows.Forms.RadioButton rbStartupOnce;
		private System.Windows.Forms.Button btnAbout;
		private System.Windows.Forms.GroupBox grpAppClose;
		private System.Windows.Forms.Label lblOptAppClose;
		private System.Windows.Forms.RadioButton rbAppCloseEnd;
		private System.Windows.Forms.RadioButton rbAppCloseResident;
		private System.Windows.Forms.Button btnCaClear;
		private System.Windows.Forms.Panel pnlIcon;
		private System.Windows.Forms.ComboBox cbEffectShadow;
		private System.Windows.Forms.ComboBox cbEffectTodayBg;
		private System.Windows.Forms.GroupBox grpCharEffect;
		private System.Windows.Forms.NumericUpDown udShadowWidth;
		private System.Windows.Forms.NumericUpDown udTodayBgWidth;
		private System.Windows.Forms.Panel pnlViewFontD;
		private System.Windows.Forms.Panel pnlViewFontW;
		private System.Windows.Forms.TabPage tabAdvanced;
		private System.Windows.Forms.GroupBox grpDayCellSize;
		private System.Windows.Forms.GroupBox grpDayStrOffset;
		private System.Windows.Forms.NumericUpDown udDayCellWidth;
		private System.Windows.Forms.Label lblDayCellHeight;
		private System.Windows.Forms.NumericUpDown udDayCellHeight;
		private System.Windows.Forms.Label lblDayCellWidth;
		private System.Windows.Forms.Label lblDayStrOffsetHeight;
		private System.Windows.Forms.NumericUpDown udDayStrOffsetY;
		private System.Windows.Forms.Label lblDayStrOffsetWidth;
		private System.Windows.Forms.NumericUpDown udDayStrOffsetX;
		private System.Windows.Forms.Button btnDayStrPreview;
		private System.Windows.Forms.Panel pnlCanvas;
	}
}

