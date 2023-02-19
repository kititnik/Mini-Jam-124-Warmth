using UnityEngine;

[RequireComponent(typeof(Rigidbody2D), typeof(Collider2D), typeof(Animator))]
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private Vector2 direction;
    private bool _isBorder;

    private Rigidbody2D _rigidbody2D;
    private Animator _animator;
    private Camera _camera;
    private Joystick _joystick;
    
    private static readonly int Horizontal = Animator.StringToHash("Horizontal");
    private static readonly int Vertical = Animator.StringToHash("Vertical");
    private static readonly int Speed = Animator.StringToHash("Speed");

    private void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
        _camera = FindObjectOfType<Camera>();
        _joystick = FindObjectOfType<Joystick>();
        _isBorder = false;
    }

    private void Update()
    {
        if (Application.platform != RuntimePlatform.WindowsEditor)
        {
            direction.x = _joystick.Horizontal;
            direction.y = _joystick.Vertical;
        }
        else
        {
            direction.x = Input.GetAxis("Horizontal");
            direction.y = Input.GetAxis("Vertical");
        }
        
        _animator.SetFloat(Horizontal, direction.x);
        _animator.SetFloat(Vertical, direction.y);
        _animator.SetFloat(Speed, direction.magnitude);
        
        var point = _camera.WorldToViewportPoint(transform.position);
        if(point.y < 0f && direction.y < 0f)
        {
            direction.y = 0;
        }
        else if(point.y > 1f && direction.y > 0f)
        {
            direction.y = 0;
        }
        if(point.x > 1f && direction.x > 0f)
        {
            direction.x = 0;
        }
        else if(point.x < 0f && direction.x < 0f)
        {
            direction.x = 0;
        }
    }

    private void FixedUpdate()
    {
        if(_isBorder) return;
        _rigidbody2D.MovePosition(_rigidbody2D.position + direction * (speed * Time.fixedDeltaTime));
    }
}