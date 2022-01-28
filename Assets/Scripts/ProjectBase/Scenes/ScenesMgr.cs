using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

/// <summary>
/// 场景切换模块
/// </summary>
public class ScenesMgr : BaseManage<ScenesMgr>
{
    public void LoadScene(string sceneName,UnityAction fun) {
        MonoManager.GetInstance().StartCoroutine(LoadSceneAsyn(sceneName, fun));
    }


    /// <summary>
    /// 异步加载场景
    /// </summary>
    /// <param name="sceneName"></param>
    /// <param name="fun"></param>
    /// <returns></returns>
    IEnumerator LoadSceneAsyn(string sceneName,UnityAction fun ) {
        var ao =  SceneManager.LoadSceneAsync(sceneName);

        while (!ao.isDone)
        {
            //事件中心分发进度
            EventCenter.GetInstance().EventTrigger("进度条更新", ao.progress);
            //这里更新进度条
            yield return ao.progress;
        }       
        fun();
    }
}
