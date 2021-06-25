using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildBrickpattern : MonoBehaviour
{
    public Gameplay Game;
    public Brick BrickPrefab;

    public Transform Centerline;

    public List<Brick> BrickObjects;
    public List<BrickData> BrickTypes;


    private void Start()
    {
        SpawnRow(0, 8);
        SpawnRow(1, 8);
        SpawnRow(2, 8);
        SpawnRow(3, 8);
    }

    private void SpawnRow(int row, int count )
    {
        for (int i = 0; i < count; i++)
        {
            var brick = Instantiate(BrickPrefab, Centerline);

            int brickType = Random.Range(0, BrickTypes.Count);

            brick.SetData(BrickTypes[brickType]);

            float offsetX = (BrickTypes[brickType].Size.x * i) + (BrickTypes[brickType].Size.x / 2);
            float offsetY = (BrickTypes[brickType].Size.y * row * - 1) - (BrickTypes[brickType].Size.y / 2);


            brick.transform.Translate(offsetX, offsetY, 0);
            brick.Game = Game;

            BrickObjects.Add(brick);
        }
    }
}
