using System.IO;
using InvOp = System.InvalidOperationException;
using NUnit.Framework;
using Active.Howl;

namespace Unit{
public class WhiteSpaceAdderTest : TestBase{

    static char[] slash = new char[]{'/'};
    static string[] ps = new string[]{"‒̥"};

    [Test] public void ConsolidateString () => o( "‒̥○".Consolidate(ps), "‒̥ ○");

    // TODO double check this
    [Test] public void Consolidate
    () => o( "Foo\n//bar".Consolidate(slash), "Foo\n/ / bar");

    // Does not acknowledge litterals, have to use segmented form
    [Test] public void Consolidate_ignoreLitterals
    () => o( "A \"litt/eral\" string".Consolidate(slash),
         "A \"litt/ eral\" string");

}}
