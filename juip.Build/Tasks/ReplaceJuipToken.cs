using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Build.Framework;

namespace juip.Build
{
    public class ReplaceJuipToken : Microsoft.Build.Utilities.Task
    {
        [Required]
        public ITaskItem ProjectDir { get; set; }
        [Required]
        public ITaskItem TargetName { get; set; }

        public override bool Execute()
        {
            try
            {

                const string token = "TargetName@juip";
                this.Log.LogMessageFromText("Replacing juip Tokens at - " + ProjectDir, MessageImportance.High);
                var controllerPath = System.IO.Path.Combine(this.ProjectDir.ToString(), "Controllers");
                var behaviorPath = System.IO.Path.Combine(this.ProjectDir.ToString(), "Behaviors");
                var viewPath = System.IO.Path.Combine(this.ProjectDir.ToString(), "Views");
                var viewModelPath = System.IO.Path.Combine(this.ProjectDir.ToString(), "ViewModels");

                var controllerFiles = System.IO.Directory.GetFiles(controllerPath);
                foreach (var controllerFile in controllerFiles)
                {
                    if (controllerFile.EndsWith(".juip.cs") || controllerFile.EndsWith(".juip.ascx"))
                    {
                        this.Log.LogMessageFromText(controllerFile, MessageImportance.High);
                        var content = System.IO.File.ReadAllText(controllerFile);
                        content = content.Replace(token, this.TargetName.ToString());
                        System.IO.File.WriteAllText(controllerFile, content);
                    }
                }

                var behaviorFiles = System.IO.Directory.GetFiles(behaviorPath);
                foreach (var behaviorFile in behaviorFiles)
                {
                    if (behaviorFile.EndsWith(".juip.cs"))
                    {
                        this.Log.LogMessageFromText(behaviorFile, MessageImportance.High);

                        var content = System.IO.File.ReadAllText(behaviorFile);
                        content = content.Replace(token, this.TargetName.ToString());
                        System.IO.File.WriteAllText(behaviorFile, content);
                    }
                }

                var viewPFiles = System.IO.Directory.GetFiles(viewPath);
                foreach (var viewFile in viewPFiles)
                {
                    if (viewFile.EndsWith(".juip.cs"))
                    {
                        this.Log.LogMessageFromText(viewFile, MessageImportance.High);

                        var content = System.IO.File.ReadAllText(viewFile);
                        content = content.Replace(token, this.TargetName.ToString());
                        System.IO.File.WriteAllText(viewFile, content);
                    }
                }

                var viewModelFiles = System.IO.Directory.GetFiles(viewModelPath);
                foreach (var viewModelFile in viewModelFiles)
                {
                    if (viewModelFile.EndsWith(".juip.cs"))
                    {
                        this.Log.LogMessageFromText(viewModelFile, MessageImportance.High);
                        var content = System.IO.File.ReadAllText(viewModelFile);
                        content = content.Replace(token, this.TargetName.ToString());
                        System.IO.File.WriteAllText(viewModelFile, content);
                    }
                }

                return true;
            }
            catch(Exception ex)
            {
                this.Log.LogError(ex.Message);
                throw;
            }
        }
    }
}
