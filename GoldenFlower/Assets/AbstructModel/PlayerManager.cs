/** 
 *Copyright(C) 2017 by YX  
 *FileName:     PlayerManager.cs 
 *Author:       lizhixing 
 *Version:      2.0 
 *UnityVersion：5.6.0f3 
 *Date:         2017-12-05 
 *Description:    
 *History: 
*/ 
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager<M, P> : MonoBehaviour where M:PlayerManager<M, P> where P : Player
{
    [SerializeField]
    protected List<P> _players = new List<P>();

    public static M Instance;
    public void Init()
    {
        Instance = this as M;
        OnStart();
    }

    protected virtual void OnStart() {}

    public virtual P GetPlayer(int tempID)
    {
        Player player = Instance._players.Find(item => { return item.tempID == tempID; });
        if(player == null)
        {
            Debug.LogError(string.Format("{0} 玩家不存在", tempID));
        }
        return player as P;
    }

    public virtual P CreatePlayer(int tempID)
    {
        P result = null;
        if(typeof(P).GetType() == typeof(GFPlayer).GetType())
        {
            P temp = Resources.Load<P>("Prefabs/GFPlay/" + typeof(P).Name);
            result = Instantiate(temp);
            result.name = typeof(P).Name + "_" + tempID;
            result.transform.SetParent(Instance.transform);
        }
        if(result != null)
        {
            Instance._players.Add(result);
        }
        return result;
    }




}
