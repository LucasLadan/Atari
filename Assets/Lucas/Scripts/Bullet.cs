using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Vector2 _movement = Vector2.zero;
    private float _movementModifer;
    private Rigidbody2D _rigidbody;
    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        _rigidbody.linearVelocity = _movement;
    }

    public void SetMovement(Vector2 movement)
    { _movement = movement; }
}
