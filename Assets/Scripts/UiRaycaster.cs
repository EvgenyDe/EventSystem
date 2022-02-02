using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

#if UNITY_EDITOR
using UnityEditor;
#endif

public class UiRaycaster : MonoBehaviour
{
    [SerializeField] private GraphicRaycaster raycaster;
    [SerializeField] private EventSystem eventSystem;

    private PointerEventData pointerEventData;

#if UNITY_EDITOR
    private void Reset()
    {
        raycaster = GetComponent<GraphicRaycaster>();
        eventSystem = FindObjectOfType<EventSystem>();

        if (raycaster == null || eventSystem == null)
        {
            EditorUtility.DisplayDialog("Ui Raycaster", "Please add ui raycaster on canvas only", "OK");
            DestroyImmediate(this);
        }
    }
#endif

    private void Update()
    {
        if (!Input.GetKeyDown(KeyCode.Mouse0))
        {
            return;
        }

        pointerEventData = new PointerEventData(eventSystem)
        {
            position = Input.mousePosition
        };

        var result = new List<RaycastResult>();
        raycaster.Raycast(pointerEventData, result);

        foreach (var raycastResult in result)
        {
            Debug.Log($"Hit {raycastResult.gameObject.name}");
        }
    }
}
