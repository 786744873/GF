/** 
 *Copyright(C) 2017 by DefaultCompany  
 *FileName:     ToolConfig.cs 
 *Author:       lizhixing 
 *Version:      2.0 
 *UnityVersion：5.6.0f3 
 *Date:         2017-11-30 
 *Description:    工具类配置
 *History: 
*/ 
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class ToolConfig
{
    private static ToolConfig _instance;
    protected static ToolConfig Instance
    {
        get
        {
            if(_instance == null)
            {
                _instance = new ToolConfig();
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

    private string _csvDir;
    public static string csvDir
    {
        get
        {
            return Instance._csvDir;
        }
    }

    private string _jsonDir;
    public static string jsonDir
    {
        get
        {
            return Instance._jsonDir;
        }
    }

    private ToolConfig()
    {
        _dataPath = Application.dataPath;

        _csvDir = _dataPath.Replace("Assets", "CSV");
        _jsonDir = _dataPath.Replace("Assets", "Data");

        if(!Directory.Exists(_csvDir))
        {
            Directory.CreateDirectory(_csvDir);
        }

        if (!Directory.Exists(_jsonDir))
        {
            Directory.CreateDirectory(_jsonDir);
        }

    }



}
