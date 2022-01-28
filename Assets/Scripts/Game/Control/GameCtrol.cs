using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class GameCtrol : BaseManage<GameCtrol>
{
    public int GameDate = 0;
    public int Action = 0;

    public void PassDay() {
        GameDate++;
    }
    public void PassAction()
    {
        Action++;
    }
}
