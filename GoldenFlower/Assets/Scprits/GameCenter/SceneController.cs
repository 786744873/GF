/** 
 *Copyright(C) 2017 by DefaultCompany  
 *FileName:     SceneController.cs 
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

public abstract class SceneController : MonoBehaviour
{
    public abstract SceneType sceneType { get; }

    private void Start()
    {
        SceneManager.RegisterScene(this);
        OnStart();  
    }

    protected virtual void OnStart(){  }

    private void OnDestroy()
    {
        LDestroy();
        SceneManager.ReleaseScene(sceneType);
    }

    protected virtual void LDestroy() { }

}
