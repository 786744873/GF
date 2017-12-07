/** 
 *Copyright(C) 2017 by YX  
 *FileName:     GamePlaySceneController.cs 
 *Author:       chenyongjun 
 *Version:      2.0 
 *UnityVersion：5.6.0f3 
 *Date:         2017-12-05 
 *Description:  打牌UI场景  
 *History: 
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GFPlayUISceneController : SceneController
{
    public Transform uiroot;   //这里先这样写，一会再改
    [SerializeField]
    private GFPlayerUIManager gfPlayerUIManager;
    /// <summary>
    /// 玩家prefab
    /// </summary>
    public GameObject playerPrefab;
    /// <summary>
    /// 生成位置
    /// </summary>
    public Transform[] transforms;
    public override SceneType sceneType
    {
        get
        {
            return SceneType.GFPlayUI;
        }
    }
    protected override void OnStart()
    {
        gfPlayerUIManager.Init();
        LoadPlayers();
    }

    void LoadPlayers()
    {
        for (int i = 0; i < 8; i++)
        {
            GameObject go = Instantiate(playerPrefab, uiroot);
            GFPlayerUI playerInfo = go.GetComponent<GFPlayerUI>();
            playerInfo.tempID = gfPlayerUIManager.GetMaxId() + 1;
            playerInfo.player_name = string.Format("玩家{0}", i + 1);
            playerInfo.count_jb = i * 100;
            playerInfo.head_img = string.Format("headimg_{0}", (i + 1));
            UILabel[] labItems = go.GetComponentsInChildren<UILabel>();
            for (int j = 0; j < labItems.Length; j++)
            {
                //昵称
                if (labItems[j].tag == "GFPlayerUI_Labname")
                {
                    labItems[j].text = playerInfo.player_name;
                }
                //金币
                if (labItems[j].tag == "GFPlayerUI_Lab_gold")
                {
                    labItems[j].text = playerInfo.count_jb.ToString();
                }
            }
            //头像
            UITexture tu = go.GetComponentInChildren<UITexture>();
            Debug.Log(tu.tag);
            tu.mainTexture = Resources.Load<Texture>("Texture/HeadImg/" + playerInfo.head_img + "");

            go.transform.position = transforms[i].position;
            gfPlayerUIManager.Add(playerInfo);
        }
    }
    protected override void LDestroy()
    {

    }
}
