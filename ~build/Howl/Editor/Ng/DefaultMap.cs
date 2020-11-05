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
        k * ("⊐", "using"),
        k * μ("⊐̥", "using static", q: true),
        // ----------------------------------------------------------
        H("Blocks")
        +
        c * ("⊓", "namespace"),
        c * ("○", "class"),
        c * ("𐋆", "delegate", alt: "ε"),  //  ⍧
        c * ("⍥", "enum"),
        c * ("𐋂", "interface", alt: ")("),  // 𐋂
        c * ("⊟", "struct"),
        // ----------------------------------------------------------
        H("Modifiers")
        +
        // Access
        m * ("‒", "public"),
        m * ("◠", "protected"),
        m * ("︲", "internal"),  // ╌
        m * new Rep("︲̑", "protected internal", px: "pri", q: true),
        m * ("▰", "private"),
        //
        m * new Rep("‒̥", "public static", px: "ps", q: true),
        m * new Rep("◠̥", "protected static", px: "prs", q: true),
        m * new Rep("︲̥", "internal static", px: "is", q: true),
        m * new Rep("︲̥̑", "protected internal static", px: "pris", q: true),
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
        f * ("～", "default", alt: "﹦)"), // alt: "↠"),
        f * -(Rep)("¦", "break;", bridge: true),
        f * ("⤏", "when", alt:"→"),
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
        f * -μ("⤬", "return false;", px: "ff", alt: "X"),   // ༎ ༒ ཀ༛༴༿ཛ
        f * -μ("⏂", "return null;", px: "nn", alt: "O"),
        // Coroutines -----------------------------------------------
        f * μ("⟾","yield return",
                    alt: "⍉", px: "yr", d: "Yield return null;"),
        f * μ("⤇","yield break;",
                    alt: "⍉", px: "yb", d: "Yield return null;"),
        f * μ("⟆","yield return null;",
                   alt: "⍉", px: "yy", d: "Yield return null;"),
        // ----------------------------------------------------------
        H("Linq")
        +
        f * ("‖", "from", alt: "‖"),
        f * ("¿", "where", alt: "?"),
        //f * ("፥", "select", alt: "⁝"),
        f * ("▸", "select"),
        f * ("⏢", "orderby", alt: "▭"),
        f * ("◿", "ascending", alt: "◢"),
        f * ("◺", "descending", alt: "◣"),
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
        o * new Rep("ᐧ", "*", bridge: true, name: "mul", π: false),
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
        k * ("╭", "get") * B("╭{ $0 }"),
        k * ("╰", "set") * B("╰{ $0 }"),
        s * -(Rep)("✓", "true"),   // ⊨
        s * -(Rep)("✗", "false"),  // ⊭
        k * ("⌢", "new"),
        s * -(Rep)("∅", "null"),
        k * -(Rep)("⦿", "this", "Θ"),
        ("┈", "void"),
        ("⋯", "params"),

        // ----------------------------------------------------------
        H("Semantics")
        +
        p * -μ("⒜", "Action", name: "Action<>", d: "Action pointer", px: "act"),
        p * -μ("⒡", "Func", name: "Func<>", d: "Function pointer") * B("⒡<${0:R}>"),
        p * -μ("𝕄", "Dictionary", alt: "D", d: "Map type"),  // ⺵
        p * -μ("𝕊", "HashSet", alt: "M", d: "Set type"),
        p * -μ("ℚ", "Queue", alt: "Q", d: "Queue type"),
        p * -μ("𝕂", "Stack", alt: "K", d: "Stack type"),
        p * -μ("𝔼", "IEnumerator", alt: "E", d: "Enumerator"),
        p * -μ("‡", "IEnumerable", d: "Enumerable"),
        p * -(Rep)("𝕃", "List", alt: "L"),
        p * -μ("√", "Sqrt", alt: "L", d: "Square root"),
        p * -(Rep)("∑", "Sum"),
        p * -(Rep)("𝛑", "pi (3.14...)", alt: "π"),
        o * -(Rep)("±", "Append", "±"),
        o * -(Rep)("∋", "Contains"),
        o * -(Rep)("⋺", "ContainsKey", "∋⎯"),
        o * -(Rep)("∃", "Exists"),
        //-(Rep)("ƪ", "Validate"),
        k * -(Rep)("𝚊", "acceleration"),
        k * -(Rep)("𝚊̱", "nominalAcceleration"),
        k * -(Rep)("𝒹", "density"),
        k * -(Rep)("𝐹", "force"),
        k * -(Rep)("𝓂", "mass"),
        k * -(Rep)("𝝇", "speed"),
        k * -(Rep)("𝑠̱", "nominalSpeed"),
        k * -(Rep)("⧕", "that", alt: "◁"),
        k * -(Rep)("◍", "target"),
        k * -(Rep)("𝜏", "torque"),
        k * -(Rep)("𝓽", "traction"),
        k * -(Rep)("𝓋", "velocity"),
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
        μ("🐰", "log.message =", alt: "[bunny]", q: true),
        μ("🐤", "log.warning =", alt: "[chick]", q: true),
        μ("🦞", "log.error =", alt: "[lobster]", q: true),

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
        // Types
        p * -new Rep("ロ", "GameObject", ι: true),  // ◰
        p * -(Rep)("⫙", "Component", alt: "m"),
        // Vectors
        p * - (Rep)("エ", "Transform"),  // 𖼲 ⟁ ⊺ ⏧ ⩀ ⁜ み サ
        k * -new Rep("み", "transform",
                   name: "Transform identifier", px: "tra"),
        k * -new Rep("˙", ".transform.position", name: ".position",
                                        px: "position"),
        k * -new Rep("⁰", ".transform.rotation", name: ".rotation",
                                        px: "rotation"),
        k * -new Rep("ˢ", ".transform.lossyScale", name: ".lossyScale",
                                        px: "lossyScale"),
        k * -(Rep)("𝚜", "localScale"),
        k * -(Rep)("𝚛", "localRotation"),
        k * -(Rep)("𝚙", "localPosition"),
        p * -(Rep)("ᇅ", "Quaternion"),  // ペ, ᇅ
        p * -new Rep("フ", "Vector2", px: "v2"),
        p * -(Rep)("シ", "Vector3"),
        p * -new Rep("タ", "Vector4", px: "v4"),
        // Points
        p * -new Rep("ト", "Vector2", name: "Point2", px: "p2"),
        p * -new Rep("メ", "Vector3", name: "Point3", px: "Point3"),
        p * -new Rep("メ̂", "Vector4", name: "Point4", px: "p4"),
        // Idioms
        p * - new Rep("⒯", "Time.time"     , name: "time",
                                            px:"time"),
        p * - new Rep("𝛿𝚝", "Time.deltaTime", name: "deltaTime",
                                            px: "deltaTime"),
        p * - new Rep("∠ʳ", "Mathf.Deg2Rad", px: "radians"),
        p * - new Rep("∠°", "Mathf.Rad2Deg", px: "degrees"),
        p * -(Rep)("⊣", "left"),
        p * -(Rep)("⊢", "right"),
        p * -(Rep)("⊥", "up"),
        p * -(Rep)("⊤", "down"),
        p * -(Rep)("⫫", "forward"),
        p * -(Rep)("⫪", "back"),
        p * -(Rep)("⟛", "center"),
        o * -(Rep)("¹", ".normalized", alt:"-"),  // 🜙 ୨
        o * -(Rep)("❚", ".magnitude", alt:"-"),  // 🜙 ୨
        o * -(Rep)("ˮ", ".gameObject.name", alt:"-"),  // 🜙 ୨
        //
        -new Rep("《", "gameObject.AddComponent<", π: false,
              name: "AddComponent", px: "AddComponent") * B("《$0》"),
        -new Rep("》", ">()", π: false, ns: true, q: true),
        -new Rep("⧼", "GetComponent<", π: false, alt: "<",
              name: "GetComponent", px: "GetComponent") * B("⧼$0⧽"),
        -new Rep("⧽", ">()", π: false, ns: true, q: true),
        // Testing
        m * μ("⏚","[UnityTest] public IEnumerator", alt: "↓",
                   px: "utest", d: "Asynchronous test"),
        m * μ("⒪","if (Skip()) yield break;", alt: "⒪",
                   px: "opt", d: "Optional test"),
        // Coroutines
        k * μ("⏰","yield return new WaitForSeconds",
                   alt: "⍉", px: "yieldsec", d: "Synchronous timer"),
        // Logging (provisional)
        -new Rep("🍥", "That.Logger.Log", alt: "﹫",
            px: "log", q: true) * B("🍥($\"$0\");"),
        -new Rep("🔺", "That.Logger.Err", alt: "▲",
            px: "err", q: true) * B("🔺($\"$0\");"),
        -new Rep("🔸", "That.Logger.Warn", alt: "◇",
            px: "warn", q: true) * B("🔸($\"$0\");"),
        // Active Logic =============================================
        H("Active Logic")
        +
        p * ("⑂", "status"),
        p * ("▷", "action"),
        p * ("𝟾", "loop"),
        p * ("⨴", "impending"),
        p * ("⨮", "pending"),
        p * ("ⓧ", "failure"),
        k * ("ʾ", ".due"),
        k * ("ʿ", ".undue"),
        k * ("ᴼ", ".ever"),
        s * -μ("◇", "done()", d: "Complete task status"),
        s * -μ("☡", "cont()", d: "Ongoing task status"),
        s * -μ("■", "fail()", d: "Failing task status"),
        // Control (status)
        k * -μ("◇̠", "return done();", px: "dd"),   // ༎ ༒ ཀ༛༴༿ཛ
        k * -μ("☡̱", "return cont();", px: "cc"),   // ༄
        k * -μ("■̠", "return fail();", px: "fa"),
        // Control (certainties)
        k * -μ("⌽", "return @void();",        px: "vvv"),
        k * -μ("ⓧ̱", "return @false();",      px: "fff"),
        k * -μ("𝟾̱", "return loop.cont();",    px: "lcc"),
        // More certainties
        k * -μ("◇̠ʾ", "return pending.done();", px: "pdd"),
        k * -μ("☡̱ʾ", "return pending.cont();", px: "pcc"),
        k * -μ("☡̱ʿ", "return impending.cont();", px: "icc"),
        k * -μ("■̠ʿ", "return impending.fail();", px: "iff"),

        // Idioms
        f * - new Rep("⍈", "Sequence()", π: false)
                                * B("⍈ [ ⩓ $1 : ${2:repeat}];"),
        f * μ("⩓", "and ?", px: "then"),
        f * - new Rep("⍰", "Selector()", π: false)
                                * B("⍰ [ ⩔ $1 : ${2:repeat}];"),
        f * μ("⩔", "or ?", px: "otherwise"),
        f * - new Rep("❰", "Once()?[", π: false) * B("❰$1❱"),       // Once
        f * - new Rep("❱", "]", π: false, ns: true, q: true),
        //
        f * - new Rep("⸨", "While(", px: "Drive", π: false)         // While
                       * B("⸨ $1 ≫ $2 ⸩"),
        o * - new Rep("≫", ")?[", π: false, ns: true, q: true),
        f * - new Rep("⸩", "]"  , π: false, ns: true, q: true),
        //
        f * - new Rep("⁅", "Tie(", π: false) * B("⁅ $1 × $2 ⁆"),    // Tie
        o * - new Rep("×", ")?[", π: false, ns: true, q: true),
        f * - new Rep("⁆", "]"  , π: false, ns: true, q: true)

        // ==========================================================

    };

}}
