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
        public float averageTime;
        [Range(0,1)]
        public float completionPercentStart;

        [Range(0, 1)]
        public float completionPercentFinish;
    }
    public LevelData[] levelDatas;
    public static int currentLevelId;

    static float lastCheckpoint;

    CarMovementController _playerMovement;

    public static MinimalTimer _timer = new MinimalTimer(); 

    [Header("UI")]
    public Text currentLevelName;
    public Text currentTimeName;
    public Image levelCompletionFillBar;
    public Text topRecordText;

    private void Start()
    {
        _playerMovement = GameObject.FindGameObjectWithTag("Player")?.GetComponent<CarMovementController>();
        if(_playerMovement)
            _playerMovement.textureXposition = lastCheckpoint;

        currentLevelName.text = levelDatas[currentLevelId].levelName;

        float topRecordTime = levelDatas[currentLevelId].averageTime;
        topRecordText.text = (int)topRecordTime / 60 + ":" + (int)topRecordTime % 60;
    }

    private void Update()
    {
        float time = _timer.ElapsedTime();
        currentTimeName.text = "" + (int)time/60 + ":" + (int)time % 60;

        if (!_playerMovement)
            return;

        float levelCompletion = _playerMovement.textureXposition / GroundTileManager.instance.levelLenght;
        float barFillPercent = Mathf.Lerp(
            levelDatas[currentLevelId].completionPercentStart,
            levelDatas[currentLevelId].completionPercentFinish,
            levelCompletion);

        levelCompletionFillBar.fillAmount = barFillPercent;
    }

    public void RecordCheckpoint(string checkpointName)
    {
        lastCheckpoint = _playerMovement.textureXposition;
        currentLevelName.text = checkpointName;
        PointManager.instance.SaveCheckpointPoints();
    }
    public void ResetToLastCheckpoint()
    {
        PointManager.instance.SaveCheckpointPoints();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex, LoadSceneMode.Single);
    }
    public void LoadNextLevel()
    {
        ++currentLevelId;
        _timer.Restart();
        PointManager.instance.SaveCheckpointPoints();

        lastCheckpoint = levelDatas[currentLevelId].initialCheckpoint;
        LivesManager.instance.ResetLives();
        SceneManager.LoadScene(levelDatas[currentLevelId].buildIndex, LoadSceneMode.Single);
    }
    public void LoadFirstLevel()
    {
        currentLevelId = 0;
        _timer.Restart();
        PointManager.instance.ResetCheckpointPoints();

        lastCheckpoint = levelDatas[currentLevelId].initialCheckpoint;
        LivesManager.instance.ResetLives();
        SceneManager.LoadScene(levelDatas[currentLevelId].buildIndex, LoadSceneMode.Single);
    }
}
