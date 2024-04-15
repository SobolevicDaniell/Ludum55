using TMPro;
using UnityEngine;

namespace GoldSystem
{
    public class GoldView : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI goldText;
        private Gold _gold;

        public void Construct(Gold gold)
        {
            _gold = gold;
        }

        private void Start()
        {
            _gold.OnScoreChange += RefreshGoldText;
            goldText.text = $"score: {_gold.GoldValue}";
        }

        private void RefreshGoldText(int curScore)
        {
            goldText.text = $"score: {curScore}";
        }

        private void OnDisable()
        {
            _gold.OnScoreChange -= RefreshGoldText;
        }
    }
}
