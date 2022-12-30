using System.Collections;
using UnityEngine;
using UnityEngine.Events;

namespace SpriteVisualEffects
{
    /**
     * Will fade the alpha value of a sprite. 
     */
    public class AlphaFade : MonoBehaviour
    {
        [SerializeField] private SpriteRenderer spriteRenderer;

        private Coroutine current;
        private UnityEvent fadeFinishedEvent = new UnityEvent();

        // Period of the fade cycle 
        private float periodTime;
        
        public void Fade(float fadeTime, float finalAlphaValue, bool deactivateAtEnd = false)
        {
            CancelCoroutine();
            
            current = StartCoroutine(_Fade(fadeTime, finalAlphaValue, deactivateAtEnd));
        } 
        
        private IEnumerator _Fade(float fadeTime, float finalAlpha, bool deactivateAtEnd)
        {
            Color spriteColor = spriteRenderer.color;
            float initialAlpha = spriteColor.a;
            
            float progress = 0;
            float timeElapsed = 0;
            while (progress < 1)
            {
                
                timeElapsed += Time.deltaTime;
                progress = timeElapsed / fadeTime;
                float newAlpha = Mathf.Lerp(initialAlpha, finalAlpha, progress);
                spriteRenderer.color = new Color(spriteColor.r, spriteColor.g, spriteColor.b, newAlpha);
                yield return new WaitForEndOfFrame();
            }
            
            current = null;
            fadeFinishedEvent.Invoke();
            
            if (deactivateAtEnd)
            {
                Debug.Log("GameObject deactivated");
                this.gameObject.SetActive(false);
            }
            
        }
        
        public void SetSpriteAlpha(float a)
        {
            Color spriteColor = spriteRenderer.color;
            spriteRenderer.color = new Color(spriteColor.r, spriteColor.g, spriteColor.b, a);
        }

        public void CancelCoroutine()
        {
            if (current != null)
            {
                Debug.Log("Canceled Coroutine");
                StopCoroutine(current);
                current = null;
            }
        }

        // Will cycle the sprite alpha value from 0 to 1, can be stopped with StopFadeCycle. Period time is the cycle time in seconds. 
        public void StartCycleFade(float periodTime)
        {
            this.periodTime = periodTime;
            Fade(periodTime / 2, 0);
            fadeFinishedEvent.AddListener(NextFadeCycle);
        }

        private void NextFadeCycle()
        {
            float newAlpha = Mathf.Approximately(spriteRenderer.color.a, 0) ? 1 : 0;
            Fade(periodTime / 2, newAlpha);
        }

        public void StopCycleFade()
        {
            fadeFinishedEvent.RemoveListener(NextFadeCycle);
            Fade(periodTime / 2, 1);
        }
    }
}
