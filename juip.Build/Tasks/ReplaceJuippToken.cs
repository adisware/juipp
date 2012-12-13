using System;
using System.IO;
using System.Linq;
using Microsoft.Build.Framework;

namespace adisware.juipp.build.Tasks
{
    public class ReplaceJuippToken : Microsoft.Build.Utilities.Task
    {
        [Required]
        public ITaskItem ProjectDir { get; set; }
        [Required]
        public ITaskItem TargetName { get; set; }

        // Methods
        public override bool Execute()
        {
            try
            {
                string[] directories;
                string str3;
                base.Log.LogMessageFromText("Replacing juipp Tokens at - " + this.ProjectDir, MessageImportance.High);
                this.ReplaceTokensUnderFolder("TargetName@juipp", this.ProjectDir.ToString());
                var path = Path.Combine(this.ProjectDir.ToString(), "_layouts");
                if (Directory.Exists(path))
                {
                    directories = Directory.GetDirectories(path);
                    foreach (string str2 in directories)
                    {
                        str3 = Path.Combine(path, str2);
                        this.ReplaceTokensUnderFolder("TargetName@juipp", str3);
                    }
                }
                path = Path.Combine(this.ProjectDir.ToString(), "Layouts");
                if (Directory.Exists(path))
                {
                    directories = Directory.GetDirectories(path);
                    foreach (string str2 in directories)
                    {
                        str3 = Path.Combine(path, str2);
                        this.ReplaceTokensUnderFolder("TargetName@juipp", str3);
                    }
                }
            }
            catch (Exception exception)
            {
                base.Log.LogError(exception.Message, new object[0]);
                throw;
            }
            return true;
        }

        private void ReplaceTokens(string token, string subPath, string extension)
        {
            if (!Directory.Exists(subPath)) return;
            var files = Directory.GetFiles(subPath);
            foreach (var str in files.Where(str => str.EndsWith(extension)))
            {
                base.Log.LogMessageFromText(str, MessageImportance.High);
                string contents = File.ReadAllText(str).Replace(token, this.TargetName.ToString());
                File.WriteAllText(str, contents);
            }
        }

        private void ReplaceTokensUnderFolder(string token, string folderPath)
        {
            var subPath = Path.Combine(folderPath, "Controllers");
            var str2 = Path.Combine(folderPath, "Behaviors");
            var str3 = Path.Combine(folderPath, "Views");
            var str4 = Path.Combine(folderPath, "ViewModels");
            this.ReplaceTokens(token, subPath, ".juipp.cs");
            this.ReplaceTokens(token, subPath, ".juipp.ascx");
            this.ReplaceTokens(token, subPath, "Controller.cs");
            this.ReplaceTokens(token, str2, ".juipp.cs");
            this.ReplaceTokens(token, str3, ".juipp.cs");
            this.ReplaceTokens(token, str4, ".juipp.cs");
        }


    }
}
