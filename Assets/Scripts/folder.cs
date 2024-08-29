using UnityEngine;
using UnityEngine.UI;

public class folder : MonoBehaviour
{
    public Transform player; // Player objesini sahneye ekleyin.
    public Transform folder1; // Folder objesini sahneye ekleyin.
    public Canvas canvas;    // Canvas objesini sahneye ekleyin.
    public float activationDistance = 2f; // Mesafe kontrol� i�in de�i�ken.

    void Update()
    {
        // Player ve folder aras�ndaki mesafeyi kontrol edin.
        float distance = Vector3.Distance(player.position, folder1.position);

        // E tu�una bas�ld���nda ve mesafe 2 metreden az oldu�unda canvas'� a��n.
        if (Input.GetKeyDown(KeyCode.E) && distance <= activationDistance)
        {
            canvas.gameObject.SetActive(true);
        }
    }

    // Continue butonuna ba�lanacak fonksiyon.
    public void CloseCanvas()
    {
        canvas.gameObject.SetActive(false);
    }
}