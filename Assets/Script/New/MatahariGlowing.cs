using UnityEngine;

public class MathariGlowing : MonoBehaviour
{
    public Color glowColor = Color.cyan;
    public float glowIntensity = 2f;
    [Range(0, 1)]
    public float transparency = 1f; // 1 is fully opaque, 0 is fully transparent

    private Material mat;
    private Color baseEmissionColor;

    void Start()
    {
        Renderer renderer = GetComponent<Renderer>();
        mat = renderer.material;

        // Get the base emission color (should start at black or transparent)
        baseEmissionColor = mat.GetColor("_EmissionColor");

        // Enable emission keyword, so emission is active
        mat.EnableKeyword("_EMISSION");

        // Set initial emission to no glow
        mat.SetColor("_EmissionColor", baseEmissionColor);
    }

    public void SetGlow(bool shouldGlow)
    {
        if (shouldGlow)
            mat.SetColor("_EmissionColor", glowColor * glowIntensity);
        else
            mat.SetColor("_EmissionColor", baseEmissionColor);
    }

    private void Update()
    {
        // Set the emission color
        mat.SetColor("_EmissionColor", glowColor * glowIntensity);

        // Adjust transparency
        Color currentColor = mat.color;
        currentColor.a = transparency; // Set the alpha value
        mat.color = currentColor;
    }
}
