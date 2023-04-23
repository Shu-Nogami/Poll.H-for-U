using System;
using UnityEngine;

namespace UI
{
    public class HowToButton : MonoBehaviour
    {
        [SerializeField] private GameObject howToCanvas;
        public void OnClick()
        {
            SoundManager.SoundManagerInstance.SetButtonSE();
            howToCanvas.SetActive(true);
        }
    }
}