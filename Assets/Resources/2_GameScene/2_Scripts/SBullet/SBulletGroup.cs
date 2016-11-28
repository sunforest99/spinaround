using UnityEngine;
using System.Collections;

/// <summary>
/// 총알 생성하는 곳 (호출은 Mng & 보류)
/// 위치 : SBulletGroup
/// </summary>

public class SBulletGroup : MonoBehaviour
{
    public SBulletCtrl[] SBulletScrp = null;  // 총알 스크립트

    public GameObject SPlayerGame = null;      //플레이어 위치를 알려주기 위해

    public void CreateBullet()
    {
        for (int i = 0; i < SBulletScrp.Length; i++)
        {
            if (!SBulletScrp[i].bDie)       // 총알이 생성되지 않았을때 초기화후 생성
            {
                SBulletScrp[i].transform.localPosition = SPlayerGame.transform.localPosition;
                SBulletScrp[i].transform.localRotation = SPlayerGame.transform.localRotation;

                SBulletScrp[i].SBullet2D.enabled = true;
                SBulletScrp[i].SBulletSprite.enabled = true;


                SBulletScrp[i].bDie = true;
                break;
            }
        }
    }
}

