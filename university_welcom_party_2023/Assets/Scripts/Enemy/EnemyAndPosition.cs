using System;
using UnityEngine;

public class EnemyAndPosition
{
    private EnemyStatus _enemyStatus;
    private EnemyPosition _enemyPosition;
    
    public void SetEnemyStatus(EnemyStatus enemyStatus)
    {
        _enemyStatus = enemyStatus;
    }

    public void SetEnemyPosition(EnemyPosition enemyPosition)
    {
        _enemyPosition = enemyPosition;
    }

    public EnemyStatus GetEnemyStatus()
    {
        return _enemyStatus;
    }

    public EnemyPosition GetEnemyPosition()
    {
        return _enemyPosition;
    }

    public void SlideEnemyPosition()
    {
        Vector3 positionCorrection;
        switch (_enemyPosition)
        {
            case EnemyPosition.Up:
                positionCorrection = new Vector3(0, -1, 0);
                break;
            case EnemyPosition.Down:
                positionCorrection = new Vector3(0, 1, 0);
                break;
            case EnemyPosition.Right:
                positionCorrection = new Vector3(-1, 0, 0);
                break;
            case EnemyPosition.Left:
                positionCorrection = new Vector3(1, 0, 0);
                break;
            default:
                positionCorrection = new Vector3(0, 0, 0);
                break;
        }
        _enemyStatus.UpdateEnemyPosition(positionCorrection);
    }
}
