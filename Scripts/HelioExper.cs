using UnityEngine;
using System.Collections;

public class ScaleUpOnTrigger : MonoBehaviour
{
    public float scaleSpeed = 0.1f;
    public float maxScale = 6f;

    private bool insideHeliotanque = false;
    private Coroutine scaleCoroutine;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("heliotanque"))
        {
            insideHeliotanque = true;
            gameObject.tag = "Balaohelio";
            if (scaleCoroutine == null)
            {
                scaleCoroutine = StartCoroutine(ScaleUp());
            }
        }
        else if (other.CompareTag("cotanque"))
        {
            insideHeliotanque = true;
            gameObject.tag = "Balaoco";
            if (scaleCoroutine == null)
            {
                scaleCoroutine = StartCoroutine(ScaleUp());
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("heliotanque") || other.CompareTag("cotanque"))
        {
            insideHeliotanque = false;
            if (scaleCoroutine != null)
            {
                StopCoroutine(scaleCoroutine);
                scaleCoroutine = null;
            }
        }
    }

    private IEnumerator ScaleUp()
    {
        while (insideHeliotanque)
        {
            Vector3 newScale = transform.localScale + Vector3.one * scaleSpeed * Time.deltaTime;
            newScale = Vector3.Min(newScale, Vector3.one * maxScale);
            transform.localScale = newScale;
            yield return null;
        }
    }
}

