﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*
 * CIS 497_2 : Design Patterns
 * Group Project 1 - XenoGarden
 * Contributed by: Wolfgang Gross 
 */

public class Singleton<T> : MonoBehaviour where T : Singleton<T>
{
    private static T instance;

    public static T Instance
    {
        get { return instance; }
    }

    public static bool IsInitialized
    {
        get { return instance != null; }
    }

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogError("[Singleton] Trying to instantiate a second instance of a singleton class");
        }
        else
        {
            instance = (T)this;
        }
    }

    protected virtual void OnDestroy()
    {
        //if this object is destroyed, make instance null so another can be created
        if (instance == this)
        {
            instance = null;
        }
    }
}