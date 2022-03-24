using UnityEngine;
using UnityEngine.UI;

public class UIHandler : MonoBehaviour
{
    [SerializeField] GameObject towerGameWinText;
    [SerializeField] Text towerGameScore;

    [SerializeField] GameObject skittleGameWinText;
    [SerializeField] Text skittleGameScore;

    [SerializeField] GameObject factoryGameOverText;
    [SerializeField] Text factoryGameTimeText;
    [SerializeField] Text factoryGameScoreText;

    private void Start()
    {
        TowerGameManager.ins.OnWin += TowerGameOnWinEventHandler;
        TowerGameManager.ins.OnScoreUpdated += UpdateTowerGameScore;


        SkittleManager.ins.OnGameOver += SkittleGameOnGameOverEventHandler;
        SkittleManager.ins.OnScoreUpdated += UpdateSkittleGameScore;

        FactoryWorkerGameManager.ins.OnGameOver += FactoryGameOnGameOverEventHandler;
        FactoryWorkerGameManager.ins.OnScoreUpdated += UpdateFactoryGameScore;

        towerGameWinText.SetActive(false);
        skittleGameWinText.SetActive(false);
        factoryGameOverText.SetActive(false);
    }

    private void LateUpdate()
    {
        factoryGameTimeText.text = ((int)(FactoryWorkerGameManager.ins.totalTime - FactoryWorkerGameManager.ins.currentTime)).ToString();
    }

    void UpdateTowerGameScore()
    {
        towerGameScore.text = "Score: " + (TowerGameManager.ins.currentlyStackedBlocks).ToString();
    }

    void TowerGameOnWinEventHandler()
    {
        towerGameWinText.SetActive(true);
    }

    public void HandleTowerGameRestartButton()
    {
        towerGameWinText.SetActive(false);
        TowerGameManager.ins.Restart();
    }

    void UpdateSkittleGameScore()
    {
        skittleGameScore.text = "Score: " + (9 - SkittleManager.ins.numberOfPinsLeft).ToString();
    }

    void SkittleGameOnGameOverEventHandler()
    {
        skittleGameWinText.SetActive(true);
    }

    public void HandleSkittleGameRestartButton()
    {
        skittleGameWinText.SetActive(false);
        SkittleManager.ins.Restart();
    }


    void UpdateFactoryGameScore()
    {
        factoryGameScoreText.text = "Score: " + FactoryWorkerGameManager.ins.score.ToString();
    }

    void FactoryGameOnGameOverEventHandler()
    {
        factoryGameOverText.SetActive(true);
    }

    public void HandleFactoryGameRestartButton()
    {
        factoryGameOverText.SetActive(false);
        FactoryWorkerGameManager.ins.Restart();
    }

}