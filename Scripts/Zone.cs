using UnityEngine;

public class Zone : MonoBehaviour
{
    [SerializeField] private AudioSource _audioSource;
    private bool _playerInZone = false;

    private void Start()
    {
        _audioSource.Play();
    }

    private void Update()
    {
        if (_playerInZone)
        {
            ChangeValue(_audioSource.maxDistance);
        }
        else
        {
            ChangeValue();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<Player>())
        {
            _playerInZone = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.GetComponent<Player>())
        {
            _playerInZone = false;
        }
    }

    private void ChangeValue(float maxValue = 0)
    {
        float maxDelta = 0.3f;

        _audioSource.volume = Mathf.MoveTowards(_audioSource.volume, maxValue, maxDelta * Time.deltaTime);

    }
}
