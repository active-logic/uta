using System.IO;
using ㅅ = System.Single;  using ㅇ = System.Boolean;
using ᆞ = System.Int32;   using ㄹ = System.String;
using NUnit.Framework;
using UnityEngine;
using ADB = UnityEditor.AssetDatabase;

// TODO all ADB methods should say viaADB
namespace Functional{
public abstract class FunctionalTest : TestBase {

    protected void Create(params ㄹ[] π){
        foreach(var x in π) if(x != null) File.WriteAllText(x, "");
    }

    protected void CreateViaADB(params ㄹ[] π){
        foreach(var x in π) if(x != null)
            ADB.CreateAsset(new TextAsset(), x);
    }

    protected void Delete(ㄹ x){
        File.Delete(x);
    }

    protected void DeleteViaADB(params ㄹ[] π){
        foreach(var x in π) if(x != null) File.WriteAllText(x, "");
    }

    protected void DeleteViaADB(ㄹ x) => ADB.DeleteAsset(x);

    protected void DeleteAll(params ㄹ[] π){
        foreach(var x in π) if(x != null) ADB.DeleteAsset(x);
    }

}}
