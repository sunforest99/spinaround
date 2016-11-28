using UnityEngine;
using UnityEngine.SceneManagement;
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
        if (!LogoTween.enabled)
        {
            HSoundMng.I.Play("Psychedelic-trip", true, true);

            SceneManager.LoadScene("1_Menuscene");
        }
    }
}
