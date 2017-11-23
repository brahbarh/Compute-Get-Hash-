using ComputeHash.Properties;
using Microsoft.Win32;
using ns1;
using System;
using System.ComponentModel;
using System.Configuration;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Resources;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace ns0
{
	internal sealed class ComputeHash : Form
	{
		private static string string_0;

		private static string string_1;

		private static string string_2;

		private static string string_3;

		private static string string_4;

		private Point point_0;

		private bool bool_0;

		private IContainer icontainer_0;

		private Label lblMD5;

		private Label lblSHA1;

		private Label lblFilename;

		private Button btnCopyMD5;

		private Button btnCopySHA1;

		private CheckBox chkCase;

		private Button btnCopySHA256;

		private Label lblSHA256;

		private Button btnCopySHA512;

		private Label lblSHA512;

		private Button btnCopySHA384;

		private Label lblSHA384;

		private BackgroundWorker backgroundWorker_0;

		private System.Windows.Forms.Timer timer_0;

		private Label label1;

		private Button btnCopyToFile;

		private SaveFileDialog saveFileDialog_0;

		private Label txtMD5;

		private Label txtSHA512;

		private Label txtSHA384;

		private Label txtSHA256;

		private Label txtSHA1;

		private CheckBox chkTopMost;

		private CheckBox chkMD5;

		private CheckBox chkSHA1;

		private CheckBox chkSHA256;

		private CheckBox chkSHA384;

		private CheckBox chkSHA512;

		private Label lblProgress;

		private Label label3;

		private GroupBox groupBox1;

		private OpenFileDialog openFileDialog_0;

		private CheckBox chkContextMenu;
        private IContainer components;
        private LinkLabel linkLabel1;
        private PictureBox pictureBox1;
        private Button SelectFile;
        private ToolTip toolTip_0;

		public ComputeHash()
		{
			this.InitializeComponent();
			Settings.Default.PropertyChanged += new PropertyChangedEventHandler(this.method_0);
			string str = "Not Selected";
			ComputeHash.string_4 = str;
			ComputeHash.string_3 = str;
			ComputeHash.string_2 = str;
			ComputeHash.string_1 = str;
			ComputeHash.string_0 = str;
		}

		private void backgroundWorker_0_DoWork(object sender, DoWorkEventArgs e)
		{
			Thread thread = new Thread(new ThreadStart(this.method_1));
			Thread thread1 = new Thread(new ThreadStart(this.method_5));
			Thread thread2 = new Thread(new ThreadStart(this.method_4));
			Thread thread3 = new Thread(new ThreadStart(this.method_3));
			Thread thread4 = new Thread(new ThreadStart(this.method_2));
			if (Settings.Default.MD5 && this.lblMD5.Text.Length < 15)
			{
				thread.Start();
				ComputeHash.string_0 = "Reading file...";
			}
			if (Settings.Default.SHA1 && this.lblSHA1.Text.Length < 15)
			{
				thread4.Start();
				ComputeHash.string_1 = "Reading file...";
			}
			if (Settings.Default.SHA256 && this.lblSHA256.Text.Length < 15)
			{
				thread3.Start();
				ComputeHash.string_2 = "Reading file...";
			}
			if (Settings.Default.SHA384 && this.lblSHA384.Text.Length < 15)
			{
				thread2.Start();
				ComputeHash.string_3 = "Reading file...";
			}
			if (Settings.Default.SHA512 && this.lblSHA512.Text.Length < 15)
			{
				thread1.Start();
				ComputeHash.string_4 = "Reading file...";
			}
			this.timer_0.Start();
			if (thread.ThreadState == System.Threading.ThreadState.Running)
			{
				thread.Join();
			}
			if (thread4.ThreadState == System.Threading.ThreadState.Running)
			{
				thread4.Join();
			}
			if (thread2.ThreadState == System.Threading.ThreadState.Running)
			{
				thread2.Join();
			}
			if (thread3.ThreadState == System.Threading.ThreadState.Running)
			{
				thread3.Join();
			}
			if (thread1.ThreadState == System.Threading.ThreadState.Running)
			{
				thread1.Join();
			}
		}

		private void backgroundWorker_0_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
		{
			this.txtMD5.Text = ComputeHash.string_0;
			this.txtSHA1.Text = ComputeHash.string_1;
			this.txtSHA256.Text = ComputeHash.string_2;
			this.txtSHA384.Text = ComputeHash.string_3;
			this.txtSHA512.Text = ComputeHash.string_4;
			this.timer_0.Stop();
			CheckBox checkBox = this.chkMD5;
			CheckBox checkBox1 = this.chkSHA1;
			CheckBox checkBox2 = this.chkSHA256;
			CheckBox checkBox3 = this.chkSHA384;
			this.chkSHA512.Enabled = true;
			checkBox3.Enabled = true;
			checkBox2.Enabled = true;
			checkBox1.Enabled = true;
			checkBox.Enabled = true;
			Label label = this.label1;
			this.lblProgress.Visible = false;
			label.Visible = false;
			this.btnCopyToFile.Visible = true;
		}

		private void btnCopyMD5_Click(object sender, EventArgs e)
		{
			Clipboard.SetText(this.txtMD5.Text);
		}

		private void btnCopySHA1_Click(object sender, EventArgs e)
		{
			Clipboard.SetText(this.txtSHA1.Text);
		}

		private void btnCopySHA256_Click(object sender, EventArgs e)
		{
			Clipboard.SetText(this.txtSHA256.Text);
		}

		private void btnCopySHA384_Click(object sender, EventArgs e)
		{
			Clipboard.SetText(this.txtSHA384.Text);
		}

		private void btnCopySHA512_Click(object sender, EventArgs e)
		{
			Clipboard.SetText(this.txtSHA512.Text);
		}

		private void btnCopyToFile_Click(object sender, EventArgs e)
		{
			this.saveFileDialog_0.InitialDirectory = Path.GetDirectoryName(Class0.smethod_0());
			this.saveFileDialog_0.FileName = Path.GetFileNameWithoutExtension(Class0.smethod_0());
			if (this.saveFileDialog_0.ShowDialog() == System.Windows.Forms.DialogResult.OK)
			{
				StreamWriter streamWriter = File.CreateText(this.saveFileDialog_0.FileName);
				streamWriter.WriteLine(string.Concat("Github ", Application.ProductName, " ", Application.ProductVersion.Substring(0, 3)));
				streamWriter.WriteLine();
				streamWriter.WriteLine();
				streamWriter.WriteLine(string.Concat("File: \t", Class0.smethod_0()));
				streamWriter.WriteLine();
				if (this.txtMD5.Text.Length > 15)
				{
					streamWriter.WriteLine(string.Concat("MD5:  \t", this.txtMD5.Text));
					streamWriter.WriteLine();
				}
				if (this.txtSHA1.Text.Length > 15)
				{
					streamWriter.WriteLine(string.Concat("SHA1:  \t", this.txtSHA1.Text));
					streamWriter.WriteLine();
				}
				if (this.txtSHA256.Text.Length > 15)
				{
					streamWriter.WriteLine(string.Concat("SAH256:\t", this.txtSHA256.Text));
					streamWriter.WriteLine();
				}
				if (this.txtSHA384.Text.Length > 15)
				{
					streamWriter.WriteLine(string.Concat("SHA384:\t", this.txtSHA384.Text));
					streamWriter.WriteLine();
				}
				if (this.txtSHA512.Text.Length > 15)
				{
					streamWriter.WriteLine(string.Concat("SHA512:\t", this.txtSHA512.Text));
					streamWriter.WriteLine();
				}
				streamWriter.WriteLine();
				streamWriter.WriteLine("www.github.com/brahbarh/Compute-Get-Hash-/");
				streamWriter.Close();
			}
		}

		private void chkCase_CheckedChanged(object sender, EventArgs e)
		{
			Settings.Default.UpperCase = this.chkCase.Checked;
			if (this.chkCase.Checked)
			{
				this.txtMD5.Text = this.txtMD5.Text.ToUpper();
				this.txtSHA1.Text = this.txtSHA1.Text.ToUpper();
				this.txtSHA256.Text = this.txtSHA256.Text.ToUpper();
				this.txtSHA384.Text = this.txtSHA384.Text.ToUpper();
				this.txtSHA512.Text = this.txtSHA512.Text.ToUpper();
				return;
			}
			this.txtMD5.Text = this.txtMD5.Text.ToLower();
			this.txtSHA1.Text = this.txtSHA1.Text.ToLower();
			this.txtSHA256.Text = this.txtSHA256.Text.ToLower();
			this.txtSHA384.Text = this.txtSHA384.Text.ToLower();
			this.txtSHA512.Text = this.txtSHA512.Text.ToLower();
		}

		private void chkContextMenu_CheckedChanged(object sender, EventArgs e)
		{
			if (this.chkContextMenu.Checked)
			{
				ComputeHash.smethod_0(false);
				return;
			}
			ComputeHash.smethod_1(false);
		}

		private void chkMD5_CheckedChanged(object sender, EventArgs e)
		{
			Settings.Default.MD5 = this.chkMD5.Checked;
			if (this.chkMD5.Checked)
			{
				Label label = this.label1;
				this.lblProgress.Visible = true;
				label.Visible = true;
				this.backgroundWorker_0.RunWorkerAsync();
			}
		}

		private void chkSHA1_CheckedChanged(object sender, EventArgs e)
		{
			Settings.Default.SHA1 = this.chkSHA1.Checked;
			if (this.chkSHA1.Checked)
			{
				Label label = this.label1;
				this.lblProgress.Visible = true;
				label.Visible = true;
				this.backgroundWorker_0.RunWorkerAsync();
			}
		}

		private void chkSHA256_CheckedChanged(object sender, EventArgs e)
		{
			Settings.Default.SHA256 = this.chkSHA256.Checked;
			if (this.chkSHA256.Checked)
			{
				Label label = this.label1;
				this.lblProgress.Visible = true;
				label.Visible = true;
				this.backgroundWorker_0.RunWorkerAsync();
			}
		}

		private void chkSHA384_CheckedChanged(object sender, EventArgs e)
		{
			Settings.Default.SHA384 = this.chkSHA384.Checked;
			if (this.chkSHA384.Checked)
			{
				Label label = this.label1;
				this.lblProgress.Visible = true;
				label.Visible = true;
				this.backgroundWorker_0.RunWorkerAsync();
			}
		}

		private void chkSHA512_CheckedChanged(object sender, EventArgs e)
		{
			Settings.Default.SHA512 = this.chkSHA512.Checked;
			if (this.chkSHA512.Checked)
			{
				Label label = this.label1;
				this.lblProgress.Visible = true;
				label.Visible = true;
				this.backgroundWorker_0.RunWorkerAsync();
			}
		}

		private void chkTopMost_CheckedChanged(object sender, EventArgs e)
		{
			Settings @default = Settings.Default;
			bool @checked = this.chkTopMost.Checked;
			bool flag = @checked;
			@default.TopMost = @checked;
			base.TopMost = flag;
		}

		private void ComputeHash_Load(object sender, EventArgs e)
		{
			bool flag;
			this.Text = string.Concat("Github ", Class0.smethod_2());
			string[] subKeyNames = Registry.CurrentUser.CreateSubKey("Software\\Classes\\*\\shell").GetSubKeyNames();
			int num = 0;
			while (true)
			{
				if (num >= (int)subKeyNames.Length)
				{
					break;
				}
				else if (subKeyNames[num].ToUpper() == "COMPUTE HASH")
				{
					this.chkContextMenu.Checked = true;
					break;
				}
				else
				{
					num++;
				}
			}
			if (!File.Exists(Class0.smethod_0()))
			{
				this.lblFilename.Visible = false;
				this.SelectFile.Visible = true;
				Label label = this.label1;
				flag = false;
				this.lblProgress.Visible = false;
				label.Visible = false;
				return;
			}
			this.lblFilename.Text = string.Concat(Path.GetFileNameWithoutExtension(Class0.smethod_0()).Substring(0, (Path.GetFileNameWithoutExtension(Class0.smethod_0()).Length > 60 ? 60 : Path.GetFileNameWithoutExtension(Class0.smethod_0()).Length)), Path.GetExtension(Class0.smethod_0()));
			this.chkMD5.Checked = Settings.Default.MD5;
			this.chkSHA1.Checked = Settings.Default.SHA1;
			this.chkSHA256.Checked = Settings.Default.SHA256;
			this.chkSHA384.Checked = Settings.Default.SHA384;
			this.chkSHA512.Checked = Settings.Default.SHA512;
			this.chkCase.Checked = Settings.Default.UpperCase;
			CheckBox checkBox = this.chkTopMost;
			bool topMost = Settings.Default.TopMost;
			flag = topMost;
			checkBox.Checked = topMost;
			base.TopMost = flag;
			CheckBox checkBox1 = this.chkMD5;
			CheckBox checkBox2 = this.chkSHA1;
			CheckBox checkBox3 = this.chkSHA256;
			CheckBox checkBox4 = this.chkSHA384;
			this.chkSHA512.Enabled = false;
			checkBox4.Enabled = false;
			checkBox3.Enabled = false;
			flag = false;
			checkBox2.Enabled = false;
			checkBox1.Enabled = false;
			Label label1 = this.label1;
			flag = true;
			this.lblProgress.Visible = true;
			label1.Visible = true;
			this.backgroundWorker_0.RunWorkerAsync();
		}

		private void ComputeHash_MouseDown(object sender, MouseEventArgs e)
		{
			if (e.Button == System.Windows.Forms.MouseButtons.Left)
			{
				int x = -e.X;
				this.point_0 = new Point(x, -e.Y);
				this.bool_0 = true;
			}
		}

		private void ComputeHash_MouseMove(object sender, MouseEventArgs e)
		{
			if (this.bool_0)
			{
				Point mousePosition = Control.MousePosition;
				mousePosition.Offset(this.point_0.X, this.point_0.Y);
				base.Location = mousePosition;
			}
		}

		private void ComputeHash_MouseUp(object sender, MouseEventArgs e)
		{
			if (e.Button == System.Windows.Forms.MouseButtons.Left)
			{
				this.bool_0 = false;
			}
		}

		protected override void Dispose(bool disposing)
		{
			if (disposing && this.icontainer_0 != null)
			{
				this.icontainer_0.Dispose();
			}
			base.Dispose(disposing);
		}

		private void InitializeComponent()
		{
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ComputeHash));
            this.backgroundWorker_0 = new System.ComponentModel.BackgroundWorker();
            this.timer_0 = new System.Windows.Forms.Timer(this.components);
            this.saveFileDialog_0 = new System.Windows.Forms.SaveFileDialog();
            this.txtSHA512 = new System.Windows.Forms.Label();
            this.txtSHA384 = new System.Windows.Forms.Label();
            this.txtSHA256 = new System.Windows.Forms.Label();
            this.txtSHA1 = new System.Windows.Forms.Label();
            this.txtMD5 = new System.Windows.Forms.Label();
            this.btnCopyToFile = new System.Windows.Forms.Button();
            this.lblMD5 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lblSHA1 = new System.Windows.Forms.Label();
            this.btnCopySHA384 = new System.Windows.Forms.Button();
            this.lblFilename = new System.Windows.Forms.Label();
            this.lblSHA384 = new System.Windows.Forms.Label();
            this.btnCopyMD5 = new System.Windows.Forms.Button();
            this.btnCopySHA512 = new System.Windows.Forms.Button();
            this.btnCopySHA1 = new System.Windows.Forms.Button();
            this.chkCase = new System.Windows.Forms.CheckBox();
            this.lblSHA512 = new System.Windows.Forms.Label();
            this.btnCopySHA256 = new System.Windows.Forms.Button();
            this.lblSHA256 = new System.Windows.Forms.Label();
            this.chkTopMost = new System.Windows.Forms.CheckBox();
            this.chkMD5 = new System.Windows.Forms.CheckBox();
            this.chkSHA1 = new System.Windows.Forms.CheckBox();
            this.chkSHA256 = new System.Windows.Forms.CheckBox();
            this.chkSHA384 = new System.Windows.Forms.CheckBox();
            this.chkSHA512 = new System.Windows.Forms.CheckBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.SelectFile = new System.Windows.Forms.Button();
            this.openFileDialog_0 = new System.Windows.Forms.OpenFileDialog();
            this.chkContextMenu = new System.Windows.Forms.CheckBox();
            this.label3 = new System.Windows.Forms.Label();
            this.lblProgress = new System.Windows.Forms.Label();
            this.toolTip_0 = new System.Windows.Forms.ToolTip(this.components);
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // backgroundWorker_0
            // 
            this.backgroundWorker_0.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker_0_DoWork);
            this.backgroundWorker_0.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker_0_RunWorkerCompleted);
            // 
            // timer_0
            // 
            this.timer_0.Interval = 1000;
            this.timer_0.Tick += new System.EventHandler(this.timer_0_Tick);
            // 
            // saveFileDialog_0
            // 
            this.saveFileDialog_0.DefaultExt = "txt";
            this.saveFileDialog_0.FileName = "Hash.txt";
            this.saveFileDialog_0.Title = "Save file to...";
            // 
            // txtSHA512
            // 
            this.txtSHA512.BackColor = System.Drawing.Color.Transparent;
            this.txtSHA512.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSHA512.ForeColor = System.Drawing.Color.Black;
            this.txtSHA512.Location = new System.Drawing.Point(82, 261);
            this.txtSHA512.Name = "txtSHA512";
            this.txtSHA512.Size = new System.Drawing.Size(414, 13);
            this.txtSHA512.TabIndex = 26;
            this.txtSHA512.Text = "-";
            // 
            // txtSHA384
            // 
            this.txtSHA384.BackColor = System.Drawing.Color.Transparent;
            this.txtSHA384.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSHA384.ForeColor = System.Drawing.Color.Black;
            this.txtSHA384.Location = new System.Drawing.Point(82, 216);
            this.txtSHA384.Name = "txtSHA384";
            this.txtSHA384.Size = new System.Drawing.Size(414, 13);
            this.txtSHA384.TabIndex = 25;
            this.txtSHA384.Text = "-";
            // 
            // txtSHA256
            // 
            this.txtSHA256.BackColor = System.Drawing.Color.Transparent;
            this.txtSHA256.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSHA256.ForeColor = System.Drawing.Color.Black;
            this.txtSHA256.Location = new System.Drawing.Point(82, 171);
            this.txtSHA256.Name = "txtSHA256";
            this.txtSHA256.Size = new System.Drawing.Size(414, 13);
            this.txtSHA256.TabIndex = 24;
            this.txtSHA256.Text = "-";
            // 
            // txtSHA1
            // 
            this.txtSHA1.BackColor = System.Drawing.Color.Transparent;
            this.txtSHA1.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSHA1.ForeColor = System.Drawing.Color.Black;
            this.txtSHA1.Location = new System.Drawing.Point(82, 126);
            this.txtSHA1.Name = "txtSHA1";
            this.txtSHA1.Size = new System.Drawing.Size(414, 13);
            this.txtSHA1.TabIndex = 23;
            this.txtSHA1.Text = "-";
            // 
            // txtMD5
            // 
            this.txtMD5.BackColor = System.Drawing.Color.Transparent;
            this.txtMD5.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMD5.ForeColor = System.Drawing.Color.Black;
            this.txtMD5.Location = new System.Drawing.Point(82, 81);
            this.txtMD5.Name = "txtMD5";
            this.txtMD5.Size = new System.Drawing.Size(414, 13);
            this.txtMD5.TabIndex = 22;
            this.txtMD5.Text = "-";
            // 
            // btnCopyToFile
            // 
            this.btnCopyToFile.ForeColor = System.Drawing.Color.Black;
            this.btnCopyToFile.Location = new System.Drawing.Point(8, 455);
            this.btnCopyToFile.Name = "btnCopyToFile";
            this.btnCopyToFile.Size = new System.Drawing.Size(105, 23);
            this.btnCopyToFile.TabIndex = 21;
            this.btnCopyToFile.Text = "Copy to File...";
            this.btnCopyToFile.UseVisualStyleBackColor = true;
            this.btnCopyToFile.Visible = false;
            this.btnCopyToFile.Click += new System.EventHandler(this.btnCopyToFile_Click);
            // 
            // lblMD5
            // 
            this.lblMD5.AutoSize = true;
            this.lblMD5.BackColor = System.Drawing.Color.Transparent;
            this.lblMD5.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMD5.ForeColor = System.Drawing.Color.Black;
            this.lblMD5.Location = new System.Drawing.Point(26, 81);
            this.lblMD5.Name = "lblMD5";
            this.lblMD5.Size = new System.Drawing.Size(35, 13);
            this.lblMD5.TabIndex = 1;
            this.lblMD5.Text = "MD5:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(149, 460);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 13);
            this.label1.TabIndex = 20;
            this.label1.Text = "Progress:";
            // 
            // lblSHA1
            // 
            this.lblSHA1.AutoSize = true;
            this.lblSHA1.BackColor = System.Drawing.Color.Transparent;
            this.lblSHA1.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSHA1.ForeColor = System.Drawing.Color.Black;
            this.lblSHA1.Location = new System.Drawing.Point(26, 126);
            this.lblSHA1.Name = "lblSHA1";
            this.lblSHA1.Size = new System.Drawing.Size(38, 13);
            this.lblSHA1.TabIndex = 2;
            this.lblSHA1.Text = "SHA1:";
            // 
            // btnCopySHA384
            // 
            this.btnCopySHA384.ForeColor = System.Drawing.Color.Black;
            this.btnCopySHA384.Location = new System.Drawing.Point(504, 211);
            this.btnCopySHA384.Name = "btnCopySHA384";
            this.btnCopySHA384.Size = new System.Drawing.Size(54, 23);
            this.btnCopySHA384.TabIndex = 18;
            this.btnCopySHA384.Text = "Copy";
            this.btnCopySHA384.UseVisualStyleBackColor = true;
            this.btnCopySHA384.Click += new System.EventHandler(this.btnCopySHA384_Click);
            // 
            // lblFilename
            // 
            this.lblFilename.BackColor = System.Drawing.Color.Transparent;
            this.lblFilename.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFilename.ForeColor = System.Drawing.Color.Black;
            this.lblFilename.Location = new System.Drawing.Point(82, 36);
            this.lblFilename.Name = "lblFilename";
            this.lblFilename.Size = new System.Drawing.Size(474, 13);
            this.lblFilename.TabIndex = 5;
            this.lblFilename.Text = "   ";
            // 
            // lblSHA384
            // 
            this.lblSHA384.AutoSize = true;
            this.lblSHA384.BackColor = System.Drawing.Color.Transparent;
            this.lblSHA384.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSHA384.ForeColor = System.Drawing.Color.Black;
            this.lblSHA384.Location = new System.Drawing.Point(26, 216);
            this.lblSHA384.Name = "lblSHA384";
            this.lblSHA384.Size = new System.Drawing.Size(50, 13);
            this.lblSHA384.TabIndex = 16;
            this.lblSHA384.Text = "SHA384:";
            // 
            // btnCopyMD5
            // 
            this.btnCopyMD5.ForeColor = System.Drawing.Color.Black;
            this.btnCopyMD5.Location = new System.Drawing.Point(504, 76);
            this.btnCopyMD5.Name = "btnCopyMD5";
            this.btnCopyMD5.Size = new System.Drawing.Size(54, 23);
            this.btnCopyMD5.TabIndex = 6;
            this.btnCopyMD5.Text = "Copy";
            this.btnCopyMD5.UseVisualStyleBackColor = true;
            this.btnCopyMD5.Click += new System.EventHandler(this.btnCopyMD5_Click);
            // 
            // btnCopySHA512
            // 
            this.btnCopySHA512.ForeColor = System.Drawing.Color.Black;
            this.btnCopySHA512.Location = new System.Drawing.Point(504, 256);
            this.btnCopySHA512.Name = "btnCopySHA512";
            this.btnCopySHA512.Size = new System.Drawing.Size(54, 23);
            this.btnCopySHA512.TabIndex = 15;
            this.btnCopySHA512.Text = "Copy";
            this.btnCopySHA512.UseVisualStyleBackColor = true;
            this.btnCopySHA512.Click += new System.EventHandler(this.btnCopySHA512_Click);
            // 
            // btnCopySHA1
            // 
            this.btnCopySHA1.ForeColor = System.Drawing.Color.Black;
            this.btnCopySHA1.Location = new System.Drawing.Point(504, 121);
            this.btnCopySHA1.Name = "btnCopySHA1";
            this.btnCopySHA1.Size = new System.Drawing.Size(54, 23);
            this.btnCopySHA1.TabIndex = 7;
            this.btnCopySHA1.Text = "Copy";
            this.btnCopySHA1.UseVisualStyleBackColor = true;
            this.btnCopySHA1.Click += new System.EventHandler(this.btnCopySHA1_Click);
            // 
            // chkCase
            // 
            this.chkCase.AutoSize = true;
            this.chkCase.BackColor = System.Drawing.Color.Transparent;
            this.chkCase.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkCase.Checked = true;
            this.chkCase.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkCase.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkCase.ForeColor = System.Drawing.Color.Black;
            this.chkCase.Location = new System.Drawing.Point(421, 12);
            this.chkCase.Name = "chkCase";
            this.chkCase.Size = new System.Drawing.Size(80, 17);
            this.chkCase.TabIndex = 8;
            this.chkCase.Text = "Uppercase";
            this.toolTip_0.SetToolTip(this.chkCase, "Check/Uncheck to show hash in uppercase/lowercase");
            this.chkCase.UseVisualStyleBackColor = false;
            this.chkCase.CheckedChanged += new System.EventHandler(this.chkCase_CheckedChanged);
            // 
            // lblSHA512
            // 
            this.lblSHA512.AutoSize = true;
            this.lblSHA512.BackColor = System.Drawing.Color.Transparent;
            this.lblSHA512.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSHA512.ForeColor = System.Drawing.Color.Black;
            this.lblSHA512.Location = new System.Drawing.Point(26, 261);
            this.lblSHA512.Name = "lblSHA512";
            this.lblSHA512.Size = new System.Drawing.Size(50, 13);
            this.lblSHA512.TabIndex = 13;
            this.lblSHA512.Text = "SHA512:";
            // 
            // btnCopySHA256
            // 
            this.btnCopySHA256.ForeColor = System.Drawing.Color.Black;
            this.btnCopySHA256.Location = new System.Drawing.Point(504, 166);
            this.btnCopySHA256.Name = "btnCopySHA256";
            this.btnCopySHA256.Size = new System.Drawing.Size(54, 23);
            this.btnCopySHA256.TabIndex = 12;
            this.btnCopySHA256.Text = "Copy";
            this.btnCopySHA256.UseVisualStyleBackColor = true;
            this.btnCopySHA256.Click += new System.EventHandler(this.btnCopySHA256_Click);
            // 
            // lblSHA256
            // 
            this.lblSHA256.AutoSize = true;
            this.lblSHA256.BackColor = System.Drawing.Color.Transparent;
            this.lblSHA256.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSHA256.ForeColor = System.Drawing.Color.Black;
            this.lblSHA256.Location = new System.Drawing.Point(26, 171);
            this.lblSHA256.Name = "lblSHA256";
            this.lblSHA256.Size = new System.Drawing.Size(50, 13);
            this.lblSHA256.TabIndex = 10;
            this.lblSHA256.Text = "SHA256:";
            // 
            // chkTopMost
            // 
            this.chkTopMost.AutoSize = true;
            this.chkTopMost.BackColor = System.Drawing.Color.Transparent;
            this.chkTopMost.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkTopMost.Checked = true;
            this.chkTopMost.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkTopMost.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkTopMost.ForeColor = System.Drawing.Color.Black;
            this.chkTopMost.Location = new System.Drawing.Point(507, 12);
            this.chkTopMost.Name = "chkTopMost";
            this.chkTopMost.Size = new System.Drawing.Size(72, 17);
            this.chkTopMost.TabIndex = 28;
            this.chkTopMost.Text = "TopMost";
            this.toolTip_0.SetToolTip(this.chkTopMost, "Check/Uncheck to set window on top of other windows");
            this.chkTopMost.UseVisualStyleBackColor = false;
            this.chkTopMost.CheckedChanged += new System.EventHandler(this.chkTopMost_CheckedChanged);
            // 
            // chkMD5
            // 
            this.chkMD5.AutoSize = true;
            this.chkMD5.BackColor = System.Drawing.Color.Transparent;
            this.chkMD5.Checked = true;
            this.chkMD5.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkMD5.ForeColor = System.Drawing.Color.Black;
            this.chkMD5.Location = new System.Drawing.Point(9, 80);
            this.chkMD5.Name = "chkMD5";
            this.chkMD5.Size = new System.Drawing.Size(15, 14);
            this.chkMD5.TabIndex = 29;
            this.chkMD5.UseVisualStyleBackColor = false;
            this.chkMD5.CheckedChanged += new System.EventHandler(this.chkMD5_CheckedChanged);
            // 
            // chkSHA1
            // 
            this.chkSHA1.AutoSize = true;
            this.chkSHA1.BackColor = System.Drawing.Color.Transparent;
            this.chkSHA1.Checked = true;
            this.chkSHA1.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkSHA1.ForeColor = System.Drawing.Color.Black;
            this.chkSHA1.Location = new System.Drawing.Point(9, 125);
            this.chkSHA1.Name = "chkSHA1";
            this.chkSHA1.Size = new System.Drawing.Size(15, 14);
            this.chkSHA1.TabIndex = 30;
            this.chkSHA1.UseVisualStyleBackColor = false;
            this.chkSHA1.CheckedChanged += new System.EventHandler(this.chkSHA1_CheckedChanged);
            // 
            // chkSHA256
            // 
            this.chkSHA256.AutoSize = true;
            this.chkSHA256.BackColor = System.Drawing.Color.Transparent;
            this.chkSHA256.Checked = true;
            this.chkSHA256.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkSHA256.ForeColor = System.Drawing.Color.Black;
            this.chkSHA256.Location = new System.Drawing.Point(9, 170);
            this.chkSHA256.Name = "chkSHA256";
            this.chkSHA256.Size = new System.Drawing.Size(15, 14);
            this.chkSHA256.TabIndex = 31;
            this.chkSHA256.UseVisualStyleBackColor = false;
            this.chkSHA256.CheckedChanged += new System.EventHandler(this.chkSHA256_CheckedChanged);
            // 
            // chkSHA384
            // 
            this.chkSHA384.AutoSize = true;
            this.chkSHA384.BackColor = System.Drawing.Color.Transparent;
            this.chkSHA384.Checked = true;
            this.chkSHA384.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkSHA384.ForeColor = System.Drawing.Color.Black;
            this.chkSHA384.Location = new System.Drawing.Point(9, 215);
            this.chkSHA384.Name = "chkSHA384";
            this.chkSHA384.Size = new System.Drawing.Size(15, 14);
            this.chkSHA384.TabIndex = 32;
            this.chkSHA384.UseVisualStyleBackColor = false;
            this.chkSHA384.CheckedChanged += new System.EventHandler(this.chkSHA384_CheckedChanged);
            // 
            // chkSHA512
            // 
            this.chkSHA512.AutoSize = true;
            this.chkSHA512.BackColor = System.Drawing.Color.Transparent;
            this.chkSHA512.Checked = true;
            this.chkSHA512.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkSHA512.ForeColor = System.Drawing.Color.Black;
            this.chkSHA512.Location = new System.Drawing.Point(9, 260);
            this.chkSHA512.Name = "chkSHA512";
            this.chkSHA512.Size = new System.Drawing.Size(15, 14);
            this.chkSHA512.TabIndex = 33;
            this.chkSHA512.UseVisualStyleBackColor = false;
            this.chkSHA512.CheckedChanged += new System.EventHandler(this.chkSHA512_CheckedChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.SelectFile);
            this.groupBox1.Controls.Add(this.lblFilename);
            this.groupBox1.Controls.Add(this.btnCopySHA384);
            this.groupBox1.Controls.Add(this.lblSHA1);
            this.groupBox1.Controls.Add(this.lblSHA384);
            this.groupBox1.Controls.Add(this.chkSHA512);
            this.groupBox1.Controls.Add(this.lblMD5);
            this.groupBox1.Controls.Add(this.chkSHA384);
            this.groupBox1.Controls.Add(this.btnCopyMD5);
            this.groupBox1.Controls.Add(this.chkSHA256);
            this.groupBox1.Controls.Add(this.btnCopySHA512);
            this.groupBox1.Controls.Add(this.chkSHA1);
            this.groupBox1.Controls.Add(this.chkMD5);
            this.groupBox1.Controls.Add(this.btnCopySHA1);
            this.groupBox1.Controls.Add(this.txtMD5);
            this.groupBox1.Controls.Add(this.lblSHA512);
            this.groupBox1.Controls.Add(this.txtSHA512);
            this.groupBox1.Controls.Add(this.txtSHA1);
            this.groupBox1.Controls.Add(this.lblSHA256);
            this.groupBox1.Controls.Add(this.txtSHA256);
            this.groupBox1.Controls.Add(this.txtSHA384);
            this.groupBox1.Controls.Add(this.btnCopySHA256);
            this.groupBox1.Location = new System.Drawing.Point(8, 80);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(574, 369);
            this.groupBox1.TabIndex = 37;
            this.groupBox1.TabStop = false;
            // 
            // SelectFile
            // 
            this.SelectFile.Location = new System.Drawing.Point(6, 33);
            this.SelectFile.Name = "SelectFile";
            this.SelectFile.Size = new System.Drawing.Size(75, 23);
            this.SelectFile.TabIndex = 35;
            this.SelectFile.Text = "SelectFile";
            this.SelectFile.UseVisualStyleBackColor = true;
            this.SelectFile.Click += new System.EventHandler(this.lnkSelectFile_LinkClicked);
            // 
            // openFileDialog_0
            // 
            this.openFileDialog_0.InitialDirectory = "...";
            this.openFileDialog_0.Title = "Select file";
            // 
            // chkContextMenu
            // 
            this.chkContextMenu.AutoSize = true;
            this.chkContextMenu.BackColor = System.Drawing.Color.Transparent;
            this.chkContextMenu.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkContextMenu.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkContextMenu.ForeColor = System.Drawing.Color.Black;
            this.chkContextMenu.Location = new System.Drawing.Point(414, 35);
            this.chkContextMenu.Name = "chkContextMenu";
            this.chkContextMenu.Size = new System.Drawing.Size(165, 17);
            this.chkContextMenu.TabIndex = 39;
            this.chkContextMenu.Text = "Integrate to Context Menu";
            this.toolTip_0.SetToolTip(this.chkContextMenu, "Check to integrate compute hash to Windows Explorer");
            this.chkContextMenu.UseVisualStyleBackColor = false;
            this.chkContextMenu.CheckedChanged += new System.EventHandler(this.chkContextMenu_CheckedChanged);
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(0, 14);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(263, 55);
            this.label3.TabIndex = 36;
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // lblProgress
            // 
            this.lblProgress.BackColor = System.Drawing.Color.White;
            this.lblProgress.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblProgress.ForeColor = System.Drawing.Color.White;
            this.lblProgress.Location = new System.Drawing.Point(210, 460);
            this.lblProgress.Name = "lblProgress";
            this.lblProgress.Size = new System.Drawing.Size(212, 13);
            this.lblProgress.TabIndex = 34;
            // 
            // linkLabel1
            // 
            this.linkLabel1.ActiveLinkColor = System.Drawing.Color.DeepSkyBlue;
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.BackColor = System.Drawing.Color.Transparent;
            this.linkLabel1.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.linkLabel1.ForeColor = System.Drawing.Color.Black;
            this.linkLabel1.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.linkLabel1.LinkColor = System.Drawing.Color.DarkOrange;
            this.linkLabel1.Location = new System.Drawing.Point(480, 460);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(97, 13);
            this.linkLabel1.TabIndex = 9;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "www.github.com/brahbarh/Compute-Get-Hash-/";
            this.linkLabel1.VisitedLinkColor = System.Drawing.Color.SkyBlue;
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox1.BackgroundImage")));
            this.pictureBox1.Location = new System.Drawing.Point(12, 5);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(302, 80);
            this.pictureBox1.TabIndex = 40;
            this.pictureBox1.TabStop = false;
            // 
            // ComputeHash
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ClientSize = new System.Drawing.Size(591, 490);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.chkContextMenu);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lblProgress);
            this.Controls.Add(this.linkLabel1);
            this.Controls.Add(this.btnCopyToFile);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.chkTopMost);
            this.Controls.Add(this.chkCase);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ComputeHash";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Compute Get Hash";
            this.TopMost = true;
            this.TransparencyKey = System.Drawing.Color.OrangeRed;
            this.Load += new System.EventHandler(this.ComputeHash_Load);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.ComputeHash_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.ComputeHash_MouseMove);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.ComputeHash_MouseUp);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			Process.Start("https://github.com/brahbarh/Compute-Get-Hash-/");
		}

		

		private void method_0(object sender, PropertyChangedEventArgs e)
		{
			Settings.Default.Save();
		}

		private void method_1()
		{
			MD5CryptoServiceProvider mD5CryptoServiceProvider = new MD5CryptoServiceProvider();
			byte[] numArray = mD5CryptoServiceProvider.ComputeHash(File.OpenRead(Class0.smethod_0()));
			StringBuilder stringBuilder = new StringBuilder();
			for (int i = 0; i < (int)numArray.Length; i++)
			{
				stringBuilder.Append(numArray[i].ToString("x2"));
			}
			mD5CryptoServiceProvider.Clear();
			ComputeHash.string_0 = (this.chkCase.Checked ? stringBuilder.ToString().ToUpper() : stringBuilder.ToString().ToLower());
		}

		private void method_2()
		{
			SHA1Managed sHA1Managed = new SHA1Managed();
			byte[] numArray = sHA1Managed.ComputeHash(File.OpenRead(Class0.smethod_0()));
			StringBuilder stringBuilder = new StringBuilder();
			for (int i = 0; i < (int)numArray.Length; i++)
			{
				stringBuilder.Append(numArray[i].ToString("x2"));
			}
			sHA1Managed.Clear();
			ComputeHash.string_1 = (this.chkCase.Checked ? stringBuilder.ToString().ToUpper() : stringBuilder.ToString().ToLower());
		}

		private void method_3()
		{
			SHA256Managed sHA256Managed = new SHA256Managed();
			byte[] numArray = sHA256Managed.ComputeHash(File.OpenRead(Class0.smethod_0()));
			StringBuilder stringBuilder = new StringBuilder();
			for (int i = 0; i < (int)numArray.Length; i++)
			{
				stringBuilder.Append(numArray[i].ToString("x2"));
			}
			sHA256Managed.Clear();
			ComputeHash.string_2 = (this.chkCase.Checked ? stringBuilder.ToString().ToUpper() : stringBuilder.ToString().ToLower());
		}

		private void method_4()
		{
			SHA384Managed sHA384Managed = new SHA384Managed();
			byte[] numArray = sHA384Managed.ComputeHash(File.OpenRead(Class0.smethod_0()));
			StringBuilder stringBuilder = new StringBuilder();
			for (int i = 0; i < (int)numArray.Length; i++)
			{
				stringBuilder.Append(numArray[i].ToString("x2"));
			}
			sHA384Managed.Clear();
			ComputeHash.string_3 = (this.chkCase.Checked ? stringBuilder.ToString().ToUpper() : stringBuilder.ToString().ToLower());
		}

		private void method_5()
		{
			SHA512Managed sHA512Managed = new SHA512Managed();
			byte[] numArray = sHA512Managed.ComputeHash(File.OpenRead(Class0.smethod_0()));
			StringBuilder stringBuilder = new StringBuilder();
			for (int i = 0; i < (int)numArray.Length; i++)
			{
				stringBuilder.Append(numArray[i].ToString("x2"));
			}
			sHA512Managed.Clear();
			ComputeHash.string_4 = (this.chkCase.Checked ? stringBuilder.ToString().ToUpper() : stringBuilder.ToString().ToLower());
		}

		internal static void smethod_0(bool bool_1)
		{
			Registry.CurrentUser.CreateSubKey("Software\\Classes\\*\\shell\\Compute Hash\\command").SetValue("", string.Concat(Path.Combine(Application.StartupPath, Application.ExecutablePath), " \"%1\""), RegistryValueKind.String);
			Registry.CurrentUser.CreateSubKey("Software\\Classes\\*\\shell\\Compute Hash").SetValue("Icon", Application.ExecutablePath, RegistryValueKind.String);
			if (bool_1)
			{
				MessageBox.Show("Compute Hash integrated to File Explorer's Context Menu", Class0.smethod_2(), MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
			}
		}

		internal static void smethod_1(bool bool_1)
		{
			try
			{
				Registry.CurrentUser.DeleteSubKeyTree("Software\\Classes\\*\\shell\\Compute Hash");
			}
			catch
			{
			}
			if (bool_1)
			{
				MessageBox.Show("Compute Hash removed from File Explorer's Context Menu", Class0.smethod_2(), MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
			}
		}

		private void timer_0_Tick(object sender, EventArgs e)
		{
			this.txtMD5.Text = ComputeHash.string_0;
			this.txtSHA1.Text = ComputeHash.string_1;
			this.txtSHA256.Text = ComputeHash.string_2;
			this.txtSHA384.Text = ComputeHash.string_3;
			this.txtSHA512.Text = ComputeHash.string_4;
		}

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void lnkSelectFile_LinkClicked(object sender, EventArgs e)
        {
            if (this.openFileDialog_0.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                Class0.smethod_1(this.openFileDialog_0.FileName);
                this.lblFilename.Text = string.Concat(Path.GetFileNameWithoutExtension(Class0.smethod_0()).Substring(0, (Path.GetFileNameWithoutExtension(Class0.smethod_0()).Length > 60 ? 60 : Path.GetFileNameWithoutExtension(Class0.smethod_0()).Length)), Path.GetExtension(Class0.smethod_0()));
                this.chkMD5.Checked = Settings.Default.MD5;
                this.chkSHA1.Checked = Settings.Default.SHA1;
                this.chkSHA256.Checked = Settings.Default.SHA256;
                this.chkSHA384.Checked = Settings.Default.SHA384;
                this.chkSHA512.Checked = Settings.Default.SHA512;
                this.chkCase.Checked = Settings.Default.UpperCase;
                CheckBox checkBox = this.chkTopMost;
                bool topMost = Settings.Default.TopMost;
                bool flag = topMost;
                checkBox.Checked = topMost;
                base.TopMost = flag;
                CheckBox checkBox1 = this.chkMD5;
                CheckBox checkBox2 = this.chkSHA1;
                CheckBox checkBox3 = this.chkSHA256;
                CheckBox checkBox4 = this.chkSHA384;
                this.chkSHA512.Enabled = false;
                checkBox4.Enabled = false;
                checkBox3.Enabled = false;
                flag = false;
                checkBox2.Enabled = false;
                checkBox1.Enabled = false;
                Label label = this.lblFilename;
                Label label1 = this.label1;
                this.lblProgress.Visible = true;
                flag = true;
                label1.Visible = true;
                label.Visible = true;
                this.backgroundWorker_0.RunWorkerAsync();
            }
        }
    }
}
