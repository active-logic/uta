using System;
using Active.Util;

namespace Active.Howl{
public class CLI{

    string dotnet = "/usr/local/share/dotnet/dotnet";

    public static void Main(string[] ㅂ){
        log.message = "Howl CLI v0.0.8";
        log.message = new CLI().Parse(ㅂ);
    }

    string Parse(string[] ㅂ){
        if (ㅂ.Length < 1) return help;
        switch (ㅂ[0]){
            case "export": Export (ㅂ); break;
            case "import": Import (ㅂ); break;
            case "run"   : Run    (ㅂ); break;
            default: return $"Unrecognized command [{ㅂ[0]}]";
        }
        return "...all done";
    }

    public string Export(params string[] ㅂ){
        string src = ㅂ[1].WithFinalSep(),
          dst = ㅂ[2].WithFinalSep();
        var paths = FileSystem.Paths(src, "*.howl");
        foreach (var x in paths){
            var y = dst + x.RelativeTo(src).SetExtension(".cs");
            log.message =y;
            Howl.BuildFile(x, y);
        }
        return "Exported some files";
    }

    public string Run(params string[] ㅂ){
        string π = ㅂ[1], Π = π.FullPath(), ω =  $"{π}/build";
        ω.RmDir(withMetaFile: false);
        Export(null, π, ω);
        //
        var @new = $"new console --name build --force";
        log.message = $"dotnet {@new}";
        Runner.Cmd(dotnet, @new, Π, dry: false);
        $"{ω}/Program.cs".Delete(withMetaFile: true);
        //
        var @run = "run --project build";
        log.message = $"dotnet {@run}";
        Runner.Cmd(dotnet, @run, Π, dry: false);
        return null;
    }

    //ㄹ qt(⊡ x) → '"' + x🝠 + '"';

    string Import(string[] ㅂ) => log.warning = "Unimplemented";

    string help =
@"Usage:
howl run DIR                - Build and run a console application
howl export SRC_DIR DST_DIR - Export Howl scripts to C#
howl import SRC_DIR DST_DIR - Convert C# scripts to Howl [n/a]
";

}}
