using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using MHomiLibrary;

/// <summary>
/// 시간 enum
/// 위치 : HGameMng
/// </summary>

public enum E_TIME
{
    E_MONSTER_TIME = 0,
    E_BULLET_TIME,
    E_RESULT_TIME,
    E_MAX
}

public enum E_STAGE
{
    E_STAGE1 = 1,
    E_STAGE2,
    E_STAGE3,
    E_STAGE4,
    E_STAGE5,
    E_STAGE6,
    E_MAX
}

public class HGameMng : HSingleton<HGameMng>
{
    protected HGameMng() { }

    public SMonsterGroup SMonsterGroupScrp = null;     // 몬스터 스크립트 알아오기
    //public SBulletGroup SBulletGroupScrp = null;       // 총알 스크립드 알아오기 (미사용)
    public GameObject SresultGame = null;            // 결과창 스크립트
    public SBomb SBombScrp = null;      // 폭탄 스크립트

    public bool bPlayerDie;     // player 생존확인

    public string[] stMonsterName;      // 몬스터 이름 저장 변수
    public int[] nMonsterHp;            // 몬스터 체력 저장 변수
    public int nMonsterRrand;           // 몬스터 랜덤 생성할 변수

    public int nStage;        // 스테이지(1 ~ 5)

    public int nMonDieCont;     // 몬스터가 다 죽으면 다음 씬으로 넘어가기위해

    public bool bTimeScale;     // 요놈이 true일때 몬스터 이동

    public float fResultTime;       // 결과창에 사용할 생존시간

    float[] getTIme = new float[(int)E_TIME.E_MAX];     // 타임함수의 변수


    void Awake()
    {
        nStage = 1;     // 스테이지 1

        if (m_Instance == null)
            m_Instance = this;
        else
            Destroy(gameObject);
    }

    void Start()
    {
        bPlayerDie = true;
    }

    void Update()
    {
        if (nMonDieCont >= 20)      // 몬스터가 다 죽으면 스테이지 넘어가기
        {
            nStage++;
            nMonDieCont = 0;
        }//SMonsterGroupScrp.CreateMonster();

        //if (TimeCtrl((int)E_TIME.E_BULLET_TIME, 0.2f))      // 총알 생성
        //    SBulletGroupScrp.CreateBullet();

        if (bPlayerDie == true && nStage < (int)E_STAGE.E_MAX)
        {
            fResultTime += Time.deltaTime;
        }

        if (bPlayerDie == true)
        {
            switch (nStage)        // 스테이지 들어가기
            {
                case (int)E_STAGE.E_STAGE1:
                    HStageMng.I.ChangeScene("SStage1");
                    break;
                case (int)E_STAGE.E_STAGE2:
                    HStageMng.I.ChangeScene("SStage2");
                    break;
                case (int)E_STAGE.E_STAGE3:
                    HStageMng.I.ChangeScene("SStage3");
                    break;
                case (int)E_STAGE.E_STAGE4:
                    HStageMng.I.ChangeScene("SStage4");
                    break;
                case (int)E_STAGE.E_STAGE5:
                    HStageMng.I.ChangeScene("SStage5");
                    break;
                case (int)E_STAGE.E_STAGE6:
                    if (SBombScrp.bBombDie == true)
                    {
                        if (SBombScrp.BombSAni.frameIndex == 5)
                            HStageMng.I.ChangeScene("SStage6");
                    }
                    else
                    {
                        HStageMng.I.ChangeScene("SStage6");
                    }
                    break;
                case (int)E_STAGE.E_MAX:
                    if (SBombScrp.bBombDie == true)
                    {
                        if (SBombScrp.BombSAni.frameIndex == 5)
                            HStageMng.I.ChangeScene("SLastScene");
                    }
                    else
                    {
                        HStageMng.I.ChangeScene("SLastScene");
                    }
                    break;
            }
        }

        else
        {
            for (int i = 0; i < SMonsterGroupScrp.SMonsterCtrlScrp.Length; i++)
            {
                SMonsterGroupScrp.SMonsterCtrlScrp[i].fSpeed = 0f;      // player가 죽으면 몬스터의 속도를 o으로
            }

            SresultGame.SetActive(true);        // 결과창 띄우기
        }
    }
    void OnDestroy()
    {
        Debug.Log("OnDestroy()/HGameMng.cs");
    }

    public bool TimeCtrl(int nIndex, float DelTime)     // 타임 컨트롤 함수
    {
        if (getTIme[nIndex] + DelTime <= Time.time)
        {
            getTIme[nIndex] = Time.time;
            return true;
        }
        return false;
    }
}
