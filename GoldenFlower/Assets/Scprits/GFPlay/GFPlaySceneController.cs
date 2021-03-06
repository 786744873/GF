/** 
 *Copyright(C) 2017 by YX  
 *FileName:     GFPlaySceneController.cs 
 *Author:       lizhixing 
 *Version:      2.0 
 *UnityVersion：5.6.0f3 
 *Date:         2017-12-06 
 *Description:    
 *History: 
*/ 
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GFPlaySceneController : SceneControllerSingle<GFPlaySceneController>
{
    [SerializeField]
    private GFPlayerManager playerManager;

    public override SceneType sceneType
    {
        get
        {
            return SceneType.Non;
        }
    }

    protected override void OnStart()
    {
        playerManager.Init();
        StartCoroutine(Load());
    }

    IEnumerator Load()
    {
        yield return null;
    }
}
