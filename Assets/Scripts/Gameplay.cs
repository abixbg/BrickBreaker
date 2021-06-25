using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//#TODO make this singleton
public class Gameplay : MonoBehaviour
{
    public UIMain UI;
    public int Score;
    public int Health;

    [Header("Paddle")]
    public Platform PlatformObject;
    public bool ballAttached;
    public Transform SpawnPoint;
    public float Speed = 5;
    public float MaxOffset;

    [Header("Ball")]
    public bool BallDestroyed;
    public Ball BallObject;
    public float MaxSpeed;
    public Vector2 BallDirection;


    [Header("Input")]
    public bool inputLeft;
    public bool inputRight;
    public bool inputShoot;
    public float PushDir;
    private float distanceThisFrame;


    private void Start()
    {
        UI.Game = this;
        PlatformObject.Game = this;

        ResetBall();

        ////BallObject.SetDirection(new Vector2(0, 1), MaxSpeed);
        //BallObject.transform.position = SpawnPoint.transform.position;
        //ballAttached = true;

    }

    private void Update()
    {
        GetPlayerInput();
        MovePlatform();
        UpdateUI();
    }


    public void AddReward(int value)
    {
        Score += value;
    }

    public void RemoveHealth(int value)
    {
        Health -= value;
    }

    private void MovePlatform()
    {


        distanceThisFrame = Speed * PushDir * Time.deltaTime;
        PlatformObject.gameObject.transform.Translate(distanceThisFrame, 0, 0);
    }

    public void SetBallDirection(Vector2 direction)
    {
        BallObject.SetDirection(direction, MaxSpeed);
    }


    public void GetPlayerInput()
    {
        float dir;
        inputLeft = Input.GetKey(KeyCode.A);
        inputRight = Input.GetKey(KeyCode.D);
        inputShoot = Input.GetKeyDown(KeyCode.Space);


        if (inputRight)
        {
            if (inputLeft)
            {
                dir = 0;
            }
            else
                dir = 1;            
        }
        else
        {
            if (inputLeft)
            {
                dir = -1;
            }
            else
                dir = 0;
        }
        PushDir = dir;

        if (inputShoot)
        {
            OnShoot();
        }
    }

    private void OnShoot()
    {
        if (ballAttached)
        {
            ShootBall();            
        }
        else
        {
            if (BallDestroyed)
            {
                ResetBall();
            }
        }
            
    }

    public void ResetBall()
    {
        
        BallObject.transform.position = SpawnPoint.transform.position; //move to resting pos
        BallObject.SetDirection(new Vector2(0, 0), 0); //stop the ball        
        BallObject.transform.SetParent(PlatformObject.transform);
        BallDestroyed = false;
        ballAttached = true;
    }

    private void ShootBall()
    {
        //get random initial direction upwards

        float angle = Random.Range(60, 120);

        BallObject.SetDirection(GetDirFromAngle(angle), MaxSpeed);
        BallObject.transform.parent = null;
        ballAttached = false;

    }
     
    

    public static Vector2 GetDirFromAngle(float angle)
    {
        float sin = Mathf.Sin(angle * Mathf.Deg2Rad);
        float cos = Mathf.Cos(angle * Mathf.Deg2Rad);
        return new Vector2(cos, sin);
    }


    private void UpdateUI()
    {
        UI.scoreText.text = Score.ToString();
    }
}
