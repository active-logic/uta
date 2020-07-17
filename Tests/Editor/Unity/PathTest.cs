using InvOp = System.InvalidOperationException;
using NUnit.Framework;
using Active.Howl;

public class PathTest : TestBase{

    [Test] public void OutPath_1()
    => o("Assets/Howl.Howl/x.howl".OutPath(),
         "Assets/x.cs");

    [Test] public void OutPath_2()
    => o("Assets/Howl.Howl/Runtime/x.howl".OutPath(),
         "Assets/Runtime/x.cs");

    [Test] public void OutPath_BadExtension()
    => Assert.Throws<InvOp>( () => "x.foo".OutPath() );

    [Test] public void OutPath_BadRoot()
    => Assert.Throws<InvOp>( () => "Fakeroot/x.howl".OutPath() );

    [Test] public void InPath(){
        var ㄸ = "Assets/Pkg/Test.cs".InPath();
        o(ㄸ, "Assets/Howl.Howl/Pkg/Test.howl");
    }

    [Test] public void InPath_Corrected(){
        var ㄸ = "Foobar/Assets/Pkg/Test.cs".InPath();
        o(ㄸ, "Assets/Howl.Howl/Pkg/Test.howl");
    }

    [Test] public void InPath_BadInput(){
        Assert.Throws<InvOp>(() => {
            "Foo/Bar/Pkg/Test.cs".InPath();
        });
    }
    
    [Test] public void Root()
    => o(Path.howlRoot, "Assets/Howl.Howl/");

    [Test] public void ProjectName() => o(Path.projectName, "Howl");

}
