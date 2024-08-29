
//using UnityEngine;
//using UnityEngine.UI;

//public class PuzzleManager : MonoBehaviour
//{
//    public Button[] puzzleButtons; // Yapboz butonlar� (9 buton)
//    private Button lastClickedButton;
//    public GameObject panel; // Paneli kapatmak i�in

//    void Start()
//    {
//        // Butonlar� kar��t�r
//        // ShuffleButtons();

//        // Butonlara t�klama olaylar�n� ekleyin
//        foreach (Button button in puzzleButtons)
//        {
//            button.onClick.AddListener(() => OnButtonClick(button));
//        }
//    }

//    //private void ShuffleButtons()
//    //{
//    //    // Butonlar� kar��t�r
//    //    for (int i = 0; i < puzzleButtons.Length; i++)
//    //    {
//    //        int randomIndex = Random.Range(0, puzzleButtons.Length);
//    //        SwapButtons(puzzleButtons[i], puzzleButtons[randomIndex]);
//    //    }
//    //}

//    private void OnButtonClick(Button clickedButton)
//    {
//        if (lastClickedButton == null)
//        {
//            // �lk butona t�klanm��sa, lastClickedButton'� ayarla
//            lastClickedButton = clickedButton;
//        }
//        else
//        {
//            // �kinci butona t�klanm��sa, yer de�i�tir
//            SwapButtons(lastClickedButton, clickedButton);
//            lastClickedButton = null;

//            // Yapbozun tamamlan�p tamamlanmad���n� kontrol et
//            CheckIfSolved();
//        }
//    }

//    private void SwapButtons(Button button1, Button button2)
//    {
//        int index1 = System.Array.IndexOf(puzzleButtons, button1);
//        int index2 = System.Array.IndexOf(puzzleButtons, button2);

//        if (index1 != -1 && index2 != -1)
//        {
//            // Yer de�i�tir
//            Vector2 tempPosition = button1.GetComponent<RectTransform>().anchoredPosition;
//            button1.GetComponent<RectTransform>().anchoredPosition = button2.GetComponent<RectTransform>().anchoredPosition;
//            button2.GetComponent<RectTransform>().anchoredPosition = tempPosition;

//            // Butonlar�n konumlar�n� g�ncelle
//            Button tempButton = puzzleButtons[index1];
//            puzzleButtons[index1] = puzzleButtons[index2];
//            puzzleButtons[index2] = tempButton;

//            // currentIndex de�erlerini g�ncelle
//            // button1.GetComponent<PuzzlePiece>().SetCurrentIndex();
//            //button2.GetComponent<PuzzlePiece>().SetCurrentIndex();

//            // Debug log ekleyin
//            Debug.Log($"Swapped {button1.name} with {button2.name}. Updated indices: {button1.GetComponent<PuzzlePiece>().currentIndex} and {button2.GetComponent<PuzzlePiece>().currentIndex}");
//        }
//    }

//    private void CheckIfSolved()
//    {
//        bool solved = true;
//        for (int i = 0; i < puzzleButtons.Length; i++)
//        {
//            Button button = puzzleButtons[i];
//            int currentIndex = button.GetComponent<PuzzlePiece>().currentIndex;
//            int correctIndex = button.GetComponent<PuzzlePiece>().correctIndex;

//            // Debug log ekleyin
//            Debug.Log($"Button {button.name}: currentIndex = {currentIndex}, correctIndex = {correctIndex}");

//            if (currentIndex != correctIndex)
//            {
//                solved = false;

//            }
//        }

//        if (solved)
//        {
//            Debug.Log("Tebrikler! Yapbozu tamamlad�n�z.");
//            panel.SetActive(false); // Paneli kapat
//        }
//    }
//}



using UnityEngine;
using UnityEngine.UI;

public class PuzzleManager : MonoBehaviour
{
    public Button[] puzzleButtons; // Yapboz butonlar� (9 buton)
    private Button lastClickedButton;
    public GameObject panel; // Paneli kapatmak i�in

    void Start()
    {
        // Butonlara t�klama olaylar�n� ekleyin
        foreach (Button button in puzzleButtons)
        {
            button.onClick.AddListener(() => OnButtonClick(button));
        }
    }

    private void OnButtonClick(Button clickedButton)
    {
        if (lastClickedButton == null)
        {
            // �lk butona t�klanm��sa, lastClickedButton'� ayarla
            lastClickedButton = clickedButton;
        }
        else
        {
            // �kinci butona t�klanm��sa, yer de�i�tir
            SwapButtons(lastClickedButton, clickedButton);
            lastClickedButton = null;

            // Yapbozun tamamlan�p tamamlanmad���n� kontrol et
            CheckIfSolved();
        }
    }

    private void SwapButtons(Button button1, Button button2)
    {
        int index1 = System.Array.IndexOf(puzzleButtons, button1);
        int index2 = System.Array.IndexOf(puzzleButtons, button2);

        if (index1 != -1 && index2 != -1)
        {
            // Yer de�i�tir
            Vector2 tempPosition = button1.GetComponent<RectTransform>().anchoredPosition;
            button1.GetComponent<RectTransform>().anchoredPosition = button2.GetComponent<RectTransform>().anchoredPosition;
            button2.GetComponent<RectTransform>().anchoredPosition = tempPosition;

            // Dizideki butonlar�n yerini de�i�tir
            Button tempButton = puzzleButtons[index1];
            puzzleButtons[index1] = puzzleButtons[index2];
            puzzleButtons[index2] = tempButton;

            // currentIndex de�erlerini g�ncelle
            button1.GetComponent<PuzzlePiece>().SetCurrentIndex(index2);
            button2.GetComponent<PuzzlePiece>().SetCurrentIndex(index1);

            // Debug log ekleyin
            Debug.Log($"Swapped {button1.name} with {button2.name}. Updated indices: {button1.GetComponent<PuzzlePiece>().currentIndex} and {button2.GetComponent<PuzzlePiece>().currentIndex}");
        }
    }

    private void CheckIfSolved()
    {
        bool solved = true;
        for (int i = 0; i < puzzleButtons.Length; i++)
        {
            Button button = puzzleButtons[i];
            int currentIndex = button.GetComponent<PuzzlePiece>().currentIndex;
            int correctIndex = button.GetComponent<PuzzlePiece>().correctIndex;

            // Debug log ekleyin
            Debug.Log($"Button {button.name}: currentIndex = {currentIndex}, correctIndex = {correctIndex}");

            if (currentIndex != correctIndex)
            {
                solved = false;
                break;
            }
        }

        if (solved)
        {
            Debug.Log("Tebrikler! Yapbozu tamamlad�n�z.");
            panel.SetActive(false); // Paneli kapat
        }
    }
}
