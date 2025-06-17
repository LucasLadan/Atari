using UnityEngine;

public class Enemy : MonoBehaviour
{
    private Vector2 _direction;
    [SerializeField] private float _speed;
    private PlayerManager _playerManager;
    private Rigidbody2D _rigidbody;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _playerManager = FindFirstObjectByType<PlayerManager>();
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        _direction = (_playerManager.gameObject.transform.position - transform.position).normalized;
        _rigidbody.linearVelocity = _direction * _speed;
    }
}
