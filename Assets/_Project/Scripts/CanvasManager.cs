using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CanvasManager : MonoBehaviour
{
    [Header("BACKGROUND")]
    [SerializeField] private Image _darkening;
    [Space(10)]
    [Header("PAUSE PANEL")]
    [SerializeField] private Button _replayButton;
    [SerializeField] private Button _optionsButton;
    [SerializeField] private Button _pauseMainMenuButton;
    [SerializeField] private Button _resumeButton;
    [SerializeField] private GameObject _optionsPanel;
    [SerializeField] private GameObject _pausePanel;
    [Space(10)]
    [Header("DEATH PANEL")]
    [SerializeField] private TMP_Text _playerScore;
    [SerializeField] private Button _playAgainButton;
    [SerializeField] private Button _deathMainMenuButton;
    [SerializeField] private GameObject _deathPanel;

    public bool IsGamePaused;

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

            if (IsGamePaused)
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
        IsGamePaused = true;
    }

    private void Pause()
    {
        Time.timeScale = 0f;
        _darkening.DOFade(0.6f, 0.25f).SetUpdate(true);
        _pausePanel.transform.DOScale(Vector3.one, 0.25f).SetUpdate(true);
        IsGamePaused = true;
    }

    private void Resume()
    {
        Time.timeScale = 1f;
        _darkening.DOFade(0, 0.25f).SetUpdate(true);
        _pausePanel.transform.DOScale(Vector3.zero, 0.25f).SetUpdate(true);
        IsGamePaused = false;
    }

    private void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
        Time.timeScale = 1f;
    }

    private void SetPausePanel()
    {
        _optionsButton.onClick.AddListener(() => _optionsPanel.SetActive(true));
        _replayButton.onClick.AddListener(() => LoadScene("Water"));
        _pauseMainMenuButton.onClick.AddListener(() => LoadScene("MainMenu"));
        _resumeButton.onClick.AddListener(Resume);
        _pausePanel.transform.localScale = Vector3.zero;
        _pausePanel.SetActive(true);
    }

    private void SetDeathPanel()
    {
        _playAgainButton.onClick.AddListener(() => LoadScene("Water"));
        _deathMainMenuButton.onClick.AddListener(() => LoadScene("MainMenu"));
        _deathPanel.transform.localScale = Vector3.zero;
        _deathPanel.SetActive(true);
    }
}
