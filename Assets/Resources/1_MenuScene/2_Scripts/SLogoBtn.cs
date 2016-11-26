using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

/// <summary>
/// 모든 버튼 컨트롤 스크립트
/// 위치 : SLogoBtn
/// </summary>

public class SLogoBtn : MonoBehaviour
{
    public void ExitBtn()       // 종료
    {
        HSoundMng.I.Play("Button Push");
        Debug.Log("Exit");
        HMng.I.bExitCheck = true;
    }

    public void PlayBtn()       // 시작
    {
        HSoundMng.I.Play("Button Push");
        Debug.Log("Play");
        HMng.I.bPlayCheck = true;
        //HGameMng.I.bPlayerDie = true;
        SceneManager.LoadScene("2_Gamescene");
    }

    public void RankBtn()       // 랭크
    {
        HSoundMng.I.Play("Button Push");
        Debug.Log("Rank");
    }

    public void FacebookBtn()       // 페이스북
    {
        HSoundMng.I.Play("Button Push");
        Debug.Log("Facebook");
    }

    public void TwitterBtn()        // 트위터
    {
        HSoundMng.I.Play("Button Push");
        Debug.Log("Twitter");
    }

    public void TrophyBtn()     // 업적
    {
        HSoundMng.I.Play("Button Push");
        Debug.Log("Trophy");
    }

    public void SettingBtn()        // 설정
    {
        HSoundMng.I.Play("Button Push");
        Debug.Log("Setting");
        if (HMng.I.bSettingCheck == false)
            HMng.I.bSettingCheck = true;
        else
            HMng.I.bSettingCheck = false;
    }

    public void Restart()       // 재시작
    {
        HSoundMng.I.Play("Button Push");
        SceneManager.LoadScene("2_Gamescene");
    }

    public void Home()
    {
        HSoundMng.I.Play("Button Push");
        HMng.I.bPlayCheck = false;
        SceneManager.LoadScene("1_Menuscene");
    }

    public void Sound()
    {
        HSoundMng.I.Play("Button Push");
        if (HMng.I.bSoundCheck == false)
        {
            HMng.I.bSoundCheck = true;
            // HSoundMng.I.Stop();
        }

        else
        {
            HMng.I.bSoundCheck = false;
            // HSoundMng.I.Play("Psychedelic-trip", true, true);
        }
    }

    public void ExitCheck()
    {
        HSoundMng.I.Play("Button Push");
        Application.Quit();
    }

    public void ExitCancel()
    {
        HSoundMng.I.Play("Button Push");
        HMng.I.bExitCheck = false;
    }
}
