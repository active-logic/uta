using static Active.Howl.Header;
using static Active.Howl.Body;

namespace Active.Howl{
public partial class Map{

    public static Map @default = new Rep[]{

        // C# =======================================================

        // ----------------------------------------------------------
        H("Header")
        +
        ("♘", "using static"),
        ("♖", "using"),
        // ----------------------------------------------------------
        H("Blocks")
        +
        ("⛩", "namespace ", alt: "Π"), //
        ("🍣", "public partial static class ", alt: "o̿", px: "ppsc"),
        ("🍚", "public static class ", alt: "O̶", px: "psc"),
        ("🍥", "public partial class ", alt: "@", px: "ppc"),
        ("🍙", "public class ", alt: "Δ̪", px: "pcls"),
        ("🍘", "class ", alt: "O̺"),
        ("🍡", "public struct ", alt: "\\̵", px: "pstruct"),
        ("🍢", "struct ", alt: "\\̴"),
        ("🍭", "public interface ", alt: "ᵖ\\", px: "pint"),
        ("🍬", "interface ", alt: "∞"),
        // ----------------------------------------------------------
        H("Modifiers")
        +
        new Rep("⃠", "public static", px: "ps"),
        ("⎅", "protected static", alt: "□̷", px: "prs"),
        ("⟠", "internal static", alt: "v̑", px: "is"),
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
        // ----------------------------------------------------------
        H("Control flow")
        +
        ("⤴", "if", alt: "↱"),    // ⑀
        ("⤵", "else", alt: "↳"),  // ⑁
        ("⤳", "else if", alt: "↪", px: "elif"), // ⑁
        //
        ("∀", "foreach"),
        ("∈", "in"),
        ("⟳", "for", alt: "↻"),
        ("⟲", "while", alt: "↺"),
        //
        ("⤭", "switch", alt: "X"),
        ("⥰", "case", alt: "⨮"), // alt: "↠"),
        -(Rep)("¦", "break;", bridge: true),
        //
        ("⮐", "return"),
        //
        ("𝄁", "from", alt: "||"),
        ("¿", "where", alt: "?"),
        ("፥", "select", alt: "⁝"),
        // NOTE: MostHated aberrations; contribs. from Rettie and Tea
        ("↯", "try"),
        ("⤒", "catch", alt: "⇤" ),
        new Rep("(ɔ˘з˘)ɔ", "catch", name: "Got U",  px: "got"),
        new Rep("(ɔ=3=)ɔ", "catch", name: "Gotcha", px: "gotcha"),
        new Rep("(ɔówó)ɔ", "catch", name: "WTF!",   px: "wtf"),
        ("(˙▿˙)"  , "finally"),
        // ----------------------------------------------------------
        H("Operators")
        +
        new Rep("→", "=>", bridge: true, name: "As (=>)"),
        new Rep("☰", "==", bridge: true, name: "Eq"),
        new Rep("≠", "!=", bridge: true, name: "NEq"),
        new Rep("≥", ">=", bridge: true, name: "GEq"),
        new Rep("≤", "<=", bridge: true, name: "LEq"),
        new Rep("∧", "&&", bridge: true, name: "And"),
        new Rep("∨", "||", bridge: true, name: "Or"),
        // NOTE: sidelined pending discussion
        new Rep("⩜", "&&", alt: "∧̶", ns: true),
        new Rep("⩝", "||", alt: "∨̶", ns: true),
        // ----------------------------------------------------------
        H("Primitives")
        +
        -new Rep("ㅇ", "bool",   ι: true),
        -new Rep("ㅅ", "float",  ι: true),
        -new Rep("ᆞ", "int",    ι: true),
        -new Rep("ㄹ", "string", ι: true),
        // ----------------------------------------------------------
        H("Keywords")
        +
        -(Rep)("✓", "true"),   // ⊨
        -(Rep)("✗", "false"),  // ⊭
        ("⌢", "new"),
        ("∙", "var"),
        -(Rep)("∅", "null"),
        ("┈", "void"),
        // ----------------------------------------------------------
        H("Identifiers")
        +
        -new Rep("𝒜", "Action", alt: "A", name: "Action<>"),
        -new Rep("ℱ", "Func", alt: "F", name: "Func<>")
                                                    * B("ℱ<${0:R}>"),
        -(Rep)("⺵", "Dictionary", "m"),
        -(Rep)("⺅", "HashSet", "I̷"),
        -(Rep)("⺀", "List", alt:"\""),
        -(Rep)("⩱", "Append", "+̿"),
        -(Rep)("∋", "Contains"),
        -(Rep)("⋺", "ContainsKey", "∋̶"),
        -(Rep)("ƪ", "Validate"),
        // ----------------------------------------------------------
        H("Idioms")
        +
        new Rep("⎚", "() =>", alt:"-", π: false, name: "Do"),
        -(Rep)("⁝", ".Count"),
        -(Rep)("❙", ".Length"),
        -(Rep)("🝠", ".ToString()", alt:"-"),  // 🜙 ୨
        -(Rep)("৴", ".ToArray()"),   // ৴  ୪ 🝠
        -new Rep("【", "(this,", px: "xargs") * B("【$0)"),
        new Rep("⍥", "public void", px: "pv"),
        new Rep("◑", "public bool", px: "pb"),

        // NUnit ====================================================

        H("NUnit")
        +
        new Rep("؟", "[Test] public void", px: "test"),
        ("⼊", "[SetUp] public void", alt: "S", px: "setup"),
        ("⽌", "[TearDown] public void", alt: "T", px: "teardown"),
        -(Rep)("ಠᴗಠ", "Assert.Throws") * B("ಠᴗಠ<$1>( ⎚ $0 );"),

        // Unity ====================================================

        H("Unity")
        +
        -new Rep("《", "gameObject.AddComponent<", π: false,
                                    px: "AddComponent") * B("《$0》"),
        -new Rep("》", ">()", π: false, ns: true),
        -new Rep("⧼", "GetComponent<", π: false,
                                     px: "GetComponent") * B("⧼$0⧽"),
        -new Rep("⧽", ">()", π: false, ns: true),
        -(Rep)("📝", "Debug.Log", "⌸"),
        -(Rep)("🚸", "Debug.LogWarning", alt: "⍚"),
        -(Rep)("⛔️", "Debug.LogError", alt:"⍜"),
        // GameObject
        -new Rep("ロ", "GameObject", ι: true),  // ◰
        -(Rep)("⫙", "Component", alt: "m"),
        // Vectors
        -(Rep)("ェ", "Transform"),  // 𖼲 ⟁ ⊺ ⏧ ⩀ ⁜ み サ
        -(Rep)("∠", "Quaternion"),
        -(Rep)("ソ", "Vector2"),
        -new Rep("ㄱ", "Vector3", ι: true),
        -(Rep)("⇢̤̈", "Vector4"),
        // Points
        -new Rep("ト", "Vector2", name: "Point2", px: "p2"),
        -new Rep("メ", "Vector3", name: "Point3", px: "p3"),
        -new Rep("⌑̤̈", "Vector4", name: "Point4", px: "p4"),

        // Active Logic =============================================

        H("Active Logic")
        +
        ("▹", "public action"),
        ("⑂", "status"),
        ("➤", "action"),
        -(Rep)("✓̱", "done()"),
        -(Rep)("☡", "cont()"),
        -(Rep)("✗̱", "fail()"),
        -(Rep)("⌽", "return @void()")

        // ==========================================================

    };

}}
