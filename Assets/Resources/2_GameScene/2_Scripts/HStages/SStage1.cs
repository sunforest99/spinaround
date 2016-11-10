using UnityEngine;
using System.Collections;
using MHomiLibrary;

/// <summary>
/// 몬스터 패턴 1 (스테이지)
/// 위치 : SStage1
/// </summary>

public class SStage1 : HState
{
    public SCountGroup CountScrp;       // 카운트 사용하기위해
    public UISprite[] BossEyeSprite = null;      // 보스눈 스프라이트 (색 변경용)

    public override void Enter(params object[] oParams)
    {
        BossEyeSprite[0].color = Color.white;
        BossEyeSprite[1].color = Color.white;
        //MAudioPlayMng.I.Play("BGM", true, true);
        Debug.Log("Here is HSate3");
        HStageMng.I.ChangeInfo("현재 스테이지 는 HStage3");
    }

    public override void Execute()
    {
        CountScrp.CountTime();      // 카운트 시작!

        if (HGameMng.I.TimeCtrl((int)E_TIME.E_MONSTER_TIME, 0.1f) && HGameMng.I.bTimeScale == true && HGameMng.I.bPlayerDie == true)      // 0.1 초마다 몬스터 생성
            HGameMng.I.SMonsterGroupScrp.CreateMonster();

        for (int i = 0; i < HGameMng.I.SMonsterGroupScrp.SMonsterCtrlScrp.Length; i++)
        {
            HGameMng.I.SMonsterGroupScrp.SMonsterCtrlScrp[i].fSpeed = 6f;
            if (HGameMng.I.SMonsterGroupScrp.SMonsterCtrlScrp[i].bDie == false)     // 각각의 몬스터의 bDie가 false일때 랜덤이 돈뒤 몬스터에 적용(몬스터 종류 0)
            {
                HGameMng.I.nMonsterRrand = 0;
                HGameMng.I.SMonsterGroupScrp.SMonsterCtrlScrp[i].RandMonster();
            }
        }
    }

    public override void Exit()
    {
        for (int i = 0; i < HGameMng.I.SMonsterGroupScrp.SMonsterCtrlScrp.Length; i++)      // 씬전환할때 초기화!
            HGameMng.I.SMonsterGroupScrp.SMonsterCtrlScrp[i].Reset();

        CountScrp.nTimer = 0;       // 카운트 시간 초기화
    }

    void OnDestroy()
    {
        //Debug.Log("OnDestroy()/HStage1.cs");
    }
}
