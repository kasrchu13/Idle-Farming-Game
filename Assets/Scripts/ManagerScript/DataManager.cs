using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements.Experimental;

public class DataManager : MonoBehaviour
{
    public static DataManager Instance;

    //references
    [SerializeField] private SpriteRenderer _playField;
    [SerializeField] public PlayerStats _playerSO;

    //game parameters
    [SerializeField] private int _plantLimit = 10;
    [SerializeField] private int _minDrop = 3;
    [SerializeField] private int _maxDrop = 5;

    //Game Data
    public List<GameObject> FruitList;
    public int Currency;
    //getter and setter

    private void Awake() {
        if(Instance != null && Instance != this) Destroy(this);
        else Instance = this;

        UpdateField();
    }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void UpdateField()
    {
        GameField.Width = _playField.size.x;
        GameField.Height = _playField.size.y;
        GameField.PlantLimit = _plantLimit;
        GameField.MinDrop = _minDrop;
        GameField.MaxDrop = _maxDrop;
    }

    
}
