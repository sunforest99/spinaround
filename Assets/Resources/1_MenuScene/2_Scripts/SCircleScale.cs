using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

/// <summary>
/// 메뉴씬에 있는 원 스키조절
/// </summary>

public class SCircleScale : MonoBehaviour
{
    public Animation CircleAni = null;
    public TweenAlpha BackLayerTween = null;

    public GameObject[] BtnGame = null;

    public UIButton[] BtnButton = null;

    public UISprite[] BtnSprite = null;

    public TweenAlpha[] BtnTween = null;

    public bool bInitAniCheck;
    public bool bExitAniCheck;

    void Start()
    {
        for (int i = 0; i < BtnGame.Length; i++)
        {
            BtnSprite[i] = BtnGame[i].GetComponent<UISprite>();
            BtnButton[i] = BtnGame[i].GetComponent<UIButton>();
            BtnTween[i] = BtnGame[i].GetComponent<TweenAlpha>();

            BtnSprite[i].enabled = false;
            BtnButton[i].enabled = false;
            BtnTween[i].enabled = false;
        }
    }

    void Update()
    {
        if (BackLayerTween.enabled == false)
        {
            if (bInitAniCheck == false)
            {
                CircleAni.Play("InitMenuAni");
                bInitAniCheck = true;
            }
            if (CircleAni.isPlaying == false)
            {
                for (int i = 0; i < BtnGame.Length; i++)
                {
                    BtnSprite[i].enabled = true;
                    BtnButton[i].enabled = true;
                    BtnTween[i].enabled = true;
                }
            }
        }

        if (HMng.I.bPlayCheck == true)
        {
            if (bExitAniCheck == false)
            {
                CircleAni.Play("ExitMenuAni");
                bExitAniCheck = true;
            }
            if (CircleAni.isPlaying == false)
            {
                SceneManager.LoadScene("2_Gamescene");
            }

            for (int i = 0; i < BtnGame.Length; i++)
            {
                BtnSprite[i].alpha -= 0.05f;
                //BtnButton[i].enabled = false;
                //BtnTween[i].from = 1f;
                //BtnTween[i].to = 0f;
                //BtnTween[i].ResetToBeginning();
            }
        }
    }
}
