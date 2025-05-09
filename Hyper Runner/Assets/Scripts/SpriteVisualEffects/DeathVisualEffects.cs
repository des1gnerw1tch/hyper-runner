using UnityEngine;

namespace SpriteVisualEffects
{
    public class DeathVisualEffects : MonoBehaviour
    {
        [SerializeField] private GameObject deathParticles;
        [SerializeField] private SpriteRenderer characterSpriteRenderer;
        [SerializeField] private GameObject motivationBar;
        
        public static DeathVisualEffects Instance { get; private set; }

        private void Awake()
        {
            if (Instance != null && Instance != this)
            {
                Destroy(this);
            }
            else
            {
                Instance = this;
            }
        }

        public void HideCharacterSprite() => characterSpriteRenderer.enabled = false;
        public void ActivateDeathParticles() => deathParticles.SetActive(true);
        public void DisableMotivationBar() => motivationBar.SetActive(false);
    }
}
