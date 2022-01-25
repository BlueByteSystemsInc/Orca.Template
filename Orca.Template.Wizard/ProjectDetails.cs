using Microsoft.Win32;
using System;
using System.Linq;

namespace Orca.Template.Wizard
{
    public class ProjectDetails
    {
        public string Vault { get; set; } = "";
        public string LicensePath { get; set; }
        public string OrcaVersion { get; set; } = "latest";

        public string[] FileVaults { get; }

        public ProjectDetails()
        {
            var settings = new WizardSettings();
            settings.Load();
            LicensePath = settings.LicencePath;

            FileVaults = GetFileVaultsFromRegistry();
        }

        private string[] GetFileVaultsFromRegistry()
        {
            try
            {
                using var serversKey = Registry.CurrentUser.OpenSubKey(@"SOFTWARE\SolidWorks\Applications\PDMWorks Enterprise\ConisioAdmin\Servers\");
                var server = serversKey?.GetSubKeyNames().FirstOrDefault();
                if (server != null)
                {
                    using var key = serversKey.OpenSubKey(server + @"\FileVaults");
                    return key?.GetSubKeyNames();
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Error while getting registry values: " + ex.ToString());
            }
            return new string[0];
        }
    }
}
