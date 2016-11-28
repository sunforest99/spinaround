using UnityEngine;
using System.Collections;

/// <summary>
/// 폭탄 컨드롤
/// 위치 : SBomb
/// </summary>

public class SBomb : MonoBehaviour
{
    public bool bBombDie;       // 폭탄의 생존확인

    //public bool basdCheck;

    //public BoxCollider2D BombBox = null;
    public GameObject game = null;

    public UISpriteAnimation BombSAni = null;

    UISprite BombSprite = null;

    void Start()
    {
        BombSprite = GetComponent<UISprite>();
        game.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        //if (bBombDie)       // bBombDie 가 true 일때 이미지 스케일 키우기
        //    transform.localScale += new Vector3(0.5f, 0.5f, 0f);

        if (bBombDie)
        {
            game.SetActive(true);
            game.transform.localScale += new Vector3(0.5f, 0.5f, 0f);
            //BombBox.enabled = true;
        }
        if (game.transform.localScale.x > 30f)
        {
            BombSprite.enabled = true;
            BombSAni.frameIndex = 0;
            game.transform.localScale = new Vector3(1f, 1f, 1f);
            bBombDie = false;
            game.SetActive(false);
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("SPlayer") && HGameMng.I.bTimeScale)       // player 가 아이템을 먹을때 bBombDie 를 true 로
        {
            BombSprite.enabled = false;
            HGameMng.I.SBombScrp.bBombDie = true;
        }
    }

    void OnTriggerStay2D(Collider2D col)
    {
        if (col.CompareTag("SPlayer") && HGameMng.I.bTimeScale)       // player 가 아이템을 먹을때 bBombDie 를 true 로
        {
            BombSprite.enabled = false;
            HGameMng.I.SBombScrp.bBombDie = true;
        }
    }
}
