using ㅅ = System.Single;  using ㅇ = System.Boolean;
using ᆞ = System.Int32;   using ㄹ = System.String;
using NUnit.Framework;
using Active.Howl;

namespace Unit{
public class Ed_AtomTest : TestBase{

    Atom ed;

    [SetUp] public void SetupEd() => ed = new Atom();

    [Test] public void Format(){
        Snippet x = ("Class", prefix: "class", body: "ℂ ");
        var y = ed.Format(x);
        o(y,  "  'Class':\n"
            + "    'prefix': 'class'\n"
            + "    'body': 'ℂ '");
    }

    [Test] public void GenUserSnippets()
    => ed.GenUserSnippets(dry: true)
         .StartsWith("  'Using static':");

    [Test] public void RemUserSnippets() => ed.RemUserSnippets();

    [Test] public void UserSnetsPath([Values(false, true)]ㅇ expand){
        var z = ed.UserSnippetsPath(expand);
        o( z.Contains("~"), !expand );
    }

    [Test] public void DfUsrSnetsPath([Values(false, true)]ㅇ expand){
        var z = ed.DefaultUserSnippetsPath(expand);
        if(expand) o( z.EndsWith(".atom/snippets.cson") );
        else       o( z, "~/.atom/snippets.cson" );
    }

    [Test] public void Name() => o( ed.Name(), "Atom");

}}
