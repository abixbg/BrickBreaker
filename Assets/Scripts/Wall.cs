using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall : MonoBehaviour
{
    public enum ReflectDirection
    {
        horizontal,
        vertical
    }

    public Gameplay Game;
    public bool DestroysBall;
    public ReflectDirection reflect;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "ball")
        {
            OnBrickHit();
        }
    }

    private void OnBrickHit()
    {
        Debug.Log("Hits Wall!");



        if (DestroysBall)
        {
            Game.RemoveHealth(1);
            Game.ResetBall();
        }
        else
        {
            Game.SetBallDirection(GetNewDir());
        }

    }
    private Vector2 GetNewDir()
    {
        float angle = Random.Range(210, 330);
        Vector2 currentDir = Game.BallDirection;
        Vector2 reflectNormal;

        if (reflect == ReflectDirection.vertical )
        {
            reflectNormal = new Vector2(1, 0);
        }
        else
            reflectNormal = new Vector2(0, 1);

        Vector2 newDir = Vector2.Reflect(currentDir, reflectNormal);


        return newDir;
    }
}
