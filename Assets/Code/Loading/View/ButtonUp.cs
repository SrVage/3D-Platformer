using UnityEngine;
using UnityEngine.EventSystems;

namespace DefaultNamespace
{
    public class ButtonUp:MonoBehaviour, IPointerDownHandler
    {
        public void OnPointerDown(PointerEventData eventData)
        {
            Debug.Log("Click");
        }
    }
}