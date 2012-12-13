using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EnvDTE;
using Microsoft.VisualStudio.TemplateWizard;

namespace adisware.juipp.build.Wizards
{
    public class BehaviorWizard : Microsoft.VisualStudio.TemplateWizard.IWizard
    {
        public void RunStarted(object automationObject, Dictionary<string, string> replacementsDictionary, WizardRunKind runKind, object[] customParams)
        {
            try
            {
                
            }
            catch(NotSupportedException ex)
            {
                throw new WizardCancelledException(ex.Message, ex);
            }
            catch(ArgumentException ex)
            {
                throw new WizardCancelledException(ex.Message, ex);
            }
        }

        public bool ShouldAddProjectItem(string filePath)
        {
            return true;
        }

        public void RunFinished()
        {
 
        }

        public void BeforeOpeningFile(ProjectItem projectItem)
        {
        }

        public void ProjectItemFinishedGenerating(ProjectItem projectItem)
        {
            var project = projectItem.ContainingProject;

            var filePath = (string) projectItem.Properties.Item("FullPath").Value;
        }

        public void ProjectFinishedGenerating(Project project)
        {
        }
    }
}
