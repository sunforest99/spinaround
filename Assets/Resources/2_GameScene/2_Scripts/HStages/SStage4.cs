using UnityEngine;
using System.Collections;
using MHomiLibrary;

/// <summary>
/// 몬스터 패턴 4 (스테이지)
/// 위치 : SStage4
/// </summary>

public class SStage4 : HState
{
    public SCountGroup CountScrp;       // 카운트 사용하기위해
    public UISprite[] BossEyeSprite = null;      // 보스 스프라이트 (색 변경용)

    public override void Enter(params object[] oParams)
    {
        BossEyeSprite[0].color = new Color(1f, 0.35f, 0.35f);
        BossEyeSprite[1].color = new Color(1f, 0.35f, 0.35f);
        //BossSprite.color = new Color(1f,0.35f,0.35f);     // 255, 90, 90
        //MAudioPlayMng.I.Play("BGM", true, true);
        Debug.Log("Here is SStage4");
        HStageMng.I.ChangeInfo("현재 스테이지 는 SStage4");
    }

    public override void Execute()
    {
        CountScrp.CountTime();      // 카운트 시작!

        if (HGameMng.I.TimeCtrl((int)E_TIME.E_MONSTER_TIME, 0.05f) && HGameMng.I.bTimeScale == true && HGameMng.I.bPlayerDie == true)      // 0.3 초마다 몬스터 생성
            HGameMng.I.SMonsterGroupScrp.CreateMonster();

        for (int i = 0; i < HGameMng.I.SMonsterGroupScrp.SMonsterCtrlScrp.Length; i++)      
        {
            if (HGameMng.I.SMonsterGroupScrp.SMonsterCtrlScrp[i].bDie == false)     // 각각의 몬스터의 bDie가 false일때 랜덤이 돈뒤 몬스터에 적용(몬스터 종류 0 ~ 3)
            {
                HGameMng.I.nMonsterRrand = Random.Range(0, 4);
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
