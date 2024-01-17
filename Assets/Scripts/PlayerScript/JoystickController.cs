using UnityEngine;
using UnityEngine.EventSystems;

public class JoystickController : MonoBehaviour, IDragHandler, IPointerUpHandler, IPointerDownHandler
{
    public RectTransform outerCircle;
    public RectTransform innerCircle;

    private Vector2 inputVector;

    public void OnDrag(PointerEventData eventData)
    {
        Vector2 pos;
        if (RectTransformUtility.ScreenPointToLocalPointInRectangle(outerCircle, eventData.position, eventData.pressEventCamera, out pos))
        {
            pos.x = (pos.x / outerCircle.sizeDelta.x);
            pos.y = (pos.y / outerCircle.sizeDelta.y);

            inputVector = new Vector2(pos.x * 2 - 1, pos.y * 2 - 1);
            inputVector = (inputVector.magnitude > 1.0f) ? inputVector.normalized : inputVector;

            // Move the inner circle based on the joystick input
            innerCircle.anchoredPosition = new Vector2(inputVector.x * (outerCircle.sizeDelta.x / 3), inputVector.y * (outerCircle.sizeDelta.y / 3));
        }
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        OnDrag(eventData);
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        inputVector = Vector2.zero;
        innerCircle.anchoredPosition = Vector2.zero;
    }

    public float GetHorizontalInput()
    {
        return inputVector.x;
    }

    public float GetVerticalInput()
    {
        return inputVector.y;
    }
}
