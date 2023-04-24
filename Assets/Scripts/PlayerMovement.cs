using UnityEngine;
using UnityEngine.Serialization;

[RequireComponent(typeof(Rigidbody2D), typeof(Collider2D), typeof(Animator))]
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private Vector2 direction;

    private Rigidbody2D _rigidbody2D;
    private Animator _animator;
    private Camera _camera;
    private Joystick _joystick;
    [SerializeField] private AudioSource snowWalkingAuso;
    [SerializeField] private AudioClip snowWalkingSound;

    private static readonly int Horizontal = Animator.StringToHash("Horizontal");
    private static readonly int Vertical = Animator.StringToHash("Vertical");
    private static readonly int Speed = Animator.StringToHash("Speed");

    private void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
        _camera = FindObjectOfType<Camera>();
        _joystick = FindObjectOfType<Joystick>();
    }

    private void Update()
    {
        if (Application.platform == RuntimePlatform.WindowsEditor)
        {
            direction.x = Input.GetAxis("Horizontal");
            direction.y = Input.GetAxis("Vertical");
        }
        else
        {
            direction.x = _joystick.Horizontal;
            direction.y = _joystick.Vertical;
        }

        _animator.SetFloat(Horizontal, direction.x);
        _animator.SetFloat(Vertical, direction.y);
        _animator.SetFloat(Speed, direction.magnitude);
        
        var point = _camera.WorldToViewportPoint(transform.position);
        switch (point.y)
        {
            case < 0f when direction.y < 0f:
            case > 1f when direction.y > 0f:
                direction.y = 0;
                break;
        }
        switch (point.x)
        {
            case > 1f when direction.x > 0f:
            case < 0f when direction.x < 0f:
                direction.x = 0;
                break;
        }
    }

    private void FixedUpdate()
    {
        if (direction == Vector2.zero) return;
        _rigidbody2D.MovePosition(_rigidbody2D.position + direction * (speed * Time.fixedDeltaTime));
    }

    private void PlayWalkingSound()
    {
        snowWalkingAuso.PlayOneShot(snowWalkingSound);
    }
}