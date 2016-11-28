using UnityEngine;
using System.Collections;
using MHomiLibrary;

/// <summary>
/// 몬스터 패턴 2 (스테이지)
/// 위치 : SStage2
/// </summary>

public class SStage2 : HState
{
    //public SCountGroup CountScrp;       // 카운트 사용하기위해

    public SMGroup_0 SMGroup_0scrp = null;     // 몬스터 스크립트 알아오기
    public SMGroup_1 SMGroup_1scrp = null;
    public SMGroup_2 SMGroup_2scrp = null;
    public SMGroup_3 SMGroup_3scrp = null;

    public GameObject SpinGame = null;

    public int nNum;

    public override void Enter(params object[] oParams)
    {
        nNum = Random.Range(1, 3);


        Debug.Log("Here is SStage2");
        HStageMng.I.ChangeInfo("현재 스테이지 는 SStage2");
    }

    public override void Execute()
    {
        HGameMng.I.ChangeMonster();
        //CountScrp.CountTime();      // 카운트 시작!

        if (HGameMng.I.TimeCtrl((int)E_TIME.E_RSPIN_TIME, 0.5f))
        {
            switch (nNum)
            {
                case 1:
                    if (HGameMng.I.nMonDieCont < 25)
                        SpinGame.transform.Rotate(0f, 0f, 15f);
                    else
                        SpinGame.transform.Rotate(0f, 0f, -15f);
                    break;

                case 2:
                    if (HGameMng.I.nMonDieCont < 25)
                        SpinGame.transform.Rotate(0f, 0f, -15f);
                    else
                        SpinGame.transform.Rotate(0f, 0f, 15f);
                    break;

                default:
                    nNum = Random.Range(0, 2);
                    break;
            }
        }

        if (HGameMng.I.TimeCtrl((int)E_TIME.E_MONSTER_TIME, 0.25f) && HGameMng.I.bPlayerDie)
            Create();

        if (HGameMng.I.nMonDieCont >= HGameMng.I.nStageMonMax[0])      // 몬스터가 다 죽으면 스테이지 넘어가기
        {
            HGameMng.I.nStage++;
            HGameMng.I.nMonDieCont = 0;
        }

    }

    public override void Exit()
    {
        for (int i = 0; i < SMGroup_0scrp.SMonsterCtrlScrp.Length; i++)      // 씬전환할때 초기화!
        {
            SMGroup_0scrp.SMonsterCtrlScrp[i].Reset();
            SMGroup_1scrp.SMonsterCtrlScrp[i].Reset();
            SMGroup_2scrp.SMonsterCtrlScrp[i].Reset();
            SMGroup_3scrp.SMonsterCtrlScrp[i].Reset();
        }

        //CountScrp.nTimer = 0;       // 카운트 시간 초기화
    }

    void OnDestroy()
    {
        //Debug.Log("OnDestroy()/HStage1.cs");
    }

    void Create()
    {
        SMGroup_0scrp.CreateMonster();
        SMGroup_1scrp.CreateMonster();
        SMGroup_2scrp.CreateMonster();
        SMGroup_3scrp.CreateMonster();
    }
}
