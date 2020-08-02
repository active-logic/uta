using System;
using UnityEngine;
using Obj = UnityEngine.Object;
using static That.GUI;

namespace Active.Howl{
public static class Onboarding{

    public static IOnboardingReqs reqs;

    public static bool UI () => r.InProgress() ? DisplayUI() || true : false;

    public static bool DisplayUI
        () => Do(S.GetIDE      , r.HasIDE()  , URL.Atom             )
        && Do(S.GetExtension, r.HasExt()  , URL.LanguageHowl     )
        && Do(S.CreateRoot  , r.HasRoot() , S.MkRoot, r.MakeRoot )
        && OptImportCsharpFiles()
        && Do(S.SetupVCS    , r.HasVCS()  , URL.AboutVCS         )
        && Do(S.AllDone     , S.Okay      , r.Validate           );
        //∧ Notice(S.AllDone , URL.OnlineDoc);

    public static bool OptImportCsharpFiles()
    => r.HereBeHowls() || !r.HereBeSharps() ? true
    : Choice(S.ImportFiles,
             r.LetsImport() != UserChoice.Undecided,
             r.DoImport, r.DoNotImport);

    // Action with label, condition and button
    public static bool Do(string label, bool κ, string buttonLabel, Action action) => Br() &&
        H(Check(label, κ), κ || B(buttonLabel, action)) && κ;

    // Action with label and button
    public static bool Do(string label, string buttonLabel, Action action) => Br() &&
        H(  P(label), flex, B(buttonLabel, action)  );

    // External action via URL
    public static bool Do(string label, bool κ, URL url) => Br() &&
        H( Check(label, κ), κ || A(url.label, url.@value) ) && κ;

    // Yes/No choice
    public static bool Choice(string label, bool κ, Action okay, Action cancel) => Br() && H(
        Check(label, κ),
        (κ || B("Yes", okay)),
        (κ || B("No" , cancel))
    ) && κ;

    public static bool Notice(string label, URL url)
    => Br() && P(label);

    static bool Check(string label, bool κ) => P(κ ? $"[✓] {label}" : label);

    static IOnboardingReqs r => reqs ?? (reqs = new OnboardingReqs());

    // --------------------------------------------------------------

    public class URL{

        public string label, @value;

        public static URL Atom         = new URL("Get Atom", "https://atom.io");
        public static URL LanguageHowl = new URL("Get", "https://atom.io/packages/language-howl");
        public static URL AboutVCS     = new URL("What's that?", "https://github.com/active-logic/howl/blob/master/Documentation/User/About-VCS.md");
        public static URL OnlineDoc    = new URL("Read the docs", "https://github.com/active-logic/howl");

        public URL(string label, string path){ this.@value = path; this.label = label; }

    }

    static class S{

        public const string GetIDE       = "A supported IDE with well configured \nsnippets is required; Atom is recommended.";
        public const string GetExtension = "Language-Howl enables snippets and \nsyntax coloring in Atom";
        public static  string CreateRoot   = $"*.howl sources files will be placed\nunder {Path.FindHowlRoot() ?? Path.defaultHowlRootPath}";
        public const string MkRoot       = "Make dir";
        public const string ImportFiles  = "Convert your C# scripts to Howl?\nIf you do not wish to use all notations,\nyou can do this later.\n(does not modify/delete any files)";
        public const string SetupVCS     = "Ensure your project is using version control\n(required during β)";
        public const string AllDone      = "All is well; access documentation using\nthe hereabove [?] badge ~ ";
        public const string Okay         = "╰(*´︶`*)╯ OK!";

    }

}}
