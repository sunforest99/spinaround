using UnityEngine;
using System.Collections;
using MHomiLibrary;

public class HMng : HSingleton<HMng>
{
    protected HMng() { }

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
