using UnityEngine;
using UnityEngine.EventSystems;

public class BtnJumpScript : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IPointerClickHandler
{

    public bool isPressed = false;
    
    public void OnPointerClick(PointerEventData eventData)
    {
        Debug.Log("OnPointerClick");
       
    }
    public void OnPointerUp(PointerEventData eventData)
    {
        Debug.Log("OnPointerUp");
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        Debug.Log("OnPointerDown");
        isPressed = true;
    }

   
}
