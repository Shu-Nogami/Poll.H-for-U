using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class EnemyStatus : MonoBehaviour
{
    [SerializeField] private int breakCount;
    [SerializeField] private List<Sprite> enemyImages;
    [SerializeField] private int scorePoint;

    private SpriteRenderer _spriteRenderer;

    private void Awake()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        UpdateEnemySprite();
    }
    
    public int GetBreakCount()
    {
        return breakCount;
    }

    public int GetScorePoint()
    {
        return scorePoint;
    }

    public void ToDamage()
    {
        breakCount--;
        if (breakCount <= 0)
        {
            InGameManager.InGameInstance.DeadEnemy();
            Destroy(gameObject);
        }
        else
        {
            UpdateEnemySprite();
        }
    }

    private void UpdateEnemySprite()
    {
        _spriteRenderer.sprite = enemyImages[breakCount - 1];
    }

    public void UpdateEnemyPosition(Vector3 positionCorrection)
    {
        gameObject.transform.position += positionCorrection;
    }
}
