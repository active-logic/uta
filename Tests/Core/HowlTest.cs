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

    [Test] public void ExportFile () => o(Howl.ExportFile($"{ρ}/Valid.howl.test", null) != null);

    [Test] public void ExportFile_AsIs(){
        var π = $"{ρ}/NonInteger.howl.test";
        var ㅂ = π.Read();
        var ㄸ = Howl.ExportFile(π, null);
        o(ㄸ, ㅂ.Replace(Howl.cerberusWard, ""));
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
        ㄸ.Del();
    }

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

    [Test] public void ImportAsIs
    () => o(Howl.ImportAsIs($"{Wards.GardenOfEden} as is"), true);

    [Test] public void ExportAsIs () => o(Howl.ExportAsIs($"{Wards.Cerberus} as is"), true);

    [Test] public void NitPickAsIs(){
        o(Howl.NitPickAsIs($"{Wards.Cerberus} as is"), true);
        o(Howl.NitPickAsIs($"{Wards.GardenOfEden} as is"), true);
    }

    [Test] public void NitPick(){
        string ㅂ = $"{ρ}/Sample.Howl", ㄸ = $"{ρ}/PolishedSample.Howl";
        Howl.NitPick(ㅂ, ㄸ, force: true);
        o( ㄸ.Read().Contains("≥") );
        ㄸ.Del();
    }

    [Test] public void NitPick_AsIs(){
        string ㅂ = $"{ρ}/NonInteger.howl.test",
           ㄸ = $"{ρ}/NonIntegerAsIs.Howl.test";
        var z = Howl.NitPick(ㅂ, ㄸ);
        o(z, ㅂ.Read());
        // Since output is unchanged, no file is output
        o(ㄸ.Exists(), false);
    }

}}
