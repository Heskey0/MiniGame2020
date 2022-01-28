using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ResMgr : BaseManage<ResMgr>
{
    /// <summary>
    /// 同步加载资源
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="name"></param>
    /// <returns></returns>
    public T Load<T>(string name) where T: Object
    {
        T res =  Resources.Load<T>(name);
        if (res is GameObject)
        {
            var obj = GameObject.Instantiate(res);
            return obj;
        }
        else {
            return res;
        }
    }

    /// <summary>
    /// 异步加载资源
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="name"></param>
    /// <param name="callback"></param>
    public void LoadAsyn<T>(string name ,UnityAction<T>  callback ) where T: Object
    {
        MonoManager.GetInstance().StartCoroutine(ReallyLoadAsyn(name ,callback));
    }

    //利用协程真正的异步加载资源
    private IEnumerator ReallyLoadAsyn<T>(string name ,UnityAction<T> callback) where T : Object
    {
        ResourceRequest res = Resources.LoadAsync<T>(name);
        
        if (res.asset is GameObject)
        {
            callback(GameObject.Instantiate(res.asset )as T);
        }
        else {
            callback(res.asset as T);
        }
        yield return res;
    }
}
