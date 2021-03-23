using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Globalization;
using System.Resources;
using System.Runtime.CompilerServices;

namespace A
{
	// Token: 0x02000002 RID: 2
	[GeneratedCode("System.Resources.Tools.StronglyTypedResourceBuilder", "4.0.0.0")]
	[DebuggerNonUserCode]
	[CompilerGenerated]
	internal class A
	{
		// Token: 0x06000002 RID: 2 RVA: 0x0000204F File Offset: 0x0000024F
		internal A()
		{
		}

		// Token: 0x17000001 RID: 1
		// (get) Token: 0x06000003 RID: 3 RVA: 0x00002057 File Offset: 0x00000257
		[EditorBrowsable(EditorBrowsableState.Advanced)]
		internal static ResourceManager A
		{
			get
			{
				if (global::A.A.A == null)
				{
					global::A.A.A = new ResourceManager("A.A", typeof(A).Assembly);
				}
				return global::A.A.A;
			}
		}

		// Token: 0x17000002 RID: 2
		// (get) Token: 0x06000004 RID: 4 RVA: 0x00002083 File Offset: 0x00000283
		// (set) Token: 0x06000005 RID: 5 RVA: 0x0000208A File Offset: 0x0000028A
		[EditorBrowsable(EditorBrowsableState.Advanced)]
		internal static CultureInfo a
		{
			get
			{
				return global::A.A.A;
			}
			set
			{
				global::A.A.A = value;
			}
		}

		// Token: 0x04000001 RID: 1
		private static ResourceManager A;

		// Token: 0x04000002 RID: 2
		private static CultureInfo A;
	}
}
