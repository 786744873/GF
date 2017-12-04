/** 
 *Copyright(C) 2017 by DefaultCompany  
 *FileName:     Bridge.cs 
 *Author:       lizhixing 
 *Version:      2.0 
 *UnityVersion：5.6.0f3 
 *Date:         2017-12-01 
 *Description:    通讯类
 *History: 
*/ 
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bridge
{
    public string bridgeType;

    public Bridge()
    {
        bridgeType = this.GetType().FullName;
    }

}
