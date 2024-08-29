using UnityEngine;

public class Card : MonoBehaviour
{
    public GameObject cardFront;  // Kart�n �n y�z�
    public GameObject cardBack;   // Kart�n arka y�z�
    public bool isFlipped = false; // Kart�n �evrilip �evrilmedi�ini kontrol eder

    private void Start()
    {
        // Ba�lang��ta sadece cardFront g�r�n�r, cardBack g�r�nmez
        cardFront.SetActive(true);
        cardBack.SetActive(false);
    }

    private void OnMouseDown()
    {
        // Kart�n �zerine t�kland���nda ne olaca��n� kontrol eder
        if (!isFlipped)
        {
            FindObjectOfType<GameManager>().SelectCard(this);
        }
    }

    public void FlipCard()
    {
        // Kart� �evirir (cardFront <-> cardBack)
        isFlipped = !isFlipped;
        cardFront.SetActive(!isFlipped);
        cardBack.SetActive(isFlipped);
    }
}
