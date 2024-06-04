using UnityEngine;

public class RotacaoConstante : MonoBehaviour
{
    
    public float velocidadeRotacao = 20f;

    void Update()
    {
        
        transform.Rotate(Vector3.up, velocidadeRotacao * Time.deltaTime, Space.World);
        
    }
}
