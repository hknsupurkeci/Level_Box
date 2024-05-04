using System.Collections;
using UnityEngine;

public class SawTwoLocController : MonoBehaviour
{
    private Vector3 startPoz;
    public Transform endPoz;
    public float startWaitTime = 1f; // Start pozisyonunda bekleme s�resi
    public float endWaitTime = 2f;   // End pozisyonunda bekleme s�resi
    public float sawSpeed = 5f;      // Hareket h�z�
    private bool movingToEnd = true; // Hedefe do�ru mu geriye mi hareket ediyor

    void Start()
    {
        startPoz = transform.position; // Ba�lang�� pozisyonunu kaydet
        StartCoroutine(MoveBetweenPositions()); // Hareketi ba�lat
    }

    IEnumerator MoveBetweenPositions()
    {
        Vector3 targetPoz = endPoz.position;
        float currentWaitTime = endWaitTime;

        while (true)
        {
            // Hedefe do�ru s�rekli hareket
            while (Vector3.Distance(transform.position, targetPoz) > 0.01f)
            {
                transform.position = Vector3.MoveTowards(transform.position, targetPoz, sawSpeed * Time.deltaTime);
                yield return null;
            }

            // Hedefe ula��nca belirlenen s�re kadar bekle
            yield return new WaitForSeconds(currentWaitTime);

            // Hedef pozisyonunu ve bekleme s�resini de�i�tir
            if (movingToEnd)
            {
                targetPoz = startPoz;
                currentWaitTime = startWaitTime;
            }
            else
            {
                targetPoz = endPoz.position;
                currentWaitTime = endWaitTime;
            }

            movingToEnd = !movingToEnd; // Hareket y�n�n� de�i�tir
        }
    }
}
