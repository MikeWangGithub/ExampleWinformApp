using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace BaseClassLibrary.Configuration
{
    public static class AppConfig
    {
        /// <summary>
        /// return  the value of the item(key) in  *.exe.config files appSettings configuration
        /// </summary>
        /// <param name="strKey"></param>
        /// <returns></returns>
        public static string GetAppConfig(string strKey)
        {
            //if(ConfigurationManager.AppSettings.getvalue
            foreach (string key in ConfigurationManager.AppSettings)
            {
                if (key.Trim().ToLower() == strKey.Trim().ToLower())
                {
                    return ConfigurationManager.AppSettings[strKey];
                }
            }
            return "";
        }
        /// <summary>
        /// Save value to Config File
        /// </summary>
        /// <param name="AppPath"></param>
        /// <param name="strKey"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public static bool SaveAppConfig(string AppPath, string strKey, string value)
        {
            bool rtn = true;
            try
            {
                
                System.Configuration.Configuration con = ConfigurationManager.OpenExeConfiguration(AppPath);
                con.AppSettings.Settings[strKey].Value = value;
                //
                con.AppSettings.SectionInformation.ForceSave = true;
                con.Save(ConfigurationSaveMode.Modified);
                //
                ConfigurationManager.RefreshSection("appSettings");
            }
            catch 
            {
                rtn = false;
            }
            return rtn;
        }
        
    }
}
