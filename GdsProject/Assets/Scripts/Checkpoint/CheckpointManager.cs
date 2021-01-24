using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CheckpointManager : MonoSingleton<CheckpointManager>
{
    [System.Serializable]
    public struct LevelData
    {
        public int buildIndex;
        public float initialCheckpoint;
        public string levelName;
        [Range(0,1)]
        public float completionPercentStart;

        [Range(0, 1)]
        public float completionPercentFinish;
    }
    public LevelData[] levelDatas;
    public int currentLevelId;

    static float lastCheckpoint;
    static float lastCheckpointTime;

    CarMovementController _playerMovement;

    MinimalTimer _timer = new MinimalTimer(); 

    [Header("UI")]
    public Text currentLevelName;
    public Text currentTimeName;
    public Image levelCompletionFillBar;

    private void Start()
    {
        _playerMovement = GameObject.FindGameObjectWithTag("Player")?.GetComponent<CarMovementController>();
        if(_playerMovement)
            _playerMovement.textureXposition = lastCheckpoint;

        currentLevelName.text = levelDatas[currentLevelId].levelName;
        _timer.Restart();
    }

    private void Update()
    {
        float time = lastCheckpointTime + _timer.ElapsedTime();
        currentTimeName.text = "" + (int)time/60 + ":" + (int)time % 60;

        if (!_playerMovement)
            return;

        float levelCompletion = _playerMovement.textureXposition / GroundTileManager.instance.levelLenght;
        float barFillPercent = Mathf.Lerp(
            levelDatas[currentLevelId].completionPercentStart,
            levelDatas[currentLevelId].completionPercentFinish,
            levelCompletion);

        levelCompletionFillBar.fillAmount = levelCompletion;
    }

    public void RecordCheckpoint()
    {
        lastCheckpoint = _playerMovement.textureXposition;
        lastCheckpointTime += _timer.ElapsedTime();
        _timer.Restart();
    }
    public void ResetToLastCheckpoint()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex, LoadSceneMode.Single);
    }
    public void LoadNextLevel()
    {
        ++currentLevelId;
        lastCheckpointTime += _timer.ElapsedTime();
        _timer.Restart();

        lastCheckpoint = levelDatas[currentLevelId].initialCheckpoint;
        LivesManager.instance.ResetLives();
        SceneManager.LoadScene(levelDatas[currentLevelId].buildIndex, LoadSceneMode.Single);
    }
    public void LoadFirstLevel()
    {
        currentLevelId = 0;
        lastCheckpointTime = 0;
        _timer.Restart();

        lastCheckpoint = levelDatas[currentLevelId].initialCheckpoint;
        LivesManager.instance.ResetLives();
        SceneManager.LoadScene(levelDatas[currentLevelId].buildIndex, LoadSceneMode.Single);
    }
}
