using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections.Generic;

public class GameManager : Singleton<GameManager>
{
    private GameObject _gameOverCanvas;
    private GameObject _gameClearCanvas;

    private readonly List<int> _stageList = new List<int>();
    private const int TotalStageCount = 1;
    
    private void Start()
    {
        InitCanvas();
        InitStageList();
    }
    
    void InitCanvas()
    {
        if (_gameOverCanvas == null)
        {
            Transform overTransform = transform.Find("GameOver_Canvas");
            if (overTransform != null) _gameOverCanvas = overTransform.gameObject;
        }
        else
        {
            Debug.Log("GameOverCanvas == null");
        }

        if (_gameClearCanvas == null)
        {
            Transform clearTransform = transform.Find("GameClear_Canvas");
            if (clearTransform != null) _gameClearCanvas = clearTransform.gameObject;
        }
        else
        {
            Debug.Log("GameClearCanvas == null");
        }

        // 초기 상태는 비활성화
        _gameOverCanvas.SetActive(false);
        _gameClearCanvas.SetActive(false);
    }

    void InitStageList()
    {
        _stageList.Clear();
        for (int i = 1; i <= TotalStageCount; i++)
        {
            _stageList.Add(i);
        }
    }

    public void LoadNextRandomStage()
    {
        Time.timeScale = 1f;

        if (_stageList.Count > 0)
        {
            int randomIndex = Random.Range(0, _stageList.Count);
            int stageNum = _stageList[randomIndex];
            _stageList.RemoveAt(randomIndex);

            SceneManager.LoadScene("Stage_" + stageNum);
            SoundManager.Instance.PlayStoppableSfx("SFX/Common/game-start");
        }
        else
        {
            ShowGameClear();
        }
    }

    public void OnGameOver()
    {
        Time.timeScale = 0f;
        _gameOverCanvas.SetActive(true);
    }

    public void RestartGame()
    {
        Time.timeScale = 1f;
        InitStageList(); 
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        // LoadNextRandomStage();

        SoundManager.Instance.StopSfx();
        
        _gameOverCanvas.SetActive(false);
        _gameClearCanvas.SetActive(false);
    }

    public void ShowGameClear()
    {
        Time.timeScale = 0f;
        _gameClearCanvas.SetActive(true);
        // TODO: game-clear 사운드로 변경
        SoundManager.Instance.PlayStoppableSfx("SFX/Common/stage-clear");
    }
}