using NUnit.Framework;
using Active.Howl;

namespace Unit{
public class IOTest : TestBase{

/*
    ؟ CopyFiles ⎚ "Assets/Howl/Editor/Unity".CopyFiles(
                  "Assets/~build", relTo: "Assets/", dry: ✓, "*.cs");
*/
    [Test] public void CopyTo () => "Assets/Foo.txt".CopyTo("Assets/Pkg/", dry: true);

    [Test] public void DirName () => o("Foo/Bar/Pkg/Test.cs".DirName(), "Foo/Bar/Pkg");

/*
    ؟ MoveTo(){
        ∙ ㅂ = "Assets/Howl/Tests/Data/Temp.howl.test";
        ∙ ㄸ = "Assets/Howl/Tests/Data/Temp2.howl.test";
        ㅂ.MoveTo(ㄸ, withMetaFile: ✓);
        ㄸ.MoveTo(ㅂ, withMetaFile: ✓);

    }
    */

}}
