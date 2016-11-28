using UnityEngine;
using System.Collections;
using MHomiLibrary;

/// <summary>
/// 몬스터 패턴 6 (스테이지)
/// 위치 : SStage6
/// </summary>

public class SStage6 : HState
{
    public SMGroup_8 SMonsterGroupScrp = null;

    public override void Enter(params object[] oParams)
    {
        Debug.Log("Here is SStage5");
        HStageMng.I.ChangeInfo("현재 스테이지 는 SStage5");
    }

    public override void Execute()
    {
        HGameMng.I.ChangeMonster();
        //CountScrp.CountTime();      // 카운트 시작!

        if (HGameMng.I.TimeCtrl((int)E_TIME.E_MONSTER_TIME, 0.2f) && HGameMng.I.bPlayerDie)
            SMonsterGroupScrp.CreateMonster();       // 막소환!

        if (HGameMng.I.nMonDieCont >= HGameMng.I.nStageMonMax[2])      // 몬스터가 다 죽으면 스테이지 넘어가기
        {
            HGameMng.I.nStage++;
            HGameMng.I.nMonDieCont = 0;
        }
    }

    public override void Exit()
    {
        for (int i = 0; i < SMonsterGroupScrp.SMonsterCtrlScrp.Length; i++)      // 씬전환할때 초기화!
            SMonsterGroupScrp.SMonsterCtrlScrp[i].Reset();

        //CountScrp.nTimer = 0;       // 카운트 시간 초기화
    }

    void OnDestroy()
    {
        //Debug.Log("OnDestroy()/HStage1.cs");
    }
}
