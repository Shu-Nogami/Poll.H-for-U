using System;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace UI
{
    public class ExitButton : MonoBehaviour
    {
        [SerializeField] private string titleSceneName;
        public void OnClick()
        {
            SoundManager.SoundManagerInstance.SetButtonSE();
            SoundManager.SoundManagerInstance.SetOpeningBGM();
            SceneManager.LoadScene(titleSceneName);
        }
    }
}