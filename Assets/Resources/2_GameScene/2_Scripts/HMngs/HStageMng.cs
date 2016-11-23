using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using MHomiLibrary;

public class HStageMng : HSingletonScene<HStageMng> {

    protected HStageMng() { }

    void Awake()
    {
        cSceneList = new Dictionary<string, HState>();

        for (int i = 0; i < SceneList.Count; i++)
            cSceneList.Add(GetClassName(SceneList[i].ToString()), SceneList[i]);
    }

    public UILabel StageInfoLabel = null;


    void Start()
    {
        ChangeScene("HStage1");        
    }

    void OnDestroy()
    {
        cSceneList.Clear();
        cSceneList = null;
    }

    public void ChangeInfo(string sText)
    {
        StageInfoLabel.text = sText;
    }

    public void ChangeScene()
    {
        if (HGameMng.I.bPlayerDie == true)
        {
            switch (HGameMng.I.nStage)        // 스테이지 들어가기
            {
                case (int)E_STAGE.E_STAGE1:
                    HStageMng.I.ChangeScene("SStage1");
                    break;
                case (int)E_STAGE.E_STAGE2:
                    HStageMng.I.ChangeScene("SStage2");
                    break;
                case (int)E_STAGE.E_STAGE3:
                    HStageMng.I.ChangeScene("SStage3");
                    break;
                case (int)E_STAGE.E_STAGE4:
                    HStageMng.I.ChangeScene("SStage4");
                    break;
                case (int)E_STAGE.E_STAGE5:
                    HStageMng.I.ChangeScene("SStage5");
                    break;
                case (int)E_STAGE.E_STAGE6:
                    if (HGameMng.I.SBombScrp.bBombDie == true)
                    {
                        if (HGameMng.I.SBombScrp.BombSAni.frameIndex == 5)
                            HStageMng.I.ChangeScene("SStage6");
                    }
                    else
                    {
                        HStageMng.I.ChangeScene("SStage6");
                    }
                    break;
                case (int)E_STAGE.E_MAX:
                    if (HGameMng.I.SBombScrp.bBombDie == true)
                    {
                        if (HGameMng.I.SBombScrp.BombSAni.frameIndex == 5)
                            HStageMng.I.ChangeScene("SLastScene");
                    }
                    else
                    {
                        HStageMng.I.ChangeScene("SLastScene");
                    }
                    break;
            }
        }

        else
        {
            HGameMng.I.fMonSpeed = 0f;

            HGameMng.I.SresultGame.SetActive(true);        // 결과창 띄우기
        }
    }
}
