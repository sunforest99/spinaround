using UnityEngine;
using System.Collections;
using MHomiLibrary;

/// <summary>
/// 몬스터 패턴 5 (스테이지)
/// 위치 : SStage5
/// </summary>

public class SStage5 : HState
{
    public SCountGroup CountScrp;       // 카운트 사용하기위해
    public GameObject SBombGame = null;     // 폭탄 오브젝트
    public Animator AngryBossAni = null;        // 보스 화남 에니메이션
    public UISprite[] BossEyeSprite = null;      // 보스 스프라이트 (색 변경용)

    public override void Enter(params object[] oParams)
    {
        AngryBossAni.enabled = true;

        BossEyeSprite[0].color = Color.red;
        BossEyeSprite[1].color = Color.red;
        //BossSprite.color = Color.red;
        //MAudioPlayMng.I.Play("BGM", true, true);
        Debug.Log("Here is SStage5");
        HStageMng.I.ChangeInfo("현재 스테이지 는 SStage5");
    }

    public override void Execute()
    {
        CountScrp.CountTime();      // 카운트 시작!
        SBombGame.SetActive(true);       // 폭탄아이템 보이게하기

        if (HGameMng.I.TimeCtrl((int)E_TIME.E_MONSTER_TIME, 0.03f) && HGameMng.I.bTimeScale == true && HGameMng.I.bPlayerDie == true)
            HGameMng.I.SMonsterGroupScrp.CreateMonster();       // 막소환!

        for (int i = 0; i < HGameMng.I.SMonsterGroupScrp.SMonsterCtrlScrp.Length; i++)
        {
            if (HGameMng.I.SMonsterGroupScrp.SMonsterCtrlScrp[i].bDie == false)     // 각각의 몬스터의 bDie가 false일때 랜덤이 돈뒤 몬스터에 적용(몬스터 종류 0 ~ 4)
            {
                HGameMng.I.nMonsterRrand = Random.Range(0, 5);
                HGameMng.I.SMonsterGroupScrp.SMonsterCtrlScrp[i].RandMonster();
            }
        }
    }

    public override void Exit()
    {
        for (int i = 0; i < HGameMng.I.SMonsterGroupScrp.SMonsterCtrlScrp.Length; i++)      // 씬전환할때 초기화!
            HGameMng.I.SMonsterGroupScrp.SMonsterCtrlScrp[i].Reset();

        SBombGame.SetActive(false);

        HGameMng.I.bTimeScale = false;

        CountScrp.nTimer = 0;       // 카운트 시간 초기화
    }

    void OnDestroy()
    {
        //Debug.Log("OnDestroy()/HStage1.cs");
    }
}
