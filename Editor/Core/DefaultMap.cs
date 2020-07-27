using static Active.Howl.Header;
using static Active.Howl.Body;

namespace Active.Howl{
public partial class Map{

    public static Map @default = new Rep[]{

        // C# =======================================================

        // ----------------------------------------------------------
        H("Header")
        +
        ("⊐̥", "using static"),
        ("⊐", "using"),
        // ----------------------------------------------------------
        H("Blocks")
        +
        ("⊓", "namespace"),
        ("○", "class"),
        ("◌", "interface"),
        ("⊟", "struct"),
        // ----------------------------------------------------------
        H("Modifiers")
        +
        // Access
        ("‒", "public"),
        ("◠", "protected"),
        ("╌", "internal"),
        new Rep("╍", "protected internal", px: "pri"),
        ("▰", "private"),
        //
        new Rep("‒̥", "public static", px: "ps"),
        new Rep("◠̥", "protected static", px: "prs"),
        new Rep("╌̥", "internal static", "⊐̥", px: "is"),
        new Rep("╍̥", "protected internal static", px: "pris"),
        new Rep("▰̥", "private static", px: "pvs"),
        // Common
        ("ᴬ", "abstract"),  // ☋
        ("ᴸ", "const"),
        ("⁺", "override"),
        ("ᴾ", "partial"),
        ("∘",  "static"),
        ("ᵛ", "virtual"),
        // Uncommon
        // (Extern, Readonly, Unsafe, Volatile
        ("🔒", "sealed ", alt: "□͆"),

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
        ("⥰", "case", alt: "﹦)"), // alt: "↠"),
        -(Rep)("¦", "break;", bridge: true),
        //
        ("⮐", "return"),
        // NOTE: MostHated aberrations; contribs. from Rettie and Tea
        ("↯", "try"),
        ("⇤", "catch"),
        //new Rep("(ɔ˘з˘)ɔ", "catch", name: "Got U",  px: "got"),
        //new Rep("(ɔ=3=)ɔ", "catch", name: "Gotcha", px: "gotcha"),
        //new Rep("(ɔówó)ɔ", "catch", name: "WTF!",   px: "wtf"),
        ("(˙▿˙)"  , "finally"),
        // ----------------------------------------------------------
        H("Linq")
        +
        ("‖", "from", alt: "‖"),
        ("¿", "where", alt: "?"),
        ("፥", "select", alt: "⁝"),
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
        //
        ("⨕", "operator", alt: "/̵"),
        ("ᵉ", " explicit"),
        ("ⁱ", " implicit"),
        // ----------------------------------------------------------
        H("Primitives")
        +
        -new Rep("ㅇ", "bool",   ι: true),  // ▢ // ◩, , ◫,
        -new Rep("ㅅ", "float",  ι: true),  // ⊓ // ⊓, ⦜, ⌗
        -new Rep("ᆞ", "int",    ι: true),  // ። // ▫, ▪,  ̻)
        -new Rep("ㄹ", "string", ι: true),  // ⌞ // ⎅ ⊝ ଽ ⦢
        //-new Rep("⩏", "double"), ι: true), ⊔

        // ----------------------------------------------------------
        H("Keywords")
        +
        new Rep("⇖", "get =>", alt:"⇖"),
        new Rep("⇘", "set =>", alt:"⇘"),
        -new Rep("↖", "get", px: "getb") * B("get{ $0 }"),
        -new Rep("↘", "set", px: "setb") * B("set{ $0 }"),
        -(Rep)("✓", "true"),   // ⊨
        -(Rep)("✗", "false"),  // ⊭
        ("⌢", "new"),
        ("∙", "var"),
        -(Rep)("∅", "null"),
        -(Rep)("⦿", "this", "•́"),
        ("┈", "void"),
        // ----------------------------------------------------------
        H("Identifiers")
        +
        -new Rep("⒜", "Action", name: "Action<>"),
        -new Rep("⒡", "Func", name: "Func<>")
                                                    * B("𝔽<${0:R}>"),
        -(Rep)("𝕄", "Dictionary", alt: "D"),  // ⺵
        -(Rep)("𝕊", "HashSet", alt: "M"),
        -(Rep)("𝕃", "List", alt: "L"),
        -(Rep)("±", "Append", "±"),
        -(Rep)("∋", "Contains"),
        -(Rep)("⋺", "ContainsKey", "∋̶"),
        //-(Rep)("ƪ", "Validate"),
        -(Rep)("⧕", "that", alt: "◁"),
        // ----------------------------------------------------------
        H("Idioms")
        +
        new Rep("⎚", "() =>", alt:"-", π: false, name: "Do"),
        -(Rep)("⁝", ".Count"),
        -(Rep)("❙", ".Length"),
        -(Rep)("🝠", ".ToString()", alt:"-"),  // 🜙 ୨
        -(Rep)("৴", ".ToArray()"),   // ৴  ୪ 🝠
        -new Rep("【", "(this,", px: "xargs") * B("【$0)"),
        new Rep("‒̈", "public void", px: "pv"),

        // NUnit ====================================================

        H("NUnit")
        +
        new Rep("؟", "[Test] public void", px: "test"),
        new Rep("⍜", "[SetUp] public void", px: "setup"),
        new Rep("⍉", "[TearDown] public void", px: "teardown"),
        -(Rep)("ಠᴗಠ", "Assert.Throws") * B("ಠᴗಠ<$1>( ⎚ $0 );"),

        // Unity ====================================================

        H("Unity")
        +
        -new Rep("ロ", "GameObject", ι: true),  // ◰
        -(Rep)("⫙", "Component", alt: "m"),
        // Vectors
        -(Rep)("エ", "Transform"),  // 𖼲 ⟁ ⊺ ⏧ ⩀ ⁜ み サ
        -(Rep)("ペ", "Quaternion"),
        -new Rep("フ", "Vector2", px: "v2"),
        -(Rep)("シ", "Vector3"),
        -new Rep("タ", "Vector4", px: "v4"),
        // Points
        -new Rep("ト", "Vector2", name: "Point2", px: "p2"),
        -new Rep("メ", "Vector3", name: "Point3"),
        -new Rep("メ̂", "Vector4", name: "Point4", px: "p4"),
        // Idioms
        -new Rep("《", "gameObject.AddComponent<", π: false,
              name: "AddComponent", px: "AddComponent") * B("《$0》"),
        -new Rep("》", ">()", π: false, ns: true),
        -new Rep("⧼", "GetComponent<", π: false, alt: "<",
              name: "GetComponent", px: "GetComponent") * B("⧼$0⧽"),
        -new Rep("⧽", ">()", π: false, ns: true),
        -(Rep)("📝", "Debug.Log", "⌸"),
        -(Rep)("🚸", "Debug.LogWarning", alt: "⍚"),
        -(Rep)("⛔️", "Debug.LogError", alt:"⍜"),
        new Rep("⏚","[UnityTest] public IEnumerator", alt: "↓",
                                                       px: "utest"),
        new Rep("⏰","yield return new WaitForSeconds",
                                          alt: "⍉", px: "yieldsec"),
        // Active Logic =============================================

        H("Active Logic")
        +
        ("▹", "public action"),
        ("⑂", "status"),
        ("➤", "action"),
        -(Rep)("✓̱", "done()"),
        -(Rep)("☡", "cont()"),
        -(Rep)("✗̱", "fail()"),
        -(Rep)("⌽", "return @void();")

        // ==========================================================

    };

}}
