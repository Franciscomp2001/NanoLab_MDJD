using UnityEngine;
using System.Collections;

public class ExplicacaoSeguranca : MonoBehaviour
{
    public GameObject Tut;
    public GameObject Start;

    public Animator animator;
    public Animator mesaAnimator;
    public AudioSource audioSource;
    public AudioClip[] audioClips;
    public GameObject LuvaDir;
    public GameObject LuvaEsq;
    public GameObject Relogio;
    public GameObject Robot;


    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Start")
        {
            StartCoroutine(PlayAudioAndAnimation());
            LuvaDir.SetActive(false);
            LuvaEsq.SetActive(false);
            Relogio.SetActive(false);
            Robot.SetActive(false);
        }
    }

    IEnumerator PlayAudioAndAnimation()
    {
        Start.SetActive(false);
        //primeiro áudio
        yield return new WaitForSeconds(2f);
        audioSource.clip = audioClips[0];
        audioSource.Play();

        animator.SetBool("isFalar", true);

        yield return new WaitForSeconds(audioClips[0].length);

        animator.SetBool("isFalar", false);
        Tut.SetActive(false);
        yield return new WaitForSeconds(1f);

        //segundo áudio
        audioSource.clip = audioClips[1];
        audioSource.Play();
        animator.SetBool("isFalar", true);

        yield return new WaitForSeconds(3.5f); 
        mesaAnimator.SetBool("tampas", true);

        yield return new WaitForSeconds(2f);
        mesaAnimator.enabled = false;

        yield return new WaitForSeconds(audioClips[1].length - 5.5f);
        animator.SetBool("isFalar", false);


    }

}
