using System.IO;
using NUnit.Framework;
using UnityEditor;
using UnityEngine;
using ADB = UnityEditor.AssetDatabase;
using Active.Howl;

namespace Functional{
public class FileOpsFu : TestBase{

    static string _root;

    string root => _root
           ?? (_root = Active.Howl.Path.howlRoot.NoFinalSep());

    [Test] public void DeleteHowlFile([Values(false, true)] bool allowExport,
                     [Values(false, true)] bool withCounterpart){
        Config.allowExport = allowExport;
        string ㅂ = $"{root}/Test.howl", ㄸ = "Assets/Test.cs";
        if(!Setup(true, withCounterpart)) return;
        //
        ADB.DeleteAsset(ㅂ);
        // After this op, the condition for the C# file to exist
        // - did exist in the first place
        // - export was disabled (or it should be deleted)
        o(File.Exists(ㄸ), withCounterpart && !allowExport);
    }

    [Test] public void MoveHowlFile([Values(false, true)] bool allowExport,
                   [Values(false, true)] bool withCounterpart){
        Config.allowExport = allowExport;
        ModificationProcessor.warnings = false;
        // Actual .cs extension would "trigger" the C# compiler
        Active.Howl.Path._Cs = ".xyz";
        string ㅂ1 = $"{root}/Test.howl",
           ㅂ2 = $"{root}/Howl/Test.howl",
          ㄸ1 = "Assets/Test.xyz",
           ㄸ2 = "Assets/Howl/Test.xyz";
        CreateViaADB(ㅂ1, withCounterpart ? ㄸ1 : null);
        ADB.MoveAsset(ㅂ1, ㅂ2);
        bool e1 = File.Exists(ㄸ1),
           e2 = File.Exists(ㄸ2);
        DeleteAll(ㅂ1, ㅂ2, ㄸ1, ㄸ2);
        //Debug.Log($"{ㄸ1}.exists? {e1}");
        //Debug.Log($"{ㄸ2}.exists? {e2}");
        o(e1, withCounterpart && !allowExport);
        // After moving a howl file, a counterpart is created whether
        // it originally existed or not.
        o(e2, allowExport);
        ModificationProcessor.warnings = true;
    }

    // From without "Howl" root to within; then, export a C# file
    [Test] public void Welcome_Howl([Values(false, true)] bool allowExport){
        Config.allowExport = allowExport;
        Howl.warnings = false;
        // Actual .cs extension would "trigger" the C# compiler
        Active.Howl.Path._Cs = ".xyz";
        string ㅂ1 = "Assets/Test.howl",
           ㅂ2 = $"{root}/Test.howl",
          ㄸ1 = null,
           ㄸ2 = "Assets/Test.xyz";
        CreateViaADB(ㅂ1);
        ADB.MoveAsset(ㅂ1, ㅂ2);
        bool e2 = File.Exists(ㄸ2);
        DeleteAll(ㅂ1, ㅂ2, ㄸ1, ㄸ2);
        o(e2, allowExport);
        Active.Howl.Path._Cs = ".cs";
        Howl.warnings = true;
    }

    // Remove a howl from the root; then, delete the matching C# file
    [Test] public void Exile_Howl([Values(false, true)] bool allowExport,
                 [Values(false, true)] bool withCounterpart){
        Config.allowExport = allowExport;
        ModificationProcessor.warnings = false;
        Howl.warnings = false;
        // Actual .cs extension would "trigger" the C# compiler
        Active.Howl.Path._Cs = ".xyz";
        string ㅂ1 = $"{root}/Test.howl",
           ㅂ2 = "Assets/Test.howl",
           ㄸ1 = "Assets/Test.xyz",
           ㄸ2 = null;
        CreateViaADB(ㅂ1, withCounterpart ? ㄸ1 : null);
        ADB.MoveAsset(ㅂ1, ㅂ2);
        bool e1 = File.Exists(ㄸ1);
        DeleteAll(ㅂ1, ㅂ2, ㄸ1, ㄸ2);
        // The condition for a C# counterpart to remain:
        // - Did exist in the first place.
        // - Export is disabled (or it would have been deleted)
        o(e1, withCounterpart && !allowExport);
        Active.Howl.Path._Cs = ".cs";
        Howl.warnings = true;
    }

    // --------------------------------------------------------------

    bool Setup(bool howlFile, bool csFile){
        string @in = $"{root}/Test.howl";
        string @out = "Assets/Test.cs";
        return Setup(@in, howlFile) && Setup(@out, csFile);
    }

    bool Setup(string fname, bool e){
        if(e && File.Exists(fname)) return true;
        if(!e && !File.Exists(fname)) return true;
        //
        if(e) CreateViaADB(fname);
        if(!e) ADB.DeleteAsset(fname);
        //
        if(e && !File.Exists(fname)){
          Debug.Log($"Setup failed: {fname} was not created");
          return false;
        }
        if(!e && File.Exists(fname)){
          Debug.Log($"Setup failed: {fname} was not deleted");
          return false;
        }
        return true;
    }

    void CreateViaADB(params string[] π){
        foreach(var x in π) if(x != null)
            ADB.CreateAsset(new TextAsset(), x);
    }

    void Create(params string[] π){
        foreach(var x in π) if(x != null) File.WriteAllText(x, "");
    }

    void DeleteAll(params string[] π){
        foreach(var x in π) if(x != null) ADB.DeleteAsset(x);
    }

    // Keep config integer ==========================================

    bool didAllowExport;

    [SetUp] public void SaveConfig() => didAllowExport = Config.allowExport;

    [TearDown] public void RestoreConfig(){
        Config.allowExport = didAllowExport;
        Active.Howl.Path._Cs = ".cs";
    }

}}
