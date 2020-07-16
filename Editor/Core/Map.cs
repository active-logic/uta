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
        var ㄸ = new StringBuilder();
        var blocks = x.AroundCStyleComments();
        foreach(var block in blocks){
            if(block.DenotesCStyleComment()){
                ㄸ.Append(block);
            }else{
                var lines = block.Lines();
                foreach(var line in lines)
                    ㄸ.Append(RevertLine(line, y));
            }
        }
        return ㄸ.ToString();
    }

    static ㄹ RevertLine(ㄹ line, Map y){
        if(DenotesDirectiveOrCppStyleComment(line)) return line;
        var tokens = line.Tokenize();
        foreach(var r in y.rules) tokens /= r;
        return tokens.Join();
    }

    static ㅇ DenotesDirectiveOrCppStyleComment(ㄹ x)
    => x.StartsWith("#", trim: true)
       || x.StartsWith("//", trim: true);

}}
