using System.Collections;
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
        if (_audioSource.volume == 0)
        {
            StopCoroutine(ChangeValue());
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Player player))
        {
            if (player != null)
            {
                StartCoroutine(ChangeValue());
                _playerInZone = true;
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Player player))
        {
            if (player != null)
            {
                _playerInZone = false;
            }
        }
    }

    private IEnumerator ChangeValue()
    {
        float maxDelta = 0.3f;

        bool isWork = true;

        while (isWork)
        {
            _audioSource.volume = Mathf.MoveTowards(_audioSource.volume, GetTarrgetValue(), maxDelta * Time.deltaTime);
            yield return null;
        }
    }

    private float GetTarrgetValue()
    {
        if (_playerInZone)
        {
            return _audioSource.maxDistance;
        }

        return 0;
    }
}
