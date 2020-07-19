using System.Linq;
using ㅅ = System.Single;  using ㅇ = System.Boolean;
using ᆞ = System.Int32;   using ㄹ = System.String;

namespace Active.Howl{
public class Reml{

    public ㄹ hint;

    public static implicit operator Reml(ㄹ that)
    => new Reml(){ hint = that };

    public static string operator * (ㄹ x, Reml y)
    => (from λ in x.Split('\n')
        where !y.ShouldCull(λ) select λ).ToArray().Join('\n');

    ㅇ ShouldCull(ㄹ x) => x.Contains("=") && x.Contains(hint);

    override public ㄹ ToString() => $"Reml[{hint} => X]";

}}
