using UnityEngine;

namespace Achievements
{
    /// <summary>
    /// Handles bringing up Achievements UI window. Updates achievement UI elements when window is brought up
    /// </summary>
    public class AchievementsUIHelper : MonoBehaviour
    {
        [SerializeField] private GameObject achievementsWindow;

        private AchievementUIElement[] achievementUIElements;

        private void Start()
        {
            achievementUIElements = FindObjectsOfType<AchievementUIElement>(true);
            UIInputHandler.Instance.OnPause.AddListener(ToggleAchievementsWindow);
        }

        private void ToggleAchievementsWindow()
        {
            achievementsWindow.SetActive(!achievementsWindow.activeSelf);

            if (achievementsWindow.activeSelf)
            {
                foreach (AchievementUIElement element in achievementUIElements)
                {
                    element.UpdateContent();
                }

                UIInputHandler.Instance.PlayerInputComponent.SwitchCurrentActionMap("UI");
            }
            else
            {
                UIInputHandler.Instance.PlayerInputComponent.SwitchCurrentActionMap("3D");
            }
        }
    }
}
