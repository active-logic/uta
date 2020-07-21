using static Active.Howl.Header;

namespace Active.Howl{
public partial class Map{

    public static Map @default = new Rep[]{
        //
        // C# =======================================================
        //
        H("Header")
        +
        ("♘", "using static"),
        ("♖", "using"),
        //
        H("Blocks")
        +
        ("⛩", "namespace ", alt: "x"), //
        ("🍣", "public partial static class ", alt: "x"),
        ("🍚", "public static class ", alt: "x"),
        ("🍥", "public partial class ", alt: "x"),
        ("🍙", "public class ", alt: "x"),
        ("🍘", "class ", alt: "x"),
        ("🍡", "public struct ", alt: "x"),
        ("🍢", "struct ", alt: "x"),
        ("🍭", "public interface ", alt: "x"),
        ("🍬", "interface ", alt: "x"),
        //
        // Modifiers ------------------------------------------------
        //
        H("Modifiers")
        +
        ("⃠", "public static"),
        ("⎅", "protected static", alt: "x"),
        ("⟠", "internal static", alt: "x"),
        //
        ("☋", "abstract"),
        ("▯", "const"),
        ("⒠", " explicit"),
        ("ⁱ", " implicit"),
        ("◊", "internal"),
        ("⨕", "operator", alt: "x"),
        ("⁺", "override "),
        ("ｦ", "partial"),
        ("○", "public"),
        ("◻︎", "protected", alt: "x"),
        ("⌿", "static "),
        ("🔒", "sealed ", alt: "x"),
        ("ᵛ", "virtual "),
        //
        H("Control flow")
        +
        ("⤴", "if", alt: "↱"),   // ⑀
        ("⤵", "else", alt: "↳"), // ⑁
        //
        ("∀", "foreach"),
        ("∈", "in"),
        ("⟳", "for", alt: "↻"),
        ("⟲", "while", alt: "↺"),
        //
        ("⤭", "switch", alt: "↬"),
        ("⤚", "case", alt: "↠"),
        ("↯", "break;", bridge: true),
        //
        ("⮐", "return"),
        //
        ("𝄁", "from", alt: "||"),
        ("¿", "where", alt: "?"),
        ("፥", "select", alt: "⁝"),
        //
        // NOTE: MostHated aberrations; contrib from Rettie and TEA
        ("ಠᴗಠ"    , "try"    ),
        ("(╯°□°)╯", "throw"  ),
        ("(ɔ˘з˘)ɔ", "catch"  ),
        ("(ɔ=3=)ɔ", "catch"  ),
        ("(ɔówó)ɔ", "catch"  ),
        ("(˙▿˙)"  , "finally"),
        //
        ("◞", "throw"),
        ("╭", "try"),
        ("❘", "catch"),
        ("╰", "finally"),
        //
        H("Operators")
        +
        ("→", "=>", bridge: true),
        ("☰", "==", bridge: true),
        ("≠", "!=", bridge: true),
        ("≥", ">=", bridge: true),
        ("≤", "<=", bridge: true),
        ("∧", "&&", bridge: true),
        ("∨", "||", bridge: true),
        ("⩜", "&&", alt: "∧̶"),
        ("⩝", "||", alt: "∨̶"),
        //
        H("Primitives")
        +
        new Rep("ㅇ", "bool",   ι: true),
        new Rep("ㅅ", "float",  ι: true),
        new Rep("ᆞ", "int",    ι: true),
        new Rep("ㄹ", "string", ι: true),
        //
        H("Keywords")
        +
        ("⊨", "true"),
        ("⊭", "false"),
        ("⌢", "new"),
        ("∙", "var"),
        ("∅", "null"),
        ("┈", "void"),
        //
        H("Identifiers")
        +
        ("𝑎", "Action", alt: "A"),
        ("𝑓", "Func", alt: "F"),
        //
        ("⺵", "Dictionary", "m"),
        ("⺅", "HashSet", "I̷"),
        ("⺀", "List", alt:"\""),
        //
        ("⩱", "Append", "+̿"),
        ("∋", "Contains"),
        ("⋺", "ContainsKey", "∋̶"),
        ("ƪ", "Validate"),
        //
        H("Idioms")
        +
        ("⎚", "() =>", alt:"-"),
        ("⁝", ".Count"),
        ("❙", ".Length"),
        ("🝠", ".ToString()", alt:"-"),  // 🜙 ୨
        ("৴", ".ToArray()"),   // ৴  ୪ 🝠
        ("【", "(this,"),
        ("⍥", "public void"),
        ("◑", "public bool"),
        //
        H("NUnit")
        +
        ("؟", "[Test] public void"),
        ("⼊", "[SetUp] public void", alt: "S"),
        ("⽌", "[TearDown] public void", alt: "T"),
        //
        H("Unity")
        +
        new Rep("《", "gameObject.AddComponent<", π: false),
                                      new Rep("》", ">()", π: false),
        new Rep("⧼", "GetComponent<", π: false),
                                       new Rep("⧽", ">()", π: false),
        ("📝", "Debug.Log", "⌸"),
        ("🚸", "Debug.LogWarning", alt: "⍚"),
        ("⛔️", "Debug.LogError", alt:"⍜"),
        // GameObject
        new Rep("ロ", "GameObject", ι: true),  // ◰
        ("⫙", "Component", alt: "m"),
        // Vectors
        ("ェ", "Transform"),  // 𖼲 ⟁ ⊺ ⏧ ⩀ ⁜ み サ
        ("∠", "Quaternion"),
        ("ソ", "Vector2"),
        new Rep("ㄱ", "Vector3", ι: true),
        ("⇢̤̈", "Vector4"),
        // Points
        ("ト", "Vector2"),
        ("メ", "Vector3"),
        ("⌑̤̈", "Vector4"),
        //
        H("Active Logic")
        +
        ("▹", "public action"),
        ("⑂", "status"),
        ("➤", "action"),
        ("✓", "done()"),
        ("☡", "cont()"),
        ("✗", "fail()"),
        ("⌽", "return @void()")
        //
        // ==========================================================
    };

}}
