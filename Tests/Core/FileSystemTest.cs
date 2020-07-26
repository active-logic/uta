using System.IO;
using NUnit.Framework;
using Active.Howl;

namespace Unit{
public class FileSystemTest : TestBase{

    [Test] public void Paths(){
        var π = FileSystem.Paths("Assets/", "*.cs");
        o(π.Count > 0);
        foreach(var x in π){
            o(x.EndsWith(".cs"));
            o(x.Contains("Assets"), true);
        }
    }

}}
