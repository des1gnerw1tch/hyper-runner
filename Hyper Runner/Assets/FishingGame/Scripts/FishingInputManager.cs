using UnityEngine;
using UnityEngine.Events;

namespace FishingGame.Scripts
{
    public class FishingInputManager : MonoBehaviour
    {
        public UnityEvent OnReelRod { get; private set; } = new UnityEvent();
        
        // Finished exiting the fishing game by holding the exit key
        public UnityEvent OnExitFishingGame { get; private set; } = new UnityEvent();
    
        // Starting to exit the fishing game by tapping the exit key
        public UnityEvent OnStartExitFishingGame = new UnityEvent();
        
        public static FishingInputManager Instance { get; private set; }

        void Awake()
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

        void OnReel() => OnReelRod.Invoke();

        void OnExitGame()
        {
            Debug.Log("Should exited fishing game!");
            OnExitFishingGame.Invoke();
        } 
        
        void OnStartExitGame() {
            Debug.Log("Should show animation for exiting fishing game!");
            OnStartExitFishingGame.Invoke();
        }
    }
}
