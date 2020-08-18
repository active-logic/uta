using NUnit.Framework;
using Active.Howl.Util;

namespace Unit{
public class GiveBackTest : TestBase{

    private GiveBack ι;

    [SetUp] public void Setup () => ι = new GiveBack();

    [Test] public void InitialState(){
        o( ι.didViewOptions, false );
        o( ι.showOptions,    false );
        o( ι.displayNotice,  false );
    }

    [Test] public void DisplayNotice(){
        ι.MaxUseCount();
        o(ι.displayNotice, false);
        o(ι.showOptions, false);
    }

    [Test] public void DismissNotice(){
        ι.MaxUseCount();
        ι.didViewOptions = true;
        o(ι.displayNotice, false);
        o(ι.showOptions, false);
    }

    [Test] public void DismissOptions(){
        ι.MaxUseCount();
        ι.didViewOptions = true;
        ι.showOptions = false;
        o(ι.displayNotice, false);
        o(ι.showOptions, false);
    }

    [Test] public void DisplayOptions_user_initiated(){
        ι.showOptions = true;
        o(ι.displayNotice, false);
        o(ι.showOptions, true);
    }

}}
