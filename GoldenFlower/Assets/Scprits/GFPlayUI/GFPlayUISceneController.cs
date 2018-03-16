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
    /// 被比玩家vs时头像位置
    /// </summary>
    public Transform match_img_vs_position;
    /// <summary>
    /// 本地玩家vs时头像位置
    /// </summary>
    public Transform local_img_vs_position;
    /// <summary>
    /// vs图标的位置
    /// </summary>
    public Transform bg_vs_position;
    /// <summary>
    /// 卡牌的prefab
    /// </summary>
    public GameObject cardPrefab;
    /// <summary>
    /// 看牌后的卡牌
    /// </summary>
    public GameObject card_lightPrefab;
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
    /// <summary>
    /// 是否开启比牌
    /// </summary>
    public bool isMatch = false;
    public GameObject gameObj_vs;
    /// <summary>
    /// 玩家手中的牌集合
    /// </summary>
    private static List<PlayerLinkCard> player_card = new List<PlayerLinkCard>();
    private static List<CardInfo> cards_send;
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
        gameObj_vs= GameObject.Find("BG_VS");
        gameObj_vs.SetActive(false);
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
            UIButton btn = go.GetComponentInChildren<UIButton>();
            UIEventListener.Get(btn.gameObject).onClick += BtnHeadimg_Click;
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
        btnSeeCard.isEnabled = false;
        //销毁未看牌的预制体
        GameObject[] goList = GameObject.FindGameObjectsWithTag("card_noSee");
        for (int i = 0; i < goList.Length; i++)
        {
            Destroy(goList[i]);
        }

        GFPlayerUI info = players.Find(d => d.player_name == "本地玩家");
        PlayerLinkCard player_link_card = player_card.Find(d => d.tempId == info.tempID);
        int flag = 0;
        foreach (var item in player_link_card.cards)
        {
            //在预定的位置生成3张牌
            GameObject go = Instantiate(card_lightPrefab, uiroot);//创建预制体
            UITexture[] tureList = go.GetComponentsInChildren<UITexture>();
            for (int j = 0; j < tureList.Length; j++)
            {
                if (tureList[j].name == "Card_color")
                {
                    if (item.cardColor == CardColorEnum.红桃)
                    {
                        tureList[j].mainTexture = Resources.Load<Texture>("Texture/Card_light/signHeart");
                    }
                    else if (item.cardColor == CardColorEnum.黑桃)
                    {
                        tureList[j].mainTexture = Resources.Load<Texture>("Texture/Card_light/signSpade");
                    }
                    else if (item.cardColor == CardColorEnum.梅花)
                    {
                        tureList[j].mainTexture = Resources.Load<Texture>("Texture/Card_light/signClub");
                    }
                    else
                    {
                        tureList[j].mainTexture = Resources.Load<Texture>("Texture/Card_light/signDiamond");
                    }
                }
                if (tureList[j].name == "Card_number")
                {
                    if (item.cardColor == CardColorEnum.红桃 || item.cardColor == CardColorEnum.方块)
                    {
                        switch (item.cardNumber)
                        {
                            case CardNumberEnum.一:
                                tureList[j].mainTexture = Resources.Load<Texture>("Texture/Card_light/red_14");
                                break;
                            case CardNumberEnum.二:
                                tureList[j].mainTexture = Resources.Load<Texture>("Texture/Card_light/red_2");
                                break;
                            case CardNumberEnum.三:
                                tureList[j].mainTexture = Resources.Load<Texture>("Texture/Card_light/red_3");
                                break;
                            case CardNumberEnum.四:
                                tureList[j].mainTexture = Resources.Load<Texture>("Texture/Card_light/red_4");
                                break;
                            case CardNumberEnum.五:
                                tureList[j].mainTexture = Resources.Load<Texture>("Texture/Card_light/red_5");
                                break;
                            case CardNumberEnum.六:
                                tureList[j].mainTexture = Resources.Load<Texture>("Texture/Card_light/red_6");
                                break;
                            case CardNumberEnum.七:
                                tureList[j].mainTexture = Resources.Load<Texture>("Texture/Card_light/red_7");
                                break;
                            case CardNumberEnum.八:
                                tureList[j].mainTexture = Resources.Load<Texture>("Texture/Card_light/red_8");
                                break;
                            case CardNumberEnum.九:
                                tureList[j].mainTexture = Resources.Load<Texture>("Texture/Card_light/red_9");
                                break;
                            case CardNumberEnum.十:
                                tureList[j].mainTexture = Resources.Load<Texture>("Texture/Card_light/red_10");
                                break;
                            case CardNumberEnum.十一:
                                tureList[j].mainTexture = Resources.Load<Texture>("Texture/Card_light/red_11");
                                break;
                            case CardNumberEnum.十二:
                                tureList[j].mainTexture = Resources.Load<Texture>("Texture/Card_light/red_12");
                                break;
                            case CardNumberEnum.十三:
                                tureList[j].mainTexture = Resources.Load<Texture>("Texture/Card_light/red_13");
                                break;
                        }
                    }
                    else
                    {
                        switch (item.cardNumber)
                        {
                            case CardNumberEnum.一:
                                tureList[j].mainTexture = Resources.Load<Texture>("Texture/Card_light/black_14");
                                break;
                            case CardNumberEnum.二:
                                tureList[j].mainTexture = Resources.Load<Texture>("Texture/Card_light/black_2");
                                break;
                            case CardNumberEnum.三:
                                tureList[j].mainTexture = Resources.Load<Texture>("Texture/Card_light/black_3");
                                break;
                            case CardNumberEnum.四:
                                tureList[j].mainTexture = Resources.Load<Texture>("Texture/Card_light/black_4");
                                break;
                            case CardNumberEnum.五:
                                tureList[j].mainTexture = Resources.Load<Texture>("Texture/Card_light/black_5");
                                break;
                            case CardNumberEnum.六:
                                tureList[j].mainTexture = Resources.Load<Texture>("Texture/Card_light/black_6");
                                break;
                            case CardNumberEnum.七:
                                tureList[j].mainTexture = Resources.Load<Texture>("Texture/Card_light/black_7");
                                break;
                            case CardNumberEnum.八:
                                tureList[j].mainTexture = Resources.Load<Texture>("Texture/Card_light/black_8");
                                break;
                            case CardNumberEnum.九:
                                tureList[j].mainTexture = Resources.Load<Texture>("Texture/Card_light/black_9");
                                break;
                            case CardNumberEnum.十:
                                tureList[j].mainTexture = Resources.Load<Texture>("Texture/Card_light/black_10");
                                break;
                            case CardNumberEnum.十一:
                                tureList[j].mainTexture = Resources.Load<Texture>("Texture/Card_light/black_11");
                                break;
                            case CardNumberEnum.十二:
                                tureList[j].mainTexture = Resources.Load<Texture>("Texture/Card_light/black_12");
                                break;
                            case CardNumberEnum.十三:
                                tureList[j].mainTexture = Resources.Load<Texture>("Texture/Card_light/black_13");
                                break;
                        }

                    }
                }
            }
            go.transform.localPosition = cardsTransform[flag].transform.localPosition + new Vector3(0, 46, 0);
            flag++;
        }
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
        isMatch = true;
    }
    /// <summary>
    /// 跟注选中改变事件
    /// </summary>
    void TogFollwer_OnChange()
    {

    }
    /// <summary>
    /// 头像点击事件
    /// </summary>
    public void BtnHeadimg_Click(GameObject go)
    {
        GFPlayerUI info = go.GetComponentInParent<GFPlayerUI>();
        if (isMatch)
        {
            //跟对应玩家比牌
            PlayerLinkCard matchCard = player_card.Find(d => d.tempId == info.tempID);
            PlayerLinkCard loclCard = player_card.Find(d => d.tempId == localPlayer.tempID);
            bool isWin = CardOpreation.matchCards(loclCard.cards, matchCard.cards);
            UILabel labWin = GameObject.Find("IsWin").GetComponent<UILabel>();
            GFPlayerUI matchInfo = players.Find(d => d.tempID == matchCard.tempId);
            GFPlayerUI loclInfo = players.Find(d => d.tempID == loclCard.tempId);
            if (isWin)
            {
                labWin.text = "骚年,恭喜你赢了对方！";
                matchInfo.cardStatus = CardStatusEnum.输了;
            }
            else
            {
                labWin.text = "不好意思，你被对方吃掉了！";
                loclInfo.cardStatus = CardStatusEnum.输了;
            }
            isMatch = false;
            Match_VS_flash(loclInfo.head_img, matchInfo.head_img);
        }
        else
        {
            //查看玩家信息
            Debug.Log("玩家信息：" + info.player_name);
        }
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
                Send_Card();
            }
        }
    }
    /// <summary>
    /// 发牌
    /// </summary>
    void Send_Card()
    {
        cards_send = new List<CardInfo>();
        BtnSetActive(true);
        for (int i = 0; i < cardsTransform.Length; i++)
        {
            GameObject go = Instantiate(cardPrefab, uiroot);//创建预制体
            go.transform.DOMove(cardsTransform[i].transform.position, 0.5f);
        }
        //给玩家发牌
        for (int i = 0; i < players.Count; i++)
        {
            PlayerLinkCard info = new PlayerLinkCard();
            info.tempId = players[i].tempID;
            info.cards = new List<CardInfo>();
            CardColorEnum[] card_color = { CardColorEnum.红桃, CardColorEnum.方块, CardColorEnum.梅花, CardColorEnum.黑桃 };
            CardNumberEnum[] card_number = { CardNumberEnum.一, CardNumberEnum.二, CardNumberEnum.三, CardNumberEnum.四, CardNumberEnum.五, CardNumberEnum.六, CardNumberEnum.七, CardNumberEnum.八, CardNumberEnum.九, CardNumberEnum.十, CardNumberEnum.十一, CardNumberEnum.十二, CardNumberEnum.十三 };
            for (int j = 0; j < 3; j++)
            {
                CardInfo card_info = new CardInfo();
                int rdColor = Random.Range(0, card_color.Length);
                card_info.cardColor = card_color[rdColor];
                int rdNumber = Random.Range(0, card_number.Length);
                card_info.cardNumber = card_number[rdNumber];
                if (cards_send.Find(d => d == card_info) == null)
                {
                    info.cards.Add(card_info);
                    cards_send.Add(card_info);
                }
                else
                {
                    j--;
                }
            }
            player_card.Add(info);
        }
    }
    /// <summary>
    /// 比牌动画
    /// </summary>
    public void Match_VS_flash(string local_headimg,string match_headimg)
    {
        gameObj_vs.SetActive(true);
        UITexture[] textureItems = gameObj_vs.GetComponentsInChildren<UITexture>();
        for (int i = 0; i < textureItems.Length; i++)
        {
            if (textureItems[i].tag == "vs_local_player")
            {
                textureItems[i].mainTexture = Resources.Load<Texture>("Texture/HeadImg/" + local_headimg + "");
                textureItems[i].transform.DOMove(local_img_vs_position.position,0.5f);
            }
            if (textureItems[i].tag == "vs_match_player")
            {
                textureItems[i].mainTexture = Resources.Load<Texture>("Texture/HeadImg/" + match_headimg + "");
                textureItems[i].transform.DOMove(match_img_vs_position.position, 0.5f);
            }
            if (textureItems[i].tag == "vs_img")
            {
                textureItems[i].transform.DOMove(bg_vs_position.position, 0.5f);
            }
        }
        StartCoroutine(Match_VS_flash_Hide());
    }
    IEnumerator Match_VS_flash_Hide()
    {
        yield return new WaitForSeconds(2f);
        gameObj_vs.SetActive(false);
    }
    protected override void LDestroy()
    {

    }
}
