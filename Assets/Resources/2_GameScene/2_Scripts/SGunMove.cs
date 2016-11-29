using UnityEngine;
using System.Collections;

/// <summary>
/// player 이동
/// 위치 : SGunMove
/// </summary>

public class SGunMove : MonoBehaviour
{
    public int fSpeed;      // 이동 속도
    public float fPosZ;     // z값 저장하는 곳
    public float fRotSpeed; // Slerp 속도


    public Camera TouchCamera = null;

    BoxCollider2D PlayerBox = null;
    UISprite sPlayerSprite = null;

    public GameObject BitGame = null;

    UISpriteAnimation BitSAni = null;
    UISprite BitSprite = null;

    TweenRotation PlayerTween = null;

    // Use this for initialization
    void Start()
    {
        PlayerTween = GetComponent<TweenRotation>();
        BitSAni = BitGame.GetComponent<UISpriteAnimation>();
        BitSprite = BitGame.GetComponent<UISprite>();

        sPlayerSprite = GetComponent<UISprite>();
        PlayerBox = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (BitSAni.frameIndex == 4)
        {
            sPlayerSprite.enabled = false;
        }

        if (BitSAni.frameIndex == 8)
        {
            BitSprite.enabled = false;
        }
        GunMove();
    }

    void GunMove()
    {
        if (HGameMng.I.bPlayerDie)      // player가 살아있을때
        {
            Key();          // 키입력 움직이기
            Touch();        // 클릭 움직이기
        }
        else
        {
            //TouchCamera.orthographicSize -= 1f * Time.deltaTime;

            //if(TouchCamera.orthographicSize <= 2f)
            //{
            //    if (TouchCamera.orthographicSize < 5f)
            //        TouchCamera.orthographicSize += 1f * Time.deltaTime;
            //}

            transform.localRotation = Quaternion.EulerAngles(0f, 0f, 0f);
            PlayerTween.enabled = false;
        }
    }

    void Key()
    {
        if (Input.GetKeyDown(KeyCode.A))     // 치트
        {
            PlayerBox.enabled = false;
        }

        if (Input.GetKeyDown(KeyCode.S))     // 치트
        {
            PlayerBox.enabled = true;
        }

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            //transform.RotateAround(new Vector3(transform.parent.position.x, transform.parent.position.y, transform.parent.position.z), Vector3.forward, fSpeed * Time.deltaTime);
            fPosZ -= Time.deltaTime * fSpeed;
        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            //transform.RotateAround(new Vector3(transform.parent.position.x, transform.parent.position.y, transform.parent.position.z), Vector3.back, fSpeed * Time.deltaTime);
            fPosZ += Time.deltaTime * fSpeed;
        }
        Quaternion PosQuat = Quaternion.Euler(0f, 0f, fPosZ);
        transform.parent.localRotation = Quaternion.Slerp(transform.parent.localRotation, PosQuat, Time.deltaTime * fRotSpeed);
    }

    void Touch()
    {
        Vector2 TouchVec = TouchCamera.ScreenToViewportPoint(Input.mousePosition);
        //Debug.Log(TouchVec);
        if (Input.GetMouseButton(0) && TouchVec.x <= 0.5f)        // 왼쪽
        {
            //transform.RotateAround(new Vector3(transform.parent.position.x, transform.parent.position.y, transform.parent.position.z), Vector3.forward, fSpeed * Time.deltaTime);
            fPosZ -= Time.deltaTime * fSpeed;
        }

        if (Input.GetMouseButton(0) && TouchVec.x >= 0.5f)        // 오른쪽
        {
            //transform.RotateAround(new Vector3(transform.parent.position.x, transform.parent.position.y, transform.parent.position.z), Vector3.back, fSpeed * Time.deltaTime);
            fPosZ += Time.deltaTime * fSpeed;
        }
        Quaternion PosQuat = Quaternion.Euler(0f, 0f, fPosZ);
        transform.parent.localRotation = Quaternion.Slerp(transform.parent.localRotation, PosQuat, Time.deltaTime * fRotSpeed);
    }
}
