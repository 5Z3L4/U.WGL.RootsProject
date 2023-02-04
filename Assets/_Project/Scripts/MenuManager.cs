using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
    [SerializeField] private string _sceneName;
    [SerializeField] private Button _playButton;

    [SerializeField] private GameObject _mainPanel;
    [SerializeField] private GameObject _optionsPanel;
    [SerializeField] private GameObject _creditsPanel;
    [SerializeField] private TMP_Text _creditsText;
    [Space(10)]
    [TextArea(15, 20)]
    [SerializeField] private string _credits;

    void Start()
    {
        _mainPanel.SetActive(true);
        _optionsPanel.SetActive(false);
        _creditsPanel.SetActive(false);
        _creditsText.text = _credits;
        _playButton.onClick.AddListener(LoadScene);
    }

    private void LoadScene()
    {
        SceneManager.LoadScene(_sceneName);
    }
}
