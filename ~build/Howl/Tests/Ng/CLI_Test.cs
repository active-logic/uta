using NUnit.Framework;
using Active.Howl;

namespace Unit{
public class CLI_Test : TestBase{

    CLI ι;

    [SetUp] public void Setup () => ι = new CLI();

    [Test] public void Main () => CLI.Main(new string[]{});

    // Fails in .net because of path differences
    #if UNITY_EDITOR

    [Test] public void Export () => ι.Export(null, "Assets/Howl/Editor/Ng", "Sandbox/CLI");

    #endif

    [Test] public void Run(){
        var target = "Sandbox/HelloWorld";
        var build  = $"{target}/build";
        var hocus  = $"{build}/build.csproj";
        var pocus  = $"{build}/program.cs";
        ι.Run(null, target);
        o( hocus.Exists(), true );
        o( pocus.Exists(), false );
    }

}}
