using UnityEngine;
using UnityEngine.UI;

public class EmptyObjectManager : MonoBehaviour
{
    public GameObject[] emptyObjects; // Array untuk menyimpan empty object
    public GameObject[] childPrefabs; // Prefab untuk child object (1-8)
    public GameObject buttonPrefab; // Prefab untuk tombol
    public Transform buttonPanel; // Panel untuk menampung tombol
    public GameObject matchButton; // Tombol pencocokan

    private int[] values; // Array untuk menyimpan nilai dari empty object

    void Start()
    {
        values = new int[emptyObjects.Length];
        matchButton.SetActive(false);
    }

    public void OnEmptyObjectClicked(int index)
    {
        ClearButtons();
        CreateButtons(index);
    }

    private void CreateButtons(int index)
    {
        for (int i = 1; i <= 8; i++)
        {
            GameObject button = Instantiate(buttonPrefab, buttonPanel);
            button.GetComponentInChildren<Text>().text = i.ToString();
            int value = i; // Local copy for closure
            button.GetComponent<Button>().onClick.AddListener(() => OnValueSelected(index, value));
        }
    }

    private void OnValueSelected(int index, int value)
    {
        values[index] = value;
        Instantiate(childPrefabs[value - 1], emptyObjects[index].transform); // Instantiate child object
        CheckMatchButton();
        ClearButtons();
    }

    private void ClearButtons()
    {
        foreach (Transform child in buttonPanel)
        {
            Destroy(child.gameObject);
        }
    }

    private void CheckMatchButton()
    {
        bool allFilled = true;
        foreach (int value in values)
        {
            if (value == 0)
            {
                allFilled = false;
                break;
            }
        }
        matchButton.SetActive(allFilled);
    }
}