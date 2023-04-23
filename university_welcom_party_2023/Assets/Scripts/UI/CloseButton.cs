using System;
using UnityEngine;

namespace UI
{
    public class CloseButton : MonoBehaviour
    {
        [SerializeField] private GameObject nowCanvas;
        public void OnClick()
        {
            SoundManager.SoundManagerInstance.SetButtonSE();
            nowCanvas.SetActive(false);
        }
    }
}