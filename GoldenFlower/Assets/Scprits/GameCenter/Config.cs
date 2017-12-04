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

    private string _jsonPath;
    public static string jsonPath
    {
        get
        {
            return Instance._jsonPath;
        }
    }

    private Config()
    {
        Debug.Log(Application.persistentDataPath);
        string userID = "UserTest";
        _jsonPath = string.Format("{0}/{1}/Json", Application.persistentDataPath, userID);
        if(!Directory.Exists(_jsonPath))
        {
            Directory.CreateDirectory(_jsonPath);
        }
    }

}
