using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManyLocationMovment : MonoBehaviour
{
    public List<Transform> waypoints; // Gezinilecek transformlar�n listesi
    public float moveSpeed = 5f; // Hareket h�z�
    private int currentIndex = 0; // Ge�erli transform indexi
    private Vector2 startPos;

    private void Start()
    {
        startPos = transform.transform.position;
    }
    // Update is called once per frame
    void Update()
    {
        if (waypoints.Count > 0)
        {
            Transform target = waypoints[currentIndex];
            transform.transform.position = Vector3.MoveTowards(transform.transform.position, target.position, moveSpeed * Time.deltaTime);

            // Hedefe ula�t���m�z� kontrol et
            if (Vector3.Distance(transform.transform.position, target.position) < 0.1f)
            {
                currentIndex = (currentIndex + 1) % waypoints.Count; // Bir sonraki transforma ge�
            }
        }
    }
}
