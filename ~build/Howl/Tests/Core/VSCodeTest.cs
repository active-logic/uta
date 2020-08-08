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

    [Test] public void GenUserSnippets_dry(){
        var x = "  'Using ∘'"
                .Replace('\'', '"');
        var y = ed.GenUserSnippets(dry: true);
        o(x, y.Substring(0, x.Length));
        o(y.EndsWith("\n"));
    }

    [Test] public void UserSnetsPath([Values(false, true)]bool expand){
        var z = ed.UserSnippetsPath(expand);
        if(expand) o( !z.Contains("~"));
    }

    [Test] public void DefaultUserSnetsPath([Values(false, true)]
                                                           bool expand){
        var z = ed.DefaultUserSnippetsPath(expand);
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

    [Test] public void Exists() => o( ed.Exists(), true);

    [Test] public void Name() => o( ed.Name(), "VSCode");

}}
