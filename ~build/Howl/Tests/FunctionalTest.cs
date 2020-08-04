using System.IO;
using NUnit.Framework;
using UnityEngine;
using ADB = UnityEditor.AssetDatabase;

// TODO all ADB methods should say viaADB
namespace Functional{
public abstract class FunctionalTest : TestBase {

    protected void Create(params string[] π){
        foreach(var x in π) if(x != null) File.WriteAllText(x, "");
    }

    protected void CreateViaADB(params string[] π){
        foreach(var x in π) if(x != null)
            ADB.CreateAsset(new TextAsset(), x);
    }

    protected void Delete(string x){
        File.Delete(x);
    }

    protected void DeleteViaADB(params string[] π){
        foreach(var x in π) if(x != null) File.WriteAllText(x, "");
    }

    protected void DeleteViaADB(string x) => ADB.DeleteAsset(x);

    protected void DeleteAll(params string[] π){
        foreach(var x in π) if(x != null) ADB.DeleteAsset(x);
    }

}}
