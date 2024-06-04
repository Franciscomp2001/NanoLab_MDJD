using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class BalaoSobe : MonoBehaviour
{
    public float ascendSpeed = 1f;
    public float descendSpeed = 0.5f; // Velocidade de descida
    private Rigidbody rb;
    public GameObject Medalha;
    

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        if (rb == null)
        {
            Debug.LogError("No Rigidbody component found on this GameObject.");
        }
    }

    private void FixedUpdate()
    {
        if (transform.localScale.x > 60f || transform.localScale.y > 60f || transform.localScale.z > 60f)
        {
            AdjustVerticalMovement();
        }
    }

    private void Update()
    {
        // Verifica continuamente se a escala mudou
        if (transform.hasChanged)
        {
            transform.hasChanged = false; // Reinicia o sinalizador de mudança
            CheckScale();
        }
    }

    private void CheckScale()
    {
        // Se a escala for maior que 60 em qualquer eixo, ajusta o movimento vertical
        if (transform.localScale.x > 60f & transform.localScale.y > 60f & transform.localScale.z > 60f)
        {
            AdjustVerticalMovement();
            Medalha.SetActive(true);
        }
    }

    private void AdjustVerticalMovement()
    {
        if (gameObject.CompareTag("Balaohelio"))
        {
            rb.AddForce(Vector3.up * ascendSpeed, ForceMode.Acceleration);
        }
        else if (gameObject.CompareTag("Balaoco"))
        {
            rb.AddForce(Vector3.down * descendSpeed, ForceMode.Acceleration);
        }
    }
}
