/** 
 *Copyright(C) 2017 by YX  
 *FileName:     Player.cs 
 *Author:       lizhixing 
 *Version:      2.0 
 *UnityVersion：5.6.0f3 
 *Date:         2017-12-05 
 *Description:    玩家
 *History: 
*/ 
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    private int _tempID;    //进入房间后临时创建的id
    public int  tempID
    {
        get
        {
            return _tempID;
        }
    }

    private Data _data;

    public void Init()
    {
        LStart();
    }

    protected virtual void LStart() { }

    public T GetData<T>() where T : Data
    {
        return _data as T;
    }

}
