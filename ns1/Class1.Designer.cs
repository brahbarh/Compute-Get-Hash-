using System;
using System.Drawing;
using System.Globalization;
using System.Resources;

namespace ns1
	
{
	internal sealed class Class1
	{
		private static ResourceManager resourceManager_0;

		private static CultureInfo cultureInfo_0;

		internal static ResourceManager smethod_0()
		{
			if (Class1.resourceManager_0 == null)
			{
				Class1.resourceManager_0 = new ResourceManager("ns1.Class1", typeof(Class1).Assembly);
			}
			return Class1.resourceManager_0;
		}

		internal static Bitmap smethod_1()
		{
			return (Bitmap)Class1.smethod_0().GetObject("ComputeHashTitle", Class1.cultureInfo_0);
		}

		internal static Bitmap smethod_2()
		{
			return (Bitmap)Class1.smethod_0().GetObject("Loader", Class1.cultureInfo_0);
		}
	}
}
