using System.Collections;
using UnityEngine;

namespace BossFight.Cyber
{
    public class DayToNightShaderManager : MonoBehaviour
    {
        [SerializeField, Range(0f, 1f)] private float startingDayNightValue;
        private const float DAY_NIGHT_LERP_STEP_SECONDS = 0.01f;
        
        
        // 0 indicates day, 1 indicates night.
        private float dayNightLerpNormalized;
        private float dayNightLerpNormalizedAtBeginningOfCoroutine;
        private float timeElapsedLerping;
        private Coroutine lerpDayToNightCoroutine;

        public void Start()
        {
            dayNightLerpNormalized = startingDayNightValue;
            UpdateShader();
            
            
            LerpDayToNightValue(1, 2.0f);
        }
        
        public void SetDayNightLerp(float dayNightLerpNormalized)
        {
            this.dayNightLerpNormalized = dayNightLerpNormalized;
            UpdateShader();
        }

        public void LerpDayToNightValue(float dayNightLerpGoal, float secondsToLerp)
        {
            if (dayNightLerpGoal < 0.0f || dayNightLerpGoal > 1.0f)
            {
                Debug.LogError("Day night lerp goal should be between 0 and 1. 0 is completely day and 1 is completely night.");
                return;
            }
            
            timeElapsedLerping = 0f;
            if (lerpDayToNightCoroutine != null)
            {
                StopCoroutine(lerpDayToNightCoroutine);
            }
            dayNightLerpNormalizedAtBeginningOfCoroutine = this.dayNightLerpNormalized;
            lerpDayToNightCoroutine = StartCoroutine(LerpToDayNightValueRoutine(dayNightLerpGoal, secondsToLerp));
        }
        
        private IEnumerator LerpToDayNightValueRoutine(float dayNightLerpGoal, float secondsToLerp)
        {
            while (true)
            {


                float progress = Mathf.Min(timeElapsedLerping / secondsToLerp, 1.0f);
                dayNightLerpNormalized = Mathf.Lerp(dayNightLerpNormalizedAtBeginningOfCoroutine, dayNightLerpGoal, progress);
                Debug.Log(progress);
                UpdateShader();
                if (Mathf.Approximately(progress, 1.0f))
                {
                    StopCoroutine(lerpDayToNightCoroutine);
                    lerpDayToNightCoroutine = null;
                }

                yield return new WaitForSeconds(DAY_NIGHT_LERP_STEP_SECONDS);
                timeElapsedLerping += DAY_NIGHT_LERP_STEP_SECONDS;
            }
        }
        

        private void UpdateShader() => Shader.SetGlobalFloat("_GlobalLerpDayToNight", dayNightLerpNormalized);
    }
}

