using DG.Tweening;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
    [SerializeField] private GameObject _gameNameObject;
    [SerializeField] private Button _playButton;

    [SerializeField] private Button _optionsButton;
    [SerializeField] private Button _returnOptionsButton;

    [SerializeField] private GameObject _mainPanel;
    [SerializeField] private GameObject _optionsPanel;

    void Start()
    {
        _mainPanel.SetActive(true);
        _optionsPanel.transform.localScale = Vector3.zero;
        _optionsPanel.SetActive(true);

        _playButton.onClick.AddListener(() => LoadScene("Water"));

        _optionsButton.onClick.AddListener(() => OpenPanel(_optionsPanel));
        _returnOptionsButton.onClick.AddListener(() => HidePanel(_optionsPanel));
    }

    private void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    private void OpenPanel(GameObject panelToOpen)
    {
        panelToOpen.transform.DOScale(Vector3.one, 0.25f).SetUpdate(true);
        _mainPanel.transform.DOScale(Vector3.zero, 0.25f).SetUpdate(true);
        _gameNameObject.transform.DOScale(Vector3.zero, 0.25f).SetUpdate(true);
    }

    private void HidePanel(GameObject panelToHide)
    {
        panelToHide.transform.DOScale(Vector3.zero, 0.25f).SetUpdate(true);
        _mainPanel.transform.DOScale(Vector3.one, 0.25f).SetUpdate(true);
        _gameNameObject.transform.DOScale(Vector3.one, 0.25f).SetUpdate(true);
    }
}
