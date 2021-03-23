using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using System.Windows;
using <PrivateImplementationDetails>{185D9E3D-29BF-4417-A826-8CC65F1B3FD4};
using Microsoft.Win32;

namespace ERALauncher
{
	// Token: 0x02000007 RID: 7
	public class ERALauncher : Application
	{
		// Token: 0x06000028 RID: 40 RVA: 0x00002AD4 File Offset: 0x00000CD4
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
		public void InitializeComponent()
		{
			if (this.A)
			{
				return;
			}
			this.A = true;
			base.StartupUri = new Uri(BA1549BC-5046-480D-BA84-5D46BF8BF439.l(), UriKind.Relative);
			Uri resourceLocator = new Uri(BA1549BC-5046-480D-BA84-5D46BF8BF439.M(), UriKind.Relative);
			Application.LoadComponent(this, resourceLocator);
		}

		// Token: 0x06000029 RID: 41 RVA: 0x00002B15 File Offset: 0x00000D15
		[STAThread]
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
		public static void Main()
		{
			ERALauncher eralauncher = new ERALauncher();
			eralauncher.InitializeComponent();
			eralauncher.Run();
		}

		// Token: 0x0600002A RID: 42 RVA: 0x00002B28 File Offset: 0x00000D28
		protected override void OnExit(ExitEventArgs e)
		{
			RegistryKey registryKey = Registry.CurrentUser.OpenSubKey(BA1549BC-5046-480D-BA84-5D46BF8BF439.L(), true);
			registryKey.SetValue(BA1549BC-5046-480D-BA84-5D46BF8BF439.m(), 0);
			registryKey.SetValue(BA1549BC-5046-480D-BA84-5D46BF8BF439.N(), 0);
			Process[] processesByName = Process.GetProcessesByName(BA1549BC-5046-480D-BA84-5D46BF8BF439.n());
			for (int i = 0; i < processesByName.Length; i++)
			{
				processesByName[i].Kill();
			}
		}

		// Token: 0x04000017 RID: 23
		private bool A;
	}
}
