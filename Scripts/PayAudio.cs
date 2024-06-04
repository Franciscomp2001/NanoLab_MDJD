using UnityEngine;

public class PlayAudioOnStart : MonoBehaviour
{
    public AudioSource audioSource;

    void Start()
    {

        audioSource = GetComponent<AudioSource>();

        if (audioSource != null && audioSource.clip != null)
        {

            audioSource.Play();
        }

    }
}
