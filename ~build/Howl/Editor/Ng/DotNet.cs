using Ex = System.Exception; using System.Runtime.InteropServices;
using Info = System.Runtime.InteropServices.RuntimeInformation;

namespace Active.Howl{
public class DotNet{

    string dotnet = "/usr/local/share/dotnet/dotnet";

    public string Build(string α, string δ, bool dry) => this["build", α, δ, dry];

    public string New(string α, string δ, string ω, bool dry){
        var ㄸ = this["new", α, δ, dry];
        $"{ω}/Program.cs".JustDelete(dry);
        return ㄸ;
    }

    public string Publish(string α, string δ, string rt, bool dry)
    => this["publish", $"{α} --runtime {rt ?? GetRuntime()}", δ, dry];

    public string Run(string α, string δ, bool dry) => this["run", α, δ, dry];

    // -------------------------------------------------------------

    public string this[string command, string args, string workdir, bool dry]{get{
        string str;
        log.message = str = $"dotnet {command} {args}";
        if (dry) return str + '\n';
        Runner.Cmd(dotnet, $"{command} {args}", workdir, dry);
        return null;
    }}

    public string GetRuntime(){
        if (Info.IsOSPlatform(OSPlatform.Linux))   return "linux-x64";
        else if (Info.IsOSPlatform(OSPlatform.OSX))     return "osx-x64";
        else if (Info.IsOSPlatform(OSPlatform.Windows)) return "win-x64";
        else throw new Ex("Unknown Runtime");
    }

}}
