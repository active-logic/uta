using System; using static UnityEngine.Networking.UnityWebRequest; using static That.GUI;
using S = Active.Howl.UIStrings.GiveBack;
using Active.Howl.Util; using Model = Active.Howl.Util.GiveBack;

namespace Active.Howl.UI{
public class GiveBack{

    static Model ι = Model.ι;

    public static bool UI () => !ι.showOptions ? false :
          P(S.GiveBackNotice)
        && Do(S.Review, URL.Review)
        && Do(S.Sponsor, URL.Sponsor)
        //∧ Do(S.Affiliate, URL.Affiliate)
        && Do(S.Loudspeaker, URL.Tweet)
        && Do(S.ThankYou, "Okay", ι.Dismiss);

    // External action via URL
    public static bool Do(string label, URL url) => Br()
        && V( P(label), H( A(url.label, url.@value), flex));

    // Action with label and button
    public static bool Do(string label, string buttonLabel, Action action)
    => Br() && H(  P(label), flex, B(buttonLabel, action)  );

    public class URL{

        public string label, @value;

        public static URL Review    = new URL("Let's do this", "???");
        public static URL Sponsor   = new URL("Tip the dev",
                                  "https://ko-fi.com/eekstork");
        //‒̥ URL Affiliate = ⌢ URL("Check it out", "???");
        public static URL Tweet     = new URL("#Howl on Twitter",
           "https://twitter.com/intent/tweet?text="
         + EscapeURL("⦿ #Howl🔥(╯°□°)╯⌢ C♯ 〜 #unity3d #gamedev"));

        public URL(string label, string path){ this.@value = path; this.label = label; }

    }

}}
