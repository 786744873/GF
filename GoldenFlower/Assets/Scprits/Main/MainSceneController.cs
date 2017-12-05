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
using UnityEngine.SceneManagement;

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
        StartCoroutine(LoadHead());
        StartCoroutine(LoadRankList());
        StartCoroutine(LoadGameModel());
        StartCoroutine(LoadMenuTool());
    }
    IEnumerator LoadHead()
    {
        yield return StartCoroutine(SceneManager.LoadSceneAsync(SceneType.MHead, LoadSceneMode.Additive));
    }
    IEnumerator LoadRankList()
    {
        yield return StartCoroutine(SceneManager.LoadSceneAsync(SceneType.MRankList, LoadSceneMode.Additive));
    }
    IEnumerator LoadGameModel()
    {
        yield return StartCoroutine(SceneManager.LoadSceneAsync(SceneType.MGameModel, LoadSceneMode.Additive));
    }
    IEnumerator LoadMenuTool()
    {
        yield return StartCoroutine(SceneManager.LoadSceneAsync(SceneType.MMenuTool, LoadSceneMode.Additive));
    }
}
