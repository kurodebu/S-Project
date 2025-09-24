using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
 
 
 
public class Slot : MonoBehaviour, IDropHandler
{
 
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
 
        //if there is not item already then set our item.
        if (!Item)
        {
 
            DragDrop.itemBeingDragged.transform.SetParent(transform);
            DragDrop.itemBeingDragged.transform.localPosition = new Vector2(0, 0);
            
            // Mengatur ukuran gambar dragdrop sesuai dengan ukuran slot
            RectTransform slotRect = GetComponent<RectTransform>();
            RectTransform draggedItemRect = DragDrop.itemBeingDragged.GetComponent<RectTransform>();
            Debug.Log("Left: " + slotRect.offsetMin.x);
            Debug.Log("Right: " + slotRect.offsetMax.x);
            Debug.Log("Top: " + slotRect.offsetMin.y);
            Debug.Log("Bottom: " + slotRect.offsetMax.y);
            Debug.Log("Offset Min: " + slotRect.offsetMin);
            Debug.Log("Offset Max: " + slotRect.offsetMax);
            Debug.Log("Ukuran Slot: " + slotRect.sizeDelta);
        
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
 
        }
 
 
    }
 
 
 
 
}