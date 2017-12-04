/** 
 *Copyright(C) 2017 by DefaultCompany  
 *FileName:     GameCenter.cs 
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

public class GameCenter : MonoBehaviour
{
    private static GameCenter _instance;
    public static GameCenter GetInstance()
    {
        if(_instance == null)
        {
            _instance = GameObject.FindObjectOfType<GameCenter>();
            if (_instance == null)
            {
                GameObject go = new GameObject(typeof(GameCenter).Name);
                _instance = go.AddComponent<GameCenter>();
            }
        }
        return _instance;
    }

    [RuntimeInitializeOnLoadMethod]
    static void GStart()
    {
        DontDestroyOnLoad(GameCenter.GetInstance());

        SceneManager sceneManager = SceneManager.GetInstance();
        sceneManager.transform.SetParent(GameCenter.GetInstance().transform);
    }

}
