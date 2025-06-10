using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerManager : MonoBehaviour
{
    [SerializeField] private InputActionReference _movement;
    [SerializeField] private float _speed;
    [SerializeField] private int _ammo;
    private bool _bulletFired = false;
    private Rigidbody2D _rigidbody;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
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
            _bulletFired = true;
        }
    }

    public void SetBulletFired(bool newBool)
    {
        _bulletFired = newBool;
    }
}
