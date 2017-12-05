/** 
 *Copyright(C) 2017 by YX  
 *FileName:     MHeadSceneController.cs 
 *Author:       chenyongjun 
 *Version:      2.0 
 *UnityVersion：5.6.0f3 
 *Date:         2017-12-05 
 *Description:    
 *History: 
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MHeadSceneController : SceneController
{

    public override SceneType sceneType
    {
        get
        {
            return SceneType.MHead;
        }
    }
    protected override void OnStart()
    {

    }
    protected override void LDestroy()
    {

    }
}
