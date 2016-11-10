using UnityEngine;
using System.Collections;

/// <summary>
/// 원모양으로 돌기 (버튼들)
/// 위치 : SCircleRotate
/// </summary>

public class SCircleRotate : MonoBehaviour
{
    public int fSpeed;      // 움직이는 속도
    public Vector3 UIVec;       // ???
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.RotateAround(new Vector3(transform.parent.position.x, transform.parent.position.y, transform.parent.position.z), Vector3.forward, fSpeed * Time.deltaTime);       // 부모의 좌표 알아온후 돌리기

        UIVec = transform.rotation.eulerAngles;

        transform.eulerAngles = new Vector3(UIVec.x, UIVec.y, 0f);      // 이미지가 돌지않고 원모양으로 돌게 하기위해 z값을 0 으로
    }

}
