using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public  interface IEventInfo{
    
    }

public class EventInfo<T>: IEventInfo
{
    public UnityAction<T> actions;
    public EventInfo(UnityAction<T> action){
        actions += action;
    }
}

/// <summary>
/// 事件中心1.Dictionary 2.委托 3.观察者设计模式
/// </summary>
public class EventCenter : BaseManage<EventCenter>
{
    //key --事件的名字
    //value-- 对应的是监听这个事件的委托
    private Dictionary<string,IEventInfo> eventDic = new Dictionary<string, IEventInfo>();

    /// <summary>
    /// 添加事件监听
    /// </summary>
    /// <param name="name">事件的名字</param>
    /// <param name="action">处理事件的委托</param>
    public void AddEventListener<T>(string name, UnityAction<T> action)
    {
        if (eventDic.ContainsKey(name))
        {
            (eventDic[name] as EventInfo<T>).actions += action;
        }
        else
        {
            eventDic.Add(name,new EventInfo<T>(action));
        }
    }

    /// <summary>
    /// 事件触发
    /// </summary>
    /// <param name="name">触发事件的名字</param>
    public void EventTrigger<T>(string name , T info)
    {
        if (eventDic.ContainsKey(name))
        {
            (eventDic[name] as EventInfo<T>).actions.Invoke(info);
        }
    }

    /// <summary>
    /// 移除事件，否则造成内存泄漏
    /// </summary>
    /// <param name="name"></param>
    /// <param name="action"></param>
    public void RemoveEventListener<T>(string name ,UnityAction<T> action) {
        if (eventDic.ContainsKey(name))
        {
            (eventDic[name] as EventInfo<T>).actions -= action;        }
    }

    /// <summary>
    /// 清空事件
    /// </summary>
    public void Clear() {
        eventDic.Clear();
    }
}
