using UnityEngine;
using System.Collections;

public class WaterCycle : MonoBehaviour
{
    [Header("Falas")]
    public GameObject[] scaleObjects;
    public AudioClip[] audioClips;
    public AudioSource robotAudioSource;
    public float scalingDuration = 3f; 
    public Animator robotAnimator;

    [Header("Robot")]
    public Transform[] positions; 
    public GameObject objectToMove;

    public Animator Barreiraanimator;
    public GameObject BarreiraWC;
    public GameObject ColliderWC;

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "WaterCycle")
        {
            ColliderWC.SetActive(false);
            StartCoroutine(PlayAudioAndScaleSequence());
            SeguirJogador seguirJogador = objectToMove.GetComponent<SeguirJogador>();
            if (seguirJogador != null)
            {
                seguirJogador.enabled = false;
            }
        }
    }

    IEnumerator PlayAudioAndScaleSequence()
    {
        // Primeiro áudio
        robotAnimator.SetBool("isOpen", true);
        robotAudioSource.clip = audioClips[0];
        robotAudioSource.Play();
        MoveObjectToPosition(objectToMove, positions[0].position, scalingDuration);
        yield return new WaitForSeconds(audioClips[0].length);
        

        // Evaporation áudio
        robotAudioSource.clip = audioClips[1];
        robotAudioSource.Play();
        ScaleObject(scaleObjects[0], Vector3.one, scalingDuration);
        MoveObjectToPosition(objectToMove, positions[1].position, scalingDuration);
        yield return new WaitForSeconds(audioClips[1].length);
        

        // Transpiration áudio
        robotAudioSource.clip = audioClips[2];
        robotAudioSource.Play();
        ScaleObject(scaleObjects[1], Vector3.one, scalingDuration);
        MoveObjectToPosition(objectToMove, positions[2].position, scalingDuration);
        yield return new WaitForSeconds(audioClips[2].length);
        

        // Condensation áudio
        robotAudioSource.clip = audioClips[3];
        robotAudioSource.Play();
        ScaleObject(scaleObjects[2], Vector3.one, scalingDuration);
        MoveObjectToPosition(objectToMove, positions[3].position, scalingDuration);
        yield return new WaitForSeconds(audioClips[3].length);
        

        // Precipitation áudio
        robotAudioSource.clip = audioClips[4];
        robotAudioSource.Play();
        ScaleObject(scaleObjects[3], Vector3.one, scalingDuration);
        MoveObjectToPosition(objectToMove, positions[4].position, scalingDuration);
        yield return new WaitForSeconds(audioClips[4].length);
        

        // Infiltration áudio
        robotAudioSource.clip = audioClips[5];
        robotAudioSource.Play();
        ScaleObject(scaleObjects[4], Vector3.one, scalingDuration);
        MoveObjectToPosition(objectToMove, positions[5].position, scalingDuration);
        yield return new WaitForSeconds(audioClips[5].length);
        

        // Collection áudio
        robotAudioSource.clip = audioClips[6];
        robotAudioSource.Play();
        ScaleObject(scaleObjects[5], Vector3.one, scalingDuration);
        MoveObjectToPosition(objectToMove, positions[6].position, scalingDuration);
        yield return new WaitForSeconds(audioClips[6].length);
        robotAnimator.SetBool("isOpen", false);

        SeguirJogador seguirJogador = objectToMove.GetComponent<SeguirJogador>();
        if (seguirJogador != null)
        {
            seguirJogador.enabled = true;
        }

        Barreiraanimator.SetBool("isOpen", true);
        yield return new WaitForSeconds(3f);
        BarreiraWC.SetActive(false);
        
    }

    void ScaleObject(GameObject obj, Vector3 targetScale, float duration)
    {
        StartCoroutine(ScaleOverTime(obj, targetScale, duration));
    }

    IEnumerator ScaleOverTime(GameObject obj, Vector3 targetScale, float duration)
    {
        Vector3 initialScale = obj.transform.localScale;
        float timeElapsed = 0f;

        while (timeElapsed < duration)
        {
            obj.transform.localScale = Vector3.Lerp(initialScale, targetScale, timeElapsed / duration);
            timeElapsed += Time.deltaTime;
            yield return null;
        }

        obj.transform.localScale = targetScale;
    }

    void MoveObjectToPosition(GameObject obj, Vector3 targetPosition, float duration)
    {
        StartCoroutine(MoveOverTime(obj, targetPosition, duration));
    }

    IEnumerator MoveOverTime(GameObject obj, Vector3 targetPosition, float duration)
    {
        Vector3 initialPosition = obj.transform.position;
        float timeElapsed = 0f;

        while (timeElapsed < duration)
        {
            obj.transform.position = Vector3.Lerp(initialPosition, targetPosition, timeElapsed / duration);
            timeElapsed += Time.deltaTime;
            yield return null;
        }

        obj.transform.position = targetPosition;
    }
}
