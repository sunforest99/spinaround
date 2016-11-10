using UnityEngine;
using System.Collections;

public class SLogoGroup : MonoBehaviour
{
    public TweenAlpha LogoTween = null;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (LogoTween.enabled == false)
        {
            HSoundMng.I.Play("Psychedelic-trip", true, true);

            Application.LoadLevel("1_Menuscene");
        }
    }
}
