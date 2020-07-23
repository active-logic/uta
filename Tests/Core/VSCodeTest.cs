using ㅅ = System.Single;  using ㅇ = System.Boolean;
using ᆞ = System.Int32;   using ㄹ = System.String;
using NUnit.Framework;
using Active.Howl;

/*
"For Loop": {
        "prefix": "for",
        "body": [
            "for (var ${index} = 0; ${index} < ${array}.length; ${index}++) {",
            "\tvar ${element} = ${array}[${index}];",
            "\t$0",
            "}"
        ],
        "description": "For Loop"
    },
*/

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
        o( z.Contains("~"), !expand );
    }

    [Test] public void DfUsrSnetsPath([Values(false, true)]ㅇ expand){
        var z = ed.DefaultUserSnippetsPath(expand);
        if(expand) o( z.EndsWith   ("snippets/howl.json") );
        else       o( z.StartsWith ("~/Library/Application Su" ) );
    }

    [Test] public void Name() => o( ed.Name(), "VSCode");

}}
