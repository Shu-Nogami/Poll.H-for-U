using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class InGameTimeView : MonoBehaviour
    {
        [SerializeField] private Text timeText;

        public void SetTime(string timeString)
        {
            timeText.text = timeString;
        }
    }
}