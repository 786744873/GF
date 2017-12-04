/** 
 *Copyright(C) 2017 by DefaultCompany  
 *FileName:     MonoSingle.cs 
 *Author:       lizhixing 
 *Version:      2.0 
 *UnityVersion：5.6.0f3 
 *Date:         2017-12-01 
 *Description:    
 *History: 
*/ 
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonoSingle<T> : MonoBehaviour where T : MonoBehaviour
{
    private bool _isInit = false;
    private static T _instance;
    public static T GetInstance()
    {
        if(_instance == null)
        {
            _instance = GameObject.FindObjectOfType<T>();
            if(_instance == null)
            {
                GameObject go = new GameObject(typeof(T).Name);
                _instance = go.AddComponent<T>();
                MonoSingle<T> mono = _instance as MonoSingle<T>;
                mono.Start();
            }
        }
        return _instance;
    }

    private void Start()
    {
        if(!_isInit)
        {
            _isInit = true;
            LStart();
        }
    }

    protected virtual void LStart() { }

}
