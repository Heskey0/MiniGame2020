using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartGamePanel : UiBase
{
    Button button_Start;
    Button button_Exit;
    // Start is called before the first frame update
    void Start()
    {
        button_Start = GetUICon<Button>("But_Start");
        button_Start.onClick.AddListener(StartGame);
        button_Exit = GetUICon<Button>("But_Exit");
        button_Exit.onClick.AddListener(ExitGame);
    }

    void StartGame() {
        ScenesMgr.GetInstance().LoadScene("Scene01",ReadSave);
    }
    void ReadSave() {
        UIManager.GetInstance().HidePanel("StartGamePanel");
        UIManager.GetInstance().ShowPanel<ChangeLevelPanel>("ChangeLevelPanel", PanelLayer.System, ChangeS);
        UIManager.GetInstance().ShowPanel<UIPanel>("UIPanel", PanelLayer.Bot);
        Debug.Log("成功开始游戏");
    }
    void ExitGame()
    {

        Debug.Log("结束游戏");
        Application.Quit();
    }

    private void ChangeS(ChangeLevelPanel clp)
    {

        clp.ChangeLevel("Scene01", "StartPos", "BGM_01");
    }
}
