using System.IO;
using ㅅ = System.Single;  using ㅇ = System.Boolean;
using ᆞ = System.Int32;   using ㄹ = System.String;
using NUnit.Framework;
using Active.Howl;

namespace Unit{
public class FileSystemTest : TestBase{

    [Test] public void Paths(){
        var π = FileSystem.Paths("Assets/", "*.cs");
        o(π.Count > 0);
        foreach(var x in π){
            o(x.EndsWith(".cs"));
            o(x.IndexOf("Assets/") > -1);
        }
    }

}}
