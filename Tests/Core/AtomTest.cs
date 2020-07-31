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
            + "    prefix : 'class'\n"
            + "    body   : 'ℂ '");
    }

    [Test] public void GenUserSnippets(){
        var pkg  = "~/.atom/packages/language-howl".Expand();
        var file = $"{pkg}/snippets/language-howl.cson";
        if(!pkg.IsDir()){
            Warn("Install Atom & `language-howl` first");
            return;
        }
        file.Delete();
        ed.GenUserSnippets(dry: false);
        o( file.Exists(), true );
     }

    [Test] public void GenUserSnippets_dry(){
        var x = "'.source.howl':\n  'Using static'";
        var y = ed.GenUserSnippets(dry: true);
        o(x, y.Substring(0, x.Length));
        o(y.EndsWith("\n"));
    }

    [Test] public void UserSnetsPath([Values(false, true)]bool expand){
        var z = ed.UserSnippetsPath(expand);
        o( z.Contains("~"), !expand );
    }

    [Test] public void DfUsrSnetsPath([Values(false, true)]bool expand){
        var z = ed.DefaultUserSnippetsPath(expand);
        var x =
          ".atom/packages/language-howl/snippets/language-howl.cson";
        if(expand) o( z.EndsWith(x) );
        else       o( z, $"~/{x}" );
    }

    [Test] public void Exists() => o( ed.Exists(), true);

    [Test] public void Name() => o( ed.Name(), "Atom");

}}
