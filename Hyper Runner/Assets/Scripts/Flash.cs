using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flash : MonoBehaviour
{
    [SerializeField] private Color flashColor;
    [SerializeField] private Material material;
    [SerializeField] private float fadeSpeed;
    private float alpha = 0;
    private bool active = false;
    private Color NO_COLOR = new Color(0, 0, 0, 0);
    // Start is called before the first frame update
    void Start()
    {
      material.SetColor("_TintColor", NO_COLOR);
    }

    void Update() {
      if (alpha >= 0)  {
        flashColor.a = alpha;
        alpha = Mathf.Clamp01(alpha - fadeSpeed * Time.deltaTime);
        material.SetColor("_TintColor", flashColor);
      }
    }

    void StartFlash(Color c, float speed) {
      flashColor = c;
      fadeSpeed = speed;
      material.SetColor("_TintColor", flashColor);
      alpha = 1;
    }
}
