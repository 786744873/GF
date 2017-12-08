/** 
 *Copyright(C) 2017 by YX  
 *FileName:     GFPlayer.cs 
 *Author:       chenyongjun 
 *Version:      2.0 
 *UnityVersion：5.6.0f3 
 *Date:         2017-12-05 
 *Description:  玩家ui数据模型  
 *History: 
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GFPlayerUI : Player
{

    protected override void LStart()
    {
        base.LStart();
    }
    /// <summary>
    /// 昵称
    /// </summary>
    public string player_name;
    /// <summary>
    /// 头像
    /// </summary>
    public string head_img;
    /// <summary>
    /// 钻石数
    /// </summary>
    public int count_zs;
    /// <summary>
    /// 金币数
    /// </summary>
    public int count_jb;
    /// <summary>
    /// 性别
    /// </summary>
    public string sex;
    /// <summary>
    /// 玩家状态
    /// </summary>
    public PlayerStatusEnum playerStatus;
    /// <summary>
    /// 玩家牌的状态
    /// </summary>
    public CardStatusEnum cardStatus;
}
