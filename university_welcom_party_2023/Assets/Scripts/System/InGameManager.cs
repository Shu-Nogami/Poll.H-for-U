using System;
using System.Collections.Generic;
using Enemy;
using UnityEngine;
using Random = UnityEngine.Random;

public class InGameManager : MonoBehaviour
{
    [SerializeField] private GameObject _inGameBeforeView;
    [SerializeField] private InGameScoreAndLivesView _inGameScoreAndLivesView;
    [SerializeField] private InGameEndView _inGameEndView;
    [SerializeField] private PlayerKeyAction _playerKeyAction;
    [SerializeField] private InGameTimeKeeper _inGameTimeKeeper;

    public static InGameManager InGameInstance { get; private set; }
    
    private List<EnemyAndPosition> _enemyAndPositions;
    private EnemySpawn _enemySpawn;
    private int score;
    private int lives;
    private int comboAmount;
    private int maxComboAmount;

    private void Awake()
    {
        if (InGameInstance == null)
        {
            InGameInstance = this;
        }
        else
        {
            Destroy(gameObject);
        }
        Initialize();
    }

    public void Initialize()
    {
        EnemyInitialize();
        ScoreInitialize();
        LivesInitialize();
        ViewInitialize();
        TimeInitialize();
        ComboInitialize();
        MaxComboInitialize();
        SoundManager.SoundManagerInstance.StopSound();
    }

    private void EnemyInitialize()
    {
        _enemyAndPositions = new List<EnemyAndPosition>();
        _enemySpawn = new EnemySpawn();
        _enemySpawn.Initialize();
        _enemySpawn.Spawn(4);
    }

    private void ScoreInitialize()
    {
        score = 0;
    }

    private void LivesInitialize()
    {
        lives = 3;
    }
    
    private void ViewInitialize()
    {
        _inGameScoreAndLivesView.ViewScore(score);
        _inGameScoreAndLivesView.ViewLives(lives);
        _inGameScoreAndLivesView.ViewCombo(comboAmount);
    }

    private void TimeInitialize()
    {
        _inGameTimeKeeper.BeforeBattle();
    }

    private void ComboInitialize()
    {
        comboAmount = 0;
    }

    private void MaxComboInitialize()
    {
        maxComboAmount = 0;
    }
    
    public void AddEnemyList(GameObject enemy)
    {
        var enemyAndPosition = new EnemyAndPosition();
        var enemyRandomPosition = Random.Range(1, Enum.GetNames(typeof(EnemyPosition)).Length + 1);
        
        EnemySlidePosition.SetEnemyPosition(enemyRandomPosition, enemy);
        EnemySlidePosition.SlideEnemyPosition(_enemyAndPositions);
        
        enemyAndPosition.SetEnemyStatus(enemy.GetComponent<EnemyStatus>());
        enemyAndPosition.SetEnemyPosition((EnemyPosition)enemyRandomPosition);
        
        _enemyAndPositions.Add(enemyAndPosition);
    }

    public void AddDamageEnemy(EnemyPosition enemyPosition)
    {
        SoundManager.SoundManagerInstance.SetAttackSE();

        if (enemyPosition == _enemyAndPositions[0].GetEnemyPosition())
        {
            comboAmount++;
            _inGameScoreAndLivesView.ViewCombo(comboAmount);
            _enemyAndPositions[0].GetEnemyStatus().ToDamage();
        }
        else
        {
            LivesDecreased(1);
        }
    }

    private void AddScore()
    {
        var scorePoint = _enemyAndPositions[0].GetEnemyStatus().GetScorePoint();
        score += scorePoint;
        _inGameScoreAndLivesView.ViewScore(score);
    }

    private void LivesDecreased(int decreasedNumber)
    {
        CheckOverMaxComboAmount();
        ComboInitialize();
        lives -= decreasedNumber;
        if (lives <= 0)
        {
            lives = 0;
            GameEnd();
        }
        _inGameScoreAndLivesView.ViewCombo(comboAmount);
        _inGameScoreAndLivesView.ViewLives(lives);
    }

    private void CheckOverMaxComboAmount()
    {
        if (comboAmount > maxComboAmount) SwitchMaxComboAmount();
    }

    private void SwitchMaxComboAmount()
    {
        maxComboAmount = comboAmount;
    }

    public void StartGame()
    {
        _inGameTimeKeeper.StartBattle();
        _playerKeyAction.StartBattle();
        _inGameBeforeView.SetActive(false);
        SoundManager.SoundManagerInstance.SetBattleBGM();
    }

    public void GameEnd()
    {
        CheckOverMaxComboAmount();
        SoundManager.SoundManagerInstance.SetResultBGM();
        _playerKeyAction.EndBattle();
        SettingGameEndView();
        _inGameTimeKeeper.EndBattle();
    }

    private void SettingGameEndView()
    {
        _inGameEndView.gameObject.SetActive(true);
        _inGameEndView.ViewScore(score);
        _inGameEndView.ViewLives(lives);
        _inGameEndView.ViewMaxCombo(maxComboAmount);
        _inGameEndView.ViewTotalScore(CalcTotalScore());
    }

    private int CalcTotalScore()
    {
        var comboAmountMultiplyScore = 1 + (maxComboAmount % 10) * 0.1;
        var livesMultiplyScore = 1 + lives * 0.1;
        var totalScore = score * comboAmountMultiplyScore * livesMultiplyScore;
        return (int)totalScore;
    }

    public void DeadEnemy()
    {
        AddScore();
        DeleteEnemy();
        _enemySpawn.Spawn(1);
    }

    private void DeleteEnemy()
    {
        _enemyAndPositions.RemoveAt(0);
    }
}
