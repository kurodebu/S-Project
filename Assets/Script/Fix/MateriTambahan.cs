using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class MateriTambahan : MonoBehaviour
{
    public int materiSelectIndex;
    public int currentFaktaIndex;
    public GameObject faktaPart1;
    public GameObject faktaPart2;
    public GameObject faktaPart3;
    public GameObject nextMenuButton;
    public GameObject backMenuButton;
    public Text materiText;          // Text to display selected materi string
    public Text namaPlanetText;
    public GameObject MenuPilihMateri;
    public GameObject MateriTampil2D;
    public Transform photosLocation;
    public List<FaktaSO> faktaSO;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        materiSelectIndex = 0;
        currentFaktaIndex = 0;
    }
    public void ShowSelectedMateri(int index)
    {
        if (index < 0 || index >= faktaSO.Count) return;
        var selectedMateri = faktaSO[index];
        materiText.text = selectedMateri.materi;
        namaPlanetText.text = selectedMateri.namaFakta;
        // Destroy previous prefab instance if exists
        // Hapus semua child di photosLocation jika ada
        for (int i = photosLocation.childCount - 1; i >= 0; i--)
        {
            Transform child = photosLocation.GetChild(i);
            Destroy(child.gameObject);
        }
        // Instantiate prefab3D jika ada
        if (selectedMateri.prefab2D != null && photosLocation != null)
        {
            GameObject newObj = Instantiate(selectedMateri.prefab2D);
            newObj.transform.SetParent(photosLocation, false); // false untuk menjaga ukuran asli
            newObj.transform.localPosition = Vector3.zero; // Set posisi ke nol
        }
    }
    void NextMateriLogic()
    {
        if (materiSelectIndex == 0)
        {
            faktaPart1.SetActive(true);
            faktaPart2.SetActive(false);
            faktaPart3.SetActive(false);
            nextMenuButton.SetActive(true);
            backMenuButton.SetActive(false);
        }
        if (materiSelectIndex == 1)
        {
            faktaPart1.SetActive(false);
            faktaPart2.SetActive(true);
            faktaPart3.SetActive(false);
            nextMenuButton.SetActive(true);
            backMenuButton.SetActive(true);
        }
        if (materiSelectIndex == 2)
        {
            faktaPart1.SetActive(false);
            faktaPart2.SetActive(false);
            faktaPart3.SetActive(true);
            nextMenuButton.SetActive(false);
            backMenuButton.SetActive(true);
        }
    }
    public void NextMenu()
    {
        if (materiSelectIndex <= 2)
        {
            materiSelectIndex += 1;
            NextMateriLogic();
        }
    }
    public void BackMenu()
    {
        if (materiSelectIndex >= 0)
        {
            materiSelectIndex -= 1;
            NextMateriLogic();
        }
    }
    public void MateriTampilClick()
    {
        MenuPilihMateri.SetActive(false);
        MateriTampil2D.SetActive(true);
        ShowSelectedMateri(currentFaktaIndex);
    }
    public void MateriTampilDisable()
    {
        MateriTampil2D.SetActive(false);
        MenuPilihMateri.SetActive(true);
    }
}
