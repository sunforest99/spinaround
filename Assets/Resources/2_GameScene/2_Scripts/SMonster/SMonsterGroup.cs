using UnityEngine;
using System.Collections;

/// <summary>
/// 몬스터 생성하는 곳 (호출은 SStage(1 ~ 5) 에서)
/// 위치 : SMonsterGroup
/// </summary>

public class SMonsterGroup : MonoBehaviour
{
    //public GameObject[] SMonsterGame;
    public SMonsterCtrl[] SMonsterCtrlScrp;     // 몬스터의 스크립트

    public void CreateMonster()
    {
        for (int i = 0; i < SMonsterCtrlScrp.Length; i++)
        {
            if (SMonsterCtrlScrp[i].bDie == false /*&& HGameMng.I.TimeCtrl((int)E_TIME.E_MONSTER_TIME, 0.1f)*/)
            {
                //SMonsterCtrlScrp[i].RandMonster();

                SMonsterCtrlScrp[i].bPosCheck = true;

                SMonsterCtrlScrp[i].bDie = true;
                break;
            }
        }
    }
}
