using System.IO;
using InvOp = System.InvalidOperationException;
using ㅅ = System.Single;  using ㅇ = System.Boolean;
using ᆞ = System.Int32;   using ㄹ = System.String;
using NUnit.Framework;
using Active.Howl;

public class HowlTest : TestBase{

    [Test] public void ImportDir(){
        Howl.ImportDir("Assets/");
    }

    [Test] public void InPath(){
        var ㄸ = Howl.InPath("Assets/Pkg/Test.cs");
        o(ㄸ, "Assets/Howl.Howl/Pkg/Test.howl");
    }

    [Test] public void InPath_Corrected(){
        var ㄸ = Howl.InPath("Foobar/Assets/Pkg/Test.cs");
        o(ㄸ, "Assets/Howl.Howl/Pkg/Test.howl");
    }

    [Test] public void InPath_BadInput(){
        Assert.Throws<InvOp>(() => {
            Howl.InPath("Foo/Bar/Pkg/Test.cs");
        });
    }

    [Test] public void OutPath_1(){
        var ㄸ = Howl.Outpath("Assets/Howl.Howl/Test.howl");
        o(ㄸ.path, "Assets/Test.cs");
    }

    [Test] public void OutPath_2(){
        var ㄸ = Howl.Outpath("Assets/Howl.Howl/Runtime/Test.howl");
        o(ㄸ.path, "Assets/Runtime/Test.cs");
    }

    [Test] public void OutPath_BadInput(){
        var ㅂ = "Assets/Src/Test.howl";
        var ㄸ = Howl.Outpath(ㅂ);
        o(ㄸ.path, null);
        o(ㄸ.msg, $"{ㅂ} should be under {Howl.root}...");
    }

    [Test] public void Root() => o(Howl.root, "Assets/Howl.Howl/");

    [Test] public void ProjectName() => o(Howl.projectName, "Howl");

}
