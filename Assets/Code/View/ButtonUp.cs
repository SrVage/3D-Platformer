using UnityEngine;
using UnityEngine.EventSystems;

namespace Code.View
{
    public class ButtonUp:MonoBehaviour, IPointerDownHandler
    {
        public void OnPointerDown(PointerEventData eventData)
        {
            Debug.Log("Click");
        }
    }
}