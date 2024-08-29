using System.Collections;
using UnityEngine;

public class emirController : MonoBehaviour
{
    public GameObject player;  // Oyuncu k�p�
    public float detectionDistance = 2f;  // Mesafe �l��m�
    public float moveDistance = 3f;  // �leri hareket mesafesi
    public float moveSpeed = 2f;  // Hareket h�z� (sabit h�z)
    public AudioSource audioSource;  // Ses kayna��
    private bool soundPlayed = false;  // Ses �ald� m� kontrol�
    private bool isMoving = false;  // Hareket halinde mi kontrol�

    void Update()
    {
        // Yaln�zca hareket etmiyorsa mesafeyi kontrol et
        if (!soundPlayed && !isMoving)
        {
            // Oyuncu ve yanda� aras�ndaki mesafeyi kontrol et
            float distance = Vector3.Distance(transform.position, player.transform.position);
            Debug.Log("Distance to player: " + distance);  // Mesafeyi yazd�r
            // Mesafe 2 metreden azsa ses �al ve ard�ndan hareket et
            if (distance <= detectionDistance)
            {
                StartCoroutine(PlaySoundAndMove());
            }
        }
    }

    // Ses �al ve sonra hareket et
    IEnumerator PlaySoundAndMove()
    {
        soundPlayed = true;

        // Sesi �al
        audioSource.Play();

        // Sesin bitmesini bekle
        yield return new WaitForSeconds(audioSource.clip.length);

        // Hareket etmeye ba�la
        StartCoroutine(MoveForward());
    }

    // 3 metre sabit h�zla hareket et
    IEnumerator MoveForward()
    {
        isMoving = true;
        Vector3 startPosition = transform.position;
        Vector3 targetPosition = startPosition + transform.forward * moveDistance;

        // Zaman i�inde hareket ettir
        float elapsedTime = 0;
        float journeyTime = moveDistance / moveSpeed;  // Hedef pozisyona varma s�resi

        while (elapsedTime < journeyTime)
        {
            // H�zla nesneyi hareket ettir
            transform.position = Vector3.Lerp(startPosition, targetPosition, elapsedTime / journeyTime);
            elapsedTime += Time.deltaTime;
            yield return null;  // Bir sonraki frame'e ge�
        }

        // Tam hedef pozisyona yerle�tir
        transform.position = targetPosition;

        // Yandas k�p�n� devre d��� yap (setActive false)
        gameObject.SetActive(false);
        isMoving = false;
    }
}