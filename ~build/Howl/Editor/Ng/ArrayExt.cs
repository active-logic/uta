using System;

namespace Active.Howl{
public static class ArrayExt{

    public static T[] Clip<T>(this T[] self, int offset)
    => Clip(self, offset, self.Length - offset);

    public static T[] Clip<T>(this T[] self, int offset, int length){
		var ㄸ = new T[length];
		Array.Copy(self, offset, ㄸ, 0, length);
		return ㄸ;
	}

}}
