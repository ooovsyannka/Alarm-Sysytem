using System.Collections;
using UnityEngine;

public class Alarm : MonoBehaviour
{
    [SerializeField] private AudioSource _audioSource;

    private Coroutine _volumeCoroutine;
    private float _maxValue = 1f;
    private float _minValue = 0f;

    private void Start()
    {
        _audioSource.Play();
    }

    private IEnumerator ValueUp(float targetValue)
    {
        float maxDelta = 0.3f;

        while (_audioSource.volume != targetValue)
        {
            _audioSource.volume = Mathf.MoveTowards(_audioSource.volume, targetValue, maxDelta * Time.deltaTime);
            yield return null;
        }
    }

    public void On()
    {
        if (_volumeCoroutine != null)
            StopCoroutine(_volumeCoroutine);

        _volumeCoroutine = StartCoroutine(ValueUp(_maxValue));
    }

    public void Off()
    {
        if(_volumeCoroutine != null)
            StopCoroutine(_volumeCoroutine);

        _volumeCoroutine = StartCoroutine(ValueUp(_minValue));
    }
}
