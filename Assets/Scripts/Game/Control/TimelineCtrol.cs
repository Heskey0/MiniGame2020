using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class TimelineCtrol : MonoBehaviour
{
    int action;
    PlayableDirector director;
    void Start()
    {
        director = GetComponent<PlayableDirector>();
        action = GameCtrol.GetInstance().Action;
        if (action == 1)
        {
            PassScene();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void PassScene() {
        GameCtrol.GetInstance().PassAction();
        Debug.Log(GameCtrol.GetInstance().Action);
        director.playableAsset = ResMgr.GetInstance().Load<PlayableAsset>("Action0" + action);
    }
}
