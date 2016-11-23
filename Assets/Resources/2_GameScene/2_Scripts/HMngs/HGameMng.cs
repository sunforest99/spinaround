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
    E_LSPIN_TIME,
    E_RSPIN_TIME,
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

    public SMGroup_0 SMGroup_0scrp = null;     // 몬스터 스크립트 알아오기
    public SMGroup_1 SMGroup_1scrp = null;
    public SMGroup_2 SMGroup_2scrp = null;
    public SMGroup_3 SMGroup_3scrp = null;
    public SMGroup_4 SMGroup_4scrp = null;
    public SMGroup_5 SMGroup_5scrp = null;
    public SMGroup_6 SMGroup_6scrp = null;
    public SMGroup_7 SMGroup_7scrp = null;

    public GameObject SresultGame = null;            // 결과창 스크립트
    public SBomb SBombScrp = null;      // 폭탄 스크립트

    public bool bPlayerDie;     // player 생존확인

    public string[] stMonsterName;      // 몬스터 이름 저장 변수
    public int nMonsterRrand;           // 몬스터 랜덤 생성할 변수
    public int[] nStageMonMax;

    public int nStage;        // 스테이지(1 ~ 5)

    public int nMonDieCont;     // 몬스터가 다 죽으면 다음 씬으로 넘어가기위해

    public bool bTimeScale;     // 요놈이 true일때 몬스터 이동

    public float fResultTime;       // 결과창에 사용할 생존시간

    public float fMonSpeed = 5f;

    float[] getTIme = new float[(int)E_TIME.E_MAX];     // 타임함수의 변수


    void Awake()
    {
        nStage = 1;     // 스테이지 1
        fMonSpeed = 5f;

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

        if (bPlayerDie == true && nStage < (int)E_STAGE.E_MAX)
        {
            fResultTime += Time.deltaTime;
        }

        HStageMng.I.ChangeScene();
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

    public void ChangeMonster()
    {
        switch (nStage)
        {
            case 2:
                nMonsterRrand = Random.Range(0,2);
                break;

            case 3:
                nMonsterRrand = Random.Range(0, 3);
                break;

            case 4:
                nMonsterRrand = Random.Range(0, 4);
                break;

            case 5:
                nMonsterRrand = Random.Range(0, 5);
                break;

            case 6:
                nMonsterRrand = Random.Range(0, 5);
                break;
        }
    }
}
