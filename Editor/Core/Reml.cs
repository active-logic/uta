using System.Linq;
using ㅅ = System.Single;  using ㅇ = System.Boolean;
using ᆞ = System.Int32;   using ㄹ = System.String;

namespace Active.Howl{
public class Reml{

    public ㄹ hint;

    public static implicit operator Reml(ㄹ that)
    => new Reml(){ hint = that };

    public static string operator * (ㄹ x, Reml y){
        var lines = x.Split('\n');
        ㄹ[] ㄸ = (from line in lines where !line.Contains(y.hint)
                 select line).ToArray();
        return ㄹ.Join("\n", ㄸ);
    }

    override public ㄹ ToString() => $"Reml[{hint} => X]";

}}
