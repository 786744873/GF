/** 
 *Copyright(C) 2017 by DefaultCompany  
 *FileName:     MRankListSceneController.cs 
 *Author:       chenyongjun 
 *Version:      2.0 
 *UnityVersion：5.6.0f3 
 *Date:         2017-12-04 
 *Description:  主页面排行榜信息初始化
 *History: 
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MRankListSceneController : SceneController
{
    /// <summary>
    /// 排行榜人物信息预制体
    /// </summary>
    [SerializeField]
    public GameObject rankInfoPrefab;
    /// <summary>
    /// 前四名的spirte
    /// </summary>
    [SerializeField]
    public UISprite[] sprites;
    /// <summary>
    /// 创建预制体的容器
    /// </summary>
    public UIGrid grid;
    public override SceneType sceneType
    {
        get
        {
            return SceneType.MRankList;
        }
    }
    protected override void OnStart()
    {
        LoadRankList();
    }
    protected override void LDestroy()
    {

    }
    private void LoadRankList()
    {
        for (int i = 0; i < 10; i++)
        {
            UISprite[] list = rankInfoPrefab.GetComponentsInChildren<UISprite>();
            for (int j = 0; j < list.Length; j++)
            {
                if (list[j].tag == "img_flag")
                {
                    if (i < 4)
                        list[j].spriteName = sprites[i].spriteName;
                    else
                        list[j].spriteName = null;
                }
            }
            GameObject itemGo = NGUITools.AddChild(grid.gameObject, rankInfoPrefab);
            grid.AddChild(itemGo.transform);
        }
    }
}
