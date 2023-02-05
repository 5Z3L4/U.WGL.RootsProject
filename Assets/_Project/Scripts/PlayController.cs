using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayController : MonoBehaviour
{
    [SerializeField] private CanvasManager _canvasManager;

    [SerializeField] private GameObject _bloodParticles;

    [SerializeField] private GameObject _body;
    public void Die()
    {
        GameObject body = Instantiate(_body, transform.position, Quaternion.identity);
        Destroy(body, 3);
        Instantiate(_bloodParticles, transform.position, Quaternion.identity);

        Destroy(gameObject);
    }
}
