using Active.Howl.Transitional;
using NUnit.Framework;

namespace Tasks{
public class CleanTask : TestBase{

    [Test] public void Clean(){
        Cleaner.Clean();
    }

}}
