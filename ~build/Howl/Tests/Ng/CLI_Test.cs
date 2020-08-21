using NUnit.Framework;
using Active.Howl;

namespace Unit{
public class CLI_Test : TestBase{

CLI ι;

[SetUp] public void Setup () => ι = new CLI(dry: true);

[Test] public void Main () => CLI.Main(new string[]{});

[Test] public void Build () => o(ι.Build(null, "src"),
@"Source dir not found: src/
dotnet new console --name build --force
dotnet build build
");

[Test] public void Publish () => o(ι.Publish(null, "src"),
@"Source dir not found: src/
dotnet new console --name build --force
dotnet publish build --runtime osx-x64
");

    // Fails in .net because of path differences
    #if UNITY_EDITOR

    [Test] public void Export () => ι.Export(null, "Assets/Howl/Editor/Ng", "Sandbox/CLI");

    [Test] public void Run(){
        var target = "Sandbox/HelloWorld";
        var build  = $"{target}/build";
        var hocus  = $"{build}/build.csproj";
        var pocus  = $"{build}/program.cs";
        ι.Run(null, target);
        o( hocus.Exists(), true );
        o( pocus.Exists(), false );
    }

    #endif

}}
