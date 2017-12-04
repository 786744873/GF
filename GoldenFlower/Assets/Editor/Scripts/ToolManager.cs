/** 
 *Copyright(C) 2017 by DefaultCompany  
 *FileName:     ToolManager.cs 
 *Author:       lizhixing 
 *Version:      2.0 
 *UnityVersion：5.6.0f3 
 *Date:         2017-11-30 
 *Description:    编辑器管理类
 *History: 
*/ 
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using LitJson;
using System.IO;
using System.Text;
using System;

public class ToolManager
{
    [MenuItem("Tools/ReadAllCsvs")]
    static void Read()
    {
        Debug.Log(Application.dataPath);
        Debug.Log(Environment.CurrentDirectory);
    }

    public static void ReadAllCsvs()   //读取所有Csv文件
    {
        string[] files = Directory.GetFiles(ToolConfig.csvDir);
        foreach (var file in files)
        {
            ReadCsv(file);
        }
        Debug.Log("所有CSV转化成功");
    }

    private static void ReadCsv(string csvPath)
    {
        string[] allLines = File.ReadAllLines(csvPath);
        List<string> _properties = new List<string>();
        foreach (var data in allLines[0].Split(','))
        {
            _properties.Add(data);
        }

        #region   //转化成Json
        StringBuilder sb = new StringBuilder();
        JsonWriter writer = new JsonWriter(sb);
        writer.WriteArrayStart();
        for (int i = 1; i < allLines.Length; i++)
        {
            writer.WriteObjectStart();
            string[] lineDatas = allLines[i].Split(',');
            for (int j = 0; j < lineDatas.Length; j++)
            {
                writer.WritePropertyName(_properties[j]);
                writer.Write(lineDatas[j]);
            }
            writer.WriteObjectEnd();
        }
        writer.WriteArrayEnd();
        #endregion

        string csvName = Path.GetFileNameWithoutExtension(csvPath);
        string jsonPath = ToolConfig.jsonDir + "/" + csvName + ".json";
        StreamWriter sw = new StreamWriter(jsonPath);
        sw.Write(sb.ToString());
        sw.Close();
        sw.Dispose();
    }

}
