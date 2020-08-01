using System.IO;
using InvOp = System.InvalidOperationException;
using NUnit.Framework;
using Active.Howl;
using static Active.Howl.Path;

namespace Unit{
public class HowlTest : TestBase{

    //  TODO disabled because we are now using Howl to develop.
    // use a sandbox instead
    //[Test] public void ImportDir(){
    //    Howl.ImportDir("Assets/");
    //}

    [Test] public void ImportFile(){
        var π = "Assets/Howl/Tests/Data/Defeat.scs";
        Howl.ImportFile(π, null);
    }

    [Test] public void ImportFile_WithConflict(){
        var π = "Assets/Howl/Tests/Data/Defeat_cf.scs";
        if(Config.ι.ignoreConflicts){
            Howl.ImportFile(π, null);
        }else{
            Assert.Throws<InvOp>( () => Howl.ImportFile(π, null) );
        }
    }

    [Test] public void Exclude()
    => o(Howl.Exclude("// ▓▒░(°◡°)░▒▓ exclude me"), true);

    [Test] public void NitPick(){
        string ㅂ = "Assets/Howl/Tests/Data/Sample.Howl";
        string ㄸ = "Assets/Howl/Tests/Data/PolishedSample.Howl";
        Howl.NitPick(ㅂ, ㄸ, force: true);
        o( ㄸ.Read().Contains("≥") );
        ㄸ.Del();
    }

}}
