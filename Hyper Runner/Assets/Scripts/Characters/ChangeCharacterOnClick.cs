using UnityEngine;
using UnityEngine.UI;

namespace Characters
{
    /// <summary>
    /// Changes current character when Interactable is clicked
    /// TODO: Not finished, does not work yet. 
    /// </summary>
    public class ChangeCharacterOnClick : MonoBehaviour
    {
        [SerializeField] private Button button;
        [SerializeField] private string nameOfCharacter;
        
        void Start()
        {
            //button.onClick.AddListener(OnButtonClicked);
        }

        private void OnButtonClicked()
        {
            CharacterSelect.Instance.ChangeCurrentCharacter(nameOfCharacter);
        }
    }
}
