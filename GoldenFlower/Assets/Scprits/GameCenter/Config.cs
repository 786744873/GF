/** 
 *Copyright(C) 2017 by DefaultCompany  
 *FileName:     Config.cs 
 *Author:       lizhixing 
 *Version:      2.0 
 *UnityVersion：5.6.0f3 
 *Date:         2017-12-04 
 *Description:    
 *History: 
*/ 
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class Config
{
    private static Config _instance;
    public static Config Instance
    {
        get
        {
            if(_instance == null)
            {
                _instance = new Config();
            }
            return _instance;
        }
    }

    private string _dataPath;
    public static string dataPath
    {
        get
        {
            return Instance._dataPath;
        }
    }

    private URL _url;
    public static URL url
    {
        get
        {
            return Instance._url;
        }
    }

    private Config()
    {
        Debug.Log(Application.persistentDataPath);
        string userID = "UserTest";
        _dataPath = string.Format("{0}/{1}/Json", Application.persistentDataPath, userID);
        if(!Directory.Exists(_dataPath))
        {
            Directory.CreateDirectory(_dataPath);
        }

        InitURL();
    }

    private void InitURL()
    {
        string urlpath = "URL/";
         switch(GameCenter.gameStatus)
        {
            case GameStatus.Debug:
                urlpath += "URL_Debug";
                break;
            case GameStatus.OnLine:
                urlpath += "URL_OnLine";
                break;
        }
        TextAsset text = MonoHelper.LoadResources<TextAsset>(urlpath);
        if(text == null)
        {
            Debug.LogError(urlpath + "  不存在");
        }
        else
        {
            _url = Tools.ToObject<URL>(text.text);
        }
    }

}
