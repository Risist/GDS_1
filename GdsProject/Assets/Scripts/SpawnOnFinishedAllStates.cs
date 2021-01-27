using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public class SpawnOnFinishedAllStates : MonoBehaviour
{
    public GameObject objectToSpawn;
    public Vector3 spawnPointOffset = Vector3.forward;

    void OnFinishedAllStates(Ai.SimpleBehaviourController.EFinishAction finishAction)
    {
        Instantiate(objectToSpawn, transform.position + spawnPointOffset, Quaternion.identity);
    }
}
