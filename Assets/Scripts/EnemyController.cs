using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float speed;
    public bool vertical;
    public float changeTime = 3.0f;
    [SerializeField] private float timer;
    [SerializeField] private int direction = 1;
    [SerializeField] private Rigidbody2D rigidbody2d;
    [SerializeField] private Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        rigidbody2d = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        timer = changeTime;
    }
    private void Update()
    {

        timer -= Time.deltaTime;
        if (timer < 0)
        {
            direction = -direction;
            timer = changeTime;
            vertical = RandomizeAxis();
        }
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        Vector2 position = rigidbody2d.position;

        if (vertical)
        {
            animator.SetFloat("Move X", 0);
            animator.SetFloat("Move Y", direction);
            position.y = position.y + speed * direction * Time.deltaTime;
        }
        else
        {
            animator.SetFloat("Move X", direction);
            animator.SetFloat("Move Y", 0);
            position.x = position.x + speed * direction * Time.deltaTime;
        }

        rigidbody2d.MovePosition(position);
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        PlayerController player = other.gameObject.GetComponent<PlayerController>();
        if (player != null)
        {
            player.ChangeHealth(-1);
        }
    }

    private bool RandomizeAxis()
    {
        // var random = new System.Random();
        var randomAxis = (UnityEngine.Random.Range(0, 2) == 0);

        return randomAxis;
    }
}
