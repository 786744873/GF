/** 
 *Copyright(C) 2017 by DefaultCompany  
 *FileName:     UIAdaptive.cs 
 *Author:       lizhixing 
 *Version:      2.0 
 *UnityVersion：5.6.0f3 
 *Date:         2017-12-04 
 *Description:    
 *History: 
*/ 
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class UIAdaptive : MonoBehaviour
{
    [SerializeField]
    private int width = 1600;
    [SerializeField]
    private int height = 900;

    private UIRoot uiRoot;

    public void Start()
    {
        uiRoot = GetComponent<UIRoot>();
        if(uiRoot != null)
        {
            uiRoot.scalingStyle = UIRoot.Scaling.Constrained;
            uiRoot.manualHeight = height;
            uiRoot.manualWidth = width;
            uiRoot.fitWidth = true;
            uiRoot.fitWidth = false;
        }
    }
}
