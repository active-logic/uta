using System; using static UnityEngine.Networking.UnityWebRequest; using static That.GUI;
using S = Active.Howl.UIStrings.GiveBack;
using Active.Howl.Util; using Model = Active.Howl.Util.GiveBack;

namespace Active.Howl.UI{
public class GiveBack{

    static Model ι = Model.ι;

    public static bool UI () => !ι.showOptions ? false :
          P(S.GiveBackNotice) && Hr()
        && Do(S.Review, URL.Review)
        && Do(S.Upvote, URL.Upvote)
        && Do(S.Sponsor, URL.Sponsor)
        //∧ Do(S.Affiliate, URL.Affiliate)
        && Do(S.Loudspeaker, URL.Tweet)
        && Do(S.Hire, URL.Hire)
        && Hr()&& Do(S.ThankYou, "Okay", ι.Dismiss);

    // External action via URL
    public static bool Do(string label, URL url) => Br()
        && V( P(label), H( A(url.label, url.@value), flex) );

    // Action with label and button
    public static bool Do(string label, string buttonLabel, Action action)
    => Br() && H(  P(label), flex, B(buttonLabel, action)  );

    public class URL{

        public string label, @value;

        public static URL Review    = new URL("Write a review ★★★★★",
            "https://assetstore.unity.com/packages/slug/177081");

        public static URL Upvote = new URL("Let's git",
                       "https://github.com/active-logic/howl/labels");

        public static URL Sponsor   = new URL("(╯°□°)╯⌢ $$",
                                  "https://ko-fi.com/eekstork");
        public static URL Hire      = new URL("Hire the dev",
                                  "http://www.linkedin.com/in/tds79");
        //‒̥ URL Affiliate = ⌢ URL("Check it out", "???");
        public static URL Tweet     = new URL("#Howl on Twitter",
           "https://twitter.com/intent/tweet?text="
         + EscapeURL("⦿ #Howl🔥(╯°□°)╯⌢ C♯ 〜 #unity3d #gamedev"));

        public URL(string label, string path){ this.@value = path; this.label = label; }

    }

}}
