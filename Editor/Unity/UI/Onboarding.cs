using System;
using UnityEngine;
using Obj = UnityEngine.Object;
using FOB = Active.Howl.Testing.FakeOnboardingReqs; using static That.GUI;

namespace Active.Howl{
public static class Onboarding{

    public static IOnboardingReqs reqs;

    public static bool UI()
        => Do(S.GetIDE      , r.HasIDE()  , URL.Atom         )
        && Do(S.GetExtension, r.HasExt()  , URL.LanguageHowl )
        && Do(S.CreateRoot  , r.HasRoot() , S.MakeRoot       )
        && (!r.HereBeHowls() ? Do(S.ImportFiles , r.MayImport()) : true)
        && Do(S.SetupVCS    , r.HasVCS()  , URL.AboutVCS     )
        && Notice(S.AllDone , URL.OnlineDoc);

    public static bool Do(string label, bool κ, URL url)
    => Br() && H( Check(label, κ), κ || A(url.label, url.@value) ) && κ;

    public static bool Do(string label, bool κ)
    => Br() && H(P(label), B("Yes"), B("No")) && κ;

    public static bool Do(string label, bool κ, string buttonLabel)
    => Br() && H(Check(label, κ), κ || B(buttonLabel)) && κ;

    public static bool Notice(string label, URL url)
    => Br() && P(label);

    static bool Check(string label, bool κ) => P(κ ? $"[✓] {label}" : label);

    static IOnboardingReqs r => reqs != null ? reqs : new OnboardingReqs();

    // --------------------------------------------------------------

    public class URL{

        public string label, @value;

        public static URL Atom         = new URL("Get Atom", "https://atom.io");
        public static URL LanguageHowl = new URL("Get", "https://atom.io/packages/language-howl");
        public static URL MakeRoot     = new URL("OK", "???");
        public static URL AboutVCS     = new URL("What's that?", "https://github.com/active-logic/howl/blob/master/Documentation/User/About-VCS.md");
        public static URL OnlineDoc    = new URL("Read the docs", "https://github.com/active-logic/howl");

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
        public const string AllDone      = "All is well and good ~ ╰(*´︶`*)╯";

    }

}}
