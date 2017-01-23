using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace AutoBagBench
{
    public class SettingClass
    {
        private readonly Configuration _appConfiguration;

        public SettingClass()
        {
            _appConfiguration = ConfigurationManager.OpenExeConfiguration(AppLocation());
        }

        public string AppLocation()
        {
            var location = Assembly.GetExecutingAssembly().Location;
            return location;

        }
        public string AppPath()
        {
            var location = Assembly.GetExecutingAssembly().Location;
            return Path.GetDirectoryName(location);

        }
        private object GetCreateSetting(string parameter, string value)
        {

            try
            {
                return _appConfiguration.AppSettings.Settings[parameter].Value;
            }
            catch (Exception)
            {
                _appConfiguration.AppSettings.Settings.Add(new KeyValueConfigurationElement(parameter, value));
                return _appConfiguration.AppSettings.Settings[parameter].Value;
            }
        }
        private void SetCreateSetting(string parameter, string value)
        {
            try
            {
                _appConfiguration.AppSettings.Settings[parameter].Value = value;
            }
            catch (Exception)
            {
                _appConfiguration.AppSettings.Settings.Add(new KeyValueConfigurationElement(parameter, value));
            }
        }
        private string GetSetting(string parameter, string defaultValue)
        {
            return GetCreateSetting(parameter, defaultValue).ToString();
        }
        private void SetSetting(string parameter, string parameterValue)
        {
            SetCreateSetting(parameter, parameterValue);
        }

        public void Save()
        {
            _appConfiguration.Save();
        }

        public string EquipmentIdentity(string defaultValue)
        {
           return  GetSetting("EquipmentIdentity", defaultValue);
        }

        public void SetEquipmentIdentity(string value)
        {
            SetCreateSetting("EquipmentIdentity", value);
        }

        public string EquipmentName(string defaultValue)
        {
            return GetSetting("EquipmentName",defaultValue);
        }

        public void SetEquipmentName(string value)
        {
            SetCreateSetting("EquipmentName", value);
        }

        public bool TraceAbility(bool defaultValue)
        {
            try
            {
                return Convert.ToBoolean(GetSetting("Traceability", defaultValue.ToString()));
            }
            catch (Exception)
            {
                return false;
            }
        }

        public void SetTraceAbility(bool value)
        {
            SetCreateSetting("Traceability",value.ToString());
        }

        public string DataBaseServer(string defaultValue)
        {
            return GetSetting("DataBaseServer", defaultValue);
        }
        public void SetDataBaseServer(string value)
        {
            SetCreateSetting("DataBaseServer", value);
        }
        public string DataBaseCatalogue(string defaultValue)
        {
            return GetSetting("DataBaseCatalogue", defaultValue);
        }
        public void SetDataBaseCatalogue(string value)
        {
            SetCreateSetting("DataBaseCatalogue", value);
        }
        public string PlcIpAddress(string defaultValue)
        {
            return GetSetting("PlcIpAddress", defaultValue);
        }
        public void SetPlcIpAddress(string value)
        {
            SetCreateSetting("PlcIpAddress", value);
        }
        public int PlcPort(int defaultValue)
        {
            try
            {
                return Convert.ToInt32(GetSetting("PlcPort", defaultValue.ToString()));
            }
            catch (Exception)
            {
                return 502;
            }
        }
        public void SetPlcPort(int value)
        {
            SetCreateSetting("PlcPort", value.ToString());
        }

        public int PlcReadInterval(int defaultValue)
        {
            try
            {
                return Convert.ToInt32(GetSetting("PlcReadInterval", defaultValue.ToString()));
            }
            catch (Exception)
            {
                return 500;
            }
        }
        public void SetPlcReadInterval(int value)
        {
            SetCreateSetting("PlcReadInterval", value.ToString());
        }
        public string LabelIndividualPath(string defaultValue)
        {
            return GetSetting("LabelIndividualPath", defaultValue);
        }
        public void SetLabelIndividualPath(string value)
        {
            SetCreateSetting("LabelIndividualPath", value);
        }
        public string LabelIndividualImagePath(string defaultValue)
        {
            return GetSetting("LabelIndividualImagePath", defaultValue);
        }
        public void SetLabelIndividualImagePath(string value)
        {
            SetCreateSetting("LabelIndividualImagePath", value);
        }
        public string LabelGroupPath(string defaultValue)
        {
            return GetSetting("LabelGroupPath", defaultValue);
        }
        public void SetLabelGroupPath(string value)
        {
            SetCreateSetting("LabelGroupPath", value);
        }
        public string LabelGroupImagePath(string defaultValue)
        {
            return GetSetting("LabelGroupImagePath", defaultValue);
        }
        public void SetLabelGroupImagePath(string value)
        {
            SetCreateSetting("LabelGroupImagePath", value);
        }
        public string LabelGroupPrinter(string defaultValue)
        {
            return GetSetting("LabelGroupPrinter", defaultValue);
        }
        public void SetLabelGroupPrinter(string value)
        {
            SetCreateSetting("LabelGroupPrinter", value);
        }
        public string LabelIndividualPrinter(string defaultValue)
        {
            return GetSetting("LabelIndividualPrinter", defaultValue);
        }
        public void SetLabelIndividualPrinter(string value)
        {
            SetCreateSetting("LabelIndividualPrinter", value);
        }
        public string BarcodeReaderComName(string defaultValue)
        {
            return GetSetting("BarcodeReaderComName", defaultValue);
        }
        public void SetBarcodeReaderComName(string value)
        {
            SetCreateSetting("BarcodeReaderComName", value);
        }
        public int BarcodeReaderBaudRate(int defaultValue)
        {
            return Convert.ToInt32(GetSetting("BarcodeReaderBaudRate", defaultValue.ToString()));
        }
        public void SetBarcodeReaderBaudRatee(int value)
        {
            SetCreateSetting("BarcodeReaderBaudRate", value.ToString());
        }
        public int LastRunningProccessId(string defaultValue)
        {
            return Convert.ToInt32(GetSetting("LastRunningProccessId", defaultValue.ToString()));
        }
        public void SeLastRunningProccessId(string value)
        {
            SetCreateSetting("LastRunningProccessId",value);
        }
    }
}
