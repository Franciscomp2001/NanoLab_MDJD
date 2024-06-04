using UnityEngine;
using System.Collections;

public class RobotFala : MonoBehaviour
{
    [Header("ANIMATORS")]
    public Animator animator;
    public Animator animatorBarreira;
    
    public Animator animatorDesinfetar;
    public Animator animatorCapsula;

    [Header("AUDIO")]
    public AudioSource entradaLab;
    public AudioClip entradaLabClip;
    public AudioClip ExplicacaML;
    public AudioSource capsula;
    public AudioClip capsulaClip;
    public AudioSource Barreira;
    public AudioClip BarreiraClip;

    [Header("GAMEOBJECTS")]
    public GameObject ColliderEntrada;
    public GameObject ColliderML;
    public GameObject Desinfetar;
    public GameObject CaraRobot;
    public GameObject SuporteRelogio;


    public GameObject Medalha;

    void Start()
    {
        SuporteRelogio.SetActive(false);
        Desinfetar.SetActive(false);

    }

    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.tag == "RobotActivate")
        {

            ColliderEntrada.SetActive(false);
            animator.SetBool("isOpen", true);
            

            Desinfetar.SetActive(true);
            animatorDesinfetar.SetBool("desinfetar", true);


            CaraRobot.SetActive(false);

            if (entradaLab != null && entradaLabClip != null)
            {
                entradaLab.clip = entradaLabClip;
                entradaLab.Play();

                StartCoroutine(WaitForAudio(entradaLabClip.length));


            }
        }

        if (other.gameObject.tag == "MacroLab")
        {

            animator.SetBool("isOpen", true);

            if (entradaLab != null && ExplicacaML != null)
            {
                entradaLab.clip = ExplicacaML;
                entradaLab.Play();

                StartCoroutine(WaitForAudio(ExplicacaML.length));

                ColliderML.SetActive(false);
                

                SuporteRelogio.SetActive(true);

                animatorCapsula.SetBool("capsula", true);
                capsula.clip = capsulaClip;
                capsula.Play();
                Medalha.SetActive(true);
            }
        }
    }

    IEnumerator WaitForAudio(float audioLength)
    {
        yield return new WaitForSeconds(audioLength);
        animator.SetBool("isOpen", false);
        
        animatorDesinfetar.SetBool("desinfetar", false);
        yield return new WaitForSeconds(3f);
        Desinfetar.SetActive(false);
        animatorBarreira.SetBool("abre", true);
        Barreira.clip = BarreiraClip;
        Barreira.Play();


    }
}
