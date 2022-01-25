using EnvDTE;
using Microsoft.VisualStudio.TemplateWizard;
using System.Collections.Generic;
using System.IO;

namespace Orca.Template.Wizard
{
    public class ProjectWizard : IWizard
    {
        public void BeforeOpeningFile(ProjectItem projectItem)
        {
        }

        public void ProjectFinishedGenerating(Project project)
        {
        }

        public void ProjectItemFinishedGenerating(ProjectItem projectItem)
        {
        }

        public void RunFinished()
        {
        }

        public void RunStarted(object automationObject,
            Dictionary<string, string> replacementsDictionary,
            WizardRunKind runKind,
            object[] customParams)
        {
            var window = new WizardWindow();

            if (window.ShowDialog() == true)
            {
                replacementsDictionary["$pdmvault$"] = window.ProjectDetails.Vault;
                replacementsDictionary["$xmllicensefile$"] = window.ProjectDetails.LicensePath;

                var orcaVersion = window.ProjectDetails.OrcaVersion;
                if (orcaVersion.ToLower() == "latest")
                {
                    orcaVersion = "*";
                }

                replacementsDictionary["$orcaversion$"] = orcaVersion;
            }
            else
            {
                // remove project folder as its creation was cancelled
                var destinationDirectory = replacementsDictionary["$destinationdirectory$"];
                Directory.Delete(destinationDirectory, true);

                // remove solution directory if it is empty
                var solutionDirectory = replacementsDictionary["$solutiondirectory$"];
                if (Directory.Exists(solutionDirectory) &&
                    Directory.GetDirectories(solutionDirectory).Length == 0 && Directory.GetFiles(solutionDirectory).Length == 0)
                {
                    Directory.Delete(solutionDirectory);
                }

                throw new WizardBackoutException();
            }
        }

        public bool ShouldAddProjectItem(string filePath)
        {
            return true;
        }
    }
}
