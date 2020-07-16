using ㅅ = System.Single;  using ㅇ = System.Boolean;
using ᆞ = System.Int32;   using ㄹ = System.String;

namespace Active.Howl{
public class Block{

    Def def;

    public static Block Enter(ㄹ x, ᆞ i, Def z){
        if(z.Enter(x, i)) return new Block(){ def = z };
        else return null;
    }

    public ㅇ Exit(ㄹ x, ᆞ i) => def.Exit(x, i);

    public class Def{

        public ㄹ prefix, suffix;

        public static implicit operator Def((ㄹ p, ㄹ s) that)
        => new Def(){ prefix = that.p, suffix = that.s.Reverse() };

        public static implicit operator Def(ㄹ that)
        => new Def(){ prefix = that, suffix = "\n" };

        public ㅇ Enter(ㄹ x, ᆞ i){
            foreach(var k in prefix)
                if(i >= x.Length || x[i++] != k) return false;
            return true;
        }

        public ㅇ Exit(ㄹ x, ᆞ i){
            foreach(var k in suffix)
                if(i < 0 || x[i--] != k) return false;
            return true;
        }

    }

}}
