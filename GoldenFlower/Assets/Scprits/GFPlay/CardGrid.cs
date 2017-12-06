/** 
 *Copyright(C) 2017 by YX  
 *FileName:     CardGrid.cs 
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

public class CardGrid : MonoBehaviour
{
    private CardData _data;
    public CardData data
    {
        get
        {
            return _data;
        }
    }

    public void Init(CardData data)
    {
        this._data = data;
    }



}
