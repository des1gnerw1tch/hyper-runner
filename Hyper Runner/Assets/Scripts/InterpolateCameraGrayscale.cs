using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class InterpolateCameraGrayscale : MonoBehaviour
{
    [SerializeField] private Volume volume;
    private ColorAdjustments colorAdjustments;
    
    public static InterpolateCameraGrayscale Instance { get; private set; }

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

    private void Start() => volume.profile.TryGet<ColorAdjustments>(out colorAdjustments);

    public void FadeToGrayscale(float fadeSpeed) => StartCoroutine(_FadeToGrayscale(fadeSpeed));

    private IEnumerator _FadeToGrayscale(float fadeSpeed)
    {
        while (colorAdjustments.saturation.value >= -100f)
        {
            colorAdjustments.saturation.value -= 1f * fadeSpeed;
            yield return new WaitForEndOfFrame();
        }
    }
}
