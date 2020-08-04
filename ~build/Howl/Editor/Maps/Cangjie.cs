namespace Active.Howl{
public static class Cangjie{

    // NOTE: These definitions break syntax coloring
    public static Map types = new Rep[]{
        ("惍","public class"),       // pc1
        ("勾","public interface"),   // pi1
        ("㥾","public struct"),      // pst1
        ("金", "class"),             // c1
        ("冖", "interface"),         // in1
        ("尸", "struct")             // s1
    };

    public static Map modifiers = new Rep[]{
        ("切 ","public static "),    // ps1
        ("愜 ","protected static "), // ps2
        ("户 ","internal static "),  // is
        ("日", "abstract"),          // a1
        ("心", "public"),            // p1
        ("㣺", "protected"),         // p2
        ("丶", "internal"),          // i2
        ("尸", "static")             // s1
    };

    public static Map operators = new Rep[]{
        ("人", "operator"),          // o1
        ("戈", "implicit"),          // i1
        ("水", "explicit")           // e1
    };

}}
