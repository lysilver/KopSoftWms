using System.Runtime.InteropServices;

namespace YL.Utils.Pub
{
    public class PubSys
    {
        public static string IsSystem()
        {
            return IsWindows() ? "Windows" : IsLinux() ? "Linux" : IsOsx() ? "OSX" : "";
        }

        public static bool IsLinux()
        {
            return RuntimeInformation.IsOSPlatform(OSPlatform.Linux);
        }

        public static bool IsWindows()
        {
            return RuntimeInformation.IsOSPlatform(OSPlatform.Windows);
        }

        public static bool IsOsx()
        {
            return RuntimeInformation.IsOSPlatform(OSPlatform.OSX);
        }
    }
}