using DG.Tweening;
using UnityEngine;
using UnityEngine.EventSystems;

namespace _Project.Scripts.UI.MainScene
{
    public class CanvasPanelMouseDisplay : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
    {
        [SerializeField] private GameObject _panelToDisplay;
        [SerializeField] private AudioSource _as;

        private void Start()
        {
            _panelToDisplay.SetActive(true);
            _panelToDisplay.transform.localScale = Vector3.zero;
        }

        public void OnPointerEnter(PointerEventData eventData)
        {
            _panelToDisplay.transform.DOScale(Vector3.one, 0.25f);
            _as.Play();
        }

        public void OnPointerExit(PointerEventData eventData)
        {
            _panelToDisplay.transform.DOScale(Vector3.zero, 0.25f);
        }
    }
}
