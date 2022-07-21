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
            PlayerCurrency.Instance.PlayerBalanceChanged.AddListener(UpdateText);
        }

        private void UpdateText() => textObject.text = SaveLoadData.Instance.GetNumTokens() + "";

    }
}
