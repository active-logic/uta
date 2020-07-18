namespace Active.Howl{
public partial class Map{

    public static Map @default = new Rep[]{
        // Unity
        ("《", "gameObject.AddComponent<"), ("》", ">()"),
        ("⧼", "GetComponent<"), ("⧽", ">()"),
        // Modifiers
        ("⁺", "override"),
        ("ᵛ", "virtual"),
        ("⿵", "abstract"),
        ("ｦ", "partial"),
        // NUnit
        ("؟", "[Test] public void"),
        ("ഗ", "[SetUp] public void"),
        ("൰", "[TearDown] public void"),
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
        //
        ("⨕", "operator"),
        ("⒠", " explicit"),
        ("ⁱ", " implicit"),
        ("♖", "using"),
        // Operators
        ("☰", "==", bridge: true),
        ("≠", "!=", bridge: true),
        ("∧", "&&", bridge: true), // ⍲ ∧
        ("∨", "||", bridge: true), // ⍱ ∨
        // Types
        ("ㅇ", "bool"),
        ("ㅅ", "float"),
        ("ᆞ", "int"),
        ("ㄹ", "string"),
        // Constants
        ("⊨", "true"),
        ("⊭", "false"),
        // Control flow
        ("⤴", "if"),   // ⑀
        ("⤵", "else"), // ⑁
        //
        ("∀", "foreach"),
        ("⍦", "for"),
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
        ("◞", "throw"),
        ("╭", "try"),
        ("❘", "catch"),
        ("╰", "finally"),
        // Misc
        (" ↣", "() =>", bridge: true),
        (" ↣", "()=>", bridge: true),
        ("→", "=>", bridge: true),
        ("⌢", "new"),
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
