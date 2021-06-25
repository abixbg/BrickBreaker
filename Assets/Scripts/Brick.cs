using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public struct BrickData
{
    public Vector2 Size;
    public Color Color;
    public int Reward;
}

[RequireComponent(typeof(BoxCollider2D))]
[RequireComponent(typeof(SpriteRenderer))]
public class Brick : MonoBehaviour
{
    public Gameplay Game;
    public BrickData Data;

    private SpriteRenderer Sprite;
    private BoxCollider2D Box;

    private void Awake()
    {
        
        Sprite = GetComponent<SpriteRenderer>();
        Box = GetComponent<BoxCollider2D>();

        UpdateBrick();
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "ball")
        {
            OnBrickHit();
        }
    }

    public void UpdateBrick()
    {
        Sprite.size = Data.Size;
        Box.size = Data.Size;
        Sprite.color = Data.Color;

    }

    public void SetData(BrickData data)
    {
        Data = new BrickData
        {
            Size = data.Size,
            Color = data.Color,
            Reward = data.Reward
        };
        UpdateBrick();
    }

    private void OnBrickHit()
    {
        Game.SetBallDirection(GetNewDir());
        Game.AddReward(Data.Reward);
        Destroy(gameObject);
    }
    private Vector2 GetNewDir()
    {       
        float angle = Random.Range(210, 330);

        Vector2 newDir = Gameplay.GetDirFromAngle(angle);

        return newDir;
    }
}
