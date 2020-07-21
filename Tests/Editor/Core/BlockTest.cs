using System.IO;
using InvOp = System.InvalidOperationException;
using ㅅ = System.Single;  using ㅇ = System.Boolean;
using ᆞ = System.Int32;   using ㄹ = System.String;
using NUnit.Framework;
using Active.Howl;

namespace Unit{
public class BlockTest : TestBase{

    [Test] public void Enter(){
        Block.Def z = ("/*", "*/");
        o(Block.Enter("Foo/*", 2, z) == null);
        o(Block.Enter("Foo/*", 3, z) != null);
        o(Block.Enter("Foo/*", 4, z) == null);
    }

    [Test] public void Exit(){
        Block.Def z = ("/*", "*/");
        var block = Block.Enter("Foo/*", 3, z);
        o(block.Exit("0123*/", 4), false);
        o(block.Exit("0123*/", 5), true);
    }

}}
