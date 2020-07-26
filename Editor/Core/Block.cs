
namespace Active.Howl{
public class Block{

    Def def;

    public static Block Enter(string x, int i, Def z){
        if(z.Enter(x, i)) return new Block(){ def = z };
        else return null;
    }

    public bool Exit(string x, int i) => def.Exit(x, i);

    public class Def{

        public string prefix, suffix;

        public static implicit operator Def((string p, string s) that)
        => new Def(){ prefix = that.p, suffix = that.s.Reverse() };

        public static implicit operator Def(string that)
        => new Def(){ prefix = that, suffix = "\n" };

        public bool Enter(string x, int i){
            foreach(var k in prefix)
                if(i >= x.Length || x[i++] != k) return false;
            return true;
        }

        public bool Exit(string x, int i){
            foreach(var k in suffix)
                if(i < 0 || x[i--] != k) return false;
            return true;
        }

    }

}}
