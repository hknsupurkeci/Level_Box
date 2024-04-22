using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target; // Karakterimizin transformu
    public float smoothSpeed = 0.125f; // Kameran�n ne kadar p�r�zs�z hareket edece�ini belirleyen fakt�r
    public float yOffset = 1f; // Kameran�n karakterin �zerinde ne kadar y�ksek duraca��n� belirleyen offset

    private void LateUpdate()
    {
        if (target != null)
        {
            // Hedefin Y pozisyonunu al ve yOffset ile ayarla
            float desiredY = target.position.y + yOffset;
            // Kameran�n �u anki Y pozisyonunu al
            float currentY = transform.position.y;
            // �stenen Y pozisyonuna do�ru p�r�zs�z bir ge�i� yap
            float smoothedY = Mathf.Lerp(currentY, desiredY, smoothSpeed * Time.deltaTime);
            // Kameran�n pozisyonunu g�ncelle, X ve Z pozisyonlar� sabit kalacak
            transform.position = new Vector3(transform.position.x, smoothedY, transform.position.z);
        }
    }
}
