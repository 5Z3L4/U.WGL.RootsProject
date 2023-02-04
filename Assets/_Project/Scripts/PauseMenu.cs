using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{
    //TODO: check main scene name string

    [SerializeField] private Button _replayButton;
    [SerializeField] private Button _optionsButton;
    [SerializeField] private Button _mainMenuButton;
    [SerializeField] private Button _resumeButton;
    [SerializeField] private GameObject _optionsPanel;
    [SerializeField] private GameObject _pausePanel;

    public bool IsGamePaused;

    private void Start()
    {
        _optionsButton.onClick.AddListener(() => _optionsPanel.SetActive(true));
        _replayButton.onClick.AddListener(() => LoadScene("MainScene"));
        _mainMenuButton.onClick.AddListener(() => LoadScene("MainMenu"));
        _resumeButton.onClick.AddListener(Resume);

        _pausePanel.SetActive(false);
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

    private void Pause()
    {
        _pausePanel.SetActive(true);
        Time.timeScale = 0f;
        IsGamePaused = true;
    }

    private void Resume()
    {
        _pausePanel.SetActive(false);
        Time.timeScale = 1f;
        IsGamePaused = false;
    }

    private void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}
