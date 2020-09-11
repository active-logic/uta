using Ex = System.Exception;

namespace Active.Howl{
public class CLI{

    bool dry;
    DotNet δ = new DotNet();

    public CLI(bool dry) => this.dry = dry;

    public static void Main(string[] ㅂ){
        log.message = "Howl CLI v0.0.18";
        log.message = new CLI(dry: false).Parse(ㅂ);
    }

    string Parse(string[] ㅂ){
        if (ㅂ.Length < 1) return help;
        switch (ㅂ[0]){
            case "build"   : Build   (ㅂ); break;
            case "export"  : Export  (ㅂ); break;
            case "import"  : Import  (ㅂ); break;
            case "install" : Install (ㅂ); break;
            case "publish" : Publish (ㅂ); break;
            case "run"     : Run     (ㅂ); break;
            case "test"    : Test    (ㅂ); break;
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

    public string Install(params string[] ㅂ){
        var π = ㅂ[1];
        string ι = null, Π = π.FullPath(), name;
        if (!π.Exists()){
            log.message = "Arg does not reflect existing path; assume name";
            π = "."; name = π;
        }else{
            name = Π.Substring(Π.LastIndexOf("/") + 1);
            log.message = $"Path exists {π}; assume project name '{name}'";
        }
        var rt = δ.GetRuntime();
        if (rt != "osx-x64"){ log.message = $"N/A: 'install' ({rt})"; return null; }
        ι += Publish(null, $"{π}/src", "Release");
        var build="src/build/bin/Release/netcoreapp3.1/osx-x64/publish";
        var link  = $"/usr/local/bin/{name.ToLower()}";
        link.JustDelete(dry);
        ι += Runner.Cmd(
             "ln", $"-s {build.FullPath()}/build {link}", π, dry);
        return ι;
    }

    public string Publish(params string[] ㅂ){
        string ι = null;
        string π = ㅂ[1], Π = π.FullPath(), ω =  $"{π}/build";
        var config = (ㅂ.Length> 2) ? ㅂ[2] : "Debug";
        ω.RmDir(dry);
        ι += Export(null, π, ω);
        ι += δ.New($"console --name build --force", Π, ω, dry);
        ι += δ.Publish($"build -c {config}", Π, rt: null, dry);
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

    public string Test(params string[] ㅂ){
        string π = ㅂ[1], Π = π.FullPath(), ω =  $"{π}/build";
        string ι = null;
        ω.MkDir(dry);
        ι += Export(null, $"{π}/src", $"{ω}/src");
        ι += Export(null, $"{π}/test", $"{ω}/test");
        ι += δ.New("solution --name Main --force", ω, null, dry);
        ι += δ.New("classlib --name src --force", ω, null, dry);
        ι += δ.New("nunit --name test --force", ω, null, dry);
        $"{ω}/src/Class1.cs".JustDelete(dry);
        $"{ω}/test/UnitTest1.cs".JustDelete(dry);
        ι += δ["add",
               "test/test.csproj reference src/src.csproj", ω, dry];
        ι += δ["sln add",
               "src/src.csproj test/test.csproj", ω, dry];
        ι += δ.Test(ω, dry);
        That.Logger.Log(ι);
        return ι;
    }

    string Import(string[] ㅂ) => log.warning = "Unimplemented";

    string help =
@"Usage:
howl export SRC_DIR DST_DIR - Export Howl scripts to C#
howl import SRC_DIR DST_DIR - Convert C# scripts to Howl [n/a]
howl build DIR              - Build a console app
howl install DIR            - Install, assuming DIR/src [macOS only]
howl publish DIR            - Build and publish a console app
howl run DIR                - Build and run a console app
howl test DIR - Build and run tests assuming DIR/src, DIR/test
";

}}
