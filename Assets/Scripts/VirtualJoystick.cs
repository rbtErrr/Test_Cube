using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;


public class VirtualJoystick : MonoBehaviour, IDragHandler, IPointerUpHandler, IPointerDownHandler {

    private Image bgImage;
    private Image joysytickImg;

    public Vector3 InputDirection { set; get; } 

    // Use this for initialization
    void Start()
    {
        bgImage = GetComponent<Image>();
        joysytickImg = transform.GetChild(0).GetComponentInChildren<Image>();
        InputDirection = Vector3.zero;
    }

    public void OnDrag(PointerEventData eventData)
    {
        Vector2 pos = Vector2.zero;

        if (RectTransformUtility.ScreenPointToLocalPointInRectangle(bgImage.rectTransform, eventData.position, eventData.pressEventCamera, out pos))
        {
            pos.x = (pos.x / bgImage.rectTransform.sizeDelta.x);
            pos.y = (pos.y / bgImage.rectTransform.sizeDelta.y);

            float x = (bgImage.rectTransform.pivot.x == 1) ? pos.x * 2 + 1 : pos.x * 2 - 1;
            float y = (bgImage.rectTransform.pivot.y == 1) ? pos.y * 2 + 1 : pos.y * 2 - 1;

            InputDirection = new Vector3(x, 0, y);
            InputDirection = (InputDirection.magnitude > 1) ? InputDirection.normalized : InputDirection;
            Debug.Log(InputDirection);
            joysytickImg.rectTransform.anchoredPosition = new Vector3(InputDirection.x * (bgImage.rectTransform.sizeDelta.x / 3),
                InputDirection.z * (bgImage.rectTransform.sizeDelta.y / 3));
        }
        //throw new System.NotImplementedException();
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        OnDrag(eventData);
        //throw new System.NotImplementedException();
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        InputDirection = Vector3.zero;
        joysytickImg.rectTransform.anchoredPosition = Vector3.zero;
        //throw new System.NotImplementedException();
    }

    public float Horizontal()
    {
        if(InputDirection.x != 0){
            return InputDirection.x;
        }else{
            return Input.GetAxis("Horizontal");
        }
    }

    public float Vertical()
    {
        if (InputDirection.z != 0)
        {
            return InputDirection.z;
        }
        else
        {
            return Input.GetAxis("Vertical");
        }
    }

    
	
	// Update is called once per frame
	void Update () {
		
	}
}
