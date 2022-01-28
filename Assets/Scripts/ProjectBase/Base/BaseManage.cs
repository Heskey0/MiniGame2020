using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// 单例模式基本模块，使用方法：继承BaseManage<T>，T为泛型
/// </summary>
/// <typeparam name="T"></typeparam>
public class BaseManage<T> where T : new()
{
    private static T Instance;
    public static T GetInstance()
    {
        if (Instance == null)
        {
            Instance = new T();
        }
        return Instance;

    }
}
