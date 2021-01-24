using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SummaryScrean : MonoSingleton<SummaryScrean>
{
    public GameObject summaryScrean;
    [Space]
    public Text timeToReachPointText;
    public Text yourTimeText;
    public Text bonusPointsText;
    public Text topRecordText;
    public GameObject brokenRecord;
    public GameObject noBonus;
    [Space]
    public GameObject buttonNextLevel;
    public GameObject buttonBackToMenu;



    public void Open(float time)
    {
        summaryScrean.SetActive(true);
        var carMovement = GameObject.FindGameObjectWithTag("Player")?.GetComponent<CarMovementController>();
        carMovement.enabled = false;

        // TODO Letter

        float topRecordTime = CheckpointManager.instance.levelDatas[CheckpointManager.instance.currentLevelId].averageTime;
        topRecordText.text = (int)topRecordTime / 60 + ":" + (int)topRecordTime % 60;
        
        yourTimeText.text = (int)time / 60 + ":" + (int)time % 60;

        bool broken = time < topRecordTime;
        brokenRecord.SetActive(broken);
        noBonus.SetActive(!broken);

        if (broken)
        {
            int points = 1000 + 100 * ((int)topRecordTime - (int)time);
            PointManager.instance.GainPoints(points);
            bonusPointsText.text = "" + points;

        }else
        {
            bonusPointsText.text = "0";
        }

        bool isThereNextLevel = CheckpointManager.instance.currentLevelId + 1 < CheckpointManager.instance.levelDatas.Length;


        buttonNextLevel.SetActive(isThereNextLevel);
        buttonBackToMenu.SetActive(!isThereNextLevel);
    }

    public void NextLevel()
    {
        CheckpointManager.instance.LoadNextLevel();
    }

    public void BackToMenu()
    {
        SceneManager.LoadScene(0);
    }
}
