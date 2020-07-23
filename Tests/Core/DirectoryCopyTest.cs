using System.IO;
using InvOp = System.InvalidOperationException;
using ㅅ = System.Single;  using ㅇ = System.Boolean;
using ᆞ = System.Int32;   using ㄹ = System.String;
using NUnit.Framework;
using Active.Howl;

namespace Unit{
public class DirectoryCopyTest : TestBase{

    [Test] public void Test(){
        DirectoryInfo fooDir = null,
                      newFooDir = new DirectoryInfo("newFoo");
        ㅇ wentFine = true;
        try{
            fooDir = "Foo".MkDir();
            "Foo/Bar.txt".Write("Hello");
            newFooDir = "Foo".Copy(to:"NewFoo");
        }catch(IOException ex){ Print(ex); wentFine = false; }
        fooDir?.Delete(recursive: true);
        newFooDir?.Delete(recursive: true);
        o(wentFine, true);
    }

}}
