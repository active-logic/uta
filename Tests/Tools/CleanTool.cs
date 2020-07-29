using Active.Howl.Transitional;
using NUnit.Framework;

namespace Tasks{
public class CleanTool : TestBase{

    [Test] public void Clean(){
        Cleaner.Clean();
    }

}}
