using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
[RequireComponent(typeof(SpriteRenderer))]
public class Platform : MonoBehaviour
{
    public Gameplay Game;

    public float Length;
    public float Thickness;
    
    public BoxCollider2D Collider;

    private void Awake()
    {
        Collider = GetComponent<BoxCollider2D>();
    }

    //private void OnValidate()
    //{
    //    GetComponent<BoxCollider2D>().size = new Vector2(Length, Thickness);
    //    GetComponent<SpriteRenderer>().size = new Vector2(Length, Thickness);
    //}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "ball")
        {
            if (!Game.ballAttached)
            {
                HitPlatform();
            }
        }
    }

    private void HitPlatform()
    {
        float dist = Vector2.Distance(transform.position, Game.BallObject.transform.position);
        Game.SetBallDirection(GetNewDir());
       
    }


    private Vector2 GetNewDir()
    {
        float angle = Random.Range(10, 170);

        //Vector2 newDir = Gameplay.GetDirFromAngle(angle);
        Vector2 newDir = Vector2.Reflect(Game.BallDirection, new Vector2(0, 1));

        return newDir;
    }
}
