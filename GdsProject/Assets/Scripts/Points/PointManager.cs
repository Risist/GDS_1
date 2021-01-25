using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

public class PointManager : MonoSingleton<PointManager>
{
    static float lastCheckpointPoints;
    public int points;

    [Header("UI")]
    public Text pointsText;
    public AudioSource pointSound;

    public void ResetCheckpointPoints()
    {
        lastCheckpointPoints = 0;
        UpdateText();
    }
    public void SaveCheckpointPoints()
    {
        lastCheckpointPoints += points;
        points = 0;
        UpdateText();
    }

    public void GainPoints(int num)
    {
        points += num;
        //pointSound.PlayOneShot(pointSound.clip);
        UpdateText();
    }

    void UpdateText()
    {
        pointsText.text = "" + (lastCheckpointPoints + points);
    }

    private void Start()
    {
        UpdateText();
    }

}
