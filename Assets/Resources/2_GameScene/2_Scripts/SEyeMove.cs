using UnityEngine;
using System.Collections;

/// <summary>
/// 보스의 눈이 player 을 따라감
/// 위치 : SEyeMove
/// </summary>

public class SEyeMove : MonoBehaviour
{
    public int fSpeed;      // 눈이 움직이는 속도

    public Camera TouchCamera;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()       // 부모의 위치를 받아서 부모의 기준으로 돌리기
    {
        if (HGameMng.I.bPlayerDie == true)
            Move();
    }

    void Move()
    {
        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.RotateAround(new Vector3(transform.parent.position.x, transform.parent.position.y, transform.parent.position.z), Vector3.forward, fSpeed * Time.deltaTime);
            transform.eulerAngles = new Vector3(0f, 0f, 0f);
        }

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.RotateAround(new Vector3(transform.parent.position.x, transform.parent.position.y, transform.parent.position.z), Vector3.back, fSpeed * Time.deltaTime);
            transform.eulerAngles = new Vector3(0f, 0f, 0f);
        }

        Vector2 TouchVec = TouchCamera.ScreenToViewportPoint(Input.mousePosition);

        if (Input.GetMouseButton(0) && TouchVec.x <= 0.5f)        // 왼쪽
        {
            transform.RotateAround(new Vector3(transform.parent.position.x, transform.parent.position.y, transform.parent.position.z), Vector3.back, fSpeed * Time.deltaTime);
        }

        if (Input.GetMouseButton(0) && TouchVec.x >= 0.5f)        // 오른쪽
        {
            transform.RotateAround(new Vector3(transform.parent.position.x, transform.parent.position.y, transform.parent.position.z), Vector3.forward, fSpeed * Time.deltaTime);
        }
    }
}
