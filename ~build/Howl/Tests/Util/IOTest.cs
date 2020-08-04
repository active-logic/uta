using NUnit.Framework;
using Active.Howl;

public class IOTest : TestBase{

    [Test] public void CopyFiles () => "Assets/Howl/Editor/Unity".CopyFiles(
                  "Assets/~build", relTo: "Assets/", dry: true, "*.cs");

    [Test] public void CopyTo () => "Assets/Foo.txt".CopyTo("Assets/Pkg/", dry: true);

    [Test] public void DirName () => o("Foo/Bar/Pkg/Test.cs".DirName(), "Foo/Bar/Pkg");

}
