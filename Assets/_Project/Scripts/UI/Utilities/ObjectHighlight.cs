using DG.Tweening;
using UnityEngine;
using UnityEngine.EventSystems;

namespace _Project.Scripts.UI.Utilities
{
    public class ObjectHighlight : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
    {
        private float _higlightScale = 1.1f;

        public void OnPointerEnter(PointerEventData eventData)
        {
            transform.DOScale(new Vector3(_higlightScale, _higlightScale, _higlightScale), 0.25f).SetUpdate(true);
        }

        public void OnPointerExit(PointerEventData eventData)
        {
            transform.DOScale(Vector3.one, 0.25f).SetUpdate(true);
        }

    }
}
