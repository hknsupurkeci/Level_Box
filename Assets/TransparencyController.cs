using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransparencyController : MonoBehaviour
{
    public List<GameObject> gameObjects; // GameObject listesi
    private int currentObjectIndex = 0; // �u anki GameObject index'i
    private Coroutine coroutine;
    void Start()
    {
        ResetTransparency(); // Ba�lang��ta t�m objeleri �effaf yap
    }

    public void OnPlayerDeath()
    {
        if (coroutine != null)
        {
            StopCoroutine(coroutine); // �al��an Coroutine'i durdur
            coroutine = null; // Coroutine referans�n� temizle
        }
        ResetTransparency();
        currentObjectIndex = 0; // Index'i s�f�rla ama �effafl�k de�i�imini ba�latma
    }


    private void ResetTransparency()
    {
        // T�m objelerin renklerini tamamen �effaf yap
        foreach (GameObject obj in gameObjects)
        {
            SpriteRenderer renderer = obj.GetComponent<SpriteRenderer>();
            if (renderer != null)
            {
                Color color = renderer.color;
                color.a = 0;
                renderer.color = color;
            }
        }
    }

    // Trigger fonksiyonu, d��ar�dan tetiklenebilir
    public void TriggerTransparencyChange()
    {
        if (currentObjectIndex < gameObjects.Count)
        {
            coroutine = StartCoroutine(ChangeTransparency(gameObjects[currentObjectIndex]));
        }
    }

    IEnumerator ChangeTransparency(GameObject obj)
    {
        SpriteRenderer renderer = obj.GetComponent<SpriteRenderer>();
        if (renderer != null)
        {
            while (renderer.color.a < 1)
            {
                Color color = renderer.color;
                color.a += Time.deltaTime / 2f; // Her saniyede renk de�i�im h�z�
                renderer.color = color;
                yield return null;
            }
            currentObjectIndex++; // Sonraki objeye ge�
            if (currentObjectIndex < gameObjects.Count)
            {
                TriggerTransparencyChange(); // Otomatik olarak sonraki objeyi tetikle
            }
        }
    }
}
