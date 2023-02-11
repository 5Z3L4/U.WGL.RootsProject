using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace _Project.Scripts.UI.MainScene
{
    public class CanvasManager : MonoBehaviour
    {
        [Header("BACKGROUND")]
        [SerializeField] private Image _darkening;
        [Space(10)]
        [Header("PAUSE PANEL BUTTONS")]
        [SerializeField] private Button _replayButton;
        [SerializeField] private Button _optionsButton;
        [SerializeField] private Button _returnFromOptionsButton;
        [SerializeField] private Button _pauseMainMenuButton;
        [SerializeField] private Button _resumeButton;
        [Header("PAUSE PANELS")]
        [SerializeField] private GameObject _pausePanel;
        [SerializeField] private GameObject _optionsPanel;
        [Space(10)]
        [Header("DEATH PANEL")]
        [SerializeField] private TMP_Text _playerScore;
        [SerializeField] private Button _playAgainButton;
        [SerializeField] private Button _deathMainMenuButton;
        [SerializeField] private GameObject _deathPanel;
        [Space(10)] 
        [Header("SCORE")] 
        [SerializeField] private TMP_Text _scoreText;

        private bool _isGamePaused;

        private void On_ScoreIncreased()
        {
            var sequence = DOTween.Sequence()
                .Append(_scoreText.DOFade(1, 0.1f))
                .Append(_scoreText.transform.DOScale(new Vector3(1 + 0.2f, 1 + 0.2f, 1 + 0.2f), .1f))
                .Append(_scoreText.transform.DOScale(1, .1f));
            sequence.Play();
        }

        private void Start()
        {
            SetPausePanel();
            SetDeathPanel();

            _darkening.gameObject.SetActive(true);
            _darkening.color = new Color32(0, 0, 0, 0);
        }

        void Update()
        {
            if (!Input.GetKeyDown(KeyCode.P)) return;

            if (_isGamePaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }

        public void DisplayDeathPanel()
        {
            Time.timeScale = 0f;
            _darkening.DOFade(0.6f, 0.25f).SetUpdate(true);
            _deathPanel.transform.DOScale(Vector3.one, 0.25f).SetUpdate(true);
            _scoreText.text = string.Empty;
            _isGamePaused = true;
        }

        private void Pause()
        {
            Time.timeScale = 0f;
            _darkening.DOFade(0.6f, 0.25f).SetUpdate(true);
            _pausePanel.transform.DOScale(Vector3.one, 0.25f).SetUpdate(true);
            _isGamePaused = true;
        }

        private void Resume()
        {
            Time.timeScale = 1f;
            _darkening.DOFade(0, 0.25f).SetUpdate(true);
            _pausePanel.transform.DOScale(Vector3.zero, 0.25f).SetUpdate(true);
            HidePanel(_optionsPanel);
            _isGamePaused = false;
        }

        private void LoadScene(string sceneName)
        {
            SceneManager.LoadScene(sceneName);
            Time.timeScale = 1f;
        }

        private void SetPausePanel()
        {
            _pausePanel.SetActive(true);
            _pausePanel.transform.localScale = Vector3.zero;

            _optionsPanel.SetActive(true);
            _optionsPanel.transform.localScale = Vector3.zero;

            _optionsButton.onClick.AddListener(() => OpenPanel(_optionsPanel));
            _returnFromOptionsButton.onClick.AddListener(() => HidePanel(_optionsPanel));
            _resumeButton.onClick.AddListener(Resume);
            _replayButton.onClick.AddListener(() =>
            {
                LoadScene("Water");
            });
            _pauseMainMenuButton.onClick.AddListener(() => LoadScene("MainMenu"));
        }

        private void SetDeathPanel()
        {
            _playAgainButton.onClick.AddListener(() =>
            {
                LoadScene("Water");
            });
            _deathMainMenuButton.onClick.AddListener(() => LoadScene("MainMenu"));
            _deathPanel.transform.localScale = Vector3.zero;
            _deathPanel.SetActive(true);
        }

        private void OpenPanel(GameObject panelToOpen)
        {
            panelToOpen.transform.DOScale(Vector3.one, 0.25f).SetUpdate(true);
        }

        private void HidePanel(GameObject panelToHide)
        {
            panelToHide.transform.DOScale(Vector3.zero, 0.25f).SetUpdate(true);
        }
    }
}
