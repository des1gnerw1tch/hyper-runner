using UnityEngine;

/// <summary>
/// Sets the CurveIntensity global property of each shader
/// </summary>
public class CurvedWorldSettings : MonoBehaviour
{
    [SerializeField] private float curveIntensity;
    void Start() => Shader.SetGlobalFloat("_GlobalCurveIntensity", curveIntensity );
}
