using UnityEngine;

public class CurvedCanvas : MonoBehaviour
{
    public Canvas canvas;
    public Material material;
    public float curvature = 0.0f;

    void Update()
    {
        material.SetFloat("_Curvature", curvature);
    }
}
