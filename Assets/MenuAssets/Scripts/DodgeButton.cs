using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DodgeButton : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    private bool mouse_over = false;
    private RectTransform myTransform;
    public RectTransform canvaCenter;

    void Start()
    {
        myTransform = GetComponent<RectTransform>();
    }

    void Update()
    {
        if (mouse_over)
        {
//            Input.mousePosition / canvas.scaleFactor;
            
            Debug.Log("button pos :" + myTransform.position + " mouse position :" + (Input.mousePosition - canvaCenter.position) + " canva center :" + canvaCenter.position);

            if (myTransform.position.x <= Input.mousePosition.x)
            {
                myTransform.position += new Vector3(0.1f, 0, 0);
            }
            else if (myTransform.position.x >= Input.mousePosition.x)
            {
                myTransform.position += new Vector3(-0.1f, 0, 0);
            }
            if (myTransform.position.y <= Input.mousePosition.y)
            {
                myTransform.position += new Vector3(0, 0.1f, 0);
            }
            else if (myTransform.position.y >= Input.mousePosition.y)
            {
                myTransform.position += new Vector3(0, -0.1f, 0);
            }
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

