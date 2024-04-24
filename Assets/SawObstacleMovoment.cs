using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SawObstacleMovoment : MonoBehaviour
{
    public GameObject obstacle;
    public List<Transform> waypoints; // Gezinilecek transformlar�n listesi
    public float moveSpeed = 5f; // Hareket h�z�
    private int currentIndex = 0; // Ge�erli transform indexi
    private bool isMoving = false; // Hareketin ba�lay�p ba�lamad���n� kontrol etmek i�in
    private Vector2 startPos;

    private void Start()
    {
        startPos = obstacle.transform.position;
    }
    // Update is called once per frame
    void Update()
    {
        // Transforma do�ru hareket
        if (isMoving)
        {
            if (waypoints.Count > 0)
            {
                Transform target = waypoints[currentIndex];
                obstacle.transform.position = Vector3.MoveTowards(obstacle.transform.position, target.position, moveSpeed * Time.deltaTime);

                // Hedefe ula�t���m�z� kontrol et
                if (Vector3.Distance(obstacle.transform.position, target.position) < 0.1f)
                {
                    currentIndex = (currentIndex + 1) % waypoints.Count; // Bir sonraki transforma ge�
                }
                if (currentIndex == waypoints.Count)
                {
                    isMoving = false;
                }
            }
        }
    }
    public Vector2 StartPosObstacle { get { return startPos; } }
    public bool IsMoving
    {
        get { return isMoving; }
        set { isMoving = value; }
    }
    public int CurrentIndex
    {
        get { return currentIndex; }
        set { currentIndex = value; }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player")) // �arpan objenin etiketi "Player" ise
        {
            Debug.Log("trigger baba");
            isMoving = true; // Hareketi ba�lat
        }
    }
}
