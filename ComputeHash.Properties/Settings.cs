using System;
using System.Configuration;

namespace ComputeHash.Properties
{
	internal sealed class Settings : ApplicationSettingsBase
	{
		private static Settings defaultInstance;

		public static Settings Default
		{
			get
			{
				return Settings.defaultInstance;
			}
		}

		[DefaultSettingValue("True")]
		[UserScopedSetting]
		public bool MD5
		{
			get
			{
				return (bool)this["MD5"];
			}
			set
			{
				this["MD5"] = value;
			}
		}

		[DefaultSettingValue("True")]
		[UserScopedSetting]
		public bool SHA1
		{
			get
			{
				return (bool)this["SHA1"];
			}
			set
			{
				this["SHA1"] = value;
			}
		}

		[DefaultSettingValue("True")]
		[UserScopedSetting]
		public bool SHA256
		{
			get
			{
				return (bool)this["SHA256"];
			}
			set
			{
				this["SHA256"] = value;
			}
		}

		[DefaultSettingValue("True")]
		[UserScopedSetting]
		public bool SHA384
		{
			get
			{
				return (bool)this["SHA384"];
			}
			set
			{
				this["SHA384"] = value;
			}
		}

		[DefaultSettingValue("True")]
		[UserScopedSetting]
		public bool SHA512
		{
			get
			{
				return (bool)this["SHA512"];
			}
			set
			{
				this["SHA512"] = value;
			}
		}

		[DefaultSettingValue("True")]
		[UserScopedSetting]
		public bool TopMost
		{
			get
			{
				return (bool)this["TopMost"];
			}
			set
			{
				this["TopMost"] = value;
			}
		}

		[DefaultSettingValue("True")]
		[UserScopedSetting]
		public bool UpperCase
		{
			get
			{
				return (bool)this["UpperCase"];
			}
			set
			{
				this["UpperCase"] = value;
			}
		}

		static Settings()
		{
			Settings.defaultInstance = (Settings)SettingsBase.Synchronized(new Settings());
		}

		public Settings()
		{
		}
	}
}