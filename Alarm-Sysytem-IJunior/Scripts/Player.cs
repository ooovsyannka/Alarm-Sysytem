using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]

public class Player : MonoBehaviour
{
    private const string NameAnimation = "IsMove";
    private const string Horizontal = nameof(Horizontal);
    private const string Vertical = nameof(Vertical);

    [SerializeField] private float _speed;
    [SerializeField] private Animator _animator;

    private bool _isMove = false;

    private void Update()
    {
        float horizontal = Input.GetAxisRaw(Horizontal) * _speed * Time.deltaTime;
        float vertical = Input.GetAxisRaw(Vertical) * _speed * Time.deltaTime;

        _isMove = horizontal != 0 || vertical != 0;
        transform.Translate(horizontal, vertical, 0, Space.World);

        FlipSprite(horizontal);

        _animator.SetBool(NameAnimation, _isMove);
    }

    private void FlipSprite(float direction)
    {
        SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();

        if (direction < 0)
            spriteRenderer.flipX = true;
        else if (direction > 0)
            spriteRenderer.flipX = false;
    }
}
