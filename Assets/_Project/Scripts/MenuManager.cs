using TMPro;
using DG.Tweening;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
    [SerializeField] private Button _startTutorialButton;
    [SerializeField] private Button _optionsButton;
    [SerializeField] private Button _creditsButton;
    [SerializeField] private Button _returnOptionsButton;
    [SerializeField] private Button _returnCreditsButton;

    [SerializeField] private Button _playButton;
    [SerializeField] private Button _returnFromTutorialToMenuButton;

    [SerializeField] private GameObject _mainPanel;
    [SerializeField] private GameObject _tutorialPanel;
    [SerializeField] private GameObject _optionsPanel;
    [SerializeField] private GameObject _creditsPanel;
    [SerializeField] private TMP_Text _creditsText;
    [Space(10)]
    [TextArea(15, 20)]
    [SerializeField] private string _credits;

    void Start()
    {
        _mainPanel.SetActive(true);
        _optionsPanel.transform.localScale = Vector3.zero;
        _optionsPanel.SetActive(true);

        _creditsPanel.SetActive(true);
        _creditsPanel.transform.localScale = Vector3.zero;

        _tutorialPanel.SetActive(true);
        _tutorialPanel.transform.localScale = Vector3.zero;

        _creditsText.text = _credits;

        _playButton.onClick.AddListener(() => LoadScene("Water"));
        _startTutorialButton.onClick.AddListener(() => OpenPanel(_tutorialPanel));
        _optionsButton.onClick.AddListener(() => OpenPanel(_optionsPanel));
        _creditsButton.onClick.AddListener(() => OpenPanel(_creditsPanel));
        _returnOptionsButton.onClick.AddListener(() => HidePanel(_optionsPanel));
        _returnCreditsButton.onClick.AddListener(() => HidePanel(_creditsPanel));
        _returnFromTutorialToMenuButton.onClick.AddListener(() => HidePanel(_tutorialPanel));

    }

    private void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    private void OpenPanel(GameObject panelToOpen)
    {
        panelToOpen.transform.DOScale(Vector3.one, 0.25f).SetUpdate(true);
        _mainPanel.transform.DOScale(Vector3.zero, 0.25f).SetUpdate(true);

    }

    private void HidePanel(GameObject panelToHide)
    {
        panelToHide.transform.DOScale(Vector3.zero, 0.25f).SetUpdate(true);
        _mainPanel.transform.DOScale(Vector3.one, 0.25f).SetUpdate(true);
    }
}
