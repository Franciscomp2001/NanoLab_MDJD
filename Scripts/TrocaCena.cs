using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class TrocarDeCenaComEscalamento : MonoBehaviour
{
 
    public Transform jogador;
  
    public float velocidadeEscalamento = 0.5f;
  
    public float velocidadeDiminuicao = 0.1f;
   
    private bool colisaoOcorreu = false;

    public Animator animatorCapsula;

    public AudioSource capsula;
    public AudioClip capsulaClip;

    private void OnTriggerEnter(Collider other)
    {
        
        if (other.CompareTag("Player") && !colisaoOcorreu)
        {
            
            colisaoOcorreu = true;
            animatorCapsula.SetBool("capsula", false);
            capsula.clip = capsulaClip;
            capsula.Play();

            StartCoroutine(DiminuirEscalaETrocarCena());
        }

    }

    
    private IEnumerator DiminuirEscalaETrocarCena()
    {
        yield return new WaitForSeconds(2f);

        float tempoTotal = 3f; 
        float tempoPassado = 0f;

        while (tempoPassado < tempoTotal)
        {
            
            jogador.localScale = Vector3.Lerp(jogador.localScale, Vector3.one * 0.1f, velocidadeDiminuicao * Time.deltaTime);

            tempoPassado += Time.deltaTime;

            yield return null;
        }
  
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}