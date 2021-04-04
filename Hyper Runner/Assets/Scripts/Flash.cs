using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flash : MonoBehaviour
{
    [SerializeField] private Color flashColor;
    [SerializeField] private Material material;
    [SerializeField] private float fadeSpeed;
    private float alpha;
    private Color NO_COLOR = new Color(0, 0, 0, 0);
    // Start is called before the first frame update
    void Start()
    {
      material.SetColor("_TintColor", NO_COLOR);
    }

    void Update() {
      if (alpha > 0)  {
        alpha = Mathf.Clamp01(alpha - (fadeSpeed * Time.deltaTime));
        flashColor.a = alpha;
        Debug.Log(alpha);
        material.SetColor("_TintColor", flashColor);
      }
    }

    public void StartFlash(Color c, float speed) {
      flashColor = c;
      fadeSpeed = speed;
      material.SetColor("_TintColor", flashColor);
      alpha = 1;
    }
}
