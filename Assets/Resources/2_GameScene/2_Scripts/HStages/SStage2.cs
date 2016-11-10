using UnityEngine;
using System.Collections;
using MHomiLibrary;

/// <summary>
/// 몬스터 패턴 2 (스테이지)
/// 위치 : SStage2
/// </summary>

public class SStage2 : HState
{
    public SCountGroup CountScrp;       // 카운트 사용하기위해
    public UISprite[] BossEyeSprite = null;      // 보스 스프라이트 (색 변경용)

    public override void Enter(params object[] oParams)
    {
        BossEyeSprite[0].color = new Color(1f, 0.74f, 0.74f);//255, 189, 189
        BossEyeSprite[1].color = new Color(1f, 0.74f, 0.74f);
      
        //MAudioPlayMng.I.Play("BGM", true, true);
        Debug.Log("Here is SStage2");
        HStageMng.I.ChangeInfo("현재 스테이지 는 SStage2");
    }

    public override void Execute()
    {
        CountScrp.CountTime();      // 카운트 시작!

        if (HGameMng.I.TimeCtrl((int)E_TIME.E_MONSTER_TIME, 0.16f) && HGameMng.I.bTimeScale == true && HGameMng.I.bPlayerDie == true)      // 0.2 초마다 몬스터 생성
            HGameMng.I.SMonsterGroupScrp.CreateMonster();

        for (int i = 0; i < HGameMng.I.SMonsterGroupScrp.SMonsterCtrlScrp.Length; i++)
        {
            if (HGameMng.I.SMonsterGroupScrp.SMonsterCtrlScrp[i].bDie == false)     // 각각의 몬스터의 bDie가 false일때 랜덤이 돈뒤 몬스터에 적용(몬스터 종류 0 ~ 1)
            {
                HGameMng.I.nMonsterRrand = Random.Range(0, 2);
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
