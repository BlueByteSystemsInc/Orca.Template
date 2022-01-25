namespace Orca.Template.Wizard
{
    public class ProjectDetails
    {
        public string Vault { get; set; } = "";
        public string LicensePath { get; set; }
        public string OrcaVersion { get; set; } = "latest";

        public ProjectDetails()
        {
            var settings = new WizardSettings();
            settings.Load();
            LicensePath = settings.LicencePath;
        }
    }
}
