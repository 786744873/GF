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
using DG.Tweening;
public class GFPlayUISceneController : SceneController
{
    /// <summary>
    /// 卡牌的prefab
    /// </summary>
    public GameObject cardPrefab;
    /// <summary>
    /// 卡牌的起始位置
    /// </summary>
    public Transform cardStarPostion;
    /// <summary>
    /// 卡牌的位置(最终位置)
    /// </summary>
    public Transform[] cardsTransform;
    /// <summary>
    /// 是否开始发牌
    /// </summary>
    public bool isStar = false;
    /// <summary>
    /// 等待其他玩家准备
    /// </summary>
    public UILabel labWait;
    /// <summary>
    /// 是否跟注
    /// </summary>
    public UIToggle togFollwer;
    /// <summary>
    /// 比牌按钮
    /// </summary>
    public UIButton btnMatch;
    /// <summary>
    /// 弃牌按钮
    /// </summary>
    public UIButton btnLoseCard;
    /// <summary>
    /// 看牌按钮
    /// </summary>
    public UIButton btnSeeCard;
    /// <summary>
    /// 加注按钮
    /// </summary>
    public UIButton btnAddMonty;
    /// <summary>
    /// 准备按钮
    /// </summary>
    public UIButton btnReady;
    /// <summary>
    /// 父级容器
    /// </summary>
    public Transform uiroot;
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
    /// <summary>
    /// 本地玩家（自己）
    /// </summary>
    public static GFPlayerUI localPlayer;
    /// <summary>
    /// 本地玩家（自己） ui控制
    /// </summary>
    public GameObject localPlayerGo;
    /// <summary>
    /// 本局的所有玩家
    /// </summary>
    public List<GFPlayerUI> players;

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
        BtnInit();
        LabInit(false);
        //初始化一个本地玩家
        localPlayer = new GFPlayerUI();
        LocalPlayerInit();
    }
    /// <summary>
    /// 加载玩家
    /// </summary>
    void LoadPlayers()
    {
        for (int i = 0; i < transforms.Length; i++)
        {
            GameObject go = Instantiate(playerPrefab, uiroot);
            GFPlayerUI playerInfo = go.GetComponent<GFPlayerUI>();
            playerInfo.tempID = gfPlayerUIManager.GetMaxId() + 1;
            playerInfo.player_name = string.Format("玩家{0}", i + 1);
            playerInfo.count_jb = i * 100;
            playerInfo.head_img = string.Format("headimg_{0}", (i + 1));
            playerInfo.playerStatus = PlayerStatusEnum.未准备;
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
            tu.mainTexture = Resources.Load<Texture>("Texture/HeadImg/" + playerInfo.head_img + "");
            go.transform.position = transforms[i].position;
            gfPlayerUIManager.Add(playerInfo);
        }
    }

    /// <summary>
    /// 初始化本地玩家（加入房间后调用）
    /// </summary>
    public void LocalPlayerInit()
    {
        localPlayer.tempID = gfPlayerUIManager.GetMaxId() + 1;
        localPlayer.player_name = "本地玩家";
        localPlayer.count_jb = 11111;
        localPlayer.head_img = "localimg";
        localPlayer.playerStatus = PlayerStatusEnum.未准备;
        gfPlayerUIManager.Add(localPlayer);

        GameObject.Find("LocalPlayerHeadImg").GetComponent<UITexture>().mainTexture = Resources.Load<Texture>("Texture/HeadImg/" + localPlayer.head_img + "");
        GameObject.Find("LocalPlayerName").GetComponent<UILabel>().text = localPlayer.player_name;
        GameObject.Find("LocalGoldcount").GetComponent<UILabel>().text = localPlayer.count_jb.ToString();
    }
    /// <summary>
    /// 按钮初始化
    /// </summary>
    void BtnInit()
    {
        btnReady.onClick.Add(new EventDelegate(BtnReady_Click));
        btnAddMonty.onClick.Add(new EventDelegate(BtnAddMonty_Click));
        btnSeeCard.onClick.Add(new EventDelegate(BtnSeeCard_Click));
        btnLoseCard.onClick.Add(new EventDelegate(BtnLoseCard_Click));
        btnMatch.onClick.Add(new EventDelegate(BtnMatch_Click));
        togFollwer.onChange.Add(new EventDelegate(TogFollwer_OnChange));
        BtnSetActive(false);
    }
    /// <summary>
    /// 按钮禁用和启用
    /// </summary>
    /// <param name="flag"></param>
    void BtnSetActive(bool flag)
    {
        btnAddMonty.gameObject.SetActive(flag);
        btnSeeCard.gameObject.SetActive(flag);
        btnLoseCard.gameObject.SetActive(flag);
        btnMatch.gameObject.SetActive(flag);
        togFollwer.gameObject.SetActive(flag);
    }
    /// <summary>
    /// Lab初始化
    /// </summary>
    void LabInit(bool flag)
    {
        labWait.gameObject.SetActive(flag);
    }
    /// <summary>
    /// 准备按钮点击事件
    /// </summary>
    void BtnReady_Click()
    {
        btnReady.gameObject.SetActive(false);
        labWait.gameObject.SetActive(true);
        //模拟所有玩家准备      
        for (int i = 0; i < players.Count; i++)
        {
            players[i].playerStatus = PlayerStatusEnum.已准备;
        }
        GameObject[] goList = GameObject.FindGameObjectsWithTag("players");
        for (int i = 0; i < goList.Length; i++)
        {
            GameObject item = goList[i];
            UILabel[] tures = item.GetComponentsInChildren<UILabel>();
            for (int j = 0; j < tures.Length; j++)
            {
                if (tures[j].tag == "GFPlayerUI_isnosee")
                {
                    tures[j].text = "已准备";
                }
            }
        }

    }
    /// <summary>
    /// 加注按钮点击事件
    /// </summary>
    void BtnAddMonty_Click()
    {

    }
    /// <summary>
    /// 看牌按钮点击事件
    /// </summary>
    void BtnSeeCard_Click()
    {

    }
    /// <summary>
    /// 弃牌按钮点击事件
    /// </summary>
    void BtnLoseCard_Click()
    {

    }
    /// <summary>
    /// 比牌按钮点击事件
    /// </summary>
    void BtnMatch_Click()
    {

    }
    /// <summary>
    /// 跟注选中改变事件
    /// </summary>
    void TogFollwer_OnChange()
    {

    }

    private void Update()
    {
        players = gfPlayerUIManager.Players;
        //所有玩家准备就绪
        if (!isStar)
        {
            if (players.FindAll(d => d.playerStatus == PlayerStatusEnum.已准备).Count == 8)
            {
                LabInit(false);
                isStar = true;
                StartCoroutine(Send_Card());
            }
        }
    }
    /// <summary>
    /// 发牌
    /// </summary>
    IEnumerator Send_Card()
    {
        BtnSetActive(true);
        for (int i = 0; i < cardsTransform.Length; i++)
        {
            GameObject go = Instantiate(cardPrefab, uiroot);//创建预制体
            go.transform.DOMove(cardsTransform[i].transform.position, 0.5f);
            //go.transform.position = cardsTransform[i].transform.position;
            yield return 0;
        }
    }
    protected override void LDestroy()
    {

    }
}
