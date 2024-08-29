using UnityEngine;

public class robotRotate : MonoBehaviour
{
    public Transform donusNoktasi; // Karakterin etraf�nda d�nece�i nokta
    public float rotationSpeed = 50f; // D�nme h�z�

    void Update()
    {
        // Karakteri belirlenen nokta etraf�nda d�nd�r
        transform.RotateAround(donusNoktasi.position, Vector3.up, rotationSpeed * Time.deltaTime);
    }
}
