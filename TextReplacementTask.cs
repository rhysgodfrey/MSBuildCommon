using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Build.Framework;
using System.IO;
using System.Security.AccessControl;

namespace RhysG.MSBuild.Common
{
    public class TextReplacementTask : ITask
    {
        private IBuildEngine _buildEngine;
        private ITaskHost _taskHost;

        public IBuildEngine BuildEngine
        {
            get
            {
                return _buildEngine;
            }
            set
            {
                _buildEngine = value;
            }
        }

        [Required]
        public string OutputFile
        {
            get;
            set;
        }

        [Required]
        public string File
        {
            get;
            set;
        }

        [Required]
        public string StringToReplace
        {
            get;
            set;
        }

        [Required]
        public string Value
        {
            get;
            set;
        }

        public bool Execute()
        {
            FileInfo file = new FileInfo(File);
            FileInfo outputFile = new FileInfo(OutputFile);

            if (file.Exists)
            {
                if (outputFile.Exists && outputFile.LastWriteTimeUtc == file.LastWriteTimeUtc)
                {
                    return true;
                }

                string input = System.IO.File.ReadAllText(file.FullName);

                string replaced = input.Replace(StringToReplace, Value);

                System.IO.File.WriteAllText(outputFile.FullName, replaced);
                outputFile.LastWriteTimeUtc = file.LastWriteTimeUtc;

                FileSecurity security = new FileSecurity();
                security.AddAccessRule(new FileSystemAccessRule("Everyone", FileSystemRights.ReadAndExecute, AccessControlType.Allow));

                outputFile.SetAccessControl(security);

                BuildEngine.LogMessageEvent(new BuildMessageEventArgs(String.Format("Packed: {0}", file.Name), String.Empty, "PackJavascriptFileTask", MessageImportance.Normal));
            }

            return true;
        }

        public ITaskHost HostObject
        {
            get
            {
                return _taskHost;
            }
            set
            {
                _taskHost = value;
            }
        }
    }
}
