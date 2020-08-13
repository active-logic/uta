using System;

namespace Active.Howl{
public class CLI{

    static void Main(string[] ㅂ){
        log.message = "Howl CLI v0.0";
        log.message = new CLI().Parse(ㅂ);
    }

    string Parse(string[] ㅂ){
        if (ㅂ.Length < 1) return help;
        switch (ㅂ[0]){
            case "export": Export(ㅂ); break;
            case "import": Import(ㅂ); break;
            default: return $"Unrecognized command [{ㅂ[0]}]";
        }
        return "Uh?";
    }

    public string Export(params string[] ㅂ){
        string src = ㅂ[1].WithFinalSep(),
          dst = ㅂ[2].WithFinalSep();
        var paths = FileSystem.Paths(src, "*.howl");
        foreach (var x in paths){
            var y = dst + x.RelativeTo(src).SetExtension(".cs");
            log.message = y;
            Howl.BuildFile(x, y);
        }
        return "Exported some files";
    }

    string Import(string[] ㅂ) => log.warning = "Unimplemented";

    string help =
@"Usage:
howl export SRC_DIR DST_DIR - Export Howl scripts to C#
howl import SRC_DIR DST_DIR - Convert C# scripts to Howl";

}}
