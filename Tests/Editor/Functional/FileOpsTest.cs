using System.IO;
using ㅅ = System.Single;  using ㅇ = System.Boolean;
using ᆞ = System.Int32;   using ㄹ = System.String;
using NUnit.Framework;
using UnityEditor;
using UnityEngine;
using ADB = UnityEditor.AssetDatabase;
using Active.Howl;

namespace FunctionalTests{
public class FileOpsTest : TestBase{

    [Test] public void DeleteHowlFile(
                          [Values(false, true)] ㅇ allowExport,
                          [Values(false, true)] ㅇ withCounterpart){
        Config.allowExport = allowExport;
        ㄹ ㅂ = "Assets/Howl.Howl/Test.howl", ㄸ = "Assets/Test.cs";
        Create(ㅂ, withCounterpart ? ㄸ : null);
        ADB.DeleteAsset(ㅂ);
        // After this op, the condition for the C# file to exist
        // - did exist in the first place
        // - export was disabled (or it should be deleted)
        o(File.Exists(ㄸ), withCounterpart && !allowExport);
    }

    [Test] public void MoveHowlFile(
                           [Values(false, true)] ㅇ allowExport,
                           [Values(false, true)] ㅇ withCounterpart){
        Config.allowExport = allowExport;
        ModificationProcessor.warnings = false;
        // Actual .cs extension would "trigger" the C# compiler
        Active.Howl.Path._Cs = ".xyz";
        ㄹ ㅂ1 = "Assets/Howl.Howl/Test.howl",
           ㅂ2 = "Assets/Howl.Howl/Howl/Test.howl",
          ㄸ1 = "Assets/Test.xyz",
           ㄸ2 = "Assets/Howl/Test.xyz";
        CreateViaADB(ㅂ1, withCounterpart ? ㄸ1 : null);
        ADB.MoveAsset(ㅂ1, ㅂ2);
        ㅇ e1 = File.Exists(ㄸ1),
           e2 = File.Exists(ㄸ2);
        DeleteAll(ㅂ1, ㅂ2, ㄸ1, ㄸ2);
        o(e1, withCounterpart && !allowExport);
        o(e2, withCounterpart ? allowExport : false);
        Active.Howl.Path._Cs = ".cs";
        ModificationProcessor.warnings = true;
    }

    // From without "Howl" root to within; then, export a C# file
    [Test] public void Welcome_Howl(
                               [Values(false, true)] ㅇ allowExport){
        Config.allowExport = allowExport;
        Howl.warnings = false;
        // Actual .cs extension would "trigger" the C# compiler
        Active.Howl.Path._Cs = ".xyz";
        ㄹ ㅂ1 = "Assets/Test.howl",
           ㅂ2 = "Assets/Howl.Howl/Test.howl",
          ㄸ1 = null,
           ㄸ2 = "Assets/Test.xyz";
        CreateViaADB(ㅂ1);
        ADB.MoveAsset(ㅂ1, ㅂ2);
        ㅇ e2 = File.Exists(ㄸ2);
        DeleteAll(ㅂ1, ㅂ2, ㄸ1, ㄸ2);
        o(e2, allowExport);
        Active.Howl.Path._Cs = ".cs";
        Howl.warnings = true;
    }

    // Remove a howl from the root; then, delete the matching C# file
    [Test] public void Exile_Howl(
                          [Values(false, true)] ㅇ allowExport,
                          [Values(false, true)] ㅇ withCounterpart){
        Config.allowExport = allowExport;
        ModificationProcessor.warnings = false;
        Howl.warnings = false;
        // Actual .cs extension would "trigger" the C# compiler
        Active.Howl.Path._Cs = ".xyz";
        ㄹ ㅂ1 = "Assets/Howl.Howl/Test.howl",
           ㅂ2 = "Assets/Test.howl",
          ㄸ1 = "Assets/Test.xyz",
           ㄸ2 = null;
        CreateViaADB(ㅂ1, withCounterpart ? ㄸ1 : null);
        ADB.MoveAsset(ㅂ1, ㅂ2);
        ㅇ e1 = File.Exists(ㄸ1);
        DeleteAll(ㅂ1, ㅂ2, ㄸ1, ㄸ2);
        // The condition for a C# counterpart to remain:
        // - Did exist in the first place.
        // - Export is disabled (or it would have been deleted)
        o(e1, withCounterpart && !allowExport);
        Active.Howl.Path._Cs = ".cs";
        Howl.warnings = true;
    }

    void CreateViaADB(params ㄹ[] π){
        foreach(var x in π) if(x != null)
            ADB.CreateAsset(new TextAsset(), x);
    }

    void Create(params ㄹ[] π){
        foreach(var x in π) if(x != null) File.WriteAllText(x, "");
    }

    void DeleteAll(params ㄹ[] π){
        foreach(var x in π) if(x != null) ADB.DeleteAsset(x);
    }

    // Keep config integer ==========================================

    ㅇ didAllowExport;

    [SetUp] public void SaveConfig()
    => didAllowExport = Config.allowExport;

    [TearDown] public void RestoreConfig()
    => Config.allowExport = didAllowExport;

}}
