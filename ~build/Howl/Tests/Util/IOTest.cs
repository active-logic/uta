using NUnit.Framework;
using Active.Howl;

namespace Unit{
public class IOTest : TestBase{

    [Test] public void CopyFiles () => "Assets/Howl/Editor/Unity".CopyFiles(
                  "Assets/~build", relTo: "Assets/", dry: true, "*.cs");

    [Test] public void CopyTo () => "Assets/Foo.txt".CopyTo("Assets/Pkg/", dry: true);

    [Test] public void DirName () => o("Foo/Bar/Pkg/Test.cs".DirName(), "Foo/Bar/Pkg");

    [Test] public void MoveTo(){
        var ㅂ = "Assets/Howl/Tests/Data/Temp.howl.test";
        var ㄸ = "Assets/Howl/Tests/Data/Temp2.howl.test";
        ㅂ.MoveTo(ㄸ, withMetaFile: true);
        ㄸ.MoveTo(ㅂ, withMetaFile: true);

    }

}}
