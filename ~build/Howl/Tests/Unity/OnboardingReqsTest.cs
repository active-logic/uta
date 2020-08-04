using NUnit.Framework;
using Active.Howl;

namespace Unit{
public class OnboardingReqsTest : TestBase{

    [Test] public void HasGit(){
        o( "Assets/Howl/.git".IsDir());
        o( OnboardingReqs.HasGit(), true);
    }

}}
