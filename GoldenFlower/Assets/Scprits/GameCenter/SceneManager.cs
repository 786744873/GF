/** 
 *Copyright(C) 2017 by DefaultCompany  
 *FileName:     SceneManager.cs 
 *Author:       lizhixing 
 *Version:      2.0 
 *UnityVersion：5.6.0f3 
 *Date:         2017-12-01 
 *Description:    场景管理
 *History: 
*/ 
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneManager : MonoSingle<SceneManager>
{

    private static List<Bridge> bridges = new List<Bridge>();
    private static List<SceneController> controllers = new List<SceneController>();


    public static void RegisterScene<T>(T controller) where T : SceneController    //添加场景
    {
        if(controller == null)
        {
            Debug.LogError(string.Format("添加的场景不能为空"));
            return;
        }
        T temp = controllers.Find(item=> { return item.sceneType == controller.sceneType; }) as T;
        if(temp == null)
        {
            controllers.Add(controller);
            Debug.Log(string.Format("{0} 场景加载成功", controller.sceneType));
        }
        else
        {
            Debug.LogError(string.Format("{0} 场景已经存在，无法重复加载", controller.sceneType));
        }
    }

    public static void ReleaseScene(SceneType sceneType)    // 销毁场景
    {
        SceneController controller = controllers.Find(item => { return item.sceneType == sceneType; });
        if (controller == null)
        {
            Debug.LogError(string.Format("{0} 场景不存在，无法移除", controller.sceneType));
        }
        else
        {
            controllers.Remove(controller);
            Debug.Log(string.Format("{0} 场景销毁", controller.sceneType));
        }
    }

    public static IEnumerator LoadScene(SceneType sceneType)    //异步加载场景
    {
        yield return null;
    }

    public void ReleaseBridge<T>() where T : Bridge      //  销毁
    {
        string bridgeType = typeof(T).FullName;
        Bridge bridge = bridges.Find(item => { return item.bridgeType == bridgeType; });
        if(bridge != null)
        {
            bridges.Remove(bridge);
        }
    }

    public static T GetBridge<T>() where T : Bridge     //获取桥
    {
        string bridgeType = typeof(T).FullName;
        Bridge bridge = bridges.Find(item => { return item.bridgeType == bridgeType; });
        return bridge as T;
    }

    public static void RegisterBridge<T>(T bridge) where T : Bridge     //注册
    {
        if (bridge == null)
        {
            return;
        }

        Bridge temp = bridges.Find(item => { return item.bridgeType == bridge.bridgeType; });
        if (temp != null)
        {
            Debug.LogError(string.Format("{0} 桥已经存在, 无法添加", bridge.bridgeType));
        }
        else
        {
            bridges.Add(bridge);
        }
    }

}
