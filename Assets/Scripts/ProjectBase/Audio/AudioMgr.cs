using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioMgr : BaseManage<AudioMgr>
{
    float bgmVolume = 1;
    float soundVolume = 1;
    GameObject SoundMgr = null;
    AudioSource bkMusic = null;
    List<AudioSource> soundList = new List<AudioSource>();

    public AudioMgr() {
        MonoManager.GetInstance().AddUpdateListener(Update);
    }
    
    /// <summary>
    /// 检测是否在播放
    /// </summary>
    void Update() {
        if (SoundMgr == null || soundList.Count == 0)
            return;
        foreach (var item in soundList)
        {
            if (!item.isPlaying)
                StopSound(item);
        }
    }

    /// <summary>
    /// 播放背景音乐
    /// </summary>
    /// <param name="name"></param>
    public void PlayBGM(string name) {
        if (bkMusic == null)
        {
            GameObject backMusicObj = new GameObject("bkMusic");
            bkMusic = backMusicObj.AddComponent<AudioSource>();
           
        }
        ResMgr.GetInstance().LoadAsyn<AudioClip>("Music/BGM/" + name, (clip) =>
        {
            bkMusic.clip = clip;
            bkMusic.volume = bgmVolume;
            bkMusic.loop = true;
            bkMusic.Play();
        });
    }
    /// <summary>
    /// 停止播放背景音乐
    /// </summary>
    public void StopBGM() {
        //判空
        if (bkMusic == null)
            return;
        bkMusic.Stop();
    }
    /// <summary>
    /// 暂停播放背景音乐
    /// </summary>
    public void PauseBGM() {
        if (bkMusic == null)
            return;

        bkMusic.Pause();
    }
    /// <summary>
    /// 改变BGM音量大小
    /// </summary>
    /// <param name="volume"></param>
    public void ChangeBGMVolume(float volume)
    {
        bgmVolume = volume;
        if (bkMusic == null)
            return;
        bkMusic.volume = volume;
    }


    /// <summary>
    /// 播放音效
    /// </summary>
    public AudioSource PlaySoundEfect(string name, bool isLoop) {

        //添加GameObject
        if (SoundMgr == null)
            SoundMgr = new GameObject("SoundMgr");
        //音效组件
        var source = SoundMgr.AddComponent<AudioSource>();
        //加载音效文件并播放
        ResMgr.GetInstance().LoadAsyn<AudioClip>("Music/Sound/" + name, (clip) =>
        {
            soundList.Add(source);
            source.clip = clip;
            source.loop = isLoop;
            source.volume = soundVolume;
            source.Play();
            
        });
        return source;
    }
    /// <summary>
    /// 停止音效
    /// </summary>
    /// <param name="soundEffect"></param>
    public void StopSound(AudioSource soundEffect)
    {
        //判空
        if (SoundMgr == null|| soundEffect == null)
            return;
        soundList.Remove(soundEffect);
        soundEffect.Stop();
        GameObject.Destroy(soundEffect);
    }
    /// <summary>
    /// 改变Sound音量大小
    /// </summary>
    /// <param name="volume"></param>
    public void ChangeSoundVolume(float volume)
    {
        soundVolume = volume;
        if (SoundMgr == null)
            return;
        foreach (var item in soundList)
        {
            item.volume = soundVolume;
        }
    }
}
