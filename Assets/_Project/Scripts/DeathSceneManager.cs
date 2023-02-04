using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class DeathSceneManager : MonoBehaviour
{
    [SerializeField] private string _sceneName;
    [SerializeField] private GameObject _deathScene;
    [SerializeField] private TMP_Text _playerScore;
    [SerializeField] private Button _playAgainButton;
    [SerializeField] private Button _mainMenuButton;

    private void Start()
    {
        _deathScene.SetActive(false);
        _playAgainButton.onClick.AddListener(LoadScene);
        _mainMenuButton.onClick.AddListener(LoadMainMenu);
    }

    public void DisplayDeathScene()
    {
        _deathScene.SetActive(true);
    }

    private void LoadScene()
    {
        SceneManager.LoadScene(_sceneName);
    }

    private void LoadMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
