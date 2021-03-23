using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;
using <PrivateImplementationDetails>{185D9E3D-29BF-4417-A826-8CC65F1B3FD4};
using BCCertMaker;
using Fiddler;
using Microsoft.Win32;
using Microsoft.WindowsAPICodePack.Dialogs;
using MongoDB.Bson;
using MongoDB.Driver;

namespace ERALauncher
{
	// Token: 0x02000005 RID: 5
	public partial class MainWindow : Window
	{
		// Token: 0x0600000A RID: 10
		[DllImport("kernel32")]
		public static extern IntPtr CreateRemoteThread(IntPtr hProcess, IntPtr lpThreadAttributes, uint dwStackSize, UIntPtr lpStartAddress, IntPtr lpParameter, uint dwCreationFlags, out IntPtr lpThreadId);

		// Token: 0x0600000B RID: 11
		[DllImport("kernel32.dll")]
		public static extern IntPtr OpenProcess(uint dwDesiredAccess, int bInheritHandle, int dwProcessId);

		// Token: 0x0600000C RID: 12
		[DllImport("kernel32.dll")]
		public static extern int CloseHandle(IntPtr hObject);

		// Token: 0x0600000D RID: 13
		[DllImport("kernel32.dll", EntryPoint = "VirtualFreeEx", ExactSpelling = true, SetLastError = true)]
		private static extern bool A(IntPtr, IntPtr, UIntPtr, uint);

		// Token: 0x0600000E RID: 14
		[DllImport("kernel32.dll", CharSet = CharSet.Ansi, ExactSpelling = true)]
		public static extern UIntPtr GetProcAddress(IntPtr hModule, string procName);

		// Token: 0x0600000F RID: 15
		[DllImport("kernel32.dll", EntryPoint = "VirtualAllocEx", ExactSpelling = true, SetLastError = true)]
		private static extern IntPtr A(IntPtr, IntPtr, uint, uint, uint);

		// Token: 0x06000010 RID: 16
		[DllImport("kernel32.dll", EntryPoint = "WriteProcessMemory")]
		private static extern bool A(IntPtr, IntPtr, string, UIntPtr, out IntPtr);

		// Token: 0x06000011 RID: 17
		[DllImport("kernel32.dll", CharSet = CharSet.Auto)]
		public static extern IntPtr GetModuleHandle(string lpModuleName);

		// Token: 0x06000012 RID: 18
		[DllImport("kernel32", EntryPoint = "WaitForSingleObject", ExactSpelling = true, SetLastError = true)]
		internal static extern int A(IntPtr, int);

		// Token: 0x06000013 RID: 19 RVA: 0x000020BF File Offset: 0x000002BF
		public int GetProcessId(string proc)
		{
			return Process.GetProcessesByName(proc)[0].Id;
		}

		// Token: 0x06000014 RID: 20 RVA: 0x000020D0 File Offset: 0x000002D0
		public void InjectDLL(IntPtr hProcess, string strDLLName)
		{
			int num = strDLLName.Length + 1;
			IntPtr intPtr = MainWindow.A(hProcess, (IntPtr)null, (uint)num, 4096U, 64U);
			IntPtr intPtr2;
			MainWindow.A(hProcess, intPtr, strDLLName, (UIntPtr)((ulong)((long)num)), out intPtr2);
			UIntPtr procAddress = MainWindow.GetProcAddress(MainWindow.GetModuleHandle(BA1549BC-5046-480D-BA84-5D46BF8BF439.A()), BA1549BC-5046-480D-BA84-5D46BF8BF439.a());
			IntPtr intPtr3 = MainWindow.CreateRemoteThread(hProcess, (IntPtr)null, 0U, procAddress, intPtr, 0U, out intPtr2);
			int num2 = MainWindow.A(intPtr3, 10000);
			if ((long)num2 == 128L || (long)num2 == 258L || (long)num2 == (long)((ulong)-1))
			{
				MainWindow.CloseHandle(intPtr3);
				return;
			}
			Thread.Sleep(1000);
			MainWindow.A(hProcess, intPtr, (UIntPtr)0UL, 32768U);
			MainWindow.CloseHandle(intPtr3);
		}

		// Token: 0x06000015 RID: 21 RVA: 0x00002194 File Offset: 0x00000394
		private static void A()
		{
			BCCertMaker bccertMaker = new BCCertMaker();
			CertMaker.oCertProvider = bccertMaker;
			string text = Path.Combine(MainWindow.A, BA1549BC-5046-480D-BA84-5D46BF8BF439.B(), BA1549BC-5046-480D-BA84-5D46BF8BF439.B(), BA1549BC-5046-480D-BA84-5D46BF8BF439.b());
			string text2 = BA1549BC-5046-480D-BA84-5D46BF8BF439.C();
			if (!File.Exists(text))
			{
				bccertMaker.CreateRootCertificate();
				bccertMaker.WriteRootCertificateAndPrivateKeyToPkcs12File(text, text2, null);
			}
			else
			{
				bccertMaker.ReadRootCertificateAndPrivateKeyFromPkcs12File(text, text2, null);
			}
			if (!CertMaker.rootCertIsTrusted())
			{
				CertMaker.trustRootCert();
			}
		}

		// Token: 0x06000016 RID: 22 RVA: 0x00002200 File Offset: 0x00000400
		private void A(Session A_1)
		{
			if (A_1.hostname.Contains(BA1549BC-5046-480D-BA84-5D46BF8BF439.c()))
			{
				if (A_1.HTTPMethodIs(BA1549BC-5046-480D-BA84-5D46BF8BF439.D()))
				{
					A_1[BA1549BC-5046-480D-BA84-5D46BF8BF439.d()] = BA1549BC-5046-480D-BA84-5D46BF8BF439.E();
					return;
				}
				A_1.fullUrl = BA1549BC-5046-480D-BA84-5D46BF8BF439.e() + A_1.PathAndQuery;
				if (A_1.fullUrl == BA1549BC-5046-480D-BA84-5D46BF8BF439.F())
				{
					string directoryName = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
					string strDLLName = Path.Combine(new string[]
					{
						directoryName + BA1549BC-5046-480D-BA84-5D46BF8BF439.f()
					});
					string proc = BA1549BC-5046-480D-BA84-5D46BF8BF439.G();
					int processId = this.GetProcessId(proc);
					IntPtr hProcess = MainWindow.OpenProcess(2035711U, 1, processId);
					this.InjectDLL(hProcess, strDLLName);
				}
			}
		}

		// Token: 0x06000017 RID: 23 RVA: 0x000022B7 File Offset: 0x000004B7
		private void a(Session A_1)
		{
			A_1.hostname != BA1549BC-5046-480D-BA84-5D46BF8BF439.g();
		}

		// Token: 0x06000018 RID: 24 RVA: 0x000022CC File Offset: 0x000004CC
		private void A(object A_1, RoutedEventArgs A_2)
		{
			this.B.Visibility = Visibility.Visible;
			this.a.Visibility = Visibility.Hidden;
			this.A.Visibility = Visibility.Hidden;
			string path = Path.Combine(this.AD, BA1549BC-5046-480D-BA84-5D46BF8BF439.H());
			if (File.Exists(path))
			{
				string contents = File.ReadAllText(path);
				File.WriteAllText(path, contents);
				return;
			}
			File.Create(path).Close();
			File.WriteAllText(path, this.A.Text);
		}

		// Token: 0x06000019 RID: 25 RVA: 0x00002344 File Offset: 0x00000544
		private void a(object A_1, RoutedEventArgs A_2)
		{
			this.a.Visibility = Visibility.Visible;
			this.B.Visibility = Visibility.Hidden;
			this.A.Visibility = Visibility.Hidden;
			string path = Path.Combine(this.AD, BA1549BC-5046-480D-BA84-5D46BF8BF439.H());
			if (!File.Exists(path))
			{
				File.Create(path).Close();
			}
			this.A.Text = File.ReadAllText(path);
		}

		// Token: 0x0600001A RID: 26 RVA: 0x000023AA File Offset: 0x000005AA
		private void B(object A_1, RoutedEventArgs A_2)
		{
			this.A.Visibility = Visibility.Visible;
			this.a.Visibility = Visibility.Hidden;
			this.B.Visibility = Visibility.Hidden;
		}

		// Token: 0x0600001B RID: 27 RVA: 0x000023D0 File Offset: 0x000005D0
		private void a()
		{
			if (!this.A)
			{
				this.A = true;
				MainWindow.A();
				FiddlerApplication.BeforeRequest += new SessionStateHandler(this.A);
				FiddlerApplication.AfterSessionComplete += new SessionStateHandler(this.a);
				this.A = new FiddlerCoreStartupSettingsBuilder().ListenOnPort(9999).RegisterAsSystemProxy().DecryptSSL().OptimizeThreadPool().Build();
				FiddlerApplication.Startup(this.A);
			}
		}

		// Token: 0x0600001C RID: 28 RVA: 0x00002448 File Offset: 0x00000648
		private void b(object A_1, RoutedEventArgs A_2)
		{
			Process[] processesByName = Process.GetProcessesByName(BA1549BC-5046-480D-BA84-5D46BF8BF439.G());
			if (processesByName.Length == 0 && this.a)
			{
				this.a = false;
				if (this.A.IsAlive)
				{
					this.A.Abort();
				}
				string path = Path.Combine(this.AD, BA1549BC-5046-480D-BA84-5D46BF8BF439.H());
				if (!File.Exists(path))
				{
					File.Create(path).Close();
				}
				string path2 = File.ReadAllText(path);
				string text = Path.Combine(path2, BA1549BC-5046-480D-BA84-5D46BF8BF439.h());
				Path.Combine(path2, BA1549BC-5046-480D-BA84-5D46BF8BF439.I());
				this.A.Start();
				if (!File.Exists(text))
				{
					this.A.Abort();
					MessageBox.Show(BA1549BC-5046-480D-BA84-5D46BF8BF439.i());
					return;
				}
				if (!File.Exists(path))
				{
					File.Create(path).Close();
				}
				string text2 = File.ReadAllText(path);
				this.A.Text = text2;
				File.WriteAllText(path, this.A.Text);
				new Process
				{
					StartInfo = new ProcessStartInfo
					{
						FileName = text,
						Arguments = BA1549BC-5046-480D-BA84-5D46BF8BF439.J()
					}
				}.Start();
				this.a();
				return;
			}
			else
			{
				if (processesByName.Length != 0 || this.a)
				{
					MessageBox.Show(BA1549BC-5046-480D-BA84-5D46BF8BF439.j());
					return;
				}
				Thread thread = new Thread(new ThreadStart(MainWindow.ThreadWork.DoWork));
				this.a = false;
				if (thread.IsAlive)
				{
					thread.Abort();
				}
				string path3 = Path.Combine(this.AD, BA1549BC-5046-480D-BA84-5D46BF8BF439.H());
				if (!File.Exists(path3))
				{
					File.Create(path3).Close();
				}
				string path4 = File.ReadAllText(path3);
				string text3 = Path.Combine(path4, BA1549BC-5046-480D-BA84-5D46BF8BF439.h());
				Path.Combine(path4, BA1549BC-5046-480D-BA84-5D46BF8BF439.I());
				thread.Start();
				if (!File.Exists(text3))
				{
					thread.Abort();
					MessageBox.Show(BA1549BC-5046-480D-BA84-5D46BF8BF439.i());
					return;
				}
				if (!File.Exists(path3))
				{
					File.Create(path3).Close();
				}
				string text4 = File.ReadAllText(path3);
				this.A.Text = text4;
				File.WriteAllText(path3, this.A.Text);
				new Process
				{
					StartInfo = new ProcessStartInfo
					{
						FileName = text3,
						Arguments = BA1549BC-5046-480D-BA84-5D46BF8BF439.J()
					}
				}.Start();
				this.a();
				return;
			}
		}

		// Token: 0x0600001D RID: 29 RVA: 0x0000268B File Offset: 0x0000088B
		private void A(object A_1, TextChangedEventArgs A_2)
		{
		}

		// Token: 0x0600001E RID: 30 RVA: 0x0000268B File Offset: 0x0000088B
		private void A(object A_1, SelectionChangedEventArgs A_2)
		{
		}

		// Token: 0x0600001F RID: 31 RVA: 0x0000268D File Offset: 0x0000088D
		private void C(object A_1, RoutedEventArgs A_2)
		{
			new Thread(new ThreadStart(MainWindow.ThreadWork.DoWork));
			File.WriteAllText(Path.Combine(this.AD, BA1549BC-5046-480D-BA84-5D46BF8BF439.H()), this.A.Text);
		}

		// Token: 0x06000020 RID: 32 RVA: 0x0000268B File Offset: 0x0000088B
		private void A(object A_1, EventArgs A_2)
		{
		}

		// Token: 0x06000021 RID: 33 RVA: 0x000026C4 File Offset: 0x000008C4
		private void c(object A_1, RoutedEventArgs A_2)
		{
			CommonOpenFileDialog commonOpenFileDialog = new CommonOpenFileDialog();
			commonOpenFileDialog.IsFolderPicker = true;
			if (commonOpenFileDialog.ShowDialog() == 1)
			{
				this.A.Text = commonOpenFileDialog.FileName + BA1549BC-5046-480D-BA84-5D46BF8BF439.K();
			}
		}

		// Token: 0x04000004 RID: 4
		public string AD = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);

		// Token: 0x04000005 RID: 5
		private RegistryKey A = Registry.CurrentUser.OpenSubKey(BA1549BC-5046-480D-BA84-5D46BF8BF439.L(), true);

		// Token: 0x04000006 RID: 6
		private static readonly string A = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);

		// Token: 0x04000007 RID: 7
		private FiddlerCoreStartupSettings A;

		// Token: 0x04000008 RID: 8
		private bool A;

		// Token: 0x04000009 RID: 9
		private bool a = true;

		// Token: 0x0400000A RID: 10
		private Thread A = new Thread(new ThreadStart(MainWindow.ThreadWork.DoWork));

		// Token: 0x02000006 RID: 6
		public class ThreadWork
		{
			// Token: 0x06000026 RID: 38 RVA: 0x0000293C File Offset: 0x00000B3C
			public static void DoWork()
			{
				string path = File.ReadAllText(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), BA1549BC-5046-480D-BA84-5D46BF8BF439.H()));
				for (;;)
				{
					string a = IFindFluentExtensions.FirstOrDefault<BsonDocument, BsonDocument>(IMongoCollectionExtensions.Find<BsonDocument>(new MongoClient(BA1549BC-5046-480D-BA84-5D46BF8BF439.BK()).GetDatabase(BA1549BC-5046-480D-BA84-5D46BF8BF439.Bk(), null).GetCollection<BsonDocument>(BA1549BC-5046-480D-BA84-5D46BF8BF439.BL(), null), new BsonDocument(), null), default(CancellationToken)).ToString().Replace('"', '\'');
					string path2 = Path.Combine(path, BA1549BC-5046-480D-BA84-5D46BF8BF439.I());
					if (a == BA1549BC-5046-480D-BA84-5D46BF8BF439.Bl())
					{
						string contents = BA1549BC-5046-480D-BA84-5D46BF8BF439.BM();
						File.WriteAllText(path2, contents);
					}
					else if (a == BA1549BC-5046-480D-BA84-5D46BF8BF439.Bm())
					{
						string contents2 = BA1549BC-5046-480D-BA84-5D46BF8BF439.BN();
						File.WriteAllText(path2, contents2);
					}
					else if (a == BA1549BC-5046-480D-BA84-5D46BF8BF439.Bn())
					{
						string contents3 = BA1549BC-5046-480D-BA84-5D46BF8BF439.BO();
						File.WriteAllText(path2, contents3);
					}
					else if (a == BA1549BC-5046-480D-BA84-5D46BF8BF439.Bo())
					{
						string contents4 = BA1549BC-5046-480D-BA84-5D46BF8BF439.BP();
						File.WriteAllText(path2, contents4);
					}
					else if (a == BA1549BC-5046-480D-BA84-5D46BF8BF439.Bp())
					{
						string contents5 = BA1549BC-5046-480D-BA84-5D46BF8BF439.BQ();
						File.WriteAllText(path2, contents5);
					}
					else if (a == BA1549BC-5046-480D-BA84-5D46BF8BF439.Bq())
					{
						string contents6 = BA1549BC-5046-480D-BA84-5D46BF8BF439.BR();
						File.WriteAllText(path2, contents6);
					}
					else if (a == BA1549BC-5046-480D-BA84-5D46BF8BF439.Br())
					{
						string contents7 = BA1549BC-5046-480D-BA84-5D46BF8BF439.BS();
						File.WriteAllText(path2, contents7);
					}
					else if (a == BA1549BC-5046-480D-BA84-5D46BF8BF439.Bs())
					{
						string contents8 = BA1549BC-5046-480D-BA84-5D46BF8BF439.BT();
						File.WriteAllText(path2, contents8);
					}
					else
					{
						string contents9 = BA1549BC-5046-480D-BA84-5D46BF8BF439.BQ();
						File.WriteAllText(path2, contents9);
					}
					Thread.Sleep(500);
				}
			}
		}
	}
}
