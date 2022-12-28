using System.Collections;
using UnityEngine;

namespace SpriteVisualEffects
{
    /**
     * Will fade the alpha value of a sprite. 
     */
    public class AlphaFade : MonoBehaviour
    {
        [SerializeField] private SpriteRenderer spriteRenderer;

        private Coroutine current;

        public void Fade(float fadeTime, float finalAlphaValue, bool deactivateAtEnd = false)
        {
            if (current != null)
            {
                StopCoroutine(current);
            }
            
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

            if (deactivateAtEnd)
            {
                this.gameObject.SetActive(false);
            }
        }
        
        public void SetSpriteAlpha(float a)
        {
            Color spriteColor = spriteRenderer.color;
            spriteRenderer.color = new Color(spriteColor.r, spriteColor.g, spriteColor.b, a);
        }
    }
}
