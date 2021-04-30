using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

// Attach this script to objects you want to flash a certain color.
// Make sure object has renderer, and its material is "Flash"
public class Flash : MonoBehaviour
{
    [SerializeField] private Color flashColor;
    [SerializeField] private Material material;
    private float fadeSpeed;
    private float alpha;
    private Color NO_COLOR = new Color(0, 0, 0, 0);

    void Awake()  {
      // Creating a new duplicate material for each object with a flash material.
      // Will need to check if object is a Tilemap or a Sprite in order to set the material
      if (this.gameObject.GetComponent<TilemapRenderer>() != null)  {
        this.gameObject.GetComponent<TilemapRenderer>().material = new Material(material);
        material = this.gameObject.GetComponent<TilemapRenderer>().material;
      } else if (this.gameObject.GetComponent<SpriteRenderer>() != null)  {
        this.gameObject.GetComponent<SpriteRenderer>().material = new Material(material);
        material = this.gameObject.GetComponent<SpriteRenderer>().material;
      } else {
        Debug.LogError("Object with name: '" + gameObject.name + "' does not have a SpriteRenderer " +
        "or a TilemapRenderer");
      }
    }

    void Start()
    {
      material.SetColor("_TintColor", NO_COLOR);
    }

    void Update() {
      if (alpha > 0)  {
        alpha = Mathf.Clamp01(alpha - (fadeSpeed * Time.deltaTime));
        flashColor.a = alpha;
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
