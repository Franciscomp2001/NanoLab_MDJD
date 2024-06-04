using UnityEngine;

public class Reseteable : MonoBehaviour
{
    private Vector3 initialPosition;

    void Start()
    {
        initialPosition = transform.position; // Salva a posi��o inicial
    }

    public void ResetPosition()
    {
        transform.position = initialPosition; // Reseta a posi��o do objeto para a posi��o inicial
    }
}
