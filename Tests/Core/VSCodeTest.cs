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
    => o( ed.GenUserSnippets(dry: true)
          .StartsWith("\"Using static\": {") );

    [Test] public void RemUserSnippets() => ed.RemUserSnippets();

    [Test] public void UserSnetsPath([Values(false, true)]bool expand){
        var z = ed.UserSnippetsPath(expand);
        if(expand) o( !z.Contains("~"));
    }

    [Test] public void DefaultUserSnetsPath([Values(false, true)]
                                                           bool expand){
        var z = ed.DefaultUserSnippetsPath(expand);
        //nityEngine.Debug.Log($"Def user snippets path {z}");
        if(expand){
            #if UNITY_EDITOR_OSX
            o( z.StartsWith ("/Users" ) );
            #elif UNITY_EDITOR_WIN
            o( z.Contains("AppData"));
            #endif
        }else{
            #if UNITY_EDITOR_WIN
            o( z.Contains("%APPDATA%") );
            #elif UNITY_EDITOR_OSX
            o( z.Contains("~/Library/Application Su"));
            #endif
        }
    }

    [Test] public void Name() => o( ed.Name(), "VSCode");

}}
