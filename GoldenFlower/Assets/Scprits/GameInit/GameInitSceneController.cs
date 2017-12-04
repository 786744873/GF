/** 
 *Copyright(C) 2017 by DefaultCompany  
 *FileName:     GameInit.cs 
 *Author:       chenyongjun 
 *Version:      2.0 
 *UnityVersion：5.6.0f3 
 *Date:         2017-12-01 
 *Description:  游戏初始化界面 用于检测版本迭代,网络连接,登录检测  
 *History: 
*/
using System;
using System.Collections;
using System.Collections.Generic;
using System.Net;
using System.Xml;
using UnityEngine;
using LitJson;
public class GameInitSceneController : SceneController
{
    public override SceneType sceneType
    {
        get
        {
            return SceneType.GameInit;
        }
    }
    protected override void OnStart()
    {
        CheckVersion();
    }
    protected override void LDestroy()
    {

    }
    /// <summary>
    /// 检查版本
    /// </summary>
    private void CheckVersion()
    {
        XmlDocument xmlDoc = new XmlDocument();
        string xmlPath = Application.dataPath + @"\Other\VersionInfo.xml";
        xmlDoc.Load(xmlPath);
        XmlNode xn = xmlDoc.SelectSingleNode("versionInfo");
        XmlNodeList xnl = xn.ChildNodes;
        string versionLocal = string.Empty;
        foreach (XmlNode xn1 in xnl)
        {
            if (xn1.Name == "gameVersion")
            {
                versionLocal = xn1.InnerText;
            }
        }
        StartCoroutine(GetWebData(versionLocal));
    }

    /// <summary>
    /// 版本比对
    /// </summary>
    /// <param name="versionLocal">本地版本号</param>
    /// <returns></returns>
    IEnumerator GetWebData(string versionLocal)
    {
        WWW www = new WWW("https://test.lightningrm.com/20171201/version.json");
        yield return www;
        if (www.isDone && www.error == null)
        {
            string versionServer = JsonMapper.ToObject<VersionModel>(www.text).version;
            if (versionServer == versionLocal)
            {
                //不需要更新

            }
            else
            {
                Debug.Log("请更新文件！本地版本号:" + versionLocal + ",服务器版本号:" + versionServer + "");
            }
        }
    }
}
