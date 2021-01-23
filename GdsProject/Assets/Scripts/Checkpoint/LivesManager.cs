using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LivesManager : MonoSingleton<LivesManager>
{
    public int maxLives;
    static int currentLives;
    static bool initialized;

    public bool hasAnyLives => currentLives > 0;
    public GameObject deathObject;

    public void ResetLives()
    {
        currentLives = maxLives;
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
        return hasAnyLives;
    }

    private void Start()
    {
        if(!initialized)
        {
            initialized = true;
            ResetLives();
        }
    }
}
