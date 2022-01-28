using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public enum PanelLayer{
    Top,
    Mid,
    Bot,
    System
}

/// <summary>
/// UI管理器
/// </summary>
public class UIManager : BaseManage<UIManager>
{
    public Dictionary<string, UiBase> panelDic = new Dictionary<string, UiBase>();

    Transform top = null;
    Transform mid = null;
    Transform bot = null;
    Transform system = null;
    
    //构造函数
    public UIManager() {
        //创建Canvas，让其过场景不被移除
        var obj = ResMgr.GetInstance().Load<GameObject>("UI/Canvas");
        GameObject.DontDestroyOnLoad(obj);

        top = obj.transform.Find("top");
        mid = obj.transform.Find("mid");
        bot = obj.transform.Find("bot");
        system = obj.transform.Find("system");

        

        //创建EventSystem，让其过场景不被移除
        obj = ResMgr.GetInstance().Load<GameObject>("UI/EventSystem");
        GameObject.DontDestroyOnLoad(obj);

    }

    /// <summary>
    /// 显示面板
    /// </summary>
    /// <param name="panelName">面板名</param>
    /// <param name="panelLayer">面板在Canvas中的层级</param>
    /// <param name="callback">创建完成后做的事</param>
    public void ShowPanel<T>(string panelName ,PanelLayer panelLayer , UnityAction<T> callback = null ) where T:UiBase
    {
        if (panelDic.ContainsKey(panelName))
        {
            if (callback != null)            
                callback(panelDic[panelName]as T);
            return;
        }
        ResMgr.GetInstance().LoadAsyn<GameObject>("UI/" + panelName, (obj) =>
        {
            Transform father = bot;
            //判断面板层级
            switch (panelLayer) {
                case PanelLayer.Mid:
                    father = mid;
                    break;
                case PanelLayer.Top:
                    father = top;
                    break;
                case PanelLayer.System:
                    father = system;
                    break;
            }

            //重置面板位置和大小信息
            obj.transform.SetParent(father);
            obj.transform.localPosition = Vector3.one;
            obj.transform.localScale = Vector3.one;
            (obj.transform as RectTransform).offsetMax = Vector3.zero;
            (obj.transform as RectTransform).offsetMin = Vector3.zero;
            T panel = obj.GetComponent<T>();
            if ( callback!= null)
                callback(panel);

            panelDic.Add(panelName,panel);
        });
    }

    /// <summary>
    /// 隐藏面板
    /// </summary>
    public void HidePanel(string panelName) 
    {
        if (panelDic.ContainsKey(panelName))
        {
            GameObject.Destroy(panelDic[panelName].gameObject);
            panelDic.Remove(panelName);

        }
        else {
            Debug.Log("没找到面板");
        }
    }
}
