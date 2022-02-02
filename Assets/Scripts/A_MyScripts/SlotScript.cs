using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class SlotScript : MonoBehaviour, IPointerEnterHandler,IPointerExitHandler,IPointerUpHandler,IPointerDownHandler
{

    private GameObject _item;
    private void Start()
    {
        Item.OnSlotEnter += SetItem;
        Item.OnDeleteReferenseItem += DeleteReferenceItem;
    }

    private void DeleteReferenceItem()
    {
        Debug.Log("I");
       
        _item.transform.localPosition = Vector3.zero;
        _item = null;
    }


    private void SetItem(GameObject item )
    {
        // if (item == null)
        // {
        //     _item.transform.SetParent(this.gameObject.transform,true);
        //     _item = null;
        // }
        // if (item != null)
        // {
        //     item.transform.SetParent(this.gameObject.transform,true);
        // }

        _item = item;
        //Debug.Log(_item);
    }
    
    public void OnPointerEnter(PointerEventData eventData)
    {
        transform.DOScale(Vector3.one * 1.2f, 0.3f);
        
        if (_item != null)
        {
            _item.transform.SetParent(this.gameObject.transform,true);
        }
        
        
    }


    public void OnPointerExit(PointerEventData eventData)
    {
       
        transform.DOScale(Vector3.one * 1f, 0.3f);
        
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        GetComponent<Image>().color = Color.yellow;
        _item = null;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        GetComponent<Image>().color = Color.green;
    }
}