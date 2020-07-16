using ㅅ = System.Single;  using ㅇ = System.Boolean;
using ᆞ = System.Int32;   using ㄹ = System.String;
using System.Linq;

namespace Active.Howl{
public class Map{

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
        var z = x.Tokenize();
        foreach(var r in y.rules) z /= r;
        return z.Join();
    }

    public static Map @default = new Rep[]{
        // Cangjie
        // Unsupported (syntax col)
        // ("惍","public class"),       // pc1
        // ("勾","public interface"),   // pi1
        // ("㥾","public struct"),      // pst1
        // ("金", "class"),             // c1
        // ("冖", "interface"),         // in1
        // ("尸", "struct"),            // s1
        // Modifiers
        ("切 ","public static "),      // ps1
        ("愜 ","protected static "),   // ps2
        ("户 ","internal static "),    // is
        ("日", "abstract"),          // a1
        ("心", "public"),            // p1
        ("㣺", "protected"),         // p2
        ("丶", "internal"),          // i2
        ("尸", "static"),            // s1
        // Operator related
        //("人", "operator"),          // o1
        //("戈", "implicit"),          // i1
        //("水", "explicit"),          // e1
        //
        // Classic
        ("☋", "abstract"),
        ("⃠ ", "public static "),
        ("⎅ ", "protected static "),
        ("⟠ ", "internal static "),
        ("▯", "const"),
        //
        ("○", "public"),
        ("◻︎", "protected"),
        ("◊", "internal"),
        ("⌿", "static"),
        //
        ("⨕", "operator"),
        ("⒠", "explicit"),
        ("⒤", "implicit"),
        ("䷲", "using"),
        // Operators
        ("≒", "==", bridge: true),
        ("≠", "!=", bridge: true),
        ("∧", "&&", bridge: true),
        ("∨", "||", bridge: true),
        // Types
        ("ㅇ", "bool"),
        ("ㅅ", "float"),
        ("ᆞ", "int"),
        ("ㄹ", "string"),
        // Control flow
        ("⤴", "if"),   // ⑀
        ("⤵", "else"), // ⑁
        //
        ("∀", "foreach"),
        ("⍦", "for"),
        ("⮑", "return"),
        //
        // MostHated aberrations, with contributions
        // from Rettie and Tea
        ("ಠᴗಠ"    , "try"    ),
        ("(╯°□°)╯", "throw"  ),
        ("(ɔ˘з˘)ɔ", "catch"  ),
        ("(ɔ=3=)ɔ", "catch"  ),
        ("(ɔówó)ɔ", "catch"  ),
        ("(˙▿˙)"  , "finally"),
        //
        ("⎇", "throw"),
        ("⏉", "try"),
        ("⏆", "catch"),
        ("⏊", "finally"),
        // Misc
        (" ⎚", "() =>", bridge: true),
        (" ⎚", "()=>", bridge: true),
        ("▬", "=>", bridge: true),
        ("⨮", "new"),
        ("∙", "var"),
        ("┈", "void"),
        // Active Logic
        ("⍑", "done()"),
        ("☡", "cont()"),
        ("⍊", "fail()")
    };

}}
