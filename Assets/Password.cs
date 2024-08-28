using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Password : MonoBehaviour
{
    private List<int> girilenRakamlar = new List<int>(); // Girilen rakamlar� tutacak liste
    private int dogruSifre = 3254; // Do�ru �ifre integer olarak
    private string girilenSifreGorunumu = "****"; // �ifre g�r�nt�s� i�in

    public TextMeshProUGUI password3Text;
    public GameObject numberPanel;
    bool isActive;
    bool isCorrectCheck;
    private void Awake()
    {
        numberPanel.SetActive(false);
    }
    private void Update()
    {
        if (numberPanel.activeSelf)
        {
            Cursor.lockState = CursorLockMode.None;
        }
        else
        {
            Cursor.lockState = CursorLockMode.Locked;
        }

        if (Input.GetKeyDown(KeyCode.E) && Movement.isPass && !isCorrectCheck)
        {
            isActive = !isActive;
            
        }
        numberPanel.SetActive(isActive);
        password3Text.text = girilenSifreGorunumu;
    }
    public void ButtonClicked(int indexDegeri)
    {
        // Girilen rakam� listeye ekle
        girilenRakamlar.Add(indexDegeri);

        // Girilen rakamlar kadar �ifre g�r�nt�s�n� g�ncelle
        char[] sifreGorunumu = girilenSifreGorunumu.ToCharArray();
        sifreGorunumu[girilenRakamlar.Count - 1] = (char)('0' + indexDegeri); // Girilen rakam� uygun yere koy
        girilenSifreGorunumu = new string(sifreGorunumu);


        // Girilen rakamlar do�ru �ifrenin uzunlu�una ula�t���nda kontrol yap
        if (girilenRakamlar.Count == dogruSifre.ToString().Length)
        {
            // Girilen rakamlar� integer olarak birle�tir
            int girilenSifre = 0;
            for (int i = 0; i < girilenRakamlar.Count; i++)
            {
                girilenSifre = girilenSifre * 10 + girilenRakamlar[i];
            }

            // Girilen �ifre ile do�ru �ifreyi kar��la�t�r
            if (girilenSifre == dogruSifre)
            {
                isActive = false;
                numberPanel.SetActive(isActive);
                isCorrectCheck  = true;
                Debug.Log("Do�ru �ifre!");
                // Do�ru �ifre i�in yap�lacak i�lemler
            }
            else
            {

                Debug.Log("Yanl�� �ifre.");
                // Yanl�� �ifre i�in yap�lacak i�lemler
            }

            // Sonraki deneme i�in listeyi temizle ve �ifre g�r�nt�s�n� s�f�rla
            girilenRakamlar.Clear();
            girilenSifreGorunumu = "****";
        }
    }

    public void FalseCheckFNC()
    {
        Debug.Log("er");
        isActive = false;
    }
}
