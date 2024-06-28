using System.Collections;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class InterpolateCameraGrayscale : MonoBehaviour
{
    [SerializeField] private Volume volume;
    private ColorAdjustments colorAdjustments;

    private void Start()
    {
        volume.profile.TryGet<ColorAdjustments>(out colorAdjustments);
    }
    
    public void FadeToGrayscale(float fadeTime)
    {
        StartCoroutine(_FadeToGrayscale(fadeTime));
    }

    private IEnumerator _FadeToGrayscale(float fadeTime)
    {
        yield return new WaitForSeconds(30f);
        float saturation = colorAdjustments.saturation.value;
        while (saturation >= -100f)
        {
            colorAdjustments.saturation.value -= 1f * fadeTime;
            yield return new WaitForEndOfFrame();
        }
    }
}
