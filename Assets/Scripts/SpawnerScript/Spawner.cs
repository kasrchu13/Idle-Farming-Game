using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.GlobalIllumination;
using Random = UnityEngine.Random;

public class Spawner : MonoBehaviour
{
    [SerializeField] private GameObject _grassPrefabs;

    //gmae field parameters
    [Range(1,5)]private float _spawnRate = 1;
    private bool _canSpawn => GameField.CurrentPlant != GameField.PlantLimit;

    void Start()
    {
        StartCoroutine(StartSpawn(_spawnRate));
    }


    private IEnumerator StartSpawn(float spawnRate)
    {
        while(true)
        {
            if(_canSpawn)
            {
                SpawnPlant();
            }
            yield return new WaitForSeconds(1/spawnRate);
        }
    }
    private void SpawnPlant()
    {
        //get random position inside the play field
        float minX = - GameField.Width /2 + 1;  
        float maxX = GameField.Width /2 - 1;
        float minY = - GameField.Height /2 + 1;
        float maxY = GameField.Height /2 - 1; 

        float rndx = Random.Range(minX, maxX);
        float rndy = Random.Range(minY, maxY);

        Vector2 spawnPos = new Vector2(rndx, rndy);
        Instantiate(_grassPrefabs, spawnPos, Quaternion.identity);
    }
}

public static class GameField
{
    public static float Width;
    public static float Height;
    public static int PlantLimit;
    public static int CurrentPlant;
    public static int MinDrop;
    public static int MaxDrop;
}