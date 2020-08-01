using System; using UnityEngine;

namespace Active.Howl{
public class STC<T> where T: struct{

    Func<T> evaluator;
    T? cached;
    float duration, endDate;

    public STC(Func<T> φ, float expiry = 1f){
        evaluator = φ;
        duration = expiry;
    }

    public T @value{ get{
        if (cached == null)         return Eval();
        else if (Time.time > endDate) return Eval();
        else return cached.Value;
    }}

    T Eval(){
        cached = evaluator();
        endDate = Time.time + duration;
        return cached.Value;
    }

}}
