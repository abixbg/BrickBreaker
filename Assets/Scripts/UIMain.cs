using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIMain : MonoBehaviour
{
    public Gameplay Game;

    public Text scoreText;
    public Text healthText;


    private void Update()
    {
        scoreText.text = Game.Score.ToString();
        healthText.text = Game.Health.ToString();
    }
}
