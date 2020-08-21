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

[Test] public void Install () => o(ι.Install(null, "."),
@"Source dir not found: ./src/
dotnet new console --name build --force
dotnet publish build --runtime osx-x64
Remove /usr/local/Uta
Move src/build/bin/Debug/netcoreapp3.1/osx-x64/publish to
/usr/local/Uta
ln -s /usr/local/Uta/build /usr/local/bin/uta");

[Test] public void Publish () => o(ι.Publish(null, "src"),
@"Source dir not found: src/
dotnet new console --name build --force
dotnet publish build --runtime osx-x64
");

[Test] public void Test () => o(ι.Test(null, "."),
@"Source dir not found: ./src/
Source dir not found: ./test/
dotnet new solution --name Main --force
dotnet new classlib --name src --force
dotnet new nunit --name test --force
dotnet add test/test.csproj reference src/src.csproj
dotnet sln add src/src.csproj test/test.csproj
dotnet test" + " \n");
/*
@"Source dir not found: src/
Source dir not found: src/test/
dotnet new solution --name Main
dotnet new classlib --name src --force
dotnet new nunit --name test --force
dotnet add test/test.csproj reference src/src.csproj
dotnet sln add src/src.csproj test/test.csproj
dotnet test" + " \n");
*/
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
