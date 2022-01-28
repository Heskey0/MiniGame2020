using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

/// <summary>
/// Mono的管理者
/// 1,生命周期函数
/// 2.事件
/// 3.协程
/// </summary>
public class MonoCtrl : MonoBehaviour
{
    public event UnityAction UpdataEvent; 

    void Start()
    {
        DontDestroyOnLoad(this.gameObject);
    }
    
    /// <summary>
    /// 增加Update更新监听者
    /// </summary>
    void Update()
    {
        if (UpdataEvent != null)
        {
            UpdataEvent();
        }
    }

    public void AddUpdateListener(UnityAction fun) {
        UpdataEvent += fun;
    }

    /// <summary>
    /// 移除监听者
    /// </summary>
    /// <param name="fun"></param>
    public void RemoveUpdateListener(UnityAction fun)
    {
        UpdataEvent -= fun;
    }
}
