using System.Collections.Generic;
using System.Text;
using ㅅ = System.Single;  using ㅇ = System.Boolean;
using ᆞ = System.Int32;   using ㄹ = System.String;
using NUnit.Framework;
using Active.Howl;

public class CStyleCommentFinderTest : TestBase{

    ㄹ x = "Foobar/* Blabla\nbla */Done";

    [Test] public void AroundCStyleComments(){
        var y = x.AroundCStyleComments();
        o(y.Length, 3);
        o(y[0], "Foobar");
        o(y[1], "/* Blabla\nbla */");
        o(y[2], "Done");
    }

    [Test] public void StartsComment()
    => CStyleCommentFinder.StartsComment(x, 6);

    [Test] public void EndsComment()
    => CStyleCommentFinder.EndsComment(x, 21);

    [Test] public void Flush(){
        var x = new StringBuilder("Foobar");
        var y = new List<ㄹ>();
        CStyleCommentFinder.Flush(x, y);
        o(x.Length, 0);
        o(y.Count, 1);
        o(y[0], "Foobar");
    }

}
