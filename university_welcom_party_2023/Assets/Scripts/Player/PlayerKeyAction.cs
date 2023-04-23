using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using Player;
using UnityEngine;

public class PlayerKeyAction : MonoBehaviour
{
    private PlayerUpdateSprite _playerUpdateSprite;
    private bool isBattle;

    private void Awake()
    {
        _playerUpdateSprite = gameObject.GetComponent<PlayerUpdateSprite>();
        Initialize();
    }

    public void Initialize()
    {
        isBattle = false;
    }

    void Update()
    {
        if (isBattle)
        {
            BattleKeyDownAction();
        }
    }

    public void StartBattle()
    {
        isBattle = true;
    }

    public void EndBattle()
    {
        isBattle = false;
    }

    private void BattleKeyDownAction()
    {
        if (Input.GetButtonDown("Up"))
        {
            _playerUpdateSprite.SetPlayerAttackUpSprite();
            InGameManager.InGameInstance.AddDamageEnemy(EnemyPosition.Up);
        }

        if (Input.GetButtonDown("Down"))
        {
            _playerUpdateSprite.SetPlayerAttackDownSprite();
            InGameManager.InGameInstance.AddDamageEnemy(EnemyPosition.Down);
        }

        if (Input.GetButtonDown("Right"))
        {
            _playerUpdateSprite.SetPlayerAttackRightSprite();
            InGameManager.InGameInstance.AddDamageEnemy(EnemyPosition.Right);
        }

        if (Input.GetButtonDown("Left"))
        {
            _playerUpdateSprite.SetPlayerAttackLeftSprite();
            InGameManager.InGameInstance.AddDamageEnemy(EnemyPosition.Left);
        }
    }
}
