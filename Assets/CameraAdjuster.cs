using UnityEngine;

public class CameraAdjuster : MonoBehaviour
{
    public float defaultWidth = 15.2f;  // Tasar�m�n�z� yapt���n�z varsay�lan geni�lik

    void Start()
    {
        AdjustCamera();
    }

    void AdjustCamera()
    {
        Camera cam = GetComponent<Camera>();
        float screenRatio = (float)Screen.width / (float)Screen.height;
        float targetRatio = defaultWidth / cam.orthographicSize;
        if (screenRatio >= targetRatio)
        {
            cam.orthographicSize = defaultWidth / screenRatio;
        }
        else
        {
            float differenceInSize = targetRatio / screenRatio;
            cam.orthographicSize *= differenceInSize;
        }
    }

    // Ekran boyutu de�i�ti�inde kameray� yeniden ayarlamak i�in
    void Update()
    {
        AdjustCamera();
    }
}
