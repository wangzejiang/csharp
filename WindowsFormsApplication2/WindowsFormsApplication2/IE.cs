using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication2
{
    public class IE
    {
        /// <summary>
        /// 设置WebBrowser的默认版本
        /// </summary>
        /// <param name="ver">IE版本</param>
        public static void SetIE()
        {
            string productName = AppDomain.CurrentDomain.SetupInformation.ApplicationName;//获取程序名称
            object version = 0x2EDF;
            RegistryKey key = Registry.CurrentUser;
            string dd = @"Software\Microsoft\Internet Explorer\Main\FeatureControl\FEATURE_BROWSER_EMULATION\";
            RegistryKey software = key.CreateSubKey(dd + productName);
            if (software != null)
            {
                software.Close();
                software.Dispose();
            }
            RegistryKey wwui =
                key.OpenSubKey(dd, true);
            //该项必须已存在
            if (wwui != null) wwui.SetValue(productName, version, RegistryValueKind.DWord);
        }
    }
}
