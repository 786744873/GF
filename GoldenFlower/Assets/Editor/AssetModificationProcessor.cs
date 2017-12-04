/** 
 *Copyright(C) 2017 by DefaultCompany  
 *FileName:     AssetModificationProcessor.cs 
 *Author:       lizhixing 
 *Version:      1.0 
 *UnityVersion：5.6.0f3 
 *Date:         2017-09-13 
 *Description:    
 *History: 
*/ 
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEngine;

namespace LGame
{
    public class AssetModificationProcessor : UnityEditor.AssetModificationProcessor
    {
        public static void OnWillCreateAsset(string newFileMeta)
        {
            ScriptStandand(newFileMeta);
        }

        private static void ScriptStandand(string scriptPath)
        {
            string newFilePath = scriptPath.Replace(".meta", "");
            if(Path.GetExtension(newFilePath) != ".cs")
            {
                return;
            }
            //注意，Application.datapath会根据使用平台不同而不同
            string realPath = Application.dataPath.Replace("Assets", "") + newFilePath;
            string scriptContent = File.ReadAllText(realPath);

            //这里实现自定义的一些规则
            scriptContent = scriptContent.Replace("#SCRIPTFULLNAME#", Path.GetFileName(newFilePath));
            scriptContent = scriptContent.Replace("#COMPANY#", PlayerSettings.companyName);
            scriptContent = scriptContent.Replace("#VERSION#", "2.0");
            scriptContent = scriptContent.Replace("#UNITYVERSION#", Application.unityVersion);
            scriptContent = scriptContent.Replace("#DATE#", System.DateTime.Now.ToString("yyyy-MM-dd"));
            File.WriteAllText(realPath, scriptContent);
        }

    }
}
