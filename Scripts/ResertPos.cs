using UnityEngine;

public class Reseteable : MonoBehaviour
{
    private Vector3 initialPosition;

    void Start()
    {
        initialPosition = transform.position; // Salva a posição inicial
    }

    public void ResetPosition()
    {
        transform.position = initialPosition; // Reseta a posição do objeto para a posição inicial
    }
}
