//using UnityEngine;
//using UnityEngine.UI;

//public class PuzzlePiece : MonoBehaviour
//{
//    public int correctIndex; // Par�an�n do�ru pozisyonu
//    public int currentIndex; // Par�an�n mevcut pozisyonu

//    void Start()
//    {
//        // Butonun ba�lang��taki do�ru konumunu ayarla
//        correctIndex = System.Array.IndexOf(GetComponentInParent<PuzzleManager>().puzzleButtons, GetComponent<Button>());

//    }

//    // currentIndex de�erini g�ncellemek i�in metot
//    public void UpdateCurrentIndex(int newIndex)
//    {
//        currentIndex = newIndex;
//    }

//    // currentIndex de�erini hesapla
//    public void SetCurrentIndex()
//    {
//        currentIndex = System.Array.IndexOf(GetComponentInParent<PuzzleManager>().puzzleButtons, GetComponent<Button>());
//    }
//}


using UnityEngine;
using UnityEngine.UI;

public class PuzzlePiece : MonoBehaviour
{
    public int correctIndex; // Par�an�n do�ru pozisyonu
    public int currentIndex; // Par�an�n mevcut pozisyonu

    void Start()
    {
        // Ba�lang��ta currentIndex'i do�ru indeks olarak ayarla
        SetCurrentIndex(correctIndex);
    }

    // currentIndex de�erini g�ncellemek i�in metot
    public void SetCurrentIndex(int newIndex)
    {
        currentIndex = newIndex;
    }
}
