using DG.Tweening;
using UnityEngine;
using UnityEngine.EventSystems;

public class CanvasPanelMouseDisplay : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField] private GameObject _panelToDisplay;

    private void Start()
    {
        _panelToDisplay.SetActive(true);
        _panelToDisplay.transform.localScale = Vector3.zero;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        _panelToDisplay.transform.DOScale(Vector3.one, 0.25f);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        _panelToDisplay.transform.DOScale(Vector3.zero, 0.25f);
    }
}
