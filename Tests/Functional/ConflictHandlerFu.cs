using System.IO;
using NUnit.Framework;
using static System.IO.FileAttributes;
using ㅅ = System.Single;  using ㅇ = System.Boolean;
using ᆞ = System.Int32;   using ㄹ = System.String;
using Active.Howl;

namespace Functional{
public class ConflictHandlerFu : FunctionalTest{

    [Test] public void HandleConflicts(){
        var π = "Assets/Howl/Tests/Data";
        var conflicts = Howl.ImportDir(π, "*.scs", dry: true);
        o(conflicts.Count, Config.ignoreConflicts ? 0 : 1);
    }

}}
