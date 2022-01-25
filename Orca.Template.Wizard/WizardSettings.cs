using SoftCircuits.WinSettings;

namespace Orca.Template.Wizard
{
    public class WizardSettings : RegistrySettings
    {
        public string LicencePath { get; set; }

        public WizardSettings() : base("Blue Byte Systems Inc", "Orca", RegistrySettingsType.CurrentUser)
        {
            LicencePath = "";
        }
    }
}
