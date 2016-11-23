using UnityEngine;
using System.Collections;

/// <summary>
/// 모든 버튼 컨트롤 스크립트
/// 위치 : SLogoBtn
/// </summary>

public class SLogoBtn : MonoBehaviour
{
    public void ExitBtn()       // 종료
    {
        Debug.Log("Exit");
        Application.Quit();
    }

    public void PlayBtn()       // 시작
    {
        Debug.Log("Play");
        HMng.I.bPlayCheck = true;
        //HGameMng.I.bPlayerDie = true;
        //Application.LoadLevel("2_Gamescene");
    }

    public void RankBtn()       // 랭크
    {
        Debug.Log("Rank");
    }

    public void FacebookBtn()       // 페이스북
    {
        Debug.Log("Facebook");
    }

    public void TwitterBtn()        // 트위터
    {
        Debug.Log("Twitter");
    }

    public void TrophyBtn()     // 업적
    {
        Debug.Log("Trophy");
    }

    public void SettingBtn()        // 설정
    {
        Debug.Log("Setting");
        if (HMng.I.bSettingCheck == false)
            HMng.I.bSettingCheck = true;
        else
            HMng.I.bSettingCheck = false;
    }

    public void Restart()       // 재시작
    {
        Application.LoadLevel("2_Gamescene");
    }

    public void Home()
    {
        HMng.I.bPlayCheck = false;
        Application.LoadLevel("1_Menuscene");
    }

    public void Sound()
    {
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
}
