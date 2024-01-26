using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace MidiToKeyboard.App.Tools
{
    public static class VersionHelper
    {
        public static string GetVersion()
        {
            var versionInfo = FileVersionInfo.GetVersionInfo(Assembly.GetEntryAssembly().Location);
            return $"胶片分流打印系统 v{versionInfo.FileVersion}";
        }

        public static string GetCopyright() =>FileVersionInfo.GetVersionInfo(Assembly.GetEntryAssembly().Location).LegalCopyright;
    }
}
