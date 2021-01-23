using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CheckpointManager : MonoSingleton<CheckpointManager>
{
    [System.Serializable]
    public struct LevelData
    {
        public int buildIndex;
        public float initialCheckpoint;
    }
    public LevelData[] levelDatas;
    public int currentLevelId;
    static float lastCheckpoint;

    CarMovementController _playerMovement;

    private void Start()
    {
        _playerMovement = GameObject.FindGameObjectWithTag("Player")?.GetComponent<CarMovementController>();
        _playerMovement.textureXposition = lastCheckpoint;
    }

    public void RecordCheckpoint()
    {
        lastCheckpoint = _playerMovement.textureXposition;
    }
    public void ResetToLastCheckpoint()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex, LoadSceneMode.Single);
    }
    public void LoadNextLevel()
    {
        ++currentLevelId;

        lastCheckpoint = levelDatas[currentLevelId].initialCheckpoint;
        LivesManager.instance.ResetLives();
        SceneManager.LoadScene(levelDatas[currentLevelId].buildIndex, LoadSceneMode.Single);
    }
}
