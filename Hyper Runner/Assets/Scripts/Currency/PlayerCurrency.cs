using SaveFileSystem;
using UnityEngine;
using UnityEngine.Events;

namespace Currency
{
    /// <summary>
    /// Stores how much money the player has, and handles transactions during runtime.
    /// </summary>
    public class PlayerCurrency : MonoBehaviour
    {
        public static PlayerCurrency Instance { get; private set; }

        public UnityEvent PlayerBalanceChanged { get; } = new UnityEvent();

        private SaveLoadData saveLoadData;
        
        private void Awake()
        {
            if (Instance != null && Instance != this)
            {
                Destroy(this.gameObject);
            }
            else
            {
                Instance = this;
            }
        }

        private void Start() => saveLoadData = SaveLoadData.Instance;

        public int AddBalance(int num)
        {
            int newValue = saveLoadData.GetNumTokens() + num;
            
            if (newValue < 0)
            {
                Debug.LogError("Insufficient funds");
                return -1;
            }

            if (saveLoadData.GetNumTokens() != newValue)
            {
                saveLoadData.SetNewTokenBalance(newValue);
                PlayerBalanceChanged.Invoke();
            }
            
            return saveLoadData.GetNumTokens();
        }
    }
}
