using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LivesManager : MonoSingleton<LivesManager>
{
    public int maxLives;
    static int currentLives;
    static bool initialized;

    public bool hasAnyLives => currentLives > 0;
    
    [Header("UI")]
    public GameObject deathObject;
    public Text livesText;

    public void ResetLives()
    {
        currentLives = maxLives;
        livesText.text = "" + currentLives;
    }
    public void GainLive(int i)
    {
        ++currentLives;
        livesText.text = "" + currentLives;
    }

    public void OpenGameOver()
    {
        deathObject.SetActive(true);
    }
    public void DeathScreanButton()
    {
        SceneManager.LoadScene(0);
    }

    // returns if still can Play
    public bool LooseLive()
    {
        --currentLives;
        livesText.text = "" + currentLives;
        return hasAnyLives;
    }

    private void Start()
    {
        if(!initialized)
        {
            initialized = true;
            ResetLives();
        }

        livesText.text = "" + currentLives;
    }
}
