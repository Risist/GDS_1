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
    }

    public void RecordCheckpoint()
    {
        lastCheckpoint = _playerMovement.textureXposition;
    }
    public void ResetToLastCheckpoint()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex, LoadSceneMode.Single);

        _playerMovement.textureXposition = lastCheckpoint;
    }
    public void LoadNextLevel(int levelIndex)
    {
        currentLevelId = levelIndex;

        SceneManager.LoadScene(levelDatas[currentLevelId].buildIndex, LoadSceneMode.Single);
        lastCheckpoint = levelDatas[currentLevelId].initialCheckpoint;

        _playerMovement.textureXposition = lastCheckpoint;
    }
}
