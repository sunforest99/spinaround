using UnityEngine;
using System.Collections;

/// <summary>
/// 몬스터 생성하는 곳 (호출은 SStage(1 ~ 5) 에서)
/// 위치 : SMonsterGroup
/// </summary>

public class SMGroup_7 : MonoBehaviour
{
    public SMonsterRDown[] SMonsterCtrlScrp;     // 몬스터의 스크립트

    public void CreateMonster()
    {
        for (int i = 0; i < SMonsterCtrlScrp.Length; i++)
        {
            if (!SMonsterCtrlScrp[i].bPosCheck)
            {
                SMonsterCtrlScrp[i].RandMonster();
            }

            if (!SMonsterCtrlScrp[i].bDie)
            { 
                SMonsterCtrlScrp[i].bPosCheck = true;

                SMonsterCtrlScrp[i].bDie = true;
                break;
            }
        }
    }
}
