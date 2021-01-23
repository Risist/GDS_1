using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public class LivesManager : MonoSingleton<LivesManager>
{
    public int maxLives;
    static int currentLives;
    static bool initialized;

    public bool hasAnyLives => currentLives > 0;

    public void ResetLives()
    {
        currentLives = maxLives;
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
