using Gma.System.MouseKeyHook;
using Microsoft.VisualBasic;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.Threading;
using System.Drawing;
using System.IO;
using IniParser;
using IniParser.Model;
using System.Runtime.CompilerServices;

namespace move_win10_notification
{
	public partial class Form1 : Form
	{
		private string runningPath = Path.GetFullPath(System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"data\running.ico"));
		private string stoppedPath = Path.GetFullPath(System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"data\stopped.ico"));
		private bool running = false;
		private bool minimized = false;
		private Thread moveNotifyThread;
		private moveNotify moveNotifyWorker = new moveNotify();
		private IKeyboardMouseEvents globalHook = Hook.GlobalEvents();
		IntPtr hwnd = new IntPtr(0);
		private Form rect = new Form();
		public Form1()
		{
			InitializeComponent();

		}

		private void LoadIniFile(string path)
		{
			if (!File.Exists(path))
			{
				SaveIniFile(path);
			}
			try
			{
				var parser = new FileIniDataParser();
				IniData data = parser.ReadFile(path);
				xPosTxtBox.Text = data["Settings"]["X_Pos"];
				yPosTxtBox.Text = data["Settings"]["Y_Pos"];
				running = bool.Parse(data["Settings"]["run_on_start"]);
				minimized = bool.Parse(data["Settings"]["minimized"]);
				checkBox2.Checked = minimized;
				checkBox1.Checked = running;
			}
			catch (Exception e)
			{
				MessageBox.Show("Error loading INI file! \n Saving Default Data to Ini File.", "Caution", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				SaveIniFile(path);
			}
			finally
			{
				var parser = new FileIniDataParser();
				IniData data = parser.ReadFile(path);
				xPosTxtBox.Text = data["Settings"]["X_Pos"];
				yPosTxtBox.Text = data["Settings"]["Y_Pos"];
				running = bool.Parse(data["Settings"]["run_on_start"]);
				minimized = bool.Parse(data["Settings"]["minimized"]);
				checkBox2.Checked = minimized;
				checkBox1.Checked = running;
			}

		}

		private void SaveIniFile(string path)
		{
			var parser = new FileIniDataParser();
			IniData data = new IniData();
			data["Settings"]["X_Pos"] = (xPosTxtBox.Text != String.Empty) ? xPosTxtBox.Text : "12";
			data["Settings"]["Y_Pos"] = (yPosTxtBox.Text != String.Empty) ? yPosTxtBox.Text : "12";
			data["Settings"]["run_on_start"] = checkBox1.Checked.ToString();
			data["Settings"]["minimized"] = checkBox2.Checked.ToString();
			parser.WriteFile(path, data);
		}

		private void Form1_Load(object sender, EventArgs e)
		{
			LoadIniFile(Path.GetFullPath(System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"data\config.ini")));
			notifyIcon1.Visible = true;
			notifyIcon1.Text = "Notification Relocator";
			rect.FormBorderStyle = FormBorderStyle.FixedSingle;
			rect.Text = string.Empty;
			rect.ControlBox = false;
			rect.Opacity = 0.5;
			rect.Width = 363;
			rect.Height = 193;
			hwnd = this.Handle;
			if (running)
			{
				notifyIcon1.Icon = new System.Drawing.Icon(this.runningPath);
				this.startToggleBtn.Text = "Stop";
				startToolStripMenuItem.Text = "Stop";
				this.statusPanel.BackColor = Color.Lime;
				moveNotifyWorker.x = (xPosTxtBox.Text != String.Empty) ? Int32.Parse(xPosTxtBox.Text) : 12;
				moveNotifyWorker.y = (yPosTxtBox.Text != String.Empty) ? Int32.Parse(yPosTxtBox.Text) : 12;
				moveNotifyWorker.running = true;
				moveNotifyThread = new Thread(moveNotifyWorker.moveNotification);
				moveNotifyThread.Start();
			}
			else
			{
				notifyIcon1.Icon = new System.Drawing.Icon(this.stoppedPath);
				this.startToggleBtn.Text = "Start";
				startToolStripMenuItem.Text = "Start";
				this.statusPanel.BackColor = Color.Red;
			}
			
			if (minimized)
			{
				this.WindowState = FormWindowState.Minimized;
			}
		}

		private void notifyIcon1_DoubleClick(object sender, EventArgs e)
		{
			this.Show();

			WindowState = FormWindowState.Normal;

		}

		private void Form1_Resize(object sender, EventArgs e)
		{
			if (WindowState == FormWindowState.Minimized)
			{
				this.Hide();
				notifyIcon1.BalloonTipTitle = "Notification Relocator";

				notifyIcon1.BalloonTipText = "Notification Relocator Minimized";
				notifyIcon1.ShowBalloonTip(1000);
			}

		}

		private void Form1_FormClosing(object sender, FormClosingEventArgs e)
		{
			if (e.CloseReason == CloseReason.WindowsShutDown) return;
			e.Cancel = true;
			if (MessageBox.Show("Minimized to Tray?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
			{
				this.WindowState = FormWindowState.Minimized;
			}
			else
			{
				closeApp();
			}
		}

		private void closeToolStripMenuItem_Click(object sender, EventArgs e)
		{
			closeApp();
		}

		private void closeApp()
		{
			notifyIcon1.Visible = false;
			notifyIcon1.Dispose();

			System.Environment.Exit(1);
		}
		private void toggleScript()
		{
			if (running)
			{
				startToolStripMenuItem.Text = "Start";
				startToggleBtn.Text = "Start";
				statusPanel.BackColor = Color.Red;
				notifyIcon1.Icon = new System.Drawing.Icon(this.stoppedPath);
				running = false;
				moveNotifyWorker.running = false;
				moveNotifyThread.Join();
			}
			else
			{
				if (xPosTxtBox.Text != "" && yPosTxtBox.Text != "")
				{
					startToolStripMenuItem.Text = "Stop";
					startToggleBtn.Text = "Stop";
					statusPanel.BackColor = Color.Lime;
					notifyIcon1.Icon = new System.Drawing.Icon(this.runningPath);
					running = true;
					moveNotifyWorker.x = (xPosTxtBox.Text != String.Empty) ? Int32.Parse(xPosTxtBox.Text) : 12;
					moveNotifyWorker.y = (yPosTxtBox.Text != String.Empty) ? Int32.Parse(yPosTxtBox.Text) : 12;
					moveNotifyWorker.running = true;
					moveNotifyThread = new Thread(moveNotifyWorker.moveNotification);
					moveNotifyThread.Start();
				}
			}
		}

		private void startToggleBtn_Click(object sender, EventArgs e)
		{
			toggleScript();
		}

		[DllImport("user32.dll")]
		static extern bool GetCursorPos(ref Point lpPoint);
		[DllImport("user32.dll")]
		static extern IntPtr SetForegroundWindow(IntPtr hWnd);
		private void getLocationBtn_Click(object sender, EventArgs e)
		{
			if (running) { toggleScript(); }
			globalHook.MouseMove += capturePos;
			globalHook.MouseClick += confirmLoc;
		}

		private void capturePos(object sender, MouseEventArgs e)
		{
			if (!rect.Visible) { rect.Visible = true; }
			Point p = new Point();
			if (GetCursorPos(ref p))
			{
				xPosTxtBox.Text = p.X.ToString();
				yPosTxtBox.Text = p.Y.ToString();
				rect.Location = p;
			}
		}

		private void confirmLoc(object sender, MouseEventArgs e)
		{
			globalHook.MouseMove -= capturePos;
			globalHook.MouseClick -= confirmLoc;
			if (rect.Visible) { rect.Visible = false; }
			SetForegroundWindow(hwnd);
		}

		private void testNotificationBtn_Click(object sender, EventArgs e)
		{
			notifyIcon1.BalloonTipText = "On the other hand, we denounce with righteous indignation and dislike men who are so beguiled and demoralized by the charms of pleasure of the moment, so blinded by desire, that they cannot foresee the pain and trouble that are bound to ensue; and equal blame belongs to those who fail in their duty through weakness of will, which is the same as saying through shrinking from toil and pain. These cases are perfectly simple and easy to distinguish. In a free hour, when our power of choice is untrammelled and when nothing prevents our being able to do what we like best, every pleasure is to be welcomed and every pain avoided. But in certain circumstances and owing to the claims of duty or the obligations of business it will frequently occur that pleasures have to be repudiated and annoyances accepted. The wise man therefore always holds in these matters to this principle of selection: he rejects pleasures to secure other greater pleasures, or else he endures pains to avoid worse pains.\"";
			notifyIcon1.ShowBalloonTip(2000);
		}

		private void saveConfigBtn_Click(object sender, EventArgs e)
		{
			SaveIniFile(Path.GetFullPath(System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"data\config.ini")));

		}

		private void startToolStripMenuItem_Click(object sender, EventArgs e)
		{
			toggleScript();
		}
	}
}
