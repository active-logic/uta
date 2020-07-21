using System.IO;
using ㅅ = System.Single;  using ㅇ = System.Boolean;
using ᆞ = System.Int32;   using ㄹ = System.String;
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
