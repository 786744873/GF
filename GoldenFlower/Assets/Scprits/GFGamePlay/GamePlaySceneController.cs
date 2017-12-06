/** 
 *Copyright(C) 2017 by YX  
 *FileName:     GamePlaySceneController.cs 
 *Author:       chenyongjun 
 *Version:      2.0 
 *UnityVersion：5.6.0f3 
 *Date:         2017-12-05 
 *Description:  打牌场景  
 *History: 
*/ 
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GFGamePlaySceneController : SceneController
{

    public override SceneType sceneType
    {
        get
        {
            return SceneType.GFGamePlay;
        }
    }
    protected override void OnStart()
    {

    }
    protected override void LDestroy()
    {

    }
}
