using UnityEngine;

public class TextureOffsetAnimator : MonoBehaviour
{
    public Renderer rend; // Refer�ncia ao componente Renderer do objeto
    public int materialIndex = 0; // �ndice do material que deseja animar
    public float scrollSpeedX = 0.5f; // Velocidade de anima��o do offset no eixo X
    public float scrollSpeedY = 0.3f; // Velocidade de anima��o do offset no eixo Y

    void Start()
    {
        rend = GetComponent<Renderer>(); // Obt�m o componente Renderer do objeto
    }

    void Update()
    {
        if (rend.materials.Length > materialIndex) // Verifica se o �ndice do material � v�lido
        {
            float offsetX = Time.time * scrollSpeedX; // Calcula o deslocamento no eixo X baseado no tempo e na velocidade
            float offsetY = Time.time * scrollSpeedY; // Calcula o deslocamento no eixo Y baseado no tempo e na velocidade

            Vector2 offset = new Vector2(offsetX, offsetY); // Cria um vetor de deslocamento
            rend.materials[materialIndex].mainTextureOffset = offset; // Aplica o deslocamento ao material do objeto
        }
        else
        {
            Debug.LogWarning("Material index is out of range!"); // Aviso se o �ndice do material n�o for v�lido
        }
    }
}
