using System.Linq; using System.Text;
using ㅅ = System.Single;  using ㅇ = System.Boolean;
using ᆞ = System.Int32;   using ㄹ = System.String;

namespace Active.Howl{
public partial class Map{

    public Rep[] rules;
    public Reml[] remove;

    public static implicit operator Map(Rep[] that){
        var map = new Map(){ rules = that };
        map.remove = (from x in that select (Reml)$"using {x.a}")
                     .ToArray();
        return map;
    }

    public static string operator * (string x, Map y){
        foreach(var k in y.remove) x *= k;
        foreach(var r in y.rules) x *= r;
        return x;
    }

    public static string operator / (string x, Map y){
        var lines = x.Lines();
        StringBuilder ㄸ = new StringBuilder();
        foreach(var line in lines){
            if( line.StartsWith("#", trim: true)
                || line.StartsWith("//", trim: true) ){
                ㄸ.Append(line);
            }else{
                var tokens = line.Tokenize();
                foreach(var r in y.rules) tokens /= r;
                ㄸ.Append(tokens.Join());
            }
        }
        return ㄸ.ToString();
    }

}}
