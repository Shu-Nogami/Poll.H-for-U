using System;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace UI
{
    public class StartButton : MonoBehaviour
    {
        [SerializeField] private string nextSceneName;
        public void OnClick()
        {
            SceneManager.LoadScene(nextSceneName);
            SoundManager.SoundManagerInstance.SetGameStartSE();
        }
    }
}