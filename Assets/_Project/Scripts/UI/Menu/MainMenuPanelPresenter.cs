using DG.Tweening;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace _Project.Scripts.UI.Menu
{
    public class MainMenuPanelPresenter : MonoBehaviour
    {
        [Header("Objects that will be hidden upon opening panels.")]
        [Space(10)]
        [SerializeField] private GameObject _titleObject;
    
        [Header("Start game")]
        [Space(10)]
        [SerializeField] private Button _playButton;
        [SerializeField] private string _sceneToLoad;

        [Header("Options")]
        [Space(10)]
        [SerializeField] private Button _optionsButton;
        [SerializeField] private Button _returnOptionsButton;

        [SerializeField] private GameObject _mainPanel;
        [SerializeField] private GameObject _optionsPanel;

        private void Start()
        {
            _mainPanel.SetActive(true);
            _optionsPanel.transform.localScale = Vector3.zero;
            _optionsPanel.SetActive(true);

            _playButton.onClick.AddListener(() => LoadScene(_sceneToLoad));

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
            _titleObject.transform.DOScale(Vector3.zero, 0.25f).SetUpdate(true);
        }

        private void HidePanel(GameObject panelToHide)
        {
            panelToHide.transform.DOScale(Vector3.zero, 0.25f).SetUpdate(true);
            _mainPanel.transform.DOScale(Vector3.one, 0.25f).SetUpdate(true);
            _titleObject.transform.DOScale(Vector3.one, 0.25f).SetUpdate(true);
        }
    }
}
