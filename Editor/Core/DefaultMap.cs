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
        ("⛩", "namespace ", alt: "Π"), //
        ("🍣", "public partial static class ", alt: "o̿"),
        ("🍚", "public static class ", alt: "O̶"),
        ("🍥", "public partial class ", alt: "@"),
        ("🍙", "public class ", alt: "Δ̪"),
        ("🍘", "class ", alt: "O̺"),
        ("🍡", "public struct ", alt: "\\̵"),
        ("🍢", "struct ", alt: "\\̴"),
        ("🍭", "public interface ", alt: "ᵖ\\"),
        ("🍬", "interface ", alt: "∞"),
        //
        // Modifiers ------------------------------------------------
        //
        H("Modifiers")
        +
        ("⃠", "public static"),
        ("⎅", "protected static", alt: "□̷"),
        ("⟠", "internal static", alt: "v̑"),
        //
        ("☋", "abstract"),
        ("▯", "const"),
        ("⒠", " explicit"),
        ("ⁱ", " implicit"),
        ("◊", "internal"),
        ("⨕", "operator", alt: "/̵"),
        ("⁺", "override "),
        ("ｦ", "partial"),
        ("○", "public"),
        ("◻︎", "protected", alt: "▢"),
        ("⌿", "static "),
        ("🔒", "sealed ", alt: "□͆"),
        ("ᵛ", "virtual "),
        //
        H("Control flow")
        +
        ("⤴", "if", alt: "↱"),     // ⑀
        ("⤵", "else", alt: "↳"),   // ⑁
        ("⤳", "else if", alt: "↪"), // ⑁
        //
        ("∀", "foreach"),
        ("∈", "in"),
        ("⟳", "for", alt: "↻"),
        ("⟲", "while", alt: "↺"),
        //
        ("⤭", "switch", alt: "X"),
        ("⥰", "case", alt: "⨮"), // alt: "↠"),
        ("¦", "break;", bridge: true),
        //
        ("⮐", "return"),
        //
        ("𝄁", "from", alt: "||"),
        ("¿", "where", alt: "?"),
        ("፥", "select", alt: "⁝"),
        //
        // NOTE: MostHated aberrations; contribs from Rettie and TEA
        ("↯", "try"),
        ("⤒", "catch", alt: "⇤" ),
        new Rep("(ɔ˘з˘)ɔ", "catch", name: "Got U"),
        new Rep("(ɔ=3=)ɔ", "catch", name: "Gotcha"),
        new Rep("(ɔówó)ɔ", "catch", name: "WTF!", prefix: "wtf"),
        ("(˙▿˙)"  , "finally"),
        //
        H("Operators")
        +
        new Rep("→", "=>", bridge: true, name: "As (=>)"),
        new Rep("☰", "==", bridge: true, name: "Eq"),
        new Rep("≠", "!=", bridge: true, name: "NEq"),
        new Rep("≥", ">=", bridge: true, name: "GEq"),
        new Rep("≤", "<=", bridge: true, name: "LEq"),
        new Rep("∧", "&&", bridge: true, name: "And"),
        new Rep("∨", "||", bridge: true, name: "Or"),
        // NOTE: sidelined from snippets pending discussion
        new Rep("⩜", "&&", alt: "∧̶", ns: true),
        new Rep("⩝", "||", alt: "∨̶", ns: true),
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
        ("✓", "true"),   // ⊨
        ("✗", "false"),  // ⊭
        ("⌢", "new"),
        ("∙", "var"),
        ("∅", "null"),
        ("┈", "void"),
        //
        H("Identifiers")
        +
        new Rep("𝑎", "Action", alt: "A", name: "Action<>"),
        new Rep("𝑓", "Func", alt: "F", name: "Func<>"),
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
        new Rep("⎚", "() =>", alt:"-", π: false, name: "Do"),
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
        ("ಠᴗಠ", "Assert.Throws"),
        //
        H("Unity")
        +
        new Rep("《", "gameObject.AddComponent<", π: false),
        new Rep("》", ">()", π: false, ns: true),
        new Rep("⧼", "GetComponent<", π: false),
        new Rep("⧽", ">()", π: false, ns: true),
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
        new Rep("ト", "Vector2", name: "Point2", prefix: "p2"),
        new Rep("メ", "Vector3", name: "Point3", prefix: "p3"),
        new Rep("⌑̤̈", "Vector4", name: "Point4", prefix: "p4"),
        //
        H("Active Logic")
        +
        ("▹", "public action"),
        ("⑂", "status"),
        ("➤", "action"),
        ("✓̱", "done()"),
        ("☡", "cont()"),
        ("✗̱", "fail()"),
        ("⌽", "return @void()")
        //
        // ==========================================================
    };

}}
