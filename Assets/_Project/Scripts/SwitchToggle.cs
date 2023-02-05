using UnityEngine;
using UnityEngine.UI;

public class SwitchToggle : MonoBehaviour
{
    [SerializeField] private Button _kretToggle;
    [SerializeField] private Sprite _toggleOn;
    [SerializeField] private Sprite _toggleOff;
    [SerializeField] private Image _toggleImage;

    private int _isKretModeOn;

    void Start()
    {
        _isKretModeOn = PlayerPrefs.GetInt("KretMode", 0);

        if(_isKretModeOn == 1)
        {
            _toggleImage.sprite = _toggleOn;
        }
        else
        {
            _toggleImage.sprite = _toggleOff;
        }

        _kretToggle.onClick.AddListener(SetState);
    }

    private void SetState()
    {
        if (_isKretModeOn == 0)
        {
            _isKretModeOn = 1;
            _toggleImage.sprite = _toggleOn;
            PlayerPrefs.SetInt("KretMode", 1);
        }
        else
        {
            _isKretModeOn = 0;
            _toggleImage.sprite = _toggleOff;
            PlayerPrefs.SetInt("KretMode", 0);
        }
    }
}
