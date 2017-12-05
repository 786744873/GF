/** 
 *Copyright(C) 2017 by YX  
 *FileName:     MonoHelper.cs 
 *Author:       lizhixing 
 *Version:      2.0 
 *UnityVersion：5.6.0f3 
 *Date:         2017-12-05 
 *Description:    继承Mono的帮助类
 *History: 
*/
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.Events;

public class MonoHelper : MonoSingle<MonoHelper>
{
    private string _httpHead;    //区分加载协议
    public static string httpHead
    {
        get
        {
            if (Application.platform == RuntimePlatform.IPhonePlayer)
            {
                GetInstance()._httpHead = "file://";
            }
            else
            {
                GetInstance()._httpHead = "file:///";
            }
            return GetInstance()._httpHead;
        }
    }

    protected override void LStart()
    {
    }


    #region   //加载资源
    public static IEnumerator LoadJson<T>(UnityAction<T> LoadBackCall) where T : Data
    {
        string localPath = string.Format("{0}/{1}.txt", Config.jsonPath, typeof(T).Name);
        if (File.Exists(localPath))   //先加载本地
        {
            T data = Tools.DeSerialize<T>();
            if (LoadBackCall != null)
            {
                LoadBackCall(data);
            }
            yield break;
        }

        string url = httpHead + localPath;
        WWW www = new WWW(url);
        yield return www;
        if (string.IsNullOrEmpty(www.error))
        {
            try
            {
                T data = Tools.ToObject<T>(www.text);
                Tools.Serialize(data);
                LoadBackCall(data);
            }
            catch (Exception ex)
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

}
