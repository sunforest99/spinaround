using UnityEngine;
using System.Collections;
using MHomiLibrary;

/// <summary>
/// 몬스터 패턴 5 (스테이지)
/// 위치 : SStage5
/// </summary>

public class SStage5 : HState
{
    //public SCountGroup CountScrp;       // 카운트 사용하기위해
    public GameObject SBombGame = null;     // 폭탄 오브젝트
    public Animator AngryBossAni = null;        // 보스 화남 에니메이션

    public SMGroup_8 SMonsterGroupScrp = null;

    public override void Enter(params object[] oParams)
    {

        AngryBossAni.enabled = true;

        //MAudioPlayMng.I.Play("BGM", true, true);
        Debug.Log("Here is SStage5");
        HStageMng.I.ChangeInfo("현재 스테이지 는 SStage5");
    }

    public override void Execute()
    {
        HGameMng.I.ChangeMonster();
        //CountScrp.CountTime();      // 카운트 시작!

        if (HGameMng.I.TimeCtrl((int)E_TIME.E_MONSTER_TIME, 0.01f) && HGameMng.I.bPlayerDie == true)
            SMonsterGroupScrp.CreateMonster();       // 막소환!

        if (HGameMng.I.nMonDieCont >= HGameMng.I.nStageMonMax[2])      // 몬스터가 다 죽으면 스테이지 넘어가기
        {
            HGameMng.I.nStage++;
            HGameMng.I.nMonDieCont = 0;
        }

        SBombGame.SetActive(true);       // 폭탄아이템 보이게하기
    }

    public override void Exit()
    {
        for (int i = 0; i < SMonsterGroupScrp.SMonsterCtrlScrp.Length; i++)      // 씬전환할때 초기화!
            SMonsterGroupScrp.SMonsterCtrlScrp[i].Reset();

        SBombGame.SetActive(false);

        //HGameMng.I.bTimeScale = false;

        //CountScrp.nTimer = 0;       // 카운트 시간 초기화
    }

    void OnDestroy()
    {
        //Debug.Log("OnDestroy()/HStage1.cs");
    }
}
