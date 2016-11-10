using UnityEngine;
using System.Collections;

/// <summary>
/// 몬스터 각자 컨트롤(이동,죽음)
/// 위치 : SMonsterCtrl
/// </summary>

public class SMonsterCtrl : MonoBehaviour
{
    public bool bPosCheck;      // ???
    public bool bDie;           // 몬스터의 생존확인
    public float fSpeed = 7f;   // 몬스터가 날아가는 속도

    public int nMonsterHp;      // 몬스터 체력

    public UISprite SMonsterSprite = null;     // 몬스터의 스프라이트

    public GameObject BitGame = null;

    void Start()
    {
        SMonsterSprite = GetComponent<UISprite>();      // 스프라이트 컴퍼넌트 받아오기
        SMonsterSprite.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (bDie == true)
        {
            if (bPosCheck == true && HGameMng.I.bTimeScale == true)     // 몬스터 스프라이트 켜주고 날라가기
            {
                SMonsterSprite.enabled = true;
                transform.Translate(transform.right * fSpeed * Time.deltaTime);
            }
        }

        if (bPosCheck == false)     // 몬스터 돌면서 체력세팅
        {
            MonsterHp();
            transform.Rotate(0f, 0f, 10f);
        }

        if (bPosCheck == false || bDie == false)        // 몬스터가 죽어있을때 스프라이트 끄기
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
            //fSpeed = 0f;
            //Time.timeScale = 0;
        }

        if (col.CompareTag("SDie"))           // 바깥벽이랑 충돌
        {
            HGameMng.I.nMonDieCont++;
            //nMonsterHp = 0;
            MonsterDie();
        }
        if (col.CompareTag("SBullet"))       // 총알이랑 충돌
        {
            HGameMng.I.nMonDieCont++;
            nMonsterHp -= 1;
            MonsterDie();
        }
        if (col.CompareTag("SBomb"))          // 폭탄이랑 추돌 
        {
            Debug.Log("Asdf");
            HGameMng.I.nMonDieCont++;
            //nMonsterHp = 0;
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
        HGameMng.I.bTimeScale = false;
        SMonsterSprite.enabled = false;
        bPosCheck = false;
        bDie = false;
        transform.localPosition = transform.parent.localPosition;
        transform.localRotation = Quaternion.Euler(0f, 0f, 0f);
    }

    void MonsterHp()        // 몬스터 체력 세팅  
    {
        switch (HGameMng.I.nMonsterRrand)
        {
            case 0:
                nMonsterHp = HGameMng.I.nMonsterHp[HGameMng.I.nMonsterRrand];
                break;
            case 1:
                nMonsterHp = HGameMng.I.nMonsterHp[HGameMng.I.nMonsterRrand];
                break;
            case 2:
                nMonsterHp = HGameMng.I.nMonsterHp[HGameMng.I.nMonsterRrand];
                break;
            case 3:
                nMonsterHp = HGameMng.I.nMonsterHp[HGameMng.I.nMonsterRrand];
                break;
            case 4:
                nMonsterHp = HGameMng.I.nMonsterHp[HGameMng.I.nMonsterRrand];
                break;
        }
    }

    void MonsterDie()       // 몬스터가 죽었을때 호출
    {
        if (nMonsterHp <= 0)
        {
            bPosCheck = false;
            //bDie = false;
            transform.localPosition = transform.parent.localPosition;
        }
    }
}
