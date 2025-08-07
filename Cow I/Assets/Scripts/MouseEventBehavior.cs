using UnityEngine;
using UnityEngine.Events;

public class MouseEventBehavior : MonoBehaviour
{
    public UnityEvent mouseDownEvent, mouseUpEvent, mouseEnterEvent, mouseExitEvent;
    public void OnMouseDown()
    {
        mouseDownEvent.Invoke();
    }
    public void OnMouseUp()
    {
        mouseUpEvent.Invoke();
    }
    public void OnMouseEnter()
    {
        mouseEnterEvent.Invoke();
    }
    public void OnMouseExit()
    {
        mouseExitEvent.Invoke();
    }
}
