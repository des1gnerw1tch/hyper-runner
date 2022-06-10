using UnityEngine;

namespace Currency
{
    /// <summary>
    /// Stores how much money the player has, and handles transactions.
    /// </summary>
    public class PlayerCurrency : MonoBehaviour
    {
        private int coins;
        
        public static PlayerCurrency Instance { get; private set; }
        
        private void Start()
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

        public int CurrentBalance() => coins;

        public void SubtractBalance(int num)
        {
            if (num > coins)
            {
                Debug.LogError("Insufficient funds");
                return;
            }
            
            coins -= num;
        }

        public void AddBalance(int num) => coins += num;
    }
}
