using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace MainMenuSystem
{
    public class Volume : MonoBehaviour
    {
        [SerializeField] private Slider volumeSlider;
        [SerializeField] private TextMeshProUGUI text;

        private void Start()
        {
            volumeSlider.value = 100f;
            text.text = Math.Round((volumeSlider.value * 100f), 0).ToString();
        }

        public void ChangeVolume()
        {
            AudioListener.volume = volumeSlider.value;
            text.text = Math.Round((volumeSlider.value * 100f), 0).ToString();
        }
    }
}
