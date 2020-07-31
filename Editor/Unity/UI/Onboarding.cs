using System;
using static That.GUI;
using R = Active.Howl.Requirements;

public static class Onboarding{

    public static bool UI()
        => Do(S.GetIDE      , R.hasIDE    , URL.Atom         )
        && Do(S.GetExtension, R.hasExt    , URL.LanguageHowl )
        && Do(S.CreateRoot  , R.hasRoot   , S.MakeRoot       )
        && Do(S.ImportFiles , R.mayImport)
        && Do(S.SetupVCS    , R.hasVCS    , URL.AboutVCS     )
        && Notice("You are all set"       , URL.OnlineDoc    );

    public static bool Do(string label, bool cond, URL url)
        => Br() && H(P(label) && A(url.label, url.@value)) && !cond;

    public static bool Do(string label, bool cond)
        => Br() && H(P(label), B("Yes"), B("No")) && !cond;

    public static bool Do(string label, bool cond, string buttonLabel)
        => Br() && H(P(label) && B(buttonLabel)) && !cond;

    public static bool Notice(string label, URL url){
        return Br() && P($"All is well and good ~ ╰(*´︶`*)╯");
    }

    // --------------------------------------------------------------

    public class URL{

        public string label, @value;

        public static URL Atom         = new URL("Get Atom", "???");
        public static URL LanguageHowl = new URL("Get", "???");
        public static URL MakeRoot     = new URL("OK", "???");
        public static URL AboutVCS     = new URL("What's that?", "???");
        public static URL OnlineDoc    = new URL("Read the docs", "???");

        public URL(string label, string @value){
            this.@value = @value;
            this.label  = label;
        }

    }

    static class S{

        public const string GetIDE       = "A supported IDE with well configured \nsnippets is required; Atom is recommended.";
        public const string GetExtension = "Language-Howl enables snippets and \nsyntax coloring in Atom";
        public const string CreateRoot   = "*.howl sources files should be placed\nunder Assets/HOWL_ROOT";
        public const string MakeRoot     = "Make root";
        public const string ImportFiles  = "Would you like to convert your C# scripts\nto Howl?\n(does not modify/delete any files)";
        public const string SetupVCS     = "Your files are not under version control\n(required during β)";
        public const string AllSet       = "All set";

    }

}
