namespace Active.Howl{
public partial class Map{

    public static Map @default = new Rep[]{
        // Unity
        ("《", "gameObject.AddComponent<"), ("》", ">()"),
        ("⧼", "GetComponent<"), ("⧽", ">()"),
        ("📝", "Debug.Log"),
        ("🚸", "Debug.LogWarning"),
        ("⛔️", "Debug.LogError"),
        // GameObject
        new Rep("ロ", "GameObject", ι: true),  // ◰
        ("⫙", "Component"),
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
        // ==============================================
        // Containers
        ("⛩", "namespace "),
        ("🍣", "public partial static class "),
        ("🍚", "public static class "),
        ("🍥", "public partial class "),
        ("🍙", "public class "),
        ("🍘", "class "),
        ("🍡", "public struct "),
        ("🍢", "struct "),
        ("public interface ", "🍭"),
        ("interface ", "🍬"),
        // Idioms
        ("୨", ".ToString()"),  // 🜙 ୨
        ("৴", ".ToArray()"),   // ৴  ୪ 🝠
        ("⠇", ".Count"),
        ("❙", ".Length"),
        // Words
        ("⩱", "Append"),
        ("∋", "Contains"),
        ("⋺", "ContainsKey"),
        ("⺵", "Dictionary"),
        ("⺅", "HashSet"),
        ("⺀", "List"),
        ("✓", "Validate"),
        // Modifiers
        ("⁺", "override "),
        ("ᵛ", " virtual"),
        ("୪", "abstract"),
        ("ｦ", "partial"),
        // NUnit
        ("؟", "[Test] public void"),
        ("⼊", "[SetUp] public void"),
        ("⽌", "[TearDown] public void"),
        // Special
        ("【", "(this,"),
        ("⌽", "return @void()"),
        ("⍥", "public void"),
        ("◑", "public bool"),
        ("▹", "public action"),
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
        ("🔒", "sealed"),
        //
        ("⨕", "operator"),
        ("⒠", " explicit"),
        ("ⁱ", " implicit"),
        ("♘", "using static"),
        ("♖", "using"),
        // Operators
        ("☰", "==", bridge: true),
        ("≠", "!=", bridge: true),
        ("≥", ">=", bridge: true),
        ("≤", "<=", bridge: true),
        ("∧", "&&", bridge: true), // ⍲ ∧
        ("∨", "||", bridge: true), // ⍱ ∨
        // Types
        ("𝑓", "Func"),
        ("𝑎", "Action"),
        // Aliased primitives
        new Rep("ㅇ", "bool",   ι: true),
        new Rep("ㅅ", "float",  ι: true),
        new Rep("ᆞ", "int",    ι: true),
        new Rep("ㄹ", "string", ι: true),
        // Constants
        ("⊨", "true"),
        ("⊭", "false"),
        // Control flow
        ("⤴", "if"),   // ⑀
        ("⤵", "else"), // ⑁
        //
        ("∀", "foreach"),
        ("∈", "in"),
        ("⟳", "for"),
        ("⟲", "while"),
        ("⮐", "return"),
        ("⤭", "switch"),
        ("⤚", "case"),
        ("↯", "break;"),
        // Linq
        ("𝄁", "from"),
        ("¿", "where"),
        ("፥", "select"),
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
        ("◞", "throw"),
        ("╭", "try"),
        ("❘", "catch"),
        ("╰", "finally"),
        // Misc
        ("↣", "() =>", bridge: true),
        ("→", "=>", bridge: true),
        ("⌢", "new"),
        ("∙", "var"),
        ("┈", "void"),
        // Active Logic
        ("⑂", "status"),
        ("➤", "action"),
        ("ʋ", "done()"),
        ("☡", "cont()"),
        ("✗", "fail()")
    };

}}
