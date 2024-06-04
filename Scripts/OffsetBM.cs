using UnityEngine;

public class TextureOffsetAnimator : MonoBehaviour
{
    public Renderer rend; // Referência ao componente Renderer do objeto
    public int materialIndex = 0; // Índice do material que deseja animar
    public float scrollSpeedX = 0.5f; // Velocidade de animação do offset no eixo X
    public float scrollSpeedY = 0.3f; // Velocidade de animação do offset no eixo Y

    void Start()
    {
        rend = GetComponent<Renderer>(); // Obtém o componente Renderer do objeto
    }

    void Update()
    {
        if (rend.materials.Length > materialIndex) // Verifica se o índice do material é válido
        {
            float offsetX = Time.time * scrollSpeedX; // Calcula o deslocamento no eixo X baseado no tempo e na velocidade
            float offsetY = Time.time * scrollSpeedY; // Calcula o deslocamento no eixo Y baseado no tempo e na velocidade

            Vector2 offset = new Vector2(offsetX, offsetY); // Cria um vetor de deslocamento
            rend.materials[materialIndex].mainTextureOffset = offset; // Aplica o deslocamento ao material do objeto
        }
        else
        {
            Debug.LogWarning("Material index is out of range!"); // Aviso se o índice do material não for válido
        }
    }
}
