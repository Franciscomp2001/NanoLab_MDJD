using UnityEngine;

public class JogoDicas : MonoBehaviour
{
    public AudioClip[] audioClips;
    public AudioClip wrong;
    public AudioClip right;
    public AudioSource audioSource;
    private int currentAudioIndex;
    public Animator EcraPequeno;
    

    public GameObject StartGame;
    public GameObject CaraRobot;

    public GameObject Medalha;
    

    void Start()
    {
        currentAudioIndex = -1; // Começa com -1 para indicar que nenhum áudio está sendo reproduzido
        CaraRobot.SetActive(false);
    }

    void OnTriggerEnter(Collider other)
    {

        Reseteable reseteable = other.GetComponent<Reseteable>();
        if (reseteable != null)
        {
            reseteable.ResetPosition();
        }

        if (audioSource.isPlaying)
        {
            Debug.Log("Audio a tocar");
            return;
        }

        if (other.CompareTag("JogoDica"))
        {
            PlayRandomAudio();
            Debug.Log("Chamou");
            StartGame.SetActive(false);
            CaraRobot.SetActive(true);
            Medalha.SetActive(true);
        }

        if (other.CompareTag("HidrogenioJD"))
        {

            if (currentAudioIndex == 0)
            {
                Debug.Log("Audio 0, Hidrogenio");
                audioSource.clip = right;
                audioSource.Play();
                EcraPequeno.SetBool("Hidrogenio", true);
                Invoke("PlayRandomAudio", 2f);
            }
            else
            {
                Debug.Log("Errado");
                audioSource.clip = wrong;
                audioSource.Play();
            }
        }

        if (other.CompareTag("CarbonoJD"))
        {

            if (currentAudioIndex == 1)
            {
                Debug.Log("Audio 1, Carbono");
                audioSource.clip = right;
                audioSource.Play();
                EcraPequeno.SetBool("Carbono", true);
                Invoke("PlayRandomAudio", 2f);
            }
            else
            {
                Debug.Log("Errado");
                audioSource.clip = wrong;
                audioSource.Play();
            }
        }

        if (other.CompareTag("OxigenioJD"))
        {

            if (currentAudioIndex == 2)
            {
                Debug.Log("Audio 2, Oxigenio");
                audioSource.clip = right;
                audioSource.Play();
                EcraPequeno.SetBool("Oxigenio", true);
                Invoke("PlayRandomAudio", 2f);
            }
            else
            {
                Debug.Log("Errado");
                audioSource.clip = wrong;
                audioSource.Play();
            }
        }

        if (other.CompareTag("HelioJD"))
        {

            if (currentAudioIndex == 3)
            {
                Debug.Log("Audio 3, Helio");
                audioSource.clip = right;
                audioSource.Play();
                EcraPequeno.SetBool("Helio", true);
                Invoke("PlayRandomAudio", 2f);
            }
            else
            {
                Debug.Log("Errado");
                audioSource.clip = wrong;
                audioSource.Play();
            }
        }

        if (other.CompareTag("FerroJD"))
        {

            if (currentAudioIndex == 4)
            {
                Debug.Log("Audio 4, Ferro");
                audioSource.clip = right;
                audioSource.Play();
                EcraPequeno.SetBool("Ferro", true);
                Invoke("PlayRandomAudio", 2f);
            }
            else
            {
                Debug.Log("Errado");
                audioSource.clip = wrong;
                audioSource.Play();
            }
        }

        if (other.CompareTag("OuroJD"))
        {

            if (currentAudioIndex == 5)
            {
                Debug.Log("Audio 5, Ouro");
                audioSource.clip = right;
                audioSource.Play();
                EcraPequeno.SetBool("Ouro", true);
                Invoke("PlayRandomAudio", 2f);
            }
            else
            {
                Debug.Log("Errado");
                audioSource.clip = wrong;
                audioSource.Play();
            }
        }

        if (other.CompareTag("AluminioJD"))
        {

            if (currentAudioIndex == 6)
            {
                Debug.Log("Audio 6, Aluminio");
                audioSource.clip = right;
                audioSource.Play();
                EcraPequeno.SetBool("Aluminio", true);
                Invoke("PlayRandomAudio", 2f);
            }
            else
            {
                Debug.Log("Errado");
                audioSource.clip = wrong;
                audioSource.Play();
            }
        }

        if (other.CompareTag("NeonJD"))
        {

            if (currentAudioIndex == 7)
            {
                Debug.Log("Audio 7, Neon");
                audioSource.clip = right;
                audioSource.Play();
                EcraPequeno.SetBool("Neon", true);
                Invoke("PlayRandomAudio", 2f);
            }
            else
            {
                Debug.Log("Errado");
                audioSource.clip = wrong;
                audioSource.Play();
            }
        }
    }

    void PlayRandomAudio()
    {
        EcraPequeno.SetBool("Hidrogenio", false);
        EcraPequeno.SetBool("Carbono", false);
        EcraPequeno.SetBool("Oxigenio", false);
        EcraPequeno.SetBool("Helio", false);
        EcraPequeno.SetBool("Ferro", false);
        EcraPequeno.SetBool("Ouro", false);
        EcraPequeno.SetBool("Aluminio", false);
        EcraPequeno.SetBool("Neon", false);

        if (audioClips.Length > 0 && audioSource != null && !audioSource.isPlaying) 
        {
            int newIndex = Random.Range(0, audioClips.Length);

            while (newIndex == currentAudioIndex)
            {
                newIndex = Random.Range(0, audioClips.Length);
            }

            currentAudioIndex = newIndex;

            audioSource.clip = audioClips[currentAudioIndex];
            audioSource.Play();

        }
        else
        {
            Debug.Log("Outro audio ja esta a tocar");
        }
    }
}
