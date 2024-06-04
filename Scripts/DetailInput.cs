using UnityEngine;

public class AddBaseMapToDetail : MonoBehaviour
{
    public Texture2D baseMapTexture; // Textura do mapa base (albedo) que você deseja adicionar
    public Material targetMaterial; // Material que você deseja modificar

    void Start()
    {
        if (targetMaterial == null || baseMapTexture == null)
        {
            Debug.LogError("Material ou textura base não definidos!");
            return;
        }

        // Criando uma cópia do material para evitar afetar outros objetos
        Material newMaterial = new Material(targetMaterial);

        // Adicionando a textura do mapa base ao material
        newMaterial.SetTexture("_BaseMap", baseMapTexture);

        // Aplicando o material modificado ao objeto atual
        GetComponent<Renderer>().material = newMaterial;
    }
}
