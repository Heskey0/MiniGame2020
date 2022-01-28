using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIPanel : UiBase
{
    private Text foodNum;
    private Text seedNum;
    private Button music;
    private Slider musicVolumn;
    private int food=0;
    private int seed =5;

    public float volumn;
    void Start()
    {
        foodNum = GetUICon<Text>("Tex_FoodNum");
        seedNum = GetUICon<Text>("Tex_SeedNum");
        foodNum.text = food.ToString();
        seedNum.text = seed.ToString();
        music = GetUICon<Button>("But_Music");
        musicVolumn = GetUICon<Slider>("Sld_BGM");

        music.onClick.AddListener(CloseBGM);
    }

    private void Update()
    {
        ChangeBGMVolumn();
    }
    //食物ui逻辑
    public void AddFood() {
        food ++;
        foodNum.text = food.ToString();
    }
    public void EatFood()
    {
        food = food -3;
        foodNum.text = food.ToString();
    }
    public void ResetFood()
    {
        food =  0;
        foodNum.text = food.ToString();
    }
    //种子ui逻辑
    public void AddSeed()
    {
        seed++;
        seedNum.text = seed.ToString();
    }
    public void PlantSeed()
    {
        seed --;
        seedNum.text = seed.ToString();
    }
    public void ResetSeed()
    {
        seed = 5;
        seedNum.text = seed.ToString();
    }


    private void CloseBGM()
    {
        AudioMgr.GetInstance().PauseBGM();
    }
    private void ChangeBGMVolumn()
    {
        volumn = musicVolumn.value;
        AudioMgr.GetInstance().ChangeBGMVolume(volumn);
    }
}
