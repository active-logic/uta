using NUnit.Framework;
using Active.Howl.Util;

namespace Unit{
public class GiveBackTest : TestBase{

    private GiveBack ι;

    [SetUp] public void Setup () => ι = new GiveBack();

    [Test] public void A_InitialState(){
        o( ι.didViewOptions, false );
        o( ι.showOptions,    false );
        o( ι.displayNotice,  false );
    }

    [Test] public void B_Notice_OnMaxUseCount(){
        ι.MaxUseCount();
        o(ι.displayNotice, true);
        o(ι.showOptions, true);
    }

    [Test] public void C_DismissNotice(){
        ι.MaxUseCount();
        ι.Dismiss();
        ι.didViewOptions = true;
        o(ι.displayNotice, false);
        o(ι.showOptions, false);
    }

}}
