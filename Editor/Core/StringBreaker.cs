using System.Collections.Generic;
using System.Text;

namespace Active.Howl{
public static class StringBreaker{

    public static bool DenotesBlock(this string x, params Block.Def[] defs){
        foreach(var k in defs)
            if(x.StartsWith(k.prefix)) return true;
        return false;
    }

    public static string[] Break(this string x, params Block.Def[] defs){
        var ㄸ = new List<string>();
        var buffer = new StringBuilder();
        Block block = null;
        for(int i = 0; i < x.Length; i++){
            if(Enter(x, i, defs, ref block)){
                Flush(buffer, ㄸ);
                buffer.Append(x[i]);
            }else if(block?.Exit(x, i) ?? false){
                buffer.Append(x[i]);
                Flush(buffer, ㄸ);
                block = null;
            }
            else buffer.Append(x[i]);
        }
        Flush(buffer, ㄸ);
        return ㄸ.ToArray();
    }

    public static bool Enter(string x, int i, Block.Def[] dfs, ref Block bk){
        if(bk != null) return false;
        foreach(var k in dfs){
            var z = Block.Enter(x, i, k);
            if(z != null){
                bk = z; return true;
            }
        }
        return false;
    }

    public static void Flush(StringBuilder buf, List<string> ㄸ){
        if(buf.Length == 0) return;
        ㄸ.Add(buf.ToString());
        buf.Clear();
    }

}}
