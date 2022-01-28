using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Changelevel : MonoBehaviour
{
    public string SceneName;
    public string posName;
    public string bgm;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            UIManager.GetInstance().ShowPanel<ChangeLevelPanel>("ChangeLevelPanel", PanelLayer.System, ChangeS);
        }

    }

    private void ChangeS(ChangeLevelPanel clp) {

        clp.ChangeLevel(SceneName, posName,bgm);
    }
}
