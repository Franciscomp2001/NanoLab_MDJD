using UnityEngine;

public class DetecaoColisaoParticulas : MonoBehaviour
{
    public Material Azul;
    public Material Laranja;
    public Material Vermelho;

    private int contadorAzul = 0;
    private int contadorLaranja = 0;
    private int contadorVermelho = 0;
    private const int colisoesNecessarias = 8;

    void OnParticleCollision(GameObject other)
    {

        if (contadorAzul < colisoesNecessarias && other.gameObject.tag == "LiquidoAzul")
        {
            Debug.Log("Azul");
            contadorLaranja = 0;
            contadorVermelho = 0;
            contadorAzul++;

            if (contadorAzul == colisoesNecessarias)
            {
                GetComponent<Renderer>().material = Azul;
                contadorAzul = 0;
            }
        }

        if (contadorLaranja < colisoesNecessarias && other.gameObject.tag == "LiquidoLaranja")
        {
            Debug.Log("Laranja");
            contadorAzul = 0;
            contadorVermelho = 0;
            contadorLaranja++;

            if (contadorLaranja == colisoesNecessarias)
            {
                GetComponent<Renderer>().material = Laranja;
                contadorLaranja = 0;
            }
        }

        if (contadorVermelho < colisoesNecessarias && other.gameObject.tag == "LiquidoVermelho")
        {
            Debug.Log("Vermelho");
            contadorAzul = 0;
            contadorLaranja = 0;
            contadorVermelho++;

            if (contadorVermelho == colisoesNecessarias)
            {
                GetComponent<Renderer>().material = Vermelho;
                contadorVermelho = 0;
            }
        }
    }
}
