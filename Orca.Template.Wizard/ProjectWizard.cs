using EnvDTE;
using Microsoft.VisualStudio.TemplateWizard;
using System;
using System.Collections.Generic;

namespace Orca.Template.Wizard
{
    public class ProjectWizard : IWizard
    {
        public void BeforeOpeningFile(ProjectItem projectItem)
        {
            throw new NotImplementedException();
        }

        public void ProjectFinishedGenerating(Project project)
        {
            throw new NotImplementedException();
        }

        public void ProjectItemFinishedGenerating(ProjectItem projectItem)
        {
            throw new NotImplementedException();
        }

        public void RunFinished()
        {
            throw new NotImplementedException();
        }

        public void RunStarted(object automationObject, Dictionary<string, string> replacementsDictionary, WizardRunKind runKind, object[] customParams)
        {
            throw new NotImplementedException();
        }

        public bool ShouldAddProjectItem(string filePath)
        {
            throw new NotImplementedException();
        }
    }
}
