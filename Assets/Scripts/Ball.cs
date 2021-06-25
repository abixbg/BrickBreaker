using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CircleCollider2D))]
[RequireComponent(typeof(SpriteRenderer))]
public class Ball : MonoBehaviour
{
    public Gameplay Game;
    public float BallRadius;
    public Vector2 Velocity;

    public Rigidbody2D rigidBody;

    private void Update()
    {
        Velocity = rigidBody.velocity;
        Game.BallDirection = rigidBody.velocity.normalized;
    }


    public void SetDirection(Vector2 dir, float velocity)
    {
        dir.Normalize();
        rigidBody.velocity = dir * velocity;
    }


    //private void OnValidate()
    //{
    //    GetComponent<CircleCollider2D>().radius = BallRadius;
    //    GetComponent<SpriteRenderer>().size = new Vector2(BallRadius * 2, BallRadius * 2); 
    //}
}
