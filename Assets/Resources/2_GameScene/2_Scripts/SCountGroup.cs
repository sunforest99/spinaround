using UnityEngine;
using System.Collections;

/// <summary>
/// 3,2,1,Go 구현
/// 위치 SCountGroup
/// </summary>

public class SCountGroup : MonoBehaviour
{
    public int nTimer;      // 시간

    public int[] nLimitTimes = null;        // [0] = 1,2 나옴 [1] = 3 나옴 [2] = go 나옴

    public GameObject FirstNumGame;        // 1
    public GameObject SecondNumGame;       // 2
    public GameObject ThirdNumGame;        // 3
    public GameObject GoGame;              // GO!

    public TweenAlpha GoTween;      // Go! 를 사라지게 하기 위한 

    // Use this for initialization
    void Start()
    {
        nTimer = 0;

        GoTween = GoGame.GetComponent<TweenAlpha>();

        FirstNumGame.SetActive(false);
        SecondNumGame.SetActive(false);
        ThirdNumGame.SetActive(false);
        GoGame.SetActive(false);
    }

    public void CountTime()
    {
        //if (nTimer == 0)        // 멘처음 시작 할때 게임 멈추기
        //{
        //    Time.timeScale = 0f;
        //}

        if (nTimer <= nLimitTimes[2])       // 최대 시간
        {
            nTimer++;       // 시간 계속 증가

            if (nTimer < nLimitTimes[0])        // 1나옴
            {
                FirstNumGame.SetActive(true);
            }

            if (nTimer > nLimitTimes[0])        // 1꺼지고 2나옴
            {
                FirstNumGame.SetActive(false);
                SecondNumGame.SetActive(true);
            }

            if (nTimer > nLimitTimes[1])        // 2꺼지고 3나옴
            {
                SecondNumGame.SetActive(false);
                ThirdNumGame.SetActive(true);
            }

            if (nTimer >= nLimitTimes[2])       // 3꺼지고 go나온후 코루틴 시작
            {
                ThirdNumGame.SetActive(false);
                GoGame.SetActive(true);
                //HGameMng.I.bTimeScale = true;
                //Time.timeScale = 1f;
                StartCoroutine("GoCount");
            }
        }
    }

    IEnumerator GoCount()        // 0.5초뒤에 Go 지움
    {
        yield return new WaitForSeconds(0.5f);
        
        GoGame.SetActive(false);
        GoTween.ResetToBeginning();
    }
}
