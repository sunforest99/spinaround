using UnityEngine;
using System.Collections;

/// <summary>
/// 몬스터 각자 컨트롤(이동,죽음)
/// 위치 : SMonsterCtrl
/// </summary>

public class SMonsterRDown : MonoBehaviour
{
    public bool bPosCheck;      // ???
    public bool bDie;           // 몬스터의 생존확인

    public UISprite SMonsterSprite = null;     // 몬스터의 스프라이트

    public GameObject WayGame = null;

    public GameObject BitGame = null;

    void Start()
    {
        SMonsterSprite = GetComponent<UISprite>();      // 스프라이트 컴퍼넌트 받아오기
        SMonsterSprite.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (bDie)
        {
            if (bPosCheck && HGameMng.I.bTimeScale)     // 몬스터 스프라이트 켜주고 날라가기
            {
                SMonsterSprite.enabled = true;
                transform.Translate(WayGame.transform.up * HGameMng.I.fMonSpeed * Time.deltaTime);
            }
        }

        if (!bPosCheck || !bDie)        // 몬스터가 죽어있을때 스프라이트 끄기
        {
            SMonsterSprite.enabled = false;
        }

        if (HGameMng.I.SBombScrp.bBombDie)
        {
            Reset();
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("SPlayer"))       // 플레이어 충돌
        {
            HSoundMng.I.Play("Dragon Bite", false, false);
            BitGame.SetActive(true);
            HGameMng.I.bPlayerDie = false;
            Debug.Log("ADF");
            MonsterDie();
        }

        if (col.CompareTag("SDie"))           // 바깥벽이랑 충돌
        {
            HGameMng.I.nMonDieCont++;
            MonsterDie();
        }

        if (col.CompareTag("SBomb"))          // 폭탄이랑 추돌 
        {
            Debug.Log("Asdf");
            HGameMng.I.nMonDieCont++;
            MonsterDie();
        }
    }

    public void RandMonster()       // 몬스터 이미지 번경
    {
        //HGameMng.I.nMonsterRrand = Random.Range(0, 5);
        SMonsterSprite.spriteName = HGameMng.I.stMonsterName[HGameMng.I.nMonsterRrand];
    }

    public void Reset()     // 새끼씬전환할때 몬스터 정보 초기화
    {
        SMonsterSprite.enabled = false;
        bPosCheck = false;
        bDie = false;
    }

    void MonsterDie()       // 몬스터가 죽었을때 호출
    {
        bPosCheck = false;
        transform.localPosition = transform.parent.localPosition;
    }
}
