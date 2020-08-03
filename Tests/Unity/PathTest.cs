using InvOp = System.InvalidOperationException;
using NUnit.Framework;
using Active.Howl;

namespace Unit{
public class PathTest : TestBase{

    [Test] public void DefaultHowlRootPath()
    => o( Path.defaultHowlRootPath, "Assets/Howl.Howl/");

    // TODO move to IO test
    [Test] public void DirName() => o( "Foo/Bar/Pkg/Test.cs".DirName(), "Foo/Bar/Pkg");

    [Test] public void InPath(){
        var ㄸ = "Assets/Pkg/Test.cs".InPath();
        o(ㄸ, $"{Path.howlRoot}Pkg/Test.howl");
    }

    [Test] public void InPath_Dir
    () => o( "Assets/Pkg/".InPath(), $"{Path.howlRoot}Pkg/" );

    [Test] public void InPath_Dir1
    () => o( "Assets/Pkg".InPath(), $"{Path.howlRoot}Pkg" );

    [Test] public void InPath_Corrected(){
        var ㄸ = "Foobar/Assets/Pkg/Test.cs".InPath();
        o(ㄸ, $"{Path.howlRoot}Pkg/Test.howl");
    }

    [Test] public void InPath_BadInput(){
        Assert.Throws<InvOp>(() => {
            "Foo/Bar/Pkg/Test.cs".InPath();
        });
    }

    [Test] public void IsHowlSource_File(){
        var π = $"{Path.howlRoot}Test.howl";
        o(π.IsHowlSource(), true);
        o(π.FullPath().IsHowlSource(), true);
    }

    [Test] public void IsHowlSource_Dir(){
        var π = $"{Path.howlRoot}Pkg/Dir";
        o(π.IsHowlSource(), true);
        o(π.FullPath().IsHowlSource(), true);
    }

    [Test] public void Nix() => o("Assets\\Howl".Nix(), "Assets/Howl");

    [Test] public void NoFinalSep([Values("Foo/", "Foo")] string x)
    => o( x.NoFinalSep() , "Foo");

    [Test] public void NoFinalSep_BS()
    => o( ("Foo" + '\\').NoFinalSep() , "Foo");

    [Test] public void OutPath_1()
    => o($"{Path.howlRoot}x.howl".OutPath(),
         "Assets/x.cs");

    [Test] public void OutPath_2()
    => o($"{Path.howlRoot}Runtime/x.howl".OutPath(),
         "Assets/Runtime/x.cs");

    [Test] public void OutPath_3(){
        var ㅂ = "Assets/Howl/Howl.Src/x.howl".FullPath();
        var ㄸ = ㅂ.OutPath();
        o(ㄸ, "Assets/x.cs");
    }

    [Test] public void OutPath_Dir
    () => o( $"{Path.howlRoot}Pkg/".OutPath(), "Assets/Pkg/" );

    [Test] public void OutPath_Dir1
    () => o( $"{Path.howlRoot}Pkg".OutPath(), "Assets/Pkg" );

    [Test] public void OutPath_BadExtension()
    => Assert.Throws<InvOp>( () => "x.foo".OutPath() );

    [Test] public void OutPath_BadRoot()
    => Assert.Throws<InvOp>( () => "Fakeroot/x.howl".OutPath() );

    [Test] public void HowlRoot() => o( Path.howlRoot, "Assets/Howl/Howl.Src/" );

    [Test] public void ProjectName() => o(Path.projectName, "Howl");

}}
