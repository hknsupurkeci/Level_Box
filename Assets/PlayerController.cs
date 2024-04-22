using System;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 5.0f;
    public float jumpForce = 10f;  // Do�rudan Y ekseninde h�z verece�imiz i�in d���k bir de�er yeterli olacak
    public float rotationSpeed = 150f; // Karakterin d�nme h�z�n� belirleyen parametre
    private Rigidbody2D rb;
    private bool isGrounded = true;

    public static int activeCheckPointId;

    public CheckPoints checkPointController;

    private void Awake()
    {
        activeCheckPointId = PlayerPrefs.GetInt("checkpointId", 0);
        transform.position = checkPointController.points[activeCheckPointId].position;
    }
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.gravityScale = 3;  // Yer �ekimi kuvvetini art�rarak daha ger�ek�i bir d���� sa�l�yoruz
    }

    void Update()
    {
        // Z�plama kontrol�
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce); // Do�rudan y ekseninde h�z vererek z�plama
            isGrounded = false;
        }

        // Karakter d�n���
        float moveInput = Input.GetAxisRaw("Horizontal");
        if (moveInput != 0)
        {
            rb.velocity = new Vector2(moveInput * speed, rb.velocity.y);
            transform.Rotate(0, 0, -moveInput * rotationSpeed * Time.deltaTime);  // Z�plama s�ras�nda karakteri d�nd�r
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Zemin ile temas� kontrol et
        if (collision.gameObject.tag == "Ground")
        {
            isGrounded = true;
            transform.rotation = Quaternion.identity;  // Karakter yere temas etti�inde rotasyonu s�f�rla
        }
        if (collision.gameObject.tag == "Obstackle")
        {
            // karakter par�alanma ve ilgili checkpointe gitme
            gameObject.GetComponent<FragmentController>().Disassemble();

            Debug.Log("dead");
        }
    }
}
