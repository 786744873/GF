/** 
 *Copyright(C) 2017 by YX  
 *FileName:     UIPlayerManager.cs 
 *Author:       chenyongjun 
 *Version:      2.0 
 *UnityVersion：5.6.0f3 
 *Date:         2017-12-06 
 *Description:  UI界面管理基类  
 *History: 
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIPlayerManager<M, P> : MonoBehaviour where M : UIPlayerManager<M, P> where P : Player
{
    protected List<P> players = new List<P>();
    public static M instance;
    public void Init()
    {
        instance = this as M;
        OnStart();
    }
    protected virtual void OnStart() { }

    public virtual void Add(P info)
    {
        if (Get(info.tempID) != null)
        {
            Debug.LogError("已存在!");
        }
        else
        {
            instance.players.Add(info);
        }
    }

    public virtual void Delete(P info)
    {
        if (Get(info.tempID) != null)
        {
            instance.players.Remove(info);
        }
        else
        {
            Debug.LogError("不存在!");
        }
    }

    public virtual P Get(int tempID)
    {
        P info = instance.players.Find(d => { return d.tempID == tempID; });
        return info;
    }

    public virtual int GetMaxId()
    {
        int flag = 0;
        for (int i = 0; i < players.Count; i++)
        {
            flag = players[i].tempID;
            for (int j = i; j < players.Count; j++)
            {
                if (players[j].tempID > players[i].tempID)
                    flag = players[j].tempID;
            }
        }
        return flag;
    }

    public virtual List<P> Players
    {
        get { return players; }
    }
}
