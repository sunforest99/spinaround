using UnityEngine;
using System.Collections;

/// <summary>
/// 총알 각각 컨트롤
/// 위치 : SBulletCtrl
/// </summary>

public class SBulletCtrl : MonoBehaviour
{
    public bool bDie;               // 총알의 생존확인
    public float fSpeed = 7f;       // 총알의 날아가는 속도

    public BoxCollider2D SBullet2D;     // 총알의 박스콜리더
    public UISprite SBulletSprite;      // 총알의 스프라이트

    void Start()
    {
        SBullet2D = GetComponent<BoxCollider2D>();
        SBulletSprite = GetComponent<UISprite>();
    }

    // Update is called once per frame
    void Update()
    {
        if (bDie)       // bDie 가 true 일때 날라가기
        {
            transform.localPosition = Vector2.Lerp(transform.localPosition, Vector2.zero, fSpeed * Time.deltaTime);
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        //Debug.Log("ASdf");
        if (col.CompareTag("SDelBullet"))        // 총알 지워주는 오브젝트랑 충돌했을때 총알 관련 초기화
        {
            SBullet2D.enabled = false;
            SBulletSprite.enabled = false;
            bDie = false;


            transform.localPosition = transform.parent.localPosition;
        }
    }
}