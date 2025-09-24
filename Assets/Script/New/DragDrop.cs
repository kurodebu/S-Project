using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
 
public class DragDrop : MonoBehaviour, IBeginDragHandler, IEndDragHandler, IDragHandler
{
    [SerializeField] private Canvas canvas;
    private RectTransform rectTransform;
    private CanvasGroup canvasGroup;
 
    public static GameObject itemBeingDragged;
    private static List<DragDrop> allDragDrops = new List<DragDrop>();
    Vector3 startPosition;
    Transform startParent;
    // Variabel untuk menyimpan nilai
    [SerializeField]
    private int value; // Nilai yang dapat diubah
    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
        canvasGroup = GetComponent<CanvasGroup>();
        // Tambahkan instance ini ke dalam list
        allDragDrops.Add(this);
    }
    public void OnBeginDrag(PointerEventData eventData)
    {
        Debug.Log("OnBeginDrag");
        canvasGroup.alpha = .6f;
        //So the ray cast will ignore the item itself.
        canvasGroup.blocksRaycasts = false;
        startPosition = transform.position;
        startParent = transform.parent;
        transform.SetParent(transform.root);
        itemBeingDragged = gameObject;
    }
    public void OnDrag(PointerEventData eventData)
    {
        //So the item will move with our mouse (at same speed)  and so it will be consistant if the canvas has a different scale (other then 1);
        rectTransform.anchoredPosition += eventData.delta;
    }
    public void OnEndDrag(PointerEventData eventData)
    {
        itemBeingDragged = null;
        if (transform.parent == startParent || transform.parent == transform.root)
        {
            transform.position = startPosition;
            transform.SetParent(startParent);
        }
        Debug.Log("OnEndDrag");
        canvasGroup.alpha = 1f;
        canvasGroup.blocksRaycasts = true;
    }
    private void OnDestroy()
    {
        // Hapus instance ini dari list saat dihancurkan
        allDragDrops.Remove(this);
    }
    // Metode untuk mengubah nilai
    public void SetValue(int newValue)
    {
        value = newValue;
    }
    // Metode untuk mendapatkan nilai
    public int GetValue()
    {
        return value;
    }
    public void ResetPosition()
    {
        // Kembalikan posisi objek ke posisi awal
        //transform.position = startPosition;
        // Set parent objek ke parent awal
        transform.SetParent(startParent);
    }
    public static void ResetAllPositions()
    {
        foreach (DragDrop dragDrop in allDragDrops)
        {
            dragDrop.ResetPosition();
        }
    }
}