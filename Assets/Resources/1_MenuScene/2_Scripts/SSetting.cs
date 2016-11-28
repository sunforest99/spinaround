using UnityEngine;
using System.Collections;

public class SSetting : MonoBehaviour
{
    public UISprite SoundBtnSprite = null;
    public Animation SettingAni = null;
    bool bcheck;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if(!HMng.I.bSoundCheck)
        {
            SoundBtnSprite.spriteName = "Sound";
            HSoundMng.I.Stop(false);
        }

        else
        {
            HSoundMng.I.Play("Psychedelic-trip", true, true);
            SoundBtnSprite.spriteName = "unSound";
        }

        if (HMng.I.bSettingCheck && !bcheck)
        {
            SettingAni.Play("SettingAni");
            bcheck = true;
        }

        if (!HMng.I.bSettingCheck && bcheck)
        {
            SettingAni.Play("SettingoffAni");
            bcheck = false;
        }

        if(HMng.I.bPlayCheck && bcheck)
        {
            HMng.I.bSettingCheck = false;
            SettingAni.Play("SettingoffAni");
        }
    }
}
