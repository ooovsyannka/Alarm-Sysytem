using System.Collections;
using UnityEngine;

public class Alarm : MonoBehaviour
{
    [SerializeField] private AudioSource _audioSource;

    private Coroutine _volumeCoroutine;
    private float _maxValue = 1f;
    private float _minValue = 0f;

    public void VolueUp()
    {
        if (_volumeCoroutine != null)
            StopCoroutine(_volumeCoroutine);

        _audioSource.Play();
        _volumeCoroutine = StartCoroutine(ValueUp(_maxValue));
    }

    public void VolueDown()
    {
        if (_volumeCoroutine != null)
            StopCoroutine(_volumeCoroutine);

        _volumeCoroutine = StartCoroutine(ValueUp(_minValue));
    }

    private IEnumerator ValueUp(float targetValue)
    {
        float maxDelta = 0.3f;

        while (_audioSource.volume != targetValue)
        {
            _audioSource.volume = Mathf.MoveTowards(_audioSource.volume, targetValue, maxDelta * Time.deltaTime);
            yield return null;
        }

        _audioSource.Pause();
    }
}
