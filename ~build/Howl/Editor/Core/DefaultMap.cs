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
        k * μ("⊐̥", "using static", q: true),
        k * ("⊐", "using"),
        // ----------------------------------------------------------
        H("Blocks")
        +
        c * ("⊓", "namespace"),
        c * ("○", "class"),
        c * ("⍧", "delegate"),
        c * ("⍥", "enum"),
        c * ("◌", "interface"),
        c * ("⊟", "struct"),
        // ----------------------------------------------------------
        H("Modifiers")
        +
        // Access
        m * ("‒", "public"),
        m * ("◠", "protected"),
        m * ("╌", "internal"),
        m * new Rep("╍", "protected internal", px: "pri", q: true),
        m * ("▰", "private"),
        //
        m * new Rep("‒̥", "public static", px: "ps", q: true),
        m * new Rep("◠̥", "protected static", px: "prs", q: true),
        m * new Rep("╌̥", "internal static", "⊐̥", px: "is", q: true),
        m * new Rep("╍̥", "protected internal static", px: "pris", q: true),
        m * new Rep("▰̥", "private static", px: "pvs", q: true),
        //
        // Common
        m * ("☋", "abstract"),
        m * ("ᴸ", "const"),
        m * ("⁺", "override"),
        m * ("ᴾ", "partial"),
        m * ("⌷", "readonly"),
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
        f * -(Rep)("〰", "continue;"),
        //
        f * ("⤭", "switch", alt: "X"),
        f * ("⥰", "case", alt: "﹦)"), // alt: "↠"),
        f * -(Rep)("¦", "break;", bridge: true),
        //
        x * ("⮐", "return"),
        // NOTE: MostHated aberration
        f * ("↯", "try"),
        f * ("⇤", "catch"),
        f * ("(╯°□°)╯", "throw"),
        //new Rep("(ɔ˘з˘)ɔ", "catch", name: "Got U",  px: "got"),
        //new Rep("(ɔ=3=)ɔ", "catch", name: "Gotcha", px: "gotcha"),
        //new Rep("(ɔówó)ɔ", "catch", name: "WTF!",   px: "wtf"),
        f * ("(˙▿˙)"  , "finally"),
        //
        f * -μ("㆑", "return true;",  px: "tt"),   // ༄
        f * -μ("⤬", "return false;", px: "ff"),   // ༎ ༒ ཀ༛༴༿ཛ
        // ----------------------------------------------------------
        H("Linq")
        +
        f * ("‖", "from", alt: "‖"),
        f * ("¿", "where", alt: "?"),
        f * ("፥", "select", alt: "⁝"),
        f * ("⏢", "orderby"),
        f * ("◿", "ascending"),
        f * ("◺", "descending"),
        // ----------------------------------------------------------
        H("Operators")
        +
        o * new Rep("→", "=>", bridge: true, name: "as (→)"),
        o * new Rep("☰", "==", bridge: true, name: "equals (☰)"),
        o * new Rep("≠", "!=", bridge: true, name: "unequals (≠)"),
        o * new Rep("≥", ">=", bridge: true, name: "greater or equals (≥)"),
        o * new Rep("≤", "<=", bridge: true, name: "lesser or equals (≤)"),
        o * new Rep("∧", "&&", bridge: true, name: "and (∧)"),
        o * new Rep("∨", "||", bridge: true, name: "or (∨)"),
        // NOTE: sidelined pending discussion
        // o * ⌢ Rep("⩜", "&&", alt: "∧̶", ns: ✓),
        // o * ⌢ Rep("⩝", "||", alt: "∨̶", ns: ✓),
        k * μ("⨕", "operator", alt: "/̵", name: "Operator",
              d: "Overloading operator") * B("⨕ ${1:⨀} ($2)"),
        m * new Rep("⒠", "public static explicit operator",
                 px: "explicit", name: "Explicit type conversion")
                                                   * B("⒠ $1($2 ⧕)"),
        m * new Rep("⒤", "public static implicit operator",
                 px: "implicit", name: "Implicit type conversion")
                                                   * B("⒤ $1($2 ⧕)"),
        // ----------------------------------------------------------
        H("Primitives")
        +
        p * - new Rep("ㅇ", "bool",    ι: true),  // ▢ // ◩, , ◫,
        p * - new Rep("ᆨ", "byte",    ι: true),  // ▢ // ◩, , ◫,
        p * - new Rep("ᆩ", "char",    ι: true),  // ▢ // ◩, , ◫,
        p * - new Rep("ᅮ", "short",   ι: true),  // ። // ▫, ▪,  ̻)
        p * - new Rep("ᆞ", "int",     ι: true),  // ። // ▫, ▪,  ̻)
        p * - new Rep("ᅭ", "long",    ι: true),  // ። // ▫, ▪,  ̻)
        p * - new Rep("ㅅ", "float",   ι: true),  // ⊓ // ⊓, ⦜, ⌗
        p * - new Rep("ㅆ", "double",  ι: true),
        p * - new Rep("ᄍ", "decimal", ι: true),
        p * - new Rep("ㄹ", "string",  ι: true),  // ⌞ // ⎅ ⊝ ଽ ⦢
        p * - new Rep("⊡", "object",   ι: true),
        p * ("∙", "var"),

        // ----------------------------------------------------------
        H("Keywords")
        +
        k * new Rep("╭", "get", px: "get") * B("╭{ $0 }"),
        k * new Rep("╰", "set", px: "set") * B("╰{ $0 }"),
        s * -(Rep)("✓", "true"),   // ⊨
        s * -(Rep)("✗", "false"),  // ⊭
        k * ("⌢", "new"),
        s * -(Rep)("∅", "null"),
        k * -(Rep)("⦿", "this", "•́"),
        ("┈", "void"),
        ("⋯", "params"),

        // ----------------------------------------------------------
        H("Semantics")
        +
        p * -μ("⒜", "Action", name: "Action<>", d: "Action pointer"),
        p * -μ("⒡", "Func", name: "Func<>", d: "Function pointer") * B("⒡<${0:R}>"),
        p * -μ("𝕄", "Dictionary", alt: "D", d: "Map type"),  // ⺵
        p * -μ("𝕊", "HashSet", alt: "M", d: "Set type"),
        p * -μ("𝔼", "IEnumerator", alt: "E", d: "Enumerable collection type"),
        p * -(Rep)("𝕃", "List", alt: "L"),
        p * -μ("√", "Sqrt", alt: "L", d: "Square root"),
        p * -(Rep)("∑", "Sum"),
        p * -(Rep)("𝛑", "pi (3.14...)", alt: "π"),
        -(Rep)("±", "Append", "±"),
        -(Rep)("∋", "Contains"),
        -(Rep)("⋺", "ContainsKey", "∋⎯"),
        -(Rep)("∃", "Exists"),
        //-(Rep)("ƪ", "Validate"),
        -(Rep)("⧕", "that", alt: "◁"),
        // ----------------------------------------------------------
        H("Idioms")
        +
        o * μ("⎚", "() =>", alt:"-", π: false, name: "Do", d: "Action reference"),
        o * -(Rep)("⁝", ".Count"),
        o * -(Rep)("❙", ".Length"),
        o * -(Rep)("🝠", ".ToString()", alt:"-"),  // 🜙 ୨
        o * -(Rep)("৴", ".ToArray()"),   // ৴  ୪ 🝠
        o * -(Rep)("ᖾ", ".Value", alt: "v"),   // ৴  ୪ 🝠
        -new Rep("【", "(this,", px: "xargs") * B("【$0)"),
        μ("🐰", "log.message =", alt: "[shell]", q: true),
        μ("🐤", "log.warning =", alt: "[chick]", q: true),
        μ("🦞", "log.error =", alt: "[lbstr]", q: true),

        // NUnit ====================================================

        H("NUnit")
        +
        m * μ("؟", "[Test] public void", px: "test", d: "Test case"),
        m * μ("⍜", "[SetUp] public void", px: "setup", d: "Fixture setup"),
        m * μ("⍉", "[TearDown] public void", px: "teardown", d: "Fixture teardown"),
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
        -new Rep("》", ">()", π: false, ns: true, q: true),
        -new Rep("⧼", "GetComponent<", π: false, alt: "<",
              name: "GetComponent", px: "GetComponent") * B("⧼$0⧽"),
        -new Rep("⧽", ">()", π: false, ns: true, q: true),
        m * μ("⏚","[UnityTest] public IEnumerator", alt: "↓",
                                                       px: "utest", d: "Asynchronous test"),
        k * μ("⏰","yield return new WaitForSeconds",
                                          alt: "⍉", px: "yieldsec", d: "Synchronous timer"),
        // Logging (provisional)
        -new Rep("🍥", "UnityEngine.Debug.Log", alt: "﹫",
            px: "log", q: true) * B("🍥($\"$0\");"),
        -new Rep("🔺", "UnityEngine.Debug.LogError", alt: "▲",
            px: "err", q: true) * B("🔺($\"$0\");"),
        -new Rep("🔸", "UnityEngine.Debug.LogWarning", alt: "◇",
            px: "warn", q: true) * B("🔸($\"$0\");"),
        // Active Logic =============================================
        H("Active Logic")
        +
        p * ("⑂", "status"),
        p * μ("▷", "public action", q: true),
        p * μ("▶", "private action", q: true),
        s * -μ("◇", "done()", d: "Complete task status"),
        s * -μ("☡", "cont()", d: "Ongoing task status"),
        s * -μ("■", "fail()", d: "Failing task status"),
        k * -μ("⌽", "return @void();", d: "Void token")

        // ==========================================================

    };

}}
