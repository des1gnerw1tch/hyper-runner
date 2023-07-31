using UnityEngine;
using UnityEngine.SceneManagement;

namespace MiniGames
{
    public class ExitMiniGameMachine : MonoBehaviour
    {
        [SerializeField] private GameObject quittingGameText;
        
        private void Start()
        {
            // Will spawn back in Menu at the correct arcade machine position
            LoadArcadeScene.sceneFrom = SceneManager.GetActiveScene().name;
            
            MiniGameInputManager.Instance.OnExitGameInput.AddListener(ExitFishingGame);
            MiniGameInputManager.Instance.OnStartExitGameInput.AddListener(ShowQuittingGameText);
            MiniGameInputManager.Instance.OnStopExitGame.AddListener(HideQuittingGameText);
        }

        public void ExitFishingGame() => SceneManager.LoadScene("Menu");
        private void ShowQuittingGameText() => quittingGameText.SetActive(true);
        private void HideQuittingGameText() => quittingGameText.SetActive(false);
    }
}
