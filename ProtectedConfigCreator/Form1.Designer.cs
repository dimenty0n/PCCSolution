namespace ProtectedConfigCreator
{
	partial class Form1
	{
		/// <summary>
		/// Обязательная переменная конструктора.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Освободить все используемые ресурсы.
		/// </summary>
		/// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Код, автоматически созданный конструктором форм Windows

		/// <summary>
		/// Требуемый метод для поддержки конструктора — не изменяйте 
		/// содержимое этого метода с помощью редактора кода.
		/// </summary>
		private void InitializeComponent()
		{
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.dBaseFileMode = new System.Windows.Forms.CheckBox();
            this.button4 = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.enterprisePath = new System.Windows.Forms.TextBox();
            this.selectEnterprisePath = new System.Windows.Forms.Button();
            this.labelEnterprisePath = new System.Windows.Forms.Label();
            this.labelDBaseDir = new System.Windows.Forms.Label();
            this.selectDBaseDir = new System.Windows.Forms.Button();
            this.dBaseDir = new System.Windows.Forms.TextBox();
            this.labelCfFileDir = new System.Windows.Forms.Label();
            this.selectCfFileDir = new System.Windows.Forms.Button();
            this.cfFileDir = new System.Windows.Forms.TextBox();
            this.labelEpfSrcDir = new System.Windows.Forms.Label();
            this.selectEpfSrcDir = new System.Windows.Forms.Button();
            this.epfSrcDir = new System.Windows.Forms.TextBox();
            this.labelEpfFileDir = new System.Windows.Forms.Label();
            this.selectV8UnpackPath = new System.Windows.Forms.Button();
            this.v8UnpackPath = new System.Windows.Forms.TextBox();
            this.labelV8UnpackPath = new System.Windows.Forms.Label();
            this.selectEpfFileDir = new System.Windows.Forms.Button();
            this.epfFileDir = new System.Windows.Forms.TextBox();
            this.labelModuleNames = new System.Windows.Forms.Label();
            this.moduleNames = new System.Windows.Forms.TextBox();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabControl2 = new System.Windows.Forms.TabControl();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.dBaseUserPass = new System.Windows.Forms.TextBox();
            this.labelDBasePassword = new System.Windows.Forms.Label();
            this.dBaseUserName = new System.Windows.Forms.TextBox();
            this.labelDBaseUser = new System.Windows.Forms.Label();
            this.labelDBaseServerName = new System.Windows.Forms.Label();
            this.dBaseName = new System.Windows.Forms.TextBox();
            this.dBaseServerName = new System.Windows.Forms.TextBox();
            this.labelDBaseName = new System.Windows.Forms.Label();
            this.tabPage5 = new System.Windows.Forms.TabPage();
            this.dBaseProtectedUserPass = new System.Windows.Forms.TextBox();
            this.labelDBaseProtectedPassword = new System.Windows.Forms.Label();
            this.dBaseProtectedUserName = new System.Windows.Forms.TextBox();
            this.labelDBaseProtectedUser = new System.Windows.Forms.Label();
            this.dBaseProtectedName = new System.Windows.Forms.TextBox();
            this.labelDBaseProtectedName = new System.Windows.Forms.Label();
            this.dBaseProtectedServerName = new System.Windows.Forms.TextBox();
            this.labelDBaseProtectedServerName = new System.Windows.Forms.Label();
            this.dBaseProtectedFileMode = new System.Windows.Forms.CheckBox();
            this.dBaseProtectedDir = new System.Windows.Forms.TextBox();
            this.selectProtectedDBaseDir = new System.Windows.Forms.Button();
            this.labelDBaseProtectedDir = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.labelKeySeries = new System.Windows.Forms.Label();
            this.keySeries = new System.Windows.Forms.TextBox();
            this.licenceEditDir = new System.Windows.Forms.TextBox();
            this.labelLicenceEditDir = new System.Windows.Forms.Label();
            this.selectLicenceEditDir = new System.Windows.Forms.Button();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabControl2.SuspendLayout();
            this.tabPage4.SuspendLayout();
            this.tabPage5.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.SuspendLayout();
            // 
            // dBaseFileMode
            // 
            this.dBaseFileMode.AutoSize = true;
            this.dBaseFileMode.Location = new System.Drawing.Point(7, 6);
            this.dBaseFileMode.Name = "dBaseFileMode";
            this.dBaseFileMode.Size = new System.Drawing.Size(118, 17);
            this.dBaseFileMode.TabIndex = 13;
            this.dBaseFileMode.Text = "Файловый режим";
            this.dBaseFileMode.UseVisualStyleBackColor = true;
            this.dBaseFileMode.CheckedChanged += new System.EventHandler(this.DBaseFileMode_CheckedChanged);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(584, 464);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(75, 23);
            this.button4.TabIndex = 3;
            this.button4.Text = "Выполнить";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.Button4_Click);
            // 
            // enterprisePath
            // 
            this.enterprisePath.Location = new System.Drawing.Point(6, 336);
            this.enterprisePath.Name = "enterprisePath";
            this.enterprisePath.Size = new System.Drawing.Size(593, 20);
            this.enterprisePath.TabIndex = 4;
            // 
            // selectEnterprisePath
            // 
            this.selectEnterprisePath.Location = new System.Drawing.Point(606, 336);
            this.selectEnterprisePath.Name = "selectEnterprisePath";
            this.selectEnterprisePath.Size = new System.Drawing.Size(24, 20);
            this.selectEnterprisePath.TabIndex = 5;
            this.selectEnterprisePath.Text = "...";
            this.selectEnterprisePath.UseVisualStyleBackColor = true;
            this.selectEnterprisePath.Click += new System.EventHandler(this.SelectEnterprisePath_Click);
            // 
            // labelEnterprisePath
            // 
            this.labelEnterprisePath.Location = new System.Drawing.Point(6, 312);
            this.labelEnterprisePath.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelEnterprisePath.Name = "labelEnterprisePath";
            this.labelEnterprisePath.Size = new System.Drawing.Size(593, 20);
            this.labelEnterprisePath.TabIndex = 6;
            this.labelEnterprisePath.Text = "Платформа:";
            // 
            // labelDBaseDir
            // 
            this.labelDBaseDir.Enabled = false;
            this.labelDBaseDir.Location = new System.Drawing.Point(7, 30);
            this.labelDBaseDir.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelDBaseDir.Name = "labelDBaseDir";
            this.labelDBaseDir.Size = new System.Drawing.Size(593, 20);
            this.labelDBaseDir.TabIndex = 9;
            this.labelDBaseDir.Text = "Каталог информационной базы:";
            // 
            // selectDBaseDir
            // 
            this.selectDBaseDir.Enabled = false;
            this.selectDBaseDir.Location = new System.Drawing.Point(606, 52);
            this.selectDBaseDir.Name = "selectDBaseDir";
            this.selectDBaseDir.Size = new System.Drawing.Size(24, 20);
            this.selectDBaseDir.TabIndex = 8;
            this.selectDBaseDir.Text = "...";
            this.selectDBaseDir.UseVisualStyleBackColor = true;
            this.selectDBaseDir.Click += new System.EventHandler(this.SelectDBaseDir_Click);
            // 
            // dBaseDir
            // 
            this.dBaseDir.Enabled = false;
            this.dBaseDir.Location = new System.Drawing.Point(7, 52);
            this.dBaseDir.Name = "dBaseDir";
            this.dBaseDir.Size = new System.Drawing.Size(593, 20);
            this.dBaseDir.TabIndex = 7;
            // 
            // labelCfFileDir
            // 
            this.labelCfFileDir.Location = new System.Drawing.Point(6, 360);
            this.labelCfFileDir.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelCfFileDir.Name = "labelCfFileDir";
            this.labelCfFileDir.Size = new System.Drawing.Size(593, 20);
            this.labelCfFileDir.TabIndex = 12;
            this.labelCfFileDir.Text = "Каталог для выгрузки файлов конфигурации:";
            // 
            // selectCfFileDir
            // 
            this.selectCfFileDir.Location = new System.Drawing.Point(606, 384);
            this.selectCfFileDir.Name = "selectCfFileDir";
            this.selectCfFileDir.Size = new System.Drawing.Size(24, 20);
            this.selectCfFileDir.TabIndex = 11;
            this.selectCfFileDir.Text = "...";
            this.selectCfFileDir.UseVisualStyleBackColor = true;
            this.selectCfFileDir.Click += new System.EventHandler(this.SelectCfFileDir_Click);
            // 
            // cfFileDir
            // 
            this.cfFileDir.Location = new System.Drawing.Point(6, 384);
            this.cfFileDir.Name = "cfFileDir";
            this.cfFileDir.Size = new System.Drawing.Size(593, 20);
            this.cfFileDir.TabIndex = 10;
            // 
            // labelEpfSrcDir
            // 
            this.labelEpfSrcDir.Location = new System.Drawing.Point(14, 66);
            this.labelEpfSrcDir.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelEpfSrcDir.Name = "labelEpfSrcDir";
            this.labelEpfSrcDir.Size = new System.Drawing.Size(582, 22);
            this.labelEpfSrcDir.TabIndex = 15;
            this.labelEpfSrcDir.Text = "Каталог исходных файлов обработки";
            this.labelEpfSrcDir.Click += new System.EventHandler(this.labelEpfSrcDir_Click);
            // 
            // selectEpfSrcDir
            // 
            this.selectEpfSrcDir.Location = new System.Drawing.Point(605, 92);
            this.selectEpfSrcDir.Name = "selectEpfSrcDir";
            this.selectEpfSrcDir.Size = new System.Drawing.Size(24, 20);
            this.selectEpfSrcDir.TabIndex = 14;
            this.selectEpfSrcDir.Text = "...";
            this.selectEpfSrcDir.UseVisualStyleBackColor = true;
            this.selectEpfSrcDir.Click += new System.EventHandler(this.SelectEpfSrcDir_Click);
            // 
            // epfSrcDir
            // 
            this.epfSrcDir.Location = new System.Drawing.Point(14, 92);
            this.epfSrcDir.Name = "epfSrcDir";
            this.epfSrcDir.Size = new System.Drawing.Size(582, 20);
            this.epfSrcDir.TabIndex = 13;
            // 
            // labelEpfFileDir
            // 
            this.labelEpfFileDir.Location = new System.Drawing.Point(14, 166);
            this.labelEpfFileDir.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelEpfFileDir.Name = "labelEpfFileDir";
            this.labelEpfFileDir.Size = new System.Drawing.Size(582, 22);
            this.labelEpfFileDir.TabIndex = 18;
            this.labelEpfFileDir.Text = "Каталог для сохранения обработок";
            // 
            // selectV8UnpackPath
            // 
            this.selectV8UnpackPath.Location = new System.Drawing.Point(605, 142);
            this.selectV8UnpackPath.Name = "selectV8UnpackPath";
            this.selectV8UnpackPath.Size = new System.Drawing.Size(24, 20);
            this.selectV8UnpackPath.TabIndex = 17;
            this.selectV8UnpackPath.Text = "...";
            this.selectV8UnpackPath.UseVisualStyleBackColor = true;
            this.selectV8UnpackPath.Click += new System.EventHandler(this.SelectV8UnpackPath_Click);
            // 
            // v8UnpackPath
            // 
            this.v8UnpackPath.Location = new System.Drawing.Point(14, 142);
            this.v8UnpackPath.Name = "v8UnpackPath";
            this.v8UnpackPath.Size = new System.Drawing.Size(582, 20);
            this.v8UnpackPath.TabIndex = 16;
            // 
            // labelV8UnpackPath
            // 
            this.labelV8UnpackPath.Location = new System.Drawing.Point(14, 116);
            this.labelV8UnpackPath.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelV8UnpackPath.Name = "labelV8UnpackPath";
            this.labelV8UnpackPath.Size = new System.Drawing.Size(582, 22);
            this.labelV8UnpackPath.TabIndex = 21;
            this.labelV8UnpackPath.Text = "V8Unpack";
            // 
            // selectEpfFileDir
            // 
            this.selectEpfFileDir.Location = new System.Drawing.Point(605, 192);
            this.selectEpfFileDir.Name = "selectEpfFileDir";
            this.selectEpfFileDir.Size = new System.Drawing.Size(24, 20);
            this.selectEpfFileDir.TabIndex = 20;
            this.selectEpfFileDir.Text = "...";
            this.selectEpfFileDir.UseVisualStyleBackColor = true;
            this.selectEpfFileDir.Click += new System.EventHandler(this.SelectEpfFileDir_Click);
            // 
            // epfFileDir
            // 
            this.epfFileDir.Location = new System.Drawing.Point(14, 192);
            this.epfFileDir.Name = "epfFileDir";
            this.epfFileDir.Size = new System.Drawing.Size(582, 20);
            this.epfFileDir.TabIndex = 19;
            // 
            // labelModuleNames
            // 
            this.labelModuleNames.Location = new System.Drawing.Point(14, 216);
            this.labelModuleNames.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelModuleNames.Name = "labelModuleNames";
            this.labelModuleNames.Size = new System.Drawing.Size(582, 22);
            this.labelModuleNames.TabIndex = 24;
            this.labelModuleNames.Text = "Список имен защищаемых модулей";
            // 
            // moduleNames
            // 
            this.moduleNames.Location = new System.Drawing.Point(14, 242);
            this.moduleNames.Multiline = true;
            this.moduleNames.Name = "moduleNames";
            this.moduleNames.Size = new System.Drawing.Size(582, 114);
            this.moduleNames.TabIndex = 22;
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(7, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(652, 446);
            this.tabControl1.TabIndex = 28;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.tabControl2);
            this.tabPage1.Controls.Add(this.enterprisePath);
            this.tabPage1.Controls.Add(this.selectEnterprisePath);
            this.tabPage1.Controls.Add(this.labelEnterprisePath);
            this.tabPage1.Controls.Add(this.cfFileDir);
            this.tabPage1.Controls.Add(this.labelCfFileDir);
            this.tabPage1.Controls.Add(this.selectCfFileDir);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(644, 420);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Параметры ИБ";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabControl2
            // 
            this.tabControl2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl2.Controls.Add(this.tabPage4);
            this.tabControl2.Controls.Add(this.tabPage5);
            this.tabControl2.Location = new System.Drawing.Point(0, 0);
            this.tabControl2.Name = "tabControl2";
            this.tabControl2.SelectedIndex = 0;
            this.tabControl2.Size = new System.Drawing.Size(644, 298);
            this.tabControl2.TabIndex = 22;
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.dBaseFileMode);
            this.tabPage4.Controls.Add(this.dBaseUserPass);
            this.tabPage4.Controls.Add(this.labelDBaseDir);
            this.tabPage4.Controls.Add(this.labelDBasePassword);
            this.tabPage4.Controls.Add(this.selectDBaseDir);
            this.tabPage4.Controls.Add(this.dBaseUserName);
            this.tabPage4.Controls.Add(this.dBaseDir);
            this.tabPage4.Controls.Add(this.labelDBaseUser);
            this.tabPage4.Controls.Add(this.labelDBaseServerName);
            this.tabPage4.Controls.Add(this.dBaseName);
            this.tabPage4.Controls.Add(this.dBaseServerName);
            this.tabPage4.Controls.Add(this.labelDBaseName);
            this.tabPage4.Location = new System.Drawing.Point(4, 22);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage4.Size = new System.Drawing.Size(636, 272);
            this.tabPage4.TabIndex = 0;
            this.tabPage4.Text = "Исходная ИБ";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // dBaseUserPass
            // 
            this.dBaseUserPass.Location = new System.Drawing.Point(7, 228);
            this.dBaseUserPass.Name = "dBaseUserPass";
            this.dBaseUserPass.Size = new System.Drawing.Size(593, 20);
            this.dBaseUserPass.TabIndex = 20;
            // 
            // labelDBasePassword
            // 
            this.labelDBasePassword.Location = new System.Drawing.Point(7, 206);
            this.labelDBasePassword.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelDBasePassword.Name = "labelDBasePassword";
            this.labelDBasePassword.Size = new System.Drawing.Size(593, 20);
            this.labelDBasePassword.TabIndex = 21;
            this.labelDBasePassword.Text = "Пароль:";
            // 
            // dBaseUserName
            // 
            this.dBaseUserName.Location = new System.Drawing.Point(7, 184);
            this.dBaseUserName.Name = "dBaseUserName";
            this.dBaseUserName.Size = new System.Drawing.Size(593, 20);
            this.dBaseUserName.TabIndex = 18;
            // 
            // labelDBaseUser
            // 
            this.labelDBaseUser.Location = new System.Drawing.Point(7, 162);
            this.labelDBaseUser.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelDBaseUser.Name = "labelDBaseUser";
            this.labelDBaseUser.Size = new System.Drawing.Size(593, 20);
            this.labelDBaseUser.TabIndex = 19;
            this.labelDBaseUser.Text = "Пользователь:";
            // 
            // labelDBaseServerName
            // 
            this.labelDBaseServerName.Location = new System.Drawing.Point(7, 74);
            this.labelDBaseServerName.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelDBaseServerName.Name = "labelDBaseServerName";
            this.labelDBaseServerName.Size = new System.Drawing.Size(593, 20);
            this.labelDBaseServerName.TabIndex = 15;
            this.labelDBaseServerName.Text = "Сервер:";
            // 
            // dBaseName
            // 
            this.dBaseName.Location = new System.Drawing.Point(7, 140);
            this.dBaseName.Name = "dBaseName";
            this.dBaseName.Size = new System.Drawing.Size(593, 20);
            this.dBaseName.TabIndex = 16;
            // 
            // dBaseServerName
            // 
            this.dBaseServerName.Location = new System.Drawing.Point(7, 96);
            this.dBaseServerName.Name = "dBaseServerName";
            this.dBaseServerName.Size = new System.Drawing.Size(593, 20);
            this.dBaseServerName.TabIndex = 14;
            this.dBaseServerName.TextChanged += new System.EventHandler(this.dBaseServerName_TextChanged);
            // 
            // labelDBaseName
            // 
            this.labelDBaseName.Location = new System.Drawing.Point(7, 118);
            this.labelDBaseName.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelDBaseName.Name = "labelDBaseName";
            this.labelDBaseName.Size = new System.Drawing.Size(593, 20);
            this.labelDBaseName.TabIndex = 17;
            this.labelDBaseName.Text = "Имя информационной база:";
            // 
            // tabPage5
            // 
            this.tabPage5.Controls.Add(this.dBaseProtectedUserPass);
            this.tabPage5.Controls.Add(this.labelDBaseProtectedPassword);
            this.tabPage5.Controls.Add(this.dBaseProtectedUserName);
            this.tabPage5.Controls.Add(this.labelDBaseProtectedUser);
            this.tabPage5.Controls.Add(this.dBaseProtectedName);
            this.tabPage5.Controls.Add(this.labelDBaseProtectedName);
            this.tabPage5.Controls.Add(this.dBaseProtectedServerName);
            this.tabPage5.Controls.Add(this.labelDBaseProtectedServerName);
            this.tabPage5.Controls.Add(this.dBaseProtectedFileMode);
            this.tabPage5.Controls.Add(this.dBaseProtectedDir);
            this.tabPage5.Controls.Add(this.selectProtectedDBaseDir);
            this.tabPage5.Controls.Add(this.labelDBaseProtectedDir);
            this.tabPage5.Location = new System.Drawing.Point(4, 22);
            this.tabPage5.Name = "tabPage5";
            this.tabPage5.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage5.Size = new System.Drawing.Size(636, 272);
            this.tabPage5.TabIndex = 1;
            this.tabPage5.Text = "Защищенная ИБ";
            this.tabPage5.UseVisualStyleBackColor = true;
            // 
            // dBaseProtectedUserPass
            // 
            this.dBaseProtectedUserPass.Location = new System.Drawing.Point(7, 228);
            this.dBaseProtectedUserPass.Name = "dBaseProtectedUserPass";
            this.dBaseProtectedUserPass.Size = new System.Drawing.Size(593, 20);
            this.dBaseProtectedUserPass.TabIndex = 44;
            // 
            // labelDBaseProtectedPassword
            // 
            this.labelDBaseProtectedPassword.Location = new System.Drawing.Point(7, 206);
            this.labelDBaseProtectedPassword.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelDBaseProtectedPassword.Name = "labelDBaseProtectedPassword";
            this.labelDBaseProtectedPassword.Size = new System.Drawing.Size(593, 15);
            this.labelDBaseProtectedPassword.TabIndex = 45;
            this.labelDBaseProtectedPassword.Text = "Пароль:";
            // 
            // dBaseProtectedUserName
            // 
            this.dBaseProtectedUserName.Location = new System.Drawing.Point(7, 184);
            this.dBaseProtectedUserName.Name = "dBaseProtectedUserName";
            this.dBaseProtectedUserName.Size = new System.Drawing.Size(593, 20);
            this.dBaseProtectedUserName.TabIndex = 42;
            // 
            // labelDBaseProtectedUser
            // 
            this.labelDBaseProtectedUser.Location = new System.Drawing.Point(7, 162);
            this.labelDBaseProtectedUser.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelDBaseProtectedUser.Name = "labelDBaseProtectedUser";
            this.labelDBaseProtectedUser.Size = new System.Drawing.Size(593, 15);
            this.labelDBaseProtectedUser.TabIndex = 43;
            this.labelDBaseProtectedUser.Text = "Пользователь:";
            // 
            // dBaseProtectedName
            // 
            this.dBaseProtectedName.Location = new System.Drawing.Point(7, 140);
            this.dBaseProtectedName.Name = "dBaseProtectedName";
            this.dBaseProtectedName.Size = new System.Drawing.Size(593, 20);
            this.dBaseProtectedName.TabIndex = 40;
            // 
            // labelDBaseProtectedName
            // 
            this.labelDBaseProtectedName.Location = new System.Drawing.Point(7, 118);
            this.labelDBaseProtectedName.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelDBaseProtectedName.Name = "labelDBaseProtectedName";
            this.labelDBaseProtectedName.Size = new System.Drawing.Size(593, 20);
            this.labelDBaseProtectedName.TabIndex = 41;
            this.labelDBaseProtectedName.Text = "Имя информационной база:";
            // 
            // dBaseProtectedServerName
            // 
            this.dBaseProtectedServerName.Location = new System.Drawing.Point(7, 96);
            this.dBaseProtectedServerName.Name = "dBaseProtectedServerName";
            this.dBaseProtectedServerName.Size = new System.Drawing.Size(593, 20);
            this.dBaseProtectedServerName.TabIndex = 38;
            // 
            // labelDBaseProtectedServerName
            // 
            this.labelDBaseProtectedServerName.Location = new System.Drawing.Point(7, 74);
            this.labelDBaseProtectedServerName.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelDBaseProtectedServerName.Name = "labelDBaseProtectedServerName";
            this.labelDBaseProtectedServerName.Size = new System.Drawing.Size(593, 20);
            this.labelDBaseProtectedServerName.TabIndex = 39;
            this.labelDBaseProtectedServerName.Text = "Сервер:";
            // 
            // dBaseProtectedFileMode
            // 
            this.dBaseProtectedFileMode.AutoSize = true;
            this.dBaseProtectedFileMode.Location = new System.Drawing.Point(7, 6);
            this.dBaseProtectedFileMode.Name = "dBaseProtectedFileMode";
            this.dBaseProtectedFileMode.Size = new System.Drawing.Size(118, 17);
            this.dBaseProtectedFileMode.TabIndex = 37;
            this.dBaseProtectedFileMode.Text = "Файловый режим";
            this.dBaseProtectedFileMode.UseVisualStyleBackColor = true;
            this.dBaseProtectedFileMode.CheckedChanged += new System.EventHandler(this.DBaseProtectedFileMode_CheckedChanged);
            // 
            // dBaseProtectedDir
            // 
            this.dBaseProtectedDir.Enabled = false;
            this.dBaseProtectedDir.Location = new System.Drawing.Point(7, 52);
            this.dBaseProtectedDir.Name = "dBaseProtectedDir";
            this.dBaseProtectedDir.Size = new System.Drawing.Size(593, 20);
            this.dBaseProtectedDir.TabIndex = 34;
            // 
            // selectProtectedDBaseDir
            // 
            this.selectProtectedDBaseDir.Enabled = false;
            this.selectProtectedDBaseDir.Location = new System.Drawing.Point(606, 52);
            this.selectProtectedDBaseDir.Name = "selectProtectedDBaseDir";
            this.selectProtectedDBaseDir.Size = new System.Drawing.Size(24, 20);
            this.selectProtectedDBaseDir.TabIndex = 35;
            this.selectProtectedDBaseDir.Text = "...";
            this.selectProtectedDBaseDir.UseVisualStyleBackColor = true;
            this.selectProtectedDBaseDir.Click += new System.EventHandler(this.SelectProtectedDBaseDir_Click);
            // 
            // labelDBaseProtectedDir
            // 
            this.labelDBaseProtectedDir.Enabled = false;
            this.labelDBaseProtectedDir.Location = new System.Drawing.Point(7, 30);
            this.labelDBaseProtectedDir.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelDBaseProtectedDir.Name = "labelDBaseProtectedDir";
            this.labelDBaseProtectedDir.Size = new System.Drawing.Size(593, 20);
            this.labelDBaseProtectedDir.TabIndex = 36;
            this.labelDBaseProtectedDir.Text = "Каталог информационной базы:";
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.labelKeySeries);
            this.tabPage2.Controls.Add(this.keySeries);
            this.tabPage2.Controls.Add(this.licenceEditDir);
            this.tabPage2.Controls.Add(this.labelLicenceEditDir);
            this.tabPage2.Controls.Add(this.selectLicenceEditDir);
            this.tabPage2.Controls.Add(this.labelEpfSrcDir);
            this.tabPage2.Controls.Add(this.epfSrcDir);
            this.tabPage2.Controls.Add(this.selectEpfSrcDir);
            this.tabPage2.Controls.Add(this.v8UnpackPath);
            this.tabPage2.Controls.Add(this.labelModuleNames);
            this.tabPage2.Controls.Add(this.selectV8UnpackPath);
            this.tabPage2.Controls.Add(this.moduleNames);
            this.tabPage2.Controls.Add(this.labelEpfFileDir);
            this.tabPage2.Controls.Add(this.labelV8UnpackPath);
            this.tabPage2.Controls.Add(this.epfFileDir);
            this.tabPage2.Controls.Add(this.selectEpfFileDir);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(644, 420);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Параметры для сборки защищенного файла";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // labelKeySeries
            // 
            this.labelKeySeries.Location = new System.Drawing.Point(14, 14);
            this.labelKeySeries.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelKeySeries.Name = "labelKeySeries";
            this.labelKeySeries.Size = new System.Drawing.Size(582, 22);
            this.labelKeySeries.TabIndex = 32;
            this.labelKeySeries.Text = "Серия ключа";
            // 
            // keySeries
            // 
            this.keySeries.Location = new System.Drawing.Point(14, 40);
            this.keySeries.Multiline = true;
            this.keySeries.Name = "keySeries";
            this.keySeries.Size = new System.Drawing.Size(582, 22);
            this.keySeries.TabIndex = 31;
            // 
            // licenceEditDir
            // 
            this.licenceEditDir.Location = new System.Drawing.Point(13, 381);
            this.licenceEditDir.Name = "licenceEditDir";
            this.licenceEditDir.Size = new System.Drawing.Size(582, 20);
            this.licenceEditDir.TabIndex = 28;
            // 
            // labelLicenceEditDir
            // 
            this.labelLicenceEditDir.Location = new System.Drawing.Point(13, 359);
            this.labelLicenceEditDir.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelLicenceEditDir.Name = "labelLicenceEditDir";
            this.labelLicenceEditDir.Size = new System.Drawing.Size(582, 22);
            this.labelLicenceEditDir.TabIndex = 30;
            this.labelLicenceEditDir.Text = "Каталог редактора файлов";
            // 
            // selectLicenceEditDir
            // 
            this.selectLicenceEditDir.Location = new System.Drawing.Point(605, 381);
            this.selectLicenceEditDir.Name = "selectLicenceEditDir";
            this.selectLicenceEditDir.Size = new System.Drawing.Size(24, 20);
            this.selectLicenceEditDir.TabIndex = 29;
            this.selectLicenceEditDir.Text = "...";
            this.selectLicenceEditDir.UseVisualStyleBackColor = true;
            this.selectLicenceEditDir.Click += new System.EventHandler(this.SelectLicenceEditDir_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Location = new System.Drawing.Point(0, 494);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(668, 22);
            this.statusStrip1.TabIndex = 29;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CausesValidation = false;
            this.ClientSize = new System.Drawing.Size(668, 516);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.button4);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "Создание защищенной конфигурации";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabControl2.ResumeLayout(false);
            this.tabPage4.ResumeLayout(false);
            this.tabPage4.PerformLayout();
            this.tabPage5.ResumeLayout(false);
            this.tabPage5.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		#endregion
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.TextBox enterprisePath;
        private System.Windows.Forms.Button selectEnterprisePath;
        private System.Windows.Forms.Label labelEnterprisePath;
        private System.Windows.Forms.Label labelDBaseDir;
        private System.Windows.Forms.Button selectDBaseDir;
        private System.Windows.Forms.TextBox dBaseDir;
        private System.Windows.Forms.Label labelCfFileDir;
        private System.Windows.Forms.Button selectCfFileDir;
        private System.Windows.Forms.TextBox cfFileDir;
        private System.Windows.Forms.Label labelEpfSrcDir;
        private System.Windows.Forms.Button selectEpfSrcDir;
        private System.Windows.Forms.TextBox epfSrcDir;
        private System.Windows.Forms.Label labelEpfFileDir;
        private System.Windows.Forms.Button selectV8UnpackPath;
        private System.Windows.Forms.TextBox v8UnpackPath;
        private System.Windows.Forms.Label labelV8UnpackPath;
        private System.Windows.Forms.Button selectEpfFileDir;
        private System.Windows.Forms.TextBox epfFileDir;
        private System.Windows.Forms.Label labelModuleNames;
        private System.Windows.Forms.TextBox moduleNames;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TextBox dBaseUserPass;
        private System.Windows.Forms.Label labelDBasePassword;
        private System.Windows.Forms.TextBox dBaseUserName;
        private System.Windows.Forms.Label labelDBaseUser;
        private System.Windows.Forms.TextBox dBaseName;
        private System.Windows.Forms.Label labelDBaseName;
        private System.Windows.Forms.TextBox dBaseServerName;
        private System.Windows.Forms.Label labelDBaseServerName;
        private System.Windows.Forms.CheckBox dBaseFileMode;
        private System.Windows.Forms.TextBox licenceEditDir;
        private System.Windows.Forms.Label labelLicenceEditDir;
        private System.Windows.Forms.Button selectLicenceEditDir;
        private System.Windows.Forms.TabControl tabControl2;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.TabPage tabPage5;
        private System.Windows.Forms.TextBox dBaseProtectedUserPass;
        private System.Windows.Forms.Label labelDBaseProtectedPassword;
        private System.Windows.Forms.TextBox dBaseProtectedUserName;
        private System.Windows.Forms.Label labelDBaseProtectedUser;
        private System.Windows.Forms.TextBox dBaseProtectedName;
        private System.Windows.Forms.Label labelDBaseProtectedName;
        private System.Windows.Forms.TextBox dBaseProtectedServerName;
        private System.Windows.Forms.Label labelDBaseProtectedServerName;
        private System.Windows.Forms.CheckBox dBaseProtectedFileMode;
        private System.Windows.Forms.TextBox dBaseProtectedDir;
        private System.Windows.Forms.Button selectProtectedDBaseDir;
        private System.Windows.Forms.Label labelDBaseProtectedDir;
        private System.Windows.Forms.Label labelKeySeries;
        private System.Windows.Forms.TextBox keySeries;
        private System.Windows.Forms.StatusStrip statusStrip1;
    }
}

