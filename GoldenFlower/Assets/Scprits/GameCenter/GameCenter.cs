/** 
 *Copyright(C) 2017 by DefaultCompany  
 *FileName:     GameCenter.cs 
 *Author:       lizhixing 
 *Version:      2.0 
 *UnityVersion：5.6.0f3 
 *Date:         2017-12-01 
 *Description:    
 *History: 
*/ 
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LitJson;
using System;
using UnityEngine.Events;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public class GameCenter : MonoBehaviour
{
    private string _httpHead;
    public static string httpHead
    {
        get
        {
            if(Application.platform == RuntimePlatform.IPhonePlayer)
            {
                GetInstance()._httpHead = "file://";
            }else
            {
                GetInstance()._httpHead = "file:///";
            }
            return GetInstance()._httpHead;
        }
    }

    private static GameCenter _instance;
    public static GameCenter GetInstance()
    {
        if(_instance == null)
        {
            _instance = GameObject.FindObjectOfType<GameCenter>();
            if (_instance == null)
            {
                GameObject go = new GameObject(typeof(GameCenter).Name);
                _instance = go.AddComponent<GameCenter>();
            }
        }
        return _instance;
    }

    [RuntimeInitializeOnLoadMethod]
    static void GStart()
    {
        DontDestroyOnLoad(GameCenter.GetInstance());

        SceneManager sceneManager = SceneManager.GetInstance();
        sceneManager.transform.SetParent(GameCenter.GetInstance().transform);

    }

    public class Person : Data
    {
        public string name;
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            //StartCoroutine(LoadJson<Person>(person =>
            //{
            //    Debug.Log(person.name);
            //}));
        }
    }


    #region   //加载资源
    public static IEnumerator LoadJson<T> (UnityAction<T> LoadBackCall) where T : Data
    {
        string localPath = string.Format("{0}/{1}.txt", Config.jsonPath, typeof(T).Name);
        if (File.Exists(localPath))   //先加载本地
        {
            T data = DeSerialize<T>();
            if (LoadBackCall != null)
            {
                LoadBackCall(data);
            }
            yield break;
        }

        string url = httpHead + localPath;
        WWW www = new WWW(url);
        yield return www;
        if(string.IsNullOrEmpty(www.error))
        {
            try
            {
                T data = ToObject<T>(www.text);
                Serialize(data);
                LoadBackCall(data);
            }catch(Exception ex)
            {
                Debug.LogError(ex);
            }
        }
        else
        {
            Debug.LogError(www.error);
        }
    }

    #endregion

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

    #region
    #endregion

    #region
    #endregion

    #region
    #endregion

}
