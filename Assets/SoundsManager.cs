using System.Collections.Generic;
using UnityEngine;

public class SoundsManager : MonoBehaviour
{
    public static SoundsManager Instance;  // Singleton instance

    public List<AudioClip> jumpSounds;  // Z�plama sesleri
    public AudioClip checkpointSound;  // Checkpoint sesi
    public AudioClip deadSound;  // �l�m sesi

    private AudioSource audioSource;

    void Awake()
    {
        // Singleton pattern uygulamas�
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);  // Scene de�i�ikliklerinde yok olmamas� i�in
        }
        else
        {
            Destroy(gameObject);
        }

        audioSource = GetComponent<AudioSource>();
    }

    // Ses dosyas�n� ve ses seviyesini parametre olarak al�r
    public void PlaySound(AudioClip clip, float volume = 1.0f)
    {
        audioSource.PlayOneShot(clip, volume);
    }
}
