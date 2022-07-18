using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Motivation bar for player in game.
/// </summary>
public class MotivationBar : MonoBehaviour
{
    [SerializeField] private Slider slider;
    [SerializeField] private Gradient gradient;
    [SerializeField] private Image fill;

    public void UpdateSlider(float fracMotivation)
    {
        fracMotivation = Mathf.Clamp(fracMotivation, 0f, 1f);
        slider.value = fracMotivation;
        fill.color = gradient.Evaluate(fracMotivation);
    }
}
