using UnityEngine;

public class Zone : MonoBehaviour
{
    [SerializeField] private Alarm _alarm;
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Player player))
        {
            _alarm.VolueUp();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Player player))
        {
            _alarm.VolueDown();
        }
    }
}