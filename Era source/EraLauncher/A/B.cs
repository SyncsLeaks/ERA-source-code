using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.IO.Compression;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Threading;
using <PrivateImplementationDetails>{185D9E3D-29BF-4417-A826-8CC65F1B3FD4};

namespace A
{
	// Token: 0x02000008 RID: 8
	[CompilerGenerated]
	internal static class B
	{
		// Token: 0x0600002C RID: 44 RVA: 0x00002B87 File Offset: 0x00000D87
		private static string A(CultureInfo A_0)
		{
			if (A_0 == null)
			{
				return BA1549BC-5046-480D-BA84-5D46BF8BF439.O();
			}
			return A_0.Name;
		}

		// Token: 0x0600002D RID: 45 RVA: 0x00002B98 File Offset: 0x00000D98
		private static Assembly A(AssemblyName A_0)
		{
			AppDomain currentDomain = AppDomain.CurrentDomain;
			Assembly[] assemblies = currentDomain.GetAssemblies();
			foreach (Assembly assembly in assemblies)
			{
				AssemblyName name = assembly.GetName();
				if (string.Equals(name.Name, A_0.Name, StringComparison.InvariantCultureIgnoreCase) && string.Equals(B.A(name.CultureInfo), B.A(A_0.CultureInfo), StringComparison.InvariantCultureIgnoreCase))
				{
					return assembly;
				}
			}
			return null;
		}

		// Token: 0x0600002E RID: 46 RVA: 0x00002C08 File Offset: 0x00000E08
		private static void A(Stream A_0, Stream A_1)
		{
			byte[] array = new byte[81920];
			int count;
			while ((count = A_0.Read(array, 0, array.Length)) != 0)
			{
				A_1.Write(array, 0, count);
			}
		}

		// Token: 0x0600002F RID: 47 RVA: 0x00002C3C File Offset: 0x00000E3C
		private static Stream A(string A_0)
		{
			Assembly executingAssembly = Assembly.GetExecutingAssembly();
			if (A_0.EndsWith(BA1549BC-5046-480D-BA84-5D46BF8BF439.o()))
			{
				using (Stream manifestResourceStream = executingAssembly.GetManifestResourceStream(A_0))
				{
					using (DeflateStream deflateStream = new DeflateStream(manifestResourceStream, CompressionMode.Decompress))
					{
						MemoryStream memoryStream = new MemoryStream();
						B.A(deflateStream, memoryStream);
						memoryStream.Position = 0L;
						return memoryStream;
					}
				}
			}
			return executingAssembly.GetManifestResourceStream(A_0);
		}

		// Token: 0x06000030 RID: 48 RVA: 0x00002CC0 File Offset: 0x00000EC0
		private static Stream A(Dictionary<string, string> A_0, string A_1)
		{
			string text;
			if (A_0.TryGetValue(A_1, out text))
			{
				return B.A(text);
			}
			return null;
		}

		// Token: 0x06000031 RID: 49 RVA: 0x00002CE0 File Offset: 0x00000EE0
		private static byte[] A(Stream A_0)
		{
			byte[] array = new byte[A_0.Length];
			A_0.Read(array, 0, array.Length);
			return array;
		}

		// Token: 0x06000032 RID: 50 RVA: 0x00002D08 File Offset: 0x00000F08
		private static Assembly A(Dictionary<string, string> A_0, Dictionary<string, string> A_1, AssemblyName A_2)
		{
			string text = A_2.Name.ToLowerInvariant();
			if (A_2.CultureInfo != null && !string.IsNullOrEmpty(A_2.CultureInfo.Name))
			{
				text = A_2.CultureInfo.Name + BA1549BC-5046-480D-BA84-5D46BF8BF439.P() + text;
			}
			byte[] rawAssembly;
			using (Stream stream = B.A(A_0, text))
			{
				if (stream == null)
				{
					return null;
				}
				rawAssembly = B.A(stream);
			}
			using (Stream stream2 = B.A(A_1, text))
			{
				if (stream2 != null)
				{
					byte[] rawSymbolStore = B.A(stream2);
					return Assembly.Load(rawAssembly, rawSymbolStore);
				}
			}
			return Assembly.Load(rawAssembly);
		}

		// Token: 0x06000033 RID: 51 RVA: 0x00002DC8 File Offset: 0x00000FC8
		public static Assembly A(object A_0, ResolveEventArgs A_1)
		{
			object obj = B.A;
			lock (obj)
			{
				if (B.A.ContainsKey(A_1.Name))
				{
					return null;
				}
			}
			AssemblyName assemblyName = new AssemblyName(A_1.Name);
			Assembly assembly = B.A(assemblyName);
			if (assembly != null)
			{
				return assembly;
			}
			assembly = B.A(B.A, B.a, assemblyName);
			if (assembly == null)
			{
				object obj2 = B.A;
				lock (obj2)
				{
					B.A[A_1.Name] = true;
				}
				if ((assemblyName.Flags & AssemblyNameFlags.Retargetable) != AssemblyNameFlags.None)
				{
					assembly = Assembly.Load(assemblyName);
				}
			}
			return assembly;
		}

		// Token: 0x06000034 RID: 52 RVA: 0x00002EAC File Offset: 0x000010AC
		// Note: this type is marked as 'beforefieldinit'.
		static B()
		{
			B.A.Add(BA1549BC-5046-480D-BA84-5D46BF8BF439.p(), BA1549BC-5046-480D-BA84-5D46BF8BF439.Q());
			B.A.Add(BA1549BC-5046-480D-BA84-5D46BF8BF439.q(), BA1549BC-5046-480D-BA84-5D46BF8BF439.R());
			B.A.Add(BA1549BC-5046-480D-BA84-5D46BF8BF439.r(), BA1549BC-5046-480D-BA84-5D46BF8BF439.S());
			B.A.Add(BA1549BC-5046-480D-BA84-5D46BF8BF439.s(), BA1549BC-5046-480D-BA84-5D46BF8BF439.T());
			B.a.Add(BA1549BC-5046-480D-BA84-5D46BF8BF439.s(), BA1549BC-5046-480D-BA84-5D46BF8BF439.t());
			B.A.Add(BA1549BC-5046-480D-BA84-5D46BF8BF439.U(), BA1549BC-5046-480D-BA84-5D46BF8BF439.u());
			B.A.Add(BA1549BC-5046-480D-BA84-5D46BF8BF439.V(), BA1549BC-5046-480D-BA84-5D46BF8BF439.v());
			B.A.Add(BA1549BC-5046-480D-BA84-5D46BF8BF439.W(), BA1549BC-5046-480D-BA84-5D46BF8BF439.w());
			B.A.Add(BA1549BC-5046-480D-BA84-5D46BF8BF439.X(), BA1549BC-5046-480D-BA84-5D46BF8BF439.x());
			B.a.Add(BA1549BC-5046-480D-BA84-5D46BF8BF439.X(), BA1549BC-5046-480D-BA84-5D46BF8BF439.Y());
			B.A.Add(BA1549BC-5046-480D-BA84-5D46BF8BF439.y(), BA1549BC-5046-480D-BA84-5D46BF8BF439.Z());
			B.A.Add(BA1549BC-5046-480D-BA84-5D46BF8BF439.z(), BA1549BC-5046-480D-BA84-5D46BF8BF439.aA());
			B.A.Add(BA1549BC-5046-480D-BA84-5D46BF8BF439.aa(), BA1549BC-5046-480D-BA84-5D46BF8BF439.aB());
			B.a.Add(BA1549BC-5046-480D-BA84-5D46BF8BF439.aa(), BA1549BC-5046-480D-BA84-5D46BF8BF439.ab());
			B.A.Add(BA1549BC-5046-480D-BA84-5D46BF8BF439.aC(), BA1549BC-5046-480D-BA84-5D46BF8BF439.ac());
			B.A.Add(BA1549BC-5046-480D-BA84-5D46BF8BF439.aD(), BA1549BC-5046-480D-BA84-5D46BF8BF439.ad());
			B.A.Add(BA1549BC-5046-480D-BA84-5D46BF8BF439.aE(), BA1549BC-5046-480D-BA84-5D46BF8BF439.ae());
			B.A.Add(BA1549BC-5046-480D-BA84-5D46BF8BF439.aF(), BA1549BC-5046-480D-BA84-5D46BF8BF439.af());
			B.A.Add(BA1549BC-5046-480D-BA84-5D46BF8BF439.aG(), BA1549BC-5046-480D-BA84-5D46BF8BF439.ag());
			B.A.Add(BA1549BC-5046-480D-BA84-5D46BF8BF439.aH(), BA1549BC-5046-480D-BA84-5D46BF8BF439.ah());
			B.A.Add(BA1549BC-5046-480D-BA84-5D46BF8BF439.aI(), BA1549BC-5046-480D-BA84-5D46BF8BF439.ai());
			B.a.Add(BA1549BC-5046-480D-BA84-5D46BF8BF439.aI(), BA1549BC-5046-480D-BA84-5D46BF8BF439.aJ());
			B.A.Add(BA1549BC-5046-480D-BA84-5D46BF8BF439.aj(), BA1549BC-5046-480D-BA84-5D46BF8BF439.aK());
			B.a.Add(BA1549BC-5046-480D-BA84-5D46BF8BF439.aj(), BA1549BC-5046-480D-BA84-5D46BF8BF439.ak());
			B.A.Add(BA1549BC-5046-480D-BA84-5D46BF8BF439.aL(), BA1549BC-5046-480D-BA84-5D46BF8BF439.al());
			B.a.Add(BA1549BC-5046-480D-BA84-5D46BF8BF439.aL(), BA1549BC-5046-480D-BA84-5D46BF8BF439.aM());
			B.A.Add(BA1549BC-5046-480D-BA84-5D46BF8BF439.am(), BA1549BC-5046-480D-BA84-5D46BF8BF439.aN());
			B.A.Add(BA1549BC-5046-480D-BA84-5D46BF8BF439.an(), BA1549BC-5046-480D-BA84-5D46BF8BF439.aO());
			B.A.Add(BA1549BC-5046-480D-BA84-5D46BF8BF439.ao(), BA1549BC-5046-480D-BA84-5D46BF8BF439.aP());
			B.A.Add(BA1549BC-5046-480D-BA84-5D46BF8BF439.ap(), BA1549BC-5046-480D-BA84-5D46BF8BF439.aQ());
			B.A.Add(BA1549BC-5046-480D-BA84-5D46BF8BF439.aq(), BA1549BC-5046-480D-BA84-5D46BF8BF439.aR());
			B.A.Add(BA1549BC-5046-480D-BA84-5D46BF8BF439.ar(), BA1549BC-5046-480D-BA84-5D46BF8BF439.aS());
			B.A.Add(BA1549BC-5046-480D-BA84-5D46BF8BF439.@as(), BA1549BC-5046-480D-BA84-5D46BF8BF439.aT());
			B.A.Add(BA1549BC-5046-480D-BA84-5D46BF8BF439.at(), BA1549BC-5046-480D-BA84-5D46BF8BF439.aU());
			B.A.Add(BA1549BC-5046-480D-BA84-5D46BF8BF439.au(), BA1549BC-5046-480D-BA84-5D46BF8BF439.aV());
			B.A.Add(BA1549BC-5046-480D-BA84-5D46BF8BF439.av(), BA1549BC-5046-480D-BA84-5D46BF8BF439.aW());
			B.A.Add(BA1549BC-5046-480D-BA84-5D46BF8BF439.aw(), BA1549BC-5046-480D-BA84-5D46BF8BF439.aX());
			B.A.Add(BA1549BC-5046-480D-BA84-5D46BF8BF439.ax(), BA1549BC-5046-480D-BA84-5D46BF8BF439.aY());
			B.A.Add(BA1549BC-5046-480D-BA84-5D46BF8BF439.ay(), BA1549BC-5046-480D-BA84-5D46BF8BF439.aZ());
			B.A.Add(BA1549BC-5046-480D-BA84-5D46BF8BF439.az(), BA1549BC-5046-480D-BA84-5D46BF8BF439.BA());
			B.A.Add(BA1549BC-5046-480D-BA84-5D46BF8BF439.Ba(), BA1549BC-5046-480D-BA84-5D46BF8BF439.BB());
			B.A.Add(BA1549BC-5046-480D-BA84-5D46BF8BF439.Bb(), BA1549BC-5046-480D-BA84-5D46BF8BF439.BC());
			B.A.Add(BA1549BC-5046-480D-BA84-5D46BF8BF439.Bc(), BA1549BC-5046-480D-BA84-5D46BF8BF439.BD());
			B.A.Add(BA1549BC-5046-480D-BA84-5D46BF8BF439.Bd(), BA1549BC-5046-480D-BA84-5D46BF8BF439.BE());
			B.A.Add(BA1549BC-5046-480D-BA84-5D46BF8BF439.Be(), BA1549BC-5046-480D-BA84-5D46BF8BF439.BF());
			B.a.Add(BA1549BC-5046-480D-BA84-5D46BF8BF439.Be(), BA1549BC-5046-480D-BA84-5D46BF8BF439.Bf());
			B.A.Add(BA1549BC-5046-480D-BA84-5D46BF8BF439.BG(), BA1549BC-5046-480D-BA84-5D46BF8BF439.Bg());
			B.A.Add(BA1549BC-5046-480D-BA84-5D46BF8BF439.BH(), BA1549BC-5046-480D-BA84-5D46BF8BF439.Bh());
			B.A.Add(BA1549BC-5046-480D-BA84-5D46BF8BF439.BI(), BA1549BC-5046-480D-BA84-5D46BF8BF439.Bi());
			B.A.Add(BA1549BC-5046-480D-BA84-5D46BF8BF439.BJ(), BA1549BC-5046-480D-BA84-5D46BF8BF439.Bj());
		}

		// Token: 0x06000035 RID: 53 RVA: 0x000032CC File Offset: 0x000014CC
		public static void A()
		{
			if (Interlocked.Exchange(ref B.A, 1) == 1)
			{
				return;
			}
			AppDomain currentDomain = AppDomain.CurrentDomain;
			currentDomain.AssemblyResolve += B.A;
		}

		// Token: 0x04000018 RID: 24
		private static object A = new object();

		// Token: 0x04000019 RID: 25
		private static Dictionary<string, bool> A = new Dictionary<string, bool>();

		// Token: 0x0400001A RID: 26
		private static Dictionary<string, string> A = new Dictionary<string, string>();

		// Token: 0x0400001B RID: 27
		private static Dictionary<string, string> a = new Dictionary<string, string>();

		// Token: 0x0400001C RID: 28
		private static int A;
	}
}
