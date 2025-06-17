using System.Collections;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Vector2 _movement = Vector2.zero;
    [SerializeField] private float _movementModifer;
    [SerializeField] private AudioClip _audioClip;
    private Rigidbody2D _rigidbody;
    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        StartCoroutine(BulletFired());
    }

    // Update is called once per frame
    void Update()
    {
        _rigidbody.linearVelocity = _movement * _movementModifer;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Enemy _enemy = collision.gameObject.GetComponent<Enemy>();
        if (_enemy != null)
        {
            FindFirstObjectByType<PlayerManager>().SetBulletFired(false);
            Destroy(_enemy.gameObject);
            Destroy(gameObject);
            FindFirstObjectByType<SoundManager>().PlaySound(_audioClip);
            FindFirstObjectByType<EnemySpawner>().EnemyDied();
        }
    }

    IEnumerator BulletFired()
    {


        yield return new WaitForSeconds(1.5f);
        FindFirstObjectByType<PlayerManager>().SetBulletFired(false);
        Destroy(gameObject);

    }

    public void SetMovement(Vector2 movement)
    { _movement = movement; }
}
