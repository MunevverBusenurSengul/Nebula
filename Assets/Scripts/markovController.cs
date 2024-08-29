using UnityEngine;

public class markovController : MonoBehaviour
{
    public Transform player; // Player objesini sahneye ekleyin.
    public float activationDistance = 3f; // Mesafe kontrol� i�in de�i�ken.
    public float moveDistance = 2f; // Markov objesinin hareket edece�i mesafe.
    public float moveSpeed = 2f; // Hareket h�z�.
    private Vector3 initialPosition; // Markov objesinin ba�lang�� pozisyonu.
    private AudioSource audioSource; // Markov objesine ba�l� AudioSource.

    private bool isMovingForward = false; // Hareket y�n�n� kontrol etmek i�in de�i�ken.
    private bool hasAudioPlayed = false;  // AudioSource'un bir kez oynat�l�p oynat�lmad���n� kontrol etmek i�in de�i�ken.

    void Start()
    {
        // Markov objesinin ba�lang�� pozisyonunu kaydedin.
        initialPosition = transform.position;

        // AudioSource bile�enini al�n.
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        // Player ve Markov objesi aras�ndaki mesafeyi kontrol edin.
        float distance = Vector3.Distance(player.position, transform.position);

        // E�er mesafe 3 metreden azsa ve ses daha �nce �al�nmam��sa, ses �almaya ba�la ve hareket et.
        if (distance <= activationDistance && !hasAudioPlayed)
        {
            audioSource.Play();
            hasAudioPlayed = true;
            isMovingForward = true;
        }

        // E�er ses �al�yorsa, Markov objesini hareket ettir.
        if (audioSource.isPlaying)
        {
            MoveMarkov();
        }
    }

    void MoveMarkov()
    {
        // Hareket y�n�n� kontrol edin ve Markov objesini ileri veya geri hareket ettirin.
        if (isMovingForward)
        {
            transform.position = Vector3.MoveTowards(transform.position, initialPosition + transform.forward * moveDistance, moveSpeed * Time.deltaTime);

            // Markov objesi belirtilen mesafeye ula�t���nda, geri d�nmeye ba�lay�n.
            if (Vector3.Distance(transform.position, initialPosition + transform.forward * moveDistance) < 0.01f)
            {
                isMovingForward = false;
            }
        }
        else
        {
            transform.position = Vector3.MoveTowards(transform.position, initialPosition, moveSpeed * Time.deltaTime);

            // Markov objesi ba�lang�� pozisyonuna d�nd���nde, ileri hareket etmeye ba�lay�n.
            if (Vector3.Distance(transform.position, initialPosition) < 0.01f)
            {
                isMovingForward = true;
            }
        }
    }
}