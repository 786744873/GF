/** 
 *Copyright(C) 2017 by DefaultCompany  
 *FileName:     SceneControllerSingle.cs 
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

public abstract  class SceneControllerSingle<T> : SceneController where T : SceneController
{
    public static T Instance;
    private void Start()
    {
        SceneManager.RegisterScene(this);
        Instance = this as T;
        OnStart();
    }

}
