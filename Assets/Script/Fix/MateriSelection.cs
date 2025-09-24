using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class MateriSelection : MonoBehaviour
{
    public int materiSelectIndex;
    public GameObject planetPart1;
    public GameObject planetPart2;
    public GameObject planetPart3;
    public GameObject nextMenuButton;
    public GameObject backMenuButton;
    public List<MateriSelectionSO> planetSelect;
    public Text materiText;          // Text to display selected materi string
    public Text namaPlanetText;      // Text to display selected namaPlanet string
    public Transform prefabDisplayArea;  // Parent GameObject where prefab will be instantiated
    public int currentPlanetIndex;
    public GameObject MenuPilihMateri;
    public GameObject MateriTampil2D;
    public GameObject MateriTampil3D;

    void Start()
    {
        materiSelectIndex = 0;
        currentPlanetIndex = 0;
        if (planetSelect == null || planetSelect.Count == 0)
        {
            Debug.LogWarning("Materi list is empty. Please assign MateriSO assets.");
            return;
        }
        // Initialize display with first materi
        ShowSelectedMateri(0);
    }
    public void ShowSelectedMateri(int index)
    {
        if (index < 0 || index >= planetSelect.Count) return;
        var selectedMateri = planetSelect[index];
        materiText.text = selectedMateri.materi;
        namaPlanetText.text = selectedMateri.namaPlanet;
        // Hapus semua child di prefabDisplayArea jika ada
        for (int i = prefabDisplayArea.childCount - 1; i >= 0; i--)
        {
            Transform child = prefabDisplayArea.GetChild(i);
            Destroy(child.gameObject);
        }
        // Instantiate prefab3D jika ada
        if (selectedMateri.prefab3D != null && prefabDisplayArea != null)
        {
            GameObject newObj = Instantiate(selectedMateri.prefab3D);
            newObj.transform.SetParent(prefabDisplayArea, false); // false untuk menjaga ukuran asli
            newObj.transform.localPosition = Vector3.zero; // Set posisi ke nol
            newObj.transform.localRotation = Quaternion.Euler(-18, 38, -8); // Set rotasi ke (0, 0, 5)
        }
    }
    void NextMateriLogic()
    {
        if (materiSelectIndex == 0)
        {
            planetPart1.SetActive(true);
            planetPart2.SetActive(false);
            planetPart3.SetActive(false);
            nextMenuButton.SetActive(true);
            backMenuButton.SetActive(false);
        }
        if (materiSelectIndex == 1)
        {
            planetPart1.SetActive(false);
            planetPart2.SetActive(true);
            planetPart3.SetActive(false);
            nextMenuButton.SetActive(true);
            backMenuButton.SetActive(true);
        }
        if (materiSelectIndex == 2)
        {
            planetPart1.SetActive(false);
            planetPart2.SetActive(false);
            planetPart3.SetActive(true);
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
        MateriTampil3D.SetActive(true);
        ShowSelectedMateri(currentPlanetIndex);
    }
    public void MateriTampilDisable()
    {
        MateriTampil2D.SetActive(false);
        MateriTampil3D.SetActive(false);
        MenuPilihMateri.SetActive(true);
    }
}
