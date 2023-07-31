using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Serialization;

namespace MiniGames
{
    public class MiniGameInputManager : MonoBehaviour
    {
        public UnityEvent OnReelRod { get; } = new UnityEvent();
        
        // Finished exiting the fishing game by holding the exit key
        public UnityEvent OnExitGameInput { get; } = new UnityEvent();
    
        // Starting to exit the fishing game by tapping the exit key
        public UnityEvent OnStartExitGameInput { get; }= new UnityEvent();
        
        // Exit game input is released.
        public UnityEvent OnStopExitGame { get; }= new UnityEvent();
        
        public static MiniGameInputManager Instance { get; private set; }

        private void Awake()
        {
            if (Instance != null && Instance != this)
            {
                Debug.LogError("Two FishingInputManagers, destroying one.");
                Destroy(this.gameObject);
            }
            else
            {
                Instance = this;
            }
        }

        #region PlayerInput Broadcasts
        private void OnExitGame() => OnExitGameInput.Invoke();
        private void OnStartExitGame() => OnStartExitGameInput.Invoke();
        private void OnReleaseExit() => OnStopExitGame.Invoke();
        
        // Fishing game
        private void OnReel() => OnReelRod.Invoke();
        #endregion
    }
}
