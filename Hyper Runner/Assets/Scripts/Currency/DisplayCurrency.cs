using SaveFileSystem;
using TMPro;
using UnityEngine;

namespace Currency
{
    public class DisplayCurrency : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI textObject;

        private void Start()
        {
            UpdateText();
            GameDataManager.Instance.PlayerBalanceChanged.AddListener(UpdateText);
        }

        private void UpdateText() => textObject.text = GameDataManager.Instance.GetNumTokens() + "";

    }
}
