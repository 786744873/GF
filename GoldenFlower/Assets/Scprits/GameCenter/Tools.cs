/** 
 *Copyright(C) 2017 by YX  
 *FileName:     Tools.cs 
 *Author:       lizhixing 
 *Version:      2.0 
 *UnityVersion：5.6.0f3 
 *Date:         2017-12-05 
 *Description:    工具类
 *History: 
*/
using LitJson;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public static class Tools
{
    #region Json
    public static string ToJson<T>(T data) where T : Data
    {
        return JsonMapper.ToJson(data);
    }

    public static T ToObject<T>(string jsonStr) where T : Data
    {
        return JsonMapper.ToObject<T>(jsonStr);
    }
    #endregion

    #region   //序列化 反序列化
    public static void Serialize<T>(T data) where T : Data
    {
        string jsonStr = ToJson(data);
        string path = string.Format("{0}/{1}.dat", Config.jsonPath, typeof(T).Name);
        FileStream fileStream = new FileStream(path, FileMode.Create);
        BinaryFormatter b = new BinaryFormatter();
        b.Serialize(fileStream, jsonStr);
        fileStream.Close();
        fileStream.Dispose();
    }

    public static T DeSerialize<T>() where T : Data
    {
        string path = string.Format("{0}/{1}.dat", Config.jsonPath, typeof(T).Name);
        FileStream fileStream = new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.Read);
        BinaryFormatter b = new BinaryFormatter();
        string jsonStr = b.Deserialize(fileStream).ToString();
        T data = ToObject<T>(jsonStr);
        fileStream.Close();
        fileStream.Dispose();
        return data;
    }
    #endregion
}
