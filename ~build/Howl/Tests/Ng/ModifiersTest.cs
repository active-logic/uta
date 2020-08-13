using NUnit.Framework;
using static Active.Howl.Modifiers;
using M = Active.Howl.Modifiers;

namespace Unit{
public class ModifiersTest : TestBase{

    [Test] public void ReorderCs () => o( M.ReorderCs("static", "public"),
                                S("public", "static") );

    [Test] public void ReorderHl () => o( M.ReorderHl("∘", "‒"), S("‒", "∘") );

    [Test] public void Nitpick () => o( M.Nitpick("∘", "‒"), "‒̥");

    [Test] public void NitpickSegment
    () => o( M.NitpickSegment("∘", "‒", "○"), S("‒̥", "○") );

    // Nitpicking places static after access modifiers and combines
    [Test] public void NitpickSegment_1
    () => o( M.NitpickSegment("∘", "‒", "ᵛ", "○"), S("‒̥ᵛ", "○") );

    [Test] public void NitpickSegment_2_bug
    () => o( M.NitpickSegment("⁺","∘", "‒", "ᵛ", "○"), S("⁺‒̥ᵛ", "○") );

    [Test] public void NitpickSegment_withWhiteSpace
    () => o( M.NitpickSegment("∘", " ", "‒", "○"), S("‒̥", "○") );

    [Test] public void NitpickSegment_withTrailingWhiteSpace
    () => o( M.NitpickSegment("∘", "‒", "  ", "○"), S("‒̥", "  ", "○") );

    string[] S(params string[] args) => args;

}}
