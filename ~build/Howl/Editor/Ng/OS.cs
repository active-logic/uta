using Ex   = System.Exception;
using Info = System.Runtime.InteropServices.RuntimeInformation;
using OSP  = System.Runtime.InteropServices.OSPlatform;

namespace Active.Howl{
public static class OS{

    public const string Windows = "win-x64";
    public const string MacOS   = "osx-x64";
    public const string Linux   = "linux-x64";

    public static  string runtime
    => Info.IsOSPlatform(OSP.Linux)   ? Linux
    : Info.IsOSPlatform(OSP.OSX)     ? MacOS
    : Info.IsOSPlatform(OSP.Windows) ? Windows
    : throw
            new Ex("Unknown Runtime");

    public static bool isWindows => Info.IsOSPlatform(OSP.Windows);
    public static bool isLinux => Info.IsOSPlatform(OSP.Linux);

}}
