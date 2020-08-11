using System; using static UnityEngine.Time;

namespace Active.Howl{
public class Cache<T> where T : struct{

    T? ω;  Func<T> evaluator;  float duration, end;

    public Cache(Func<T> φ, float expiry = 1f){
        evaluator = φ;
        duration = expiry;
    }

    public static implicit operator T(Cache<T> x) => time > x.end || x.ω == null ? +x : x.ω.Value;

    public static T operator +(Cache<T> x){
        x.end = time + x.duration;
        return (x.ω = x.evaluator()).Value;
    }

}}
