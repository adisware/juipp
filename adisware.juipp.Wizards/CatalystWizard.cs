using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using EnvDTE;
using Microsoft.VisualStudio.TemplateWizard;
using VSLangProj;

namespace adisware.juipp.Wizards
{
    public class CatalystWizard : IWizard
    {
        private Project _project;
        private readonly List<ProjectItem> _items = new List<ProjectItem>();

        #region IWizard Members

        public void BeforeOpeningFile(ProjectItem projectItem)
        {
        }

        public void ProjectFinishedGenerating(Project project)
        {

        }

        public void ProjectItemFinishedGenerating(ProjectItem projectItem)
        {
            _project = projectItem.ContainingProject;
            _items.Add(projectItem);
        }


        public void RunFinished()
        {
            var catalysts = _project.ProjectItems.Item("_catalysts");

            this.RunCustomTool(catalysts);
        }

        public void RunCustomTool(ProjectItem catalysts)
        {

            foreach (var projectItem in catalysts.ProjectItems)
            {
                var item = (ProjectItem)projectItem;
                if (!item.FileNames[0].EndsWith(".tt"))
                {
                    if (!item.FileNames[0].EndsWith("_catalyst") || !item.FileNames[0].EndsWith("_catalyst/")) this.RunCustomTool(item);
                    continue;
                }
                var vsItem = item.Object as VSProjectItem;
                if (vsItem != null) vsItem.RunCustomTool();
            }
        }
        public void RunStarted(object automationObject, Dictionary<string, string> replacementsDictionary, WizardRunKind runKind, object[] customParams)
        {
        }

        public bool ShouldAddProjectItem(string filePath)
        {
            return true;
        }

        #endregion
    }
}
