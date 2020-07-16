namespace Active.Howl{
public partial class Map{

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

        //("切 ","public static "),      // ps1
        //("愜 ","protected static "),   // ps2
        //("户 ","internal static "),    // is
        //("日", "abstract"),          // a1
        //("心", "public"),            // p1
        //("㣺", "protected"),         // p2
        //("丶", "internal"),          // i2
        //("尸", "static"),            // s1
        ("⁺", " override"),         // s1
        ("ᵛ", " virtual"),          // s1
        ("⿵", "abstract"),          // s1
        ("ｦ", "partial"),          // s1
        // Operator related
        //("人", "operator"),          // o1
        //("戈", "implicit"),          // i1
        //("水", "explicit"),          // e1
        //
        // Classic
        ("☋", "abstract"),
        ("⃠", "public static"),
        ("⎅", "protected static"),
        ("⟠", "internal static"),
        ("▯", "const"),
        //
        ("○", "public"),
        ("◻︎", "protected"),
        ("◊", "internal"),
        ("⌿", "static"),
        //
        ("⨕", "operator"),
        ("⒠", "explicit"),
        ("ⁱ", " implicit"),
        ("♖", "using"),
        // Operators
        ("☰", "==", bridge: true),
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
        ("⃕", "for"),
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
        (" ↣", "() =>", bridge: true),
        (" ↣", "()=>", bridge: true),
        ("→", "=>", bridge: true),
        ("⨮", "new"),
        ("∙", "var"),
        ("┈", "void"),
        // Active Logic
        ("⑂", "status"),
        ("➤", "action"),
        ("✓", "done()"),
        ("☡", "cont()"),
        ("✗", "fail()")
    };

}}
