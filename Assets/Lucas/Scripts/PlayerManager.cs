using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class PlayerManager : MonoBehaviour
{
    [SerializeField] private InputActionReference _movement;
    [SerializeField] private float _speed;
    [SerializeField] private int _ammo;
    [SerializeField] private int _maxAmmo;
    [SerializeField] Animator _bulletAnimator;
    [SerializeField] private Bullet _bullet;
    [SerializeField] private AudioClip _bulletClip;
    [SerializeField] private AudioClip _ammoClip;
    private SoundManager _soundManager;
    private bool _bulletFired = false;
    private Rigidbody2D _rigidbody;
    private Vector2 _lookDirection = Vector2.right;
    public UnityEvent<int, int> firedBullet;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _soundManager = FindFirstObjectByType<SoundManager>();
    }

    private void FixedUpdate()
    {
        _rigidbody.linearVelocity = _movement.action.ReadValue<Vector2>() * _speed;
        Debug.Log(_movement.action.ReadValue<Vector2>() * Time.deltaTime * _speed);
    }

    private void OnAttack(InputValue input)
    {
        if (input.isPressed && _ammo > 0 && !_bulletFired)
        {
            _ammo--;
            firedBullet.Invoke(_ammo, _maxAmmo);
            _bulletFired = true;
            Bullet bullet = Instantiate(_bullet,transform.position,new Quaternion(0,0,0,0));
            bullet.SetMovement(_lookDirection);
            _soundManager.PlaySound(_bulletClip);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
       
        if (collision.CompareTag("Ammo"))
        {
            _ammo += 4;
            if (_ammo > _maxAmmo)
            {
                _ammo = _maxAmmo;
            }
            firedBullet.Invoke(_ammo, _maxAmmo);
            _soundManager.PlaySound( _ammoClip);
            Destroy(collision.gameObject);
            return;
        }

        Enemy enemy = collision.gameObject.GetComponent<Enemy>();
        if (enemy != null)
        {
            SceneManager.LoadScene("GameOver");
        }
    }

    public void SetBulletFired(bool newBool)
    {
        _bulletFired = newBool;
    }

    public void OnMove(InputValue input)
    {
        Vector2 inputDirection = input.Get<Vector2>();
        if (inputDirection != null && inputDirection != Vector2.zero)
        {
            _lookDirection = inputDirection;
            if (_lookDirection.y > 0)
            {
                if (_lookDirection.x > 0)
                {
                    _bulletAnimator.Play("UpRight");
                }
                else if (_lookDirection.x < 0)
                {
                    _bulletAnimator.Play("UpLeft");
                }
                else
                {
                    _bulletAnimator.Play("Up");
                }
            }
            else if (_lookDirection.y < 0)
            {
                if (_lookDirection.x > 0)
                {
                    _bulletAnimator.Play("DownRight");
                }
                else if (_lookDirection.x < 0)
                {
                    _bulletAnimator.Play("DownLeft");
                }
                else
                {
                    _bulletAnimator.Play("Down");
                }
            }
            else
            {
                if (_lookDirection.x > 0)
                {
                    _bulletAnimator.Play("Right");
                }
                else if (_lookDirection.x < 0)
                {
                    _bulletAnimator.Play("Left");
                }
            }
        }
    }
}
