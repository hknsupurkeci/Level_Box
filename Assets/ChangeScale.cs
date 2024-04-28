using System.Collections;
using UnityEngine;

public class ChangeScale : MonoBehaviour
{
    public GameObject target;
    public float decreaseRate = 0.5f;  // Ne kadar h�zl� azalaca��
    public float minimumScale = 0.1f;  // En d���k �l�ek de�eri
    private bool isMoving=false;
    private Vector3 firstScale;
    private void Start()
    {
        firstScale = target.transform.localScale;
    }
    private void Update()
    {
        if (isMoving)
        {
            // GameObject'in x �l�e�i minimumScale'den b�y�k oldu�u s�rece d�ng�ye devam et
            if (target.transform.localScale.x > minimumScale)
            {
                // Yeni �l�e�i hesapla
                Vector3 newScale = target.transform.localScale;
                newScale.x -= Time.deltaTime * decreaseRate;

                // Yeni �l�e�i uygula
                target.transform.localScale = newScale;
            }
            else
            {
                IsMoving = false;
            }
        }
        else
        {
            target.transform.localScale = firstScale;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("Scale trigger");
            // E�er trigger'a ba�ka bir GameObject girerse scale azaltma i�lemine ba�la
            IsMoving = true;
        }
    }
    public bool IsMoving
    {
        get { return isMoving; }
        set { isMoving = value; }
    }
}
