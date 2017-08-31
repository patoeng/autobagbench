using System;
using System.Configuration;
using System.Reflection;

namespace AutoBagBench
{
    public class SettingHelper
    {
        private static string SettingLocation()
        {
            var location = Assembly.GetExecutingAssembly().Location;
            return location;
        }

        private static Configuration AppConfig()
        {
            return ConfigurationManager.OpenExeConfiguration(SettingLocation());
        }
        private static object GetCreateSetting(string parameter, string value)
        {
            var kk = AppConfig();
            try
            {
                return kk.AppSettings.Settings[parameter].Value;
            }
            catch (Exception)
            {
                kk.AppSettings.Settings.Add(new KeyValueConfigurationElement(parameter, value));
                kk.Save();
                return kk.AppSettings.Settings[parameter].Value;
            }
        }
        private static void SetCreateSetting(string parameter, string value)
        {
            var kk = AppConfig();
            try
            {
                kk.AppSettings.Settings[parameter].Value = value;
                kk.Save();
            }
            catch (Exception)
            {
                kk.AppSettings.Settings.Add(new KeyValueConfigurationElement(parameter, value));
                kk.Save();
            }
        }
        private static object GetSetting(string key)
        {
            try
            {
                return AppConfig().AppSettings.Settings[key].Value;
            }
            catch (Exception)
            {
                return null;
            }
        }
        public static string EquipmentIdentity()
        {
            return (string) GetSetting("EquipmentIdentity");
        }

        public static string EquipmentName()
        {
            return (string)GetSetting("EquipmentName");
        }

        public static bool Traceability()
        {
            return Convert.ToBoolean(GetSetting("Traceability"));
        }
        public static string DataBaseServer()
        {
            return (string)GetSetting("DataBaseServer");
        }
        public static string DataBaseCatalogue()
        {
            return (string)GetSetting("DataBaseCatalogue");
        }
        public static string PlcIpAddress()
        {
            return (string)GetSetting("PlcIpAddress");
        }
        public static int PlcPort()
        {
            return Convert.ToInt32(GetSetting("PlcPort"));
        }
        public static int PlcReadInterval()
        {
            return Convert.ToInt32(GetSetting("PlcReadInterval"));
        }
        public static string LabelIndividualPath()
        {
            return (string)GetSetting("LabelIndividualPath");
        }
        public static string LabelIndividualImagePath()
        {
            return (string)GetSetting("LabelIndividualImagePath");
        }
        public static string LabelGroupPath()
        {
            return (string)GetSetting("LabelGroupPath");
        }
        public static string LabelGroupImagePath()
        {
            return (string)GetSetting("LabelGroupImagePath");
        }
        public static string LabelGroupPrinter()
        {
            return (string)GetSetting("LabelGroupPrinter");
        }
        public static string LabelIndividualPrinter()
        {
            return (string)GetSetting("LabelIndividualPrinter");
        }
        public static string BarcodeReaderComName()
        {
            return (string)GetSetting("BarcodeReaderComName");
        }
        public static int BarcodeReaderBaudRate()
        {
            return Convert.ToInt32(GetSetting("BarcodeReaderBaudRate"));
        }

        public static string LastRunningProccessId()
        {
            var j = (string)GetCreateSetting("LastRunningProccessId", new Guid().ToString());
            
            return j;
        }
        public static void SetLastRunningProccessId(string value)
        {
           SetCreateSetting("LastRunningProccessId", value);
        }
      
        public static string DatabaseConnection()
        {
            return
                $"Data Source={DataBaseServer()};Initial Catalog={DataBaseCatalogue()};Persist Security Info=True;User ID=sa;Password=passwordsa;MultipleActiveResultSets=True;Max Pool Size=500";
        }

        public static int GroupLabelHorizontalOffset()
        {
            var j = Convert.ToInt32(GetCreateSetting("GroupLabelHorizontalOffset", "0"));
            return j;
        }
        public static void SetGroupLabelHorizontalOffset(int value)
        {
            SetCreateSetting("GroupLabelHorizontalOffset", value.ToString());
        }
        public static int GroupLabelVerticalOffset()
        {
            var j = Convert.ToInt32(GetCreateSetting("GroupLabelVerticalOffset", "0"));
            return j;
        }
        public static void SetGroupLabelVerticalOffset(int value)
        {
            SetCreateSetting("GroupLabelVerticalOffset", value.ToString());
        }
        public static int IndividualLabelHorizontalOffset()
        {
            var j = Convert.ToInt32(GetCreateSetting("IndividualLabelHorizontalOffset", "0"));
            return j;
        }
        public static void SetIndividualLabelHorizontalOffset(int value)
        {
            SetCreateSetting("IndividualLabelHorizontalOffset", value.ToString());
        }
        public static int IndividualLabelVerticalOffset()
        {
            var j = Convert.ToInt32(GetCreateSetting("IndividualLabelVerticalOffset", "0"));
            return j;
        }
        public static void SetIndividualLabelVerticalOffset(int value)
        {
            SetCreateSetting("IndividualLabelVerticalOffset", value.ToString());
        }
        public static int IndividualLabelRotate()
        {
            var j = Convert.ToInt32(GetCreateSetting("IndividualLabelRotate", "0"));
            return j;
        }
        public static void SetIndividualLabelRotate(int value)
        {
            SetCreateSetting("IndividualLabelRotate", value.ToString());
        }
        public static int GroupLabelRotate()
        {
            var j = Convert.ToInt32(GetCreateSetting("GroupLabelRotate", "0"));
            return j;
        }
        public static void SetGroupLabelRotate(int value)
        {
            SetCreateSetting("GroupLabelRotate", value.ToString());
        }
        public static void SetPassword(string password)
        {
            SetCreateSetting("Password", password);
        }
        public static string GetPassword()
        {
            var j = (string)GetCreateSetting("Password", @"C/oXr8tjb/9jwTtkfeP9mEofPKzd2xjcmqUFOffug/xIXC0r6YIUJe9k/sOHY7cXCk+Dp7ORkELw4bC7k8GfhSA6tYwUglAQRGFam763ewl/0csodEuhen7QbI/f5B1i");
            return j;
        }
        public static string GetDatabaseConnection()
        {
            return (string)GetCreateSetting("DatabaseConnection", $"Data Source=127.0.0.1;Initial Catalog=XS156TRAC;Persist Security Info=True;User ID=sa;Password=passwordsa;MultipleActiveResultSets=True;Max Pool Size=500;");
        }
    }
}
