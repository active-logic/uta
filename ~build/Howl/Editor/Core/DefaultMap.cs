using static Active.Howl.Header;
using static Active.Howl.Body;
using static Active.Howl.Classifier;

namespace Active.Howl{
public partial class Map{

    public static Map @default = new Rep[]{

        // C# =======================================================

        // ----------------------------------------------------------
        H("Header")
        +
        k * ("⊐̥", "using static" ),
        k * ("⊐", "using"),
        // ----------------------------------------------------------
        H("Blocks")
        +
        c * ("⊓", "namespace"),
        c * ("○", "class"),
        c * ("◌", "interface"),
        c * ("⊟", "struct"),
        // ----------------------------------------------------------
        H("Modifiers")
        +
        // Access
        m * ("‒", "public"),
        m * ("◠", "protected"),
        m * ("╌", "internal"),
        m * new Rep("╍", "protected internal", px: "pri"),
        m * ("▰", "private"),
        //
        m * new Rep("‒̥", "public static", px: "ps"),
        m * new Rep("◠̥", "protected static", px: "prs"),
        m * new Rep("╌̥", "internal static", "⊐̥", px: "is"),
        m * new Rep("╍̥", "protected internal static", px: "pris"),
        m * new Rep("▰̥", "private static", px: "pvs"),
        //
        // Common
        m * ("ᴬ", "abstract"),  // ☋
        m * ("ᴸ", "const"),
        m * ("⁺", "override"),
        m * ("ᴾ", "partial"),
        m * ("∘", "static"),
        m * ("ᵛ", "virtual"),
        // Uncommon
        // (Extern, Readonly, Unsafe, Volatile
        m * ("🔒", "sealed ", alt: "□͆"),

        // ----------------------------------------------------------
        H("Control flow")
        +
        f * ("⤴", "if", alt: "↱"),    // ⑀
        f * ("⤵", "else", alt: "↳"),  // ⑁
        f * ("⤳", "else if", alt: "↪", px: "elif"), // ⑁
        //
        f * ("∀", "foreach")  ,
        f * new Rep("∈", "in", π: false),
        f * ("⟳", "for", alt: "↻"),
        f * ("⟲", "while", alt: "↺"),
        f * -(Rep)("⤓", "continue;"),
        //
        f * ("⤭", "switch", alt: "X"),
        f * ("⥰", "case", alt: "﹦)"), // alt: "↠"),
        f * -(Rep)("¦", "break;", bridge: true),
        //
        x * ("⮐", "return"),
        // NOTE: MostHated aberrations; contribs. from Rettie and Tea
        f * ("↯", "try"),
        f * ("⇤", "catch"),
        f * ("(╯°□°)╯", "throw"),
        //new Rep("(ɔ˘з˘)ɔ", "catch", name: "Got U",  px: "got"),
        //new Rep("(ɔ=3=)ɔ", "catch", name: "Gotcha", px: "gotcha"),
        //new Rep("(ɔówó)ɔ", "catch", name: "WTF!",   px: "wtf"),
        f * ("(˙▿˙)"  , "finally"),
        // ----------------------------------------------------------
        H("Linq")
        +
        f * ("‖", "from", alt: "‖"),
        f * ("¿", "where", alt: "?"),
        f * ("፥", "select", alt: "⁝"),
        // ----------------------------------------------------------
        H("Operators")
        +
        o * new Rep("→", "=>", bridge: true, name: "As (=>)"),
        o * new Rep("☰", "==", bridge: true, name: "Eq"),
        o * new Rep("≠", "!=", bridge: true, name: "NEq"),
        o * new Rep("≥", ">=", bridge: true, name: "GEq"),
        o * new Rep("≤", "<=", bridge: true, name: "LEq"),
        o * new Rep("∧", "&&", bridge: true, name: "And"),
        o * new Rep("∨", "||", bridge: true, name: "Or"),
        // NOTE: sidelined pending discussion
        o * new Rep("⩜", "&&", alt: "∧̶", ns: true),
        o * new Rep("⩝", "||", alt: "∨̶", ns: true),
        //
        k * ("⨕", "operator", alt: "/̵"),
        k * ("ᵉ", "explicit"),
        k * ("ⁱ", "implicit"),
        // ----------------------------------------------------------
        H("Primitives")
        +
        p * - new Rep("ㅇ", "bool",    ι: true),  // ▢ // ◩, , ◫,
        p * - new Rep("ㅅ", "float",   ι: true),  // ⊓ // ⊓, ⦜, ⌗
        p * - new Rep("ᆞ", "int",     ι: true),  // ። // ▫, ▪,  ̻)
        p * - new Rep("ㄹ", "string",  ι: true),  // ⌞ // ⎅ ⊝ ଽ ⦢
        p * - new Rep("⊡", "object",  ι: true),
        p * - new Rep("ㅆ", "double",  ι: true),

        // ----------------------------------------------------------
        H("Keywords")
        +
        k * new Rep("╭", "get", px: "get") * B("╭{ $0 }"),
        k * new Rep("╰", "set", px: "set") * B("╰{ $0 }"),
        s * -(Rep)("✓", "true"),   // ⊨
        s * -(Rep)("✗", "false"),  // ⊭
        k * ("⌢", "new"),
        k * ("∙", "var"),
        s * -(Rep)("∅", "null"),
        k * -(Rep)("⦿", "this", "•́"),
        ("┈", "void"),
        ("⋯", "params"),

        // ----------------------------------------------------------
        H("Identifiers")
        +
        p * -new Rep("⒜", "Action", name: "Action<>"),
        p * -new Rep("⒡", "Func", name: "Func<>") * B("⒡<${0:R}>"),
        p * -(Rep)("𝕄", "Dictionary", alt: "D"),  // ⺵
        p * -(Rep)("𝕊", "HashSet", alt: "M"),
        p * -(Rep)("𝕃", "List", alt: "L"),
        -(Rep)("±", "Append", "±"),
        -(Rep)("∋", "Contains"),
        -(Rep)("⋺", "ContainsKey", "∋⎯"),
        //-(Rep)("ƪ", "Validate"),
        -(Rep)("⧕", "that", alt: "◁"),
        // ----------------------------------------------------------
        H("Idioms")
        +
        o * new Rep("⎚", "() =>", alt:"-", π: false, name: "Do"),
        o * -(Rep)("⁝", ".Count"),
        o * -(Rep)("❙", ".Length"),
        o * -(Rep)("🝠", ".ToString()", alt:"-"),  // 🜙 ୨
        o * -(Rep)("৴", ".ToArray()"),   // ৴  ୪ 🝠
        -new Rep("【", "(this,", px: "xargs") * B("【$0)"),
        ("🐚", "log.message =", alt: "[shell]"),
        ("🐤", "log.warning =", alt: "[chick]"),
        ("🦞", "log.error =", alt: "[lbstr]"),

        // NUnit ====================================================

        H("NUnit")
        +
        m * new Rep("؟", "[Test] public void", px: "test"),
        m * new Rep("⍜", "[SetUp] public void", px: "setup"),
        m * new Rep("⍉", "[TearDown] public void", px: "teardown"),
        -(Rep)("ಠᴗಠ", "Assert.Throws") * B("ಠᴗಠ<$1>( ⎚ $0 );"),

        // Unity ====================================================

        H("Unity")
        +
        p * -new Rep("ロ", "GameObject", ι: true),  // ◰
        p * -(Rep)("⫙", "Component", alt: "m"),
        // Vectors
        p * -(Rep)("エ", "Transform"),  // 𖼲 ⟁ ⊺ ⏧ ⩀ ⁜ み サ
        p * -(Rep)("ᇅ", "Quaternion"),  // ペ, ᇅ
        p * -new Rep("フ", "Vector2", px: "v2"),
        p * -(Rep)("シ", "Vector3"),
        p * -new Rep("タ", "Vector4", px: "v4"),
        // Points
        p * -new Rep("ト", "Vector2", name: "Point2", px: "p2"),
        p * -new Rep("メ", "Vector3", name: "Point3"),
        p * -new Rep("メ̂", "Vector4", name: "Point4", px: "p4"),
        // Idioms
        -new Rep("《", "gameObject.AddComponent<", π: false,
              name: "AddComponent", px: "AddComponent") * B("《$0》"),
        -new Rep("》", ">()", π: false, ns: true),
        -new Rep("⧼", "GetComponent<", π: false, alt: "<",
              name: "GetComponent", px: "GetComponent") * B("⧼$0⧽"),
        -new Rep("⧽", ">()", π: false, ns: true),
        m * new Rep("⏚","[UnityTest] public IEnumerator", alt: "↓",
                                                       px: "utest"),
        k * new Rep("⏰","yield return new WaitForSeconds",
                                          alt: "⍉", px: "yieldsec"),
        // Logging (provisional)
        -new Rep("🍥", "UnityEngine.Debug.Log", alt: "▲",
            px: "log") * B("🍥($\"$0\");"),
        -new Rep("🔺", "UnityEngine.Debug.LogError", alt: "▲",
            px: "err") * B("🔺($\"$0\");"),
        -new Rep("🔸", "UnityEngine.Debug.LogWarning", alt: "▲",
            px: "warn") * B("🔸($\"$0\");"),
        // Active Logic =============================================

        H("Active Logic")
        +
        p * ("⑂", "status"),
        p * ("▷", "public action"),
        p * ("▶", "private action"),
        s * -(Rep)("◇", "done()"),
        s * -(Rep)("☡", "cont()"),
        s * -(Rep)("■", "fail()"),
        k * -(Rep)("⌽", "return @void();")

        // ==========================================================

    };

}}
