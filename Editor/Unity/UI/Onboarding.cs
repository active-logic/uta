using System;
using static That.GUI;
using R = Active.Howl.Requirements;

namespace Active.Howl{
public static class Onboarding{

    public static bool UI()
        => Do(S.GetIDE      , R.hasIDE    , URL.Atom         )
        && Do(S.GetExtension, R.hasExt    , URL.LanguageHowl )
        && Do(S.CreateRoot  , R.hasRoot   , S.MakeRoot       )
        && (!FileSystem.HasFileOfType("Assets/", "*.howl")
            ? Do(S.ImportFiles , R.mayImport)
            : true)
        && Do(S.SetupVCS    , R.hasVCS    , URL.AboutVCS     )
        && Notice("You are all set"       , URL.OnlineDoc    );

    public static bool Do(string label, bool κ, URL url)
    => Br() && H( Check(label, κ), κ || A(url.label, url.@value) ) && κ;

    public static bool Do(string label, bool κ)
    => Br() && H(P(label), B("Yes"), B("No")) && κ;

    public static bool Do(string label, bool κ, string buttonLabel)
    => Br() && H(Check(label, κ), κ || B(buttonLabel)) && κ;

    public static bool Notice(string label, URL url)
    => Br() && P($"All is well and good ~ ╰(*´︶`*)╯");

    static bool Check(string label, bool κ) => P(κ ? $"[✓] {label}" : label);

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
        public static  string CreateRoot   = $"*.howl sources files should be placed\nunder {Path.defaultHowlRootPath}";
        public const string MakeRoot     = "Make dir.";
        public const string ImportFiles  = "Would you like to convert your C# scripts\nto Howl?\n(does not modify/delete any files)";
        public const string SetupVCS     = "Ensure your project is using version control\n(required during β)";
        public const string AllSet       = "All set";

    }

}}
