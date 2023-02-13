using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DodgeButton : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    private bool mouse_over = false;
    private RectTransform myTransform;
    public RectTransform canvas;

    void Start()
    {
        myTransform = GetComponent<RectTransform>();
        Debug.Log(myTransform.position);
    }

    void Update()
    {
        if (mouse_over)
        {
            Vector3 randomDirection = new Vector3(Random.Range(-1, 1), Random.Range(-1, 1), 0);
            Debug.Log(randomDirection);
            myTransform.position += randomDirection;
        }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        mouse_over = true;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        mouse_over = false;
    }
}
