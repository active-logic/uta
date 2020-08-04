namespace Active.Howl.Parsing{
public class Taxonomy{

    string[] mod = {
      "public", "internal", "protected", "private", "static",
      "abstract", "const", "extern", "override", "partial",
      "readonly", "sealed", "unsafe", "virtual", "volatile",
      "explicit", "implicit" };

    string[] cat = {
      "class", "interface", "struct", "enum", "var", "delegate",
    };

    string[] flow = {
      "async", "await", "by", "if", "else", "foreach", "in", "for",
      "do", "while", "switch", "case", "break", "return", "yield",
      "try", "catch", "finally", "continue", "from", "where",
      "select", "throw", "join", "goto", "lock", "orderby"
    };

    string[] key = {
      "add", "using" , "int", "bool", "string", "float", "char",
      "into", "double", "value", "byte", "checked", "decimal",
      "global", "sbyte", "short", "uint", "ushort", "let", "new",
      "operator", "params", "this", "typeof", "default", "equals",
      "long", "object", "out", "ref", "sizeof", "ulong", "descending",
      "ascending", "dynamic", "fixed", "group", "is", "get", "set",
      "on", "remove", "stackalloc", "unchecked", "as", "base"
    };

}}
