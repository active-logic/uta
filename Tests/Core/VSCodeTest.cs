using ㅅ = System.Single;  using ㅇ = System.Boolean;
using ᆞ = System.Int32;   using ㄹ = System.String;
using NUnit.Framework;
using Active.Howl;

namespace Unit{
public class Ed_VSCodeTest : TestBase{

    VSCode ed;

    [SetUp] public void SetupEd() => ed = new VSCode();

    [Test] public void Format(){
        Snippet x = ("Class", prefix: "class", body: "ℂ ");
        var y = ed.Format(x);
        o(y,  ("  'Class': {\n"
            +  "    'prefix': 'class',\n"
            +  "    'body': [ 'ℂ ' ],\n"
            +  "  }").Replace('\'', '"'));
    }

    [Test] public void GenUserSnippets()
    => ed.GenUserSnippets(dry: true)
         .StartsWith("\"Using static\": {");

    [Test] public void RemUserSnippets() => ed.RemUserSnippets();

    [Test] public void UserSnetsPath([Values(false, true)]ㅇ expand){
        var z = ed.UserSnippetsPath(expand);
        //nityEngine.Debug.Log($"user snippets path {z}");
        if(expand){
           o( !z.Contains("~"));
        }
    }

    [Test] public void DfUsrSnetsPath([Values(false, true)]ㅇ expand){
        var z = ed.DefaultUserSnippetsPath(expand);
        //nityEngine.Debug.Log($"Def user snippets path {z}");
        if(expand){
            #if UNITY_EDITOR_OSX
            o( z.StartsWith ("~/Library/Application Su" ) );
            #elif UNITY_EDITOR_WIN
            o( z.Contains("AppData"));
            #endif
        }else{
            o( z.Contains("%APPDATA%") );
        }
    }

    [Test] public void Name() => o( ed.Name(), "VSCode");

}}
