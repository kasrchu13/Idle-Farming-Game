using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEngine;
using Random = UnityEngine.Random;

//this script should assign to <GameObject> fruit Prefabs
public class Fruit : MonoBehaviour, ICollectable
{
    //referenece
    [SerializeField] private FruitType _thisFruit;
    [SerializeField] private InventoryManager _inventoryManager;


    private bool canCollect => (Vector2) transform.position == _endPos;

    #region Fruit Animation Parameters
    [SerializeField] private float _popRange = 1;
    [SerializeField] private float _popSpeed = 1;
    [SerializeField] private AnimationCurve _curve;
    private Vector2 _startPos;
    private Vector2 _endPos;
    private float _current = 0;
    #endregion

    private void Awake()
    {
        _inventoryManager = GameObject.Find("InventoryHolder").GetComponent<InventoryManager>();
    }
    private void Start()
    {
        
        //get the random pop direction of the fruit 
        _startPos = (Vector2) transform.position;
        
        var rndx = Random.Range(-_popRange,_popRange);
        var rndy = Random.Range(-_popRange,_popRange);
        var randomDir = new Vector2(rndx,rndy).normalized;

        _endPos = _startPos + randomDir;

    }
    private void Update()
    {
        //fruit pops
        _current = Mathf.MoveTowards(_current, 1, _popSpeed * Time.deltaTime);
        transform.position = Vector2.Lerp(transform.position, _endPos, _curve.Evaluate(_current));
    }


    #region interface
    public void Collect()
    {
        if(!canCollect) return;
        Debug.Log("collected");
        _inventoryManager.Inventory.AddToInventory(_thisFruit, 1);
        Destroy(gameObject);

    }
    
    #endregion
}
