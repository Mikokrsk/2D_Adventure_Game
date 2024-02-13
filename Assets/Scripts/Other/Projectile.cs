using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Projectile : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rigidbody2d;
    [SerializeField] public Vector3 startPosition;
    [SerializeField] public float distance;
    [SerializeField] public int damage;
    // Start is called before the first frame update
    void Awake()
    {
        rigidbody2d = GetComponent<Rigidbody2D>();
    }

    public void Launch(Vector2 direction, float force)
    {
        rigidbody2d.AddForce(direction * force);
    }

    private void Update()
    {
        if (Vector3.Distance(startPosition, transform.position) > distance)
        {
            Destroy(gameObject);
        }
    }
    void OnCollisionEnter2D(Collision2D other)
    {
        EnemyHealthManager enemy = other.collider.GetComponent<EnemyHealthManager>();
        if (enemy != null)
        {
            enemy.GetHit(damage);
        }
        Debug.Log("Projectile collision with " + other.gameObject);
        Destroy(gameObject);
    }
}
