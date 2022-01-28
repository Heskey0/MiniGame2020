using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UiBase : MonoBehaviour
{
    Dictionary<string, List<UIBehaviour>> uiBaseMgr = new Dictionary<string, List<UIBehaviour>>();
    void Awake()
    {
        FindUICon<Button>();
        FindUICon<Image>();
        FindUICon<Slider>();
        FindUICon<Text>();
        FindUICon<Toggle>();
        FindUICon<ScrollRect>();
    }

    public virtual void OpenPanel() {

    }
    public virtual void ClosePanel()
    {

    }


    /// <summary>
    /// 找到子物体上的UI组件
    /// </summary>
    /// <typeparam name="T"></typeparam>
    void FindUICon<T>() where T: UIBehaviour
    {
        T[] controls = this.GetComponentsInChildren<T>();
        foreach (var item in controls)
        {
            if (uiBaseMgr.ContainsKey(item.gameObject.name))
                uiBaseMgr[item.gameObject.name].Add(item);
            else
                uiBaseMgr.Add(item.gameObject.name, new List<UIBehaviour>() { item });

        }
    }

    /// <summary>
    /// 得到名字对应的脚本
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="name"></param>
    /// <returns></returns>
    protected T GetUICon<T>( string name) where T: UIBehaviour
    {
        if (uiBaseMgr.ContainsKey(name))
        {
            foreach (var item in uiBaseMgr[name])
            {
                if (item is T)
                    return item as T;
            }
        }
        return null; 
    }


}
