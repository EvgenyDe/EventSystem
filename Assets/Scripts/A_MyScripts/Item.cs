using System;
using DG.Tweening;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Item : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IPointerEnterHandler, IPointerExitHandler
, IDragHandler
{
    [SerializeField] private Image image;
    [SerializeField] private Camera camera;

    [SerializeField] private GameObject dragObject = null;

    public static event Action<GameObject> OnSlotEnter;
    public static event Action OnDeleteReferenseItem;
  
    public void OnPointerDown(PointerEventData eventData)
    {
        image.DOColor(new Color(1f, 0.9f, 0.9f, 1f), 0.3f);
        OnSlotEnter?.Invoke(this.gameObject);
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        image.DOColor(Color.white, 0.3f);
        
        OnSlotEnter?.Invoke(null);
        //Invoke(nameof(ResetReferense),0.1f);
        
    }
   

    public void OnPointerEnter(PointerEventData eventData)
    {
        transform.DOScale(Vector3.one * 1.1f, 0.3f);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        transform.DOScale(Vector3.one, 0.3f);
    }
    
    

    public void OnDrag(PointerEventData eventData)
    {
        var pos = camera.ScreenToWorldPoint(Input.mousePosition);
        pos.z = 0f;
        transform.position = pos;

        dragObject = this.gameObject;
        
    }
}