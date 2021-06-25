using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildBrickpattern : MonoBehaviour
{
    public Gameplay Game;
    public int SpawnCount;
    public Brick BrickPrefab;

    public Transform Centerline;

    public List<Brick> BrickObjects;
    public List<BrickData> BrickTypes;


    private void Start()
    {
        for (int i = 0; i < SpawnCount; i++)
        {
            var brick = Instantiate(BrickPrefab);

            int brickType = Random.Range(0,BrickTypes.Count);
            
            brick.SetData(BrickTypes[brickType]);

            float offset = BrickTypes[brickType].Size.x * i;

            brick.transform.Translate(offset, 0,0);
            brick.Game = Game;

            BrickObjects.Add(brick);
        }
    }
}
