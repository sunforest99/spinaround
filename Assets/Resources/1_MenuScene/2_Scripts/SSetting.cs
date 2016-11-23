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
        if(HMng.I.bSoundCheck == false)
        {
            SoundBtnSprite.spriteName = "Sound";
            HSoundMng.I.Stop();
        }

        else
        {
            HSoundMng.I.Play("Psychedelic-trip", true, true);
            SoundBtnSprite.spriteName = "unSound";
        }

        if (HMng.I.bSettingCheck == true && bcheck == false)
        {
            SettingAni.Play("SettingAni");
            bcheck = true;
        }

        if (HMng.I.bSettingCheck == false && bcheck == true)
        {
            SettingAni.Play("SettingoffAni");
            bcheck = false;
        }

        if(HMng.I.bPlayCheck == true)
        {
            HMng.I.bSettingCheck = false;
            SettingAni.Play("SettingoffAni");
        }
    }
}
