using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
 
 
 
public class SlotChecking : MonoBehaviour, IDropHandler
{
    // Variabel untuk menyimpan nilai yang diterima
    private int receivedValue;
 
    public GameObject Item
    {
        get
        {
            if (transform.childCount > 0 )
            {
                return transform.GetChild(0).gameObject;
            }
 
            return null;
        }
    }
 
 
 
 
 
 
    public void OnDrop(PointerEventData eventData)
    {
        Debug.Log("OnDrop");
        DragDrop itemBeingDragged = eventData.pointerDrag.GetComponent<DragDrop>();
        //if there is not item already then set our item.
        if (!Item)
        {
 
            itemBeingDragged.transform.SetParent(transform);
            itemBeingDragged.transform.localPosition = new Vector2(0, 0);
            
            // Mengatur ukuran gambar dragdrop sesuai dengan ukuran slot
            RectTransform slotRect = GetComponent<RectTransform>();
            RectTransform draggedItemRect = DragDrop.itemBeingDragged.GetComponent<RectTransform>();
        
            // Mengatur ukuran gambar dragdrop agar sesuai dengan slot
            //draggedItemRect.sizeDelta = slotRect.sizeDelta;
            if (slotRect.sizeDelta.x > 0 && slotRect.sizeDelta.y > 0)
            {
                draggedItemRect.sizeDelta = slotRect.sizeDelta;
            }
            else
            {
                Debug.LogWarning("Ukuran slot tidak valid!");
            }

            // Mengatur posisi gambar dragdrop ke tengah slot
            draggedItemRect.anchoredPosition = Vector2.zero;
            // Memberikan nilai dari objek yang di-drag
            ReceiveValue(itemBeingDragged.GetValue());
 
        }

    }

    // Metode untuk menerima nilai
    public void ReceiveValue(int value)
    {
        receivedValue = value; // Simpan nilai yang diterima
        Debug.Log("Received value: " + receivedValue); // Tampilkan nilai yang diterima
    }

    // Metode untuk mendapatkan nilai yang diterima
    public int GetReceivedValue()
    {
        return receivedValue;
    }

     // Metode untuk mengatur nilai menjadi 0 jika tidak ada child
    private void UpdateValueIfNoChild()
    {
        if (transform.childCount == 0)
        {
            receivedValue = 0; // Set nilai menjadi 0
        }
    }

    void Update() 
    {
        UpdateValueIfNoChild();
    }
 
 
 
 
}