using UnityEngine;
using System.Collections;

/// <summary>
/// 결과창 띄우고 시간계산(점수)
/// 위치 : SResultGroup
/// </summary>

public class SResultGroup : MonoBehaviour
{
    public UILabel TimerLable = null;

    Vector2 PosVec = Vector2.zero;

    // Use this for initialization
    void Start()
    {
        PosVec.x = -4000f;
        transform.localPosition = PosVec;
    }

    // Update is called once per frame
    void Update()
    {
        string str = string.Format("{0:f2}", HGameMng.I.fResultTime);

        TimerLable.text = str;
        SetPos();
    }

    void SetPos()
    {
        if(HGameMng.I.bPlayerDie == false)
        {
            transform.localPosition = Vector3.zero;
        }
    }
}
