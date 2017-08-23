using UnityEngine;

public static class SerializeHelper
{
    //扩展
    public static string ToJson<T>(this T t) where T : class
    {
    #if  UNITY_EDITOR
        return JsonUtility.ToJson(t, true);
    #endif
        return JsonUtility.ToJson(t);
    }
    public static T FromJson<T>(this string jsonStr) where T : class
    {
        return JsonUtility.FromJson<T>(jsonStr);
    }
    public static byte[] ToProtoBuf<T>(this T t) where T : class
    {
        using (System.IO.MemoryStream stream=new System.IO.MemoryStream())
        {
            ProtoBuf.Serializer.Serialize<T>(stream,t);
            return stream.ToArray();
        }
    }
    public static T FromProtoBuf<T>(this byte[] bytes) where T : class
    {
        if(bytes==null || bytes.Length==0)
            throw new System.ArgumentNullException("bytes");
        return ProtoBuf.Serializer.Deserialize<T>(new System.IO.MemoryStream(bytes));
    }


    //外用 
    public static void SaveJson<T>(T t, string path) where T : class
    {
        System.IO.File.WriteAllText(path,t.ToJson());
    }
    public static T LoadJson<T>(string path) where T : class
    {
        return System.IO.File.ReadAllText(path).FromJson<T>();
    }

    public static void SaveProtoBuf<T>(T t, string path) where T : class
    {
        System.IO.File.WriteAllBytes(path,t.ToProtoBuf());
    }

    public static T LoadProtoBuf<T>(string path) where T : class
    {
        return System.IO.File.ReadAllBytes(path).FromProtoBuf<T>();
    }
}
