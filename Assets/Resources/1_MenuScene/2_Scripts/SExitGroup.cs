using UnityEngine;
using System.Collections;

public class SExitGroup : MonoBehaviour
{
    public Animation ExitAni = null;
    public bool bCheck;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Ani();
    }

    void Ani()
    {
        if(HMng.I.bExitCheck && !bCheck)
        {
            ExitAni.Play("ExitonAni");
            bCheck = true;
        }
        if(!HMng.I.bExitCheck&& bCheck)
        {
            ExitAni.Play("ExitoffAni");
            bCheck = false;
        }

        if (HMng.I.bPlayCheck && bCheck)
        {
            HMng.I.bExitCheck = false;
            ExitAni.Play("ExitoffAni");
        }
    }
}
