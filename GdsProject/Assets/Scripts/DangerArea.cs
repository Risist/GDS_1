using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public class DangerArea : MonoBehaviour
{
    public DangerManager.EDangerType dangerType;
    public string playerTag = "Player";

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag(playerTag))
            DangerManager.instance.SetDanger(dangerType);
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag(playerTag))
            DangerManager.instance.UnsetDanger(dangerType);
    }
}
