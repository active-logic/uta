using System.IO;
using NUnit.Framework;
using Active.Howl;

namespace Unit{
public class ImportConfigTest : TestBase{

    [Test] public void Read(){
        ImportConfig.Read();
    }

    [Test] public void Write(){
        ImportConfig.Write();
    }

    [TearDown] public void Clear(){
        ImportConfig.Clear();
    }

}}
