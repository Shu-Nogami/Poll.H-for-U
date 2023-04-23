using UI;
using UnityEngine;

namespace System
{
    public class InGameTimeKeeper : MonoBehaviour
    {
        private readonly float BEFORE_TIME = 4.0f;
        private readonly float BATTLE_TIME = 61.0f;

        [SerializeField] private InGameTimeView _beforeInGameTimeView;
        [SerializeField] private InGameTimeView _battleInGameTimeView;
        private float time;
        private bool isCountDown;
        private bool isBattle;

        private void Awake()
        {
            Initialize();
        }

        private void Initialize()
        {
            isCountDown = false;
            isBattle = false;
            time = BEFORE_TIME;
        }

        private void Update()
        {
            if (isCountDown)
            {
                if (isBattle)
                {
                    BattleTimeCountDown();
                }
                else
                {
                    BeforeTimeCountDown();
                }
            }
        }

        public void BeforeBattle()
        {
            time = BEFORE_TIME;
            isBattle = false;
            isCountDown = true;
        }

        public void StartBattle()
        {
            time = BATTLE_TIME;
            isBattle = true;
            isCountDown = true;
        }

        public void EndBattle()
        {
            isCountDown = false;
        }
        
        private void BeforeTimeCountDown()
        {
            time -= Time.deltaTime;
            _beforeInGameTimeView.SetTime(((int)time).ToString());
            if(time <= 0) InGameManager.InGameInstance.StartGame();
        }

        private void BattleTimeCountDown()
        {
            time -= Time.deltaTime;
            _battleInGameTimeView.SetTime("Time ： " + (int)time);
            if(time <= 0) InGameManager.InGameInstance.GameEnd();
        }
    }
}