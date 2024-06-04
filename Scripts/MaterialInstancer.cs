using UnityEngine;

public class MaterialInstancer : MonoBehaviour
{
    public int materialIndex;
    public bool changeColor = true;
    public bool changeEmissionColor = true;
    public bool changeTextureOffset = true;
    public bool activateBaseMap = true;
    public Vector2 textureTiling = new Vector2(1, 1); // Novo parâmetro para definir o tiling da textura
    public Color color;
    public Color emissionColor;
    public Vector2 textureOffset;

    void Start()
    {
        Renderer renderer = GetComponent<Renderer>();

        if (renderer != null)
        {
            Material[] materials = renderer.materials;

            if (materialIndex >= 0 && materialIndex < materials.Length)
            {
                Material originalMaterial = materials[materialIndex];
                Material newMaterial = new Material(originalMaterial);

                // Ativando ou desativando o mapa base (albedo)
                if (!activateBaseMap)
                    newMaterial.SetTexture("_BaseMap", null);

                if (changeColor)
                    newMaterial.color = color;

                if (changeEmissionColor)
                    newMaterial.SetColor("_EmissionColor", emissionColor);

                if (changeTextureOffset)
                {
                    newMaterial.mainTextureOffset = textureOffset;
                    newMaterial.mainTextureScale = textureTiling; // Definindo o tiling da textura
                }

                materials[materialIndex] = newMaterial;
                renderer.materials = materials;
            }
            else
            {
                Debug.LogError("Índice do material inválido.");
            }
        }
        else
        {
            Debug.LogError("Renderer não encontrado.");
        }
    }
}
