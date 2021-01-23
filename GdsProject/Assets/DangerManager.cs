using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DangerManager : MonoSingleton<DangerManager>
{
    public enum EDangerType
    {
        EMines,
        EFight,
        ECount
    }
    [System.Serializable]
    public class DangerRecord
    {
        public EDangerType type;
        public Image image;

        [HideInInspector]
        public bool flag;

        [HideInInspector]
        public float timeSetUp;
    }
    public DangerRecord[] dangerData;
    public GameObject anyIndicator;
    public float animationSpeed;
    public float backAnimationSpeed;

    public void SetDanger(EDangerType type)
    {
        foreach(var it in dangerData)
            if(!it.flag && it.type == type)
            {
                it.flag = true;
                it.timeSetUp = Time.time;
            }
    }
    public void UnsetDanger(EDangerType type)
    {
        foreach (var it in dangerData)
            if (it.type == type)
            {
                it.flag = false;
            }
    }

    private void Update()
    {
        bool any = false;
        foreach(var it in dangerData)
            if(it.flag)
            {
                var color = it.image.color;
                float timeElapsed = Time.time - it.timeSetUp;
                color.a = Mathf.Cos(timeElapsed* animationSpeed);
                it.image.color = color;

                any = true;
            }else
            {
                var color = it.image.color;
                color.a = Mathf.MoveTowards(color.a, 0, backAnimationSpeed * Time.deltaTime);
                it.image.color = color;
            }

        anyIndicator.SetActive(any);
    }
}
