using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Achievements
{
    public class AchievementUIElement : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI tokenRewardText;
        [SerializeField] private Image border;

        public int GetNumRewardTokens() => int.Parse(tokenRewardText.text);

        public void ShowAchievementCompleted()
        {
            //TODO: Make this a checkmark or something more aesthetically pleasing...
            
            border.color = Color.green;
        }
    }
}
