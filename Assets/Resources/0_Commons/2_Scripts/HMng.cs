using UnityEngine;
using System.Collections;
using MHomiLibrary;

public class HMng : HSingleton<HMng>
{
    protected HMng() { }

    public bool bPlayCheck;

    public bool bSettingCheck;
    public bool bSoundCheck;

    void Awake()
    {
        Screen.SetResolution(1280, 800, false);
        if (m_Instance == null)
            m_Instance = this;
        else
            Destroy(gameObject);
    }

    void Start()
    {
        Screen.sleepTimeout = SleepTimeout.NeverSleep;
        DontDestroyOnLoad(this);
    }

    void Update()
    {

    }

    void OnDestroy()
    {
        Debug.Log("OnDestroy()/HMng.cs");
    }
}
