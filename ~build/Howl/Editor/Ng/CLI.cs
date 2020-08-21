namespace Active.Howl{
public class CLI{

    bool dry;
    DotNet δ = new DotNet();

    public CLI(bool dry) => this.dry = dry;

    public static void Main(string[] ㅂ){
        log.message = "Howl CLI v0.0.10";
        log.message = new CLI(dry: false).Parse(ㅂ);
    }

    string Parse(string[] ㅂ){
        if (ㅂ.Length < 1) return help;
        switch (ㅂ[0]){
            case "build"   : Build   (ㅂ); break;
            case "export"  : Export  (ㅂ); break;
            case "import"  : Import  (ㅂ); break;
            case "publish" : Publish (ㅂ); break;
            case "run"     : Run     (ㅂ); break;
            default: return $"Unrecognized command [{ㅂ[0]}]";
        }
        return "...all done";
    }

    public string Build(params string[] ㅂ){
        string ι = null, π = ㅂ[1], Π = π.FullPath(), ω =  $"{π}/build";
        ω.RmDir(dry);
        ι += Export(null, π, ω);
        ι += δ.New($"console --name build --force", Π, ω, dry);
        ι += δ.Build("build", Π, dry);
        return ι;
    }

    public string Export(params string[] ㅂ){
        string src = ㅂ[1].WithFinalSep(),
          dst = ㅂ[2].WithFinalSep();
        if (!src.IsDir()) return $"Source dir not found: {src}\n";
        var paths = FileSystem.Paths(src, "*.howl");
        if (dry){
            return null;
        }
        foreach (var x in paths){
            var y = dst + x.RelativeTo(src).SetExtension(".cs");
            log.message =y;
            Howl.BuildFile(x, y);
        }
        return "Exported some files";
    }

    public string Publish(params string[] ㅂ){
        string ι = null;
        string π = ㅂ[1], Π = π.FullPath(), ω =  $"{π}/build";
        ω.RmDir(dry);
        ι += Export(null, π, ω);
        ι += δ.New($"console --name build --force", Π, ω, dry);
        ι += δ.Publish("build", Π, rt: null, dry);
        return ι;
    }

    public string Run(params string[] ㅂ){
        string π = ㅂ[1], Π = π.FullPath(), ω =  $"{π}/build";
        ω.RmDir(dry);
        Export(null, π, ω);
        δ.New($"console --name build --force", Π, ω, dry);
        δ.Run("--project build", Π, dry);
        return null;
    }

    string Import(string[] ㅂ) => log.warning = "Unimplemented";

    string help =
@"Usage:
howl export SRC_DIR DST_DIR - Export Howl scripts to C#
howl import SRC_DIR DST_DIR - Convert C# scripts to Howl [n/a]
howl build DIR              - Build a console app
howl publish DIR            - Build and publish a console app
howl run DIR                - Build and run a console app
";

}}
