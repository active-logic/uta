namespace Active.Howl{
public partial class Map{

    public static Map @default = new Rep[]{
        //
        // C# =======================================================
        //
        ("♘", "using static"),
        ("♖", "using"),
        //
        // Containers -----------------------------------------------
        //
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
        //
        // Modifiers ------------------------------------------------
        //
        ("⃠", "public static"),
        ("⎅", "protected static"),
        ("⟠", "internal static"),
        //
        ("☋", "abstract"),
        ("▯", "const"),
        ("⒠", " explicit"),
        ("ⁱ", " implicit"),
        ("◊", "internal"),
        ("⨕", "operator"),
        ("⁺", "override "),
        ("ｦ", "partial"),
        ("○", "public"),
        ("◻︎", "protected"),
        ("⌿", " static"),
        ("🔒", " sealed"),
        ("ᵛ", " virtual"),
        //
        // Control flow ---------------------------------------------
        //
        ("⤴", "if"),   // ⑀
        ("⤵", "else"), // ⑁
        //
        ("∀", "foreach"),
        ("∈", "in"),
        ("⟳", "for"),
        ("⟲", "while"),
        //
        ("⤭", "switch"),
        ("⤚", "case"),
        ("↯", "break;"),
        //
        ("⮐", "return"),
        //
        ("𝄁", "from"),
        ("¿", "where"),
        ("፥", "select"),
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
        // Operators ------------------------------------------------
        //
        ("→", "=>", bridge: true),
        ("☰", "==", bridge: true),
        ("≠", "!=", bridge: true),
        ("≥", ">=", bridge: true),
        ("≤", "<=", bridge: true),
        ("∧", "&&", bridge: true),
        ("⩜", "&&", bridge: true),
        ("∨", "||", bridge: true),
        ("⩝", "||", bridge: true),
        //
        // Primitive types ------------------------------------------
        //
        new Rep("ㅇ", "bool",   ι: true),
        new Rep("ㅅ", "float",  ι: true),
        new Rep("ᆞ", "int",    ι: true),
        new Rep("ㄹ", "string", ι: true),
        //
        // Constants & keywords -------------------------------------
        //
        ("⊨", "true"),
        ("⊭", "false"),
        ("⌢", "new"),
        ("∙", "var"),
        ("∅", "null"),
        ("┈", "void"),
        //
        // Identifiers ----------------------------------------------
        //
        ("𝑎", "Action"),
        ("𝑓", "Func"),
        //
        ("⺵", "Dictionary"),
        ("⺅", "HashSet"),
        ("⺀", "List"),
        //
        ("⩱", "Append"),
        ("∋", "Contains"),
        ("⋺", "ContainsKey"),
        ("ƪ", "Validate"),
        //
        // Idioms ---------------------------------------------------
        //
        ("⎚", "() =>", bridge: true),
        ("⠇", ".Count"),
        ("❙", ".Length"),
        ("🝠", ".ToString()"),  // 🜙 ୨
        ("৴", ".ToArray()"),   // ৴  ୪ 🝠
        ("【", "(this,"),
        ("⍥", "public void"),
        ("◑", "public bool"),
        //
        // NUnit ----------------------------------------------------
        //
        ("؟", "[Test] public void"),
        ("⼊", "[SetUp] public void"),
        ("⽌", "[TearDown] public void"),
        //
        // Unity ====================================================
        //
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
        //
        // Active Logic =============================================
        //
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
