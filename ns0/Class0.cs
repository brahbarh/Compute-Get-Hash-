using System;
using System.IO;
using System.Windows.Forms;

namespace ns0
{
	internal static class Class0
	{
		private static string string_0;

		private static string string_1;

		[STAThread]
		private static void Main(string[] args)
		{
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
			Class0.smethod_3(string.Concat(Application.ProductName, " ", Application.ProductVersion.Substring(0, 3)));
			if (args.Length == 0)
			{
				Application.Run(new ComputeHash());
				return;
			}
			string upper = args[0].ToUpper();
			if (upper == "/I")
			{
				ComputeHash.smethod_0(true);
				return;
			}
			if (upper == "/U")
			{
				ComputeHash.smethod_1(true);
				return;
			}
			if (File.Exists(args[0]))
			{
				Class0.smethod_1(Path.GetFullPath(args[0]));
			}
			Application.Run(new ComputeHash());
		}

		internal static string smethod_0()
		{
			return Class0.string_0;
		}

		internal static void smethod_1(string string_2)
		{
			Class0.string_0 = string_2;
		}

		internal static string smethod_2()
		{
			return Class0.string_1;
		}

		internal static void smethod_3(string string_2)
		{
			Class0.string_1 = string_2;
		}
	}
}