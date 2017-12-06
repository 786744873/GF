/** 
 *Copyright(C) 2017 by YX  
 *FileName:     NetworkData.cs 
 *Author:       lizhixing 
 *Version:      2.0 
 *UnityVersion：5.6.0f3 
 *Date:         2017-12-05 
 *Description:    网络数据
 *History: 
*/ 
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NetworkData<T> : Data
{
    public int code;
    public T result;
}
