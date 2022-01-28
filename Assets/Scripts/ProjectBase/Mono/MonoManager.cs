using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;
using UnityEngine.Events;

/// <summary>
/// Mono模块管理者
/// </summary>
public class MonoManager : BaseManage<MonoManager>
{
    private MonoCtrl MonoCtrl;

    public MonoManager()
    {
        //保证唯一性
        GameObject obj = new GameObject("MonoManager");
        MonoCtrl = obj.AddComponent<MonoCtrl>();
    }
    public void AddUpdateListener(UnityAction fun)
    {
        MonoCtrl.AddUpdateListener(fun);
    }

    public void RemoveUpdateListener(UnityAction fun)
    {
        MonoCtrl.RemoveUpdateListener(fun);
    }

    /// <summary>
    /// 重新封装的协程方法
    /// </summary>
    /// <param name="routine"></param>
    /// <returns></returns>
    public Coroutine StartCoroutine(IEnumerator routine)
    {
         return MonoCtrl.StartCoroutine(routine);
    }
    public Coroutine StartCoroutine(string methodName, [DefaultValue("null")] object value)
    {
        return MonoCtrl.StartCoroutine(methodName, value);
    }
    public Coroutine StartCoroutine_Auto(IEnumerator routine)
    {
        return MonoCtrl.StartCoroutine(routine);
    }
    public void StopAllCoroutines()
    {
        MonoCtrl.StopAllCoroutines();
    }
    public void StopCoroutine(IEnumerator routine)
    {
        MonoCtrl.StopCoroutine(routine);
    }
    public void StopCoroutine(Coroutine routine)
    {
        MonoCtrl.StopCoroutine(routine);
    }
    public void StopCoroutine(string methodName)
    {
        MonoCtrl.StopCoroutine(methodName);

    }
}
