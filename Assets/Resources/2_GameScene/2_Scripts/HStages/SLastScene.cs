using UnityEngine;
using System.Collections;
using MHomiLibrary;

/// <summary>
/// 마지막 결과창 (결과창)
/// 위치 : SLastScene
/// </summary>

public class SLastScene : HState
{
    public GameObject LastScene = null;         // lastScene게임 오브젝트 가져오기

    public Animator BossAni = null;     // 보스움직이는 에니메이터
    public TweenAlpha BossTween = null;     // 보스 트윈알파
    public UISprite BossSprite = null;

    bool PumkinCheck;

    public GameObject PumkinGame = null;

    public GameObject[] AllGame = null;     // 모든 게임오브젝트 끄기

    public override void Enter(params object[] oParams)
    {
        BossSprite.color = new Color(1f, 0f, 0f);
        AllGame[0].SetActive(false);
        AllGame[1].SetActive(false);
        LastScene.SetActive(true);

        //MAudioPlayMng.I.Play("BGM", true, true);
        Debug.Log("Here is LastScene");
        HStageMng.I.ChangeInfo("현재 스테이지 는 LastScene");
    }

    public override void Execute()
    {
        //Debug.Log(BossAni.GetCurrentAnimatorStateInfo(0).IsName("LastBoss"));
        //if (BossAni.GetCurrentAnimatorStateInfo(0).IsName("LastBoss"))
        //{
        //    BossTween.enabled = true;
        //}

        if (BossTween.enabled == false && PumkinCheck == false)
        {
            PumkinGame.SetActive(true);
            PumkinCheck = true;
        }
    }

    public override void Exit()
    {

    }

    void OnDestroy()
    {
        //Debug.Log("OnDestroy()/HStage1.cs");
    }
}
