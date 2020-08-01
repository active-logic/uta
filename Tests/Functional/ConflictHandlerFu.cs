using System.IO;
using NUnit.Framework;
using static System.IO.FileAttributes;
using Active.Howl;

namespace Functional{
public class ConflictHandlerFu : FunctionalTest{

    [Test] public void HandleConflicts(){
        var π = "Assets/Howl/Tests/Data";
        var conflicts = Howl.ImportDir(π, "*.scs", dry: true);
        o(conflicts.Count, Config.ι.ignoreConflicts ? 0 : 1);
    }

}}
