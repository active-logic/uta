using System.IO;
using InvOp = System.InvalidOperationException;
using NUnit.Framework;
using Active.Howl;
using static Active.Howl.Path;

namespace Unit{
public class HowlTest : TestBase{

    const string ρ = "Assets/Howl/Tests/Data";

    [SetUp] public void Setup    () => Howl.warnings = false;
    [TearDown] public void Teardown () => Howl.warnings = true;

    [Test] public void BuildFile () => o(Howl.BuildFile($"{ρ}/Valid.howl.test", null) != null);

    [Test] public void BuildFile_AsIs(){
        var π = $"{ρ}/NonInteger.howl.test";
        var ㅂ = π.Read();
        var ㄸ = Howl.BuildFile(π, null);
        o(ㄸ, ㅂ.Replace(Howl.cerberusWard, ""));
    }

    #if UNITY_EDITOR

    [Test] public void ExportAssemblyDefToken(){
        string π = "Assets/Howl/Editor/zHw.Editor.asmdt";
        var ㄸ = Howl.ExportAssemblyDefToken(π, dry: true);
        o(ㄸ,

@"Rename Assets/Howl/~build/Howl/Editor/zHw.Editor.asmdef to
Assets/Howl/Editor/zHw.Editor.asmdef
and delete Assets/Howl/Editor/zHw.Editor.asmdt");

    }

    [Test] public void ImportAssemblyDefToken(){
        string π = "Assets/Howl/Editor/zHw.Editor.asmdef";
        var ㄸ = Howl.ImportAssemblyDefToken(π, dry: true);
        o(ㄸ,

@"Rename Assets/Howl/Editor/zHw.Editor.asmdef to
Assets/Howl/~build/Howl/Editor/zHw.Editor.asmdef
and create Assets/Howl/Editor/zHw.Editor.asmdt");

    }

    [Test] public void ImportDir () => Howl.ImportDir("Assets/", dry: true);


    [Test] public void ImportFile_IntegrityFails() => o(
        Howl.ImportFile($"{ρ}/NonInteger.cs.test", null)
            .StartsWith(Howl.cerberusWard), true);

    [Test] public void ImportFile_IntegrityFails_WardOnce(){
        string ㅂ = $"{ρ}/NonInteger.cs.test", ㄸ = $"{ρ}/Temp.howl.test";
        Howl.ImportFile(ㅂ    , ㄸ);
        Howl.ImportFile(ㅂ = ㄸ, ㄸ);
        string[] Λ = ㄸ.ReadLines();
        o( Λ[0].Contains(Wards.Cerberus), true);
        o( Λ[1].Contains(Wards.Cerberus), false);
        // Doesn't work. Try via ADB
        // ㄸ.Del();
    }


    [Test] public void ImportFileMovingCsFile
    () => o( Howl.ImportFile($"{ρ}/Valid.cs.test", dry: true),

@"Import
Assets/Howl/Tests/Data/Valid.cs.test as
Assets/Howl/Tests/Data/Valid.cs.howl and move it to
Assets/Howl/~build/Howl/Tests/Data/Valid.cs.cs");

    #endif  // end editor tests

    // TODO improve test
    [Test] public void ImportFile () => o(
        Howl.ImportFile($"{ρ}/Valid.cs.test", null)
            .StartsWith(Howl.cerberusWard), false);

    // TODO not well formed
    [Test] public void ImportFile_WithConflict(){
        var  π = $"{ρ}/Defeat_cf.scs";
        if (Config.ι.ignoreConflicts) Howl.ImportFile(π, null);
        else
           Assert.Throws<InvOp>( () => Howl.ImportFile(π, null) );
    }

    [Test] public void ReimportFile () => o(
        Howl.ReimportFile($"{ρ}/Valid.howl.test", dry: true)
            .StartsWith(Howl.cerberusWard), false);

    [Test] public void NitPick(){
        string ㅂ = $"{ρ}/Sample.Howl", ㄸ = $"{ρ}/PolishedSample.Howl";
        Howl.NitPick(ㅂ, ㄸ, force: true);
        o( ㄸ.Read().Contains("≥") );
        ㄸ.Delete(withMetaFile: true);
    }

    [Test] public void NitPick_AsIs(){
        string ㅂ = $"{ρ}/NonInteger.howl.test",
           ㄸ = $"{ρ}/NonIntegerAsIs.Howl.test";
        var z = Howl.NitPick(ㅂ, ㄸ);
        o(z, ㅂ.Read());
        // Since output is unchanged, no file is output
        o(ㄸ.Exists(), false);
    }

    // #endif  // Common tests ------------------------------------------

    [Test] public void ImportAsIs
    () => o(Howl.ImportAsIs($"{Wards.GardenOfEden} as is"), true);

    [Test] public void ImportString () => o( Howl.ImportString("class Foo;"), "○ Foo;" );

    [Test] public void ExportAsIs () => o(Howl.ExportAsIs($"{Wards.Cerberus} as is"), true);

    [Test] public void NitPickAsIs(){
        o(Howl.NitPickAsIs($"{Wards.Cerberus} as is"), true);
        o(Howl.NitPickAsIs($"{Wards.GardenOfEden} as is"), true);
    }

}}
