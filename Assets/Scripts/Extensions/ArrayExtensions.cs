using System;

public static class ArrayExtensions
{
    public static T Random<T>(this T[] array)
    {
        return array[UnityEngine.Random.Range(0, array.Length)];
    }
    
    public static T[] Add<T>(this T[] target, T item)
    {
        if (target == null)
        {
            throw new ArgumentException();
        }
        
        T[] result = new T[target.Length + 1];
        target.CopyTo(result, 0);
        result[target.Length] = item;
        target = result;
        return result;
    }
}