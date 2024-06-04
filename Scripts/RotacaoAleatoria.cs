using UnityEngine;

public class RotacaoObjeto : MonoBehaviour
{
    
    public float velocidadeRotacaoY = 50f;
    public float velocidadeRotacaoZ = 30f;

    
    void Update()
    {
        
        transform.Rotate(0f, velocidadeRotacaoY * Time.deltaTime, -velocidadeRotacaoZ * Time.deltaTime);
    }
}
