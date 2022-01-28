using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Main : MonoBehaviour
{

    private void Awake()
    {
        UIManager.GetInstance().ShowPanel<StartGamePanel>("StartGamePanel", PanelLayer.Mid);
    }

}
