using System.IO;
using NUnit.Framework;
using Active.Howl;

namespace Unit{
public class FileSystemTest : TestBase{

    const string π = "Assets/Howl/~build";
    const string π1 = "Assets";

    [Test] public void Match1 () => o( !FileSystem.Match("~build", π, files: true, dirs: true) );

    [Test] public void Match2 () => o( FileSystem.Match("~build", π1, files: true, dirs: true) );

    [Test] public void Paths(){
        var ㄸ = FileSystem.Paths(π, "*.cs");
        o( ㄸ.Count > 0 );
        foreach(var x in ㄸ) o( x.EndsWith(".cs") && x.Contains(π) );
    }

    // A file exactly named ".cs" does not exist
    [Test] public void Paths_exact_match () => o(FileSystem.Paths(π, ".cs").Count == 0);

    [Test] public void Paths_matches_filenames_not_path_strings(){
        var ㄸ = FileSystem.Paths(π, "*.cs");
        // There are *.cs files in ~build
        o( ㄸ.Count > 0 );
        // Their paths of course contains the string '/~build/'
        o( ㄸ[0].Contains("/~build/") );
        // However Paths pattern matches file names, not paths.
        ㄸ = FileSystem.Paths(π, "*~build*");
        o( ㄸ.Count == 0 );
    }

}}
