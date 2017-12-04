/** 
 *Copyright(C) 2017 by YX  
 *FileName:     MainSceneController.cs 
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

public class MainSceneController : SceneControllerSingle<MainSceneController>
{
    [SerializeField]
    private UISprite _bg;
    [SerializeField]
    private UISprite _person;

    public override SceneType sceneType
    {
        get
        {
            return SceneType.Non;
        }
    }

    protected override void OnStart()
    {
    }
}
