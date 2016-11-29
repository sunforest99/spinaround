using UnityEngine;
using System.Collections;
using MHomiLibrary;

/// <summary>
/// 몬스터 패턴 1 (스테이지)
/// 위치 : SStage1
/// </summary>

public class SStage1 : HState
{
    //public SCountGroup CountScrp;       // 카운트 사용하기위해

    public SMGroup_0 SMGroup_0scrp = null;     // 몬스터 스크립트 알아오기
    public SMGroup_1 SMGroup_1scrp = null;
    public SMGroup_2 SMGroup_2scrp = null;
    public SMGroup_3 SMGroup_3scrp = null;

    public Animation StartAnni = null;

    public UISpriteAnimation MouthAni = null;

    public override void Enter(params object[] oParams)
    {
        StartAnni.Play();

        Debug.Log("Here is HSate3");
        HStageMng.I.ChangeInfo("현재 스테이지 는 HStage3");
    }

    public override void Execute()
    {
        //CountScrp.CountTime();      // 카운트 시작!
        if (!StartAnni.isPlaying)
        {
            MouthAni.enabled = true;
        }

        if(MouthAni.frameIndex == 4)
        {
            HGameMng.I.bTimeScale = true;
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
