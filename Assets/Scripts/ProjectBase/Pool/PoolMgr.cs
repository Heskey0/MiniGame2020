using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

/// <summary>
/// 缓存池
/// </summary>
public class PoolMgr : BaseManage<PoolMgr>
{
    ///缓存池容器
    public Dictionary<string, PoolDate> PoolDic = new Dictionary<string, PoolDate>();

    private GameObject PoolObj;

    //拿
    public void GetObj(string name ,  UnityAction<GameObject> callback) {

        if (PoolDic.ContainsKey(name)&&PoolDic[name].PoolList.Count > 0)
        {
            callback(PoolDic[name].GetObj());
        }
        else {
            ResMgr.GetInstance().LoadAsyn<GameObject>(name,(O)=> {
                callback(O);
                O.name = name;
            });
        }
    }


    //还
    public void PushObj(string name ,GameObject Obj ) {

        //检测池子是否存在
        if (PoolObj == null)
            PoolObj = new GameObject("Pool");

        if (PoolDic.ContainsKey(name))
        {
            PoolDic[name].PushObj(Obj);
        }
        else
        {
            PoolDic.Add(name, new PoolDate(Obj, PoolObj));
        }

    }
    /// <summary>
    /// 清空缓存值
    /// </summary>
    public void Clear() {
        PoolDic.Clear();
        PoolObj = null;
    }
}

/// <summary>
/// 缓存池里的列表
/// </summary>
public class PoolDate
{
    //父节点
    public GameObject fatherObj;
    //池子中容器列表
    public List<GameObject> PoolList;

    //构造函数
    public PoolDate(GameObject Obj ,GameObject poolObj) {

        fatherObj = new GameObject(Obj.name);
        fatherObj.transform.parent = poolObj.transform;
        PoolList = new List<GameObject>() { Obj };
        Obj.transform.parent = fatherObj.transform;
        Obj.SetActive(false);
    }

    //压进去对象
    public void PushObj( GameObject Obj)
    {
        Obj.SetActive(false);
        //存起来
        PoolList.Add(Obj);
        Obj.transform.parent = fatherObj.transform;

    }

    //得到对象
    public GameObject GetObj() {
        GameObject Obj = null;
        //取出来
        Obj = PoolList[0];
        //列表移除
        PoolList.RemoveAt(0);
        //激活
        Obj.SetActive(true);
        //取消父节点
        Obj.transform.parent = null;

        return Obj;
    }

}


