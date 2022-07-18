using UnityEngine;
using UnityEngine.UI;
using System.Collections;

/// <summary>
/// Motivation bar for player in game.
/// </summary>
public class MotivationBar : MonoBehaviour
{
    private enum BarState
    {
        Hidden,
        FadeIn,
        Showing,
        FadeOut
    }
    
    [SerializeField] private Slider slider;
    [SerializeField] private Gradient gradient;
    [SerializeField] private Image fill;
    [SerializeField] private Image border;

    private BarState state = BarState.Hidden;
    private const float FADE_SPEED = .2f;
    private const float FADE_REFRESH_RATE = .05f;
    private const float SHOW_LENGTH = 1f;

    private Coroutine showingBarRoutine;
    private Coroutine fadeOutBarRoutine;
    private float alpha = 0;

    void Start()
    {
        UpdateSliderAlpha();
    }
    
    private void UpdateSliderAlpha()
    {
        border.color = ChangeAlphaOfColor(border.color, alpha);
        fill.color = ChangeAlphaOfColor(fill.color, alpha);
    }
    
    private Color ChangeAlphaOfColor(Color color, float a)
    {
        Color newColor = new Color(color.r, color.g, color.b, a);
        return newColor;
    }
    
    public void UpdateSlider(float fracMotivation, bool showSlider)
    {
        fracMotivation = Mathf.Clamp(fracMotivation, 0f, 1f);
        slider.value = fracMotivation;
        fill.color = ChangeAlphaOfColor(gradient.Evaluate(fracMotivation), alpha);

        if (!showSlider)
        {
            return;
        }

        switch (state)
        {
            case BarState.Hidden:
                StartCoroutine(FadeIn());
                break;
            case BarState.FadeOut:
                StopCoroutine(fadeOutBarRoutine);
                StartCoroutine(FadeIn());
                break;
            case BarState.Showing:
                StopCoroutine(showingBarRoutine);
                showingBarRoutine = StartCoroutine(ShowingSlider());
                break;
        }
    }

    private IEnumerator FadeIn()
    {
        state = BarState.FadeIn;
        while (alpha <= 1)
        {
            alpha += FADE_SPEED;
            UpdateSliderAlpha();
            yield return new WaitForSeconds(FADE_REFRESH_RATE);
        }

        showingBarRoutine = StartCoroutine(ShowingSlider());
    }

    

    private IEnumerator ShowingSlider()
    {
        state = BarState.Showing;
        yield return new WaitForSeconds(SHOW_LENGTH);
        
        fadeOutBarRoutine = StartCoroutine(FadeSlider());
    }

    private IEnumerator FadeSlider()
    {
        state = BarState.FadeOut;

        while (alpha >= 0)
        {
            alpha -= FADE_SPEED;
            UpdateSliderAlpha();
            yield return new WaitForSeconds(FADE_REFRESH_RATE);
        }

        state = BarState.Hidden;
    }

}
