using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEditor.EditorTools;
using UnityEditor.iOS.Extensions.Common;
using UnityEngine;
using Random = UnityEngine.Random;

//this script should assign to <GameObject> Grass
public class Plant : MonoBehaviour, IHarvest
{   

    private List<GameObject> _localFruitList;
    private bool canHarvest => (Vector2) transform.localScale == _targetScale;

    #region Plant Animation Parameters
    [SerializeField] private AnimationCurve _curve;
    [SerializeField] private float _growSpeed = 1;
    [Tooltip("According to the prefab's scale")]
    [SerializeField] private Vector2 _targetScale;
    private float _current = 0;
    #endregion

    

    private void Start()
    {
        _localFruitList = DataManager.Instance.FruitList;
    }
    private void Update()
    {
        //plant grow
        _current = Mathf.MoveTowards(_current, 1, _growSpeed * Time.deltaTime);
        transform.localScale = Vector2.Lerp(Vector2.zero, _targetScale, _curve.Evaluate(_current));
    }
    private void OnEnable()
    {
        GameField.CurrentPlant++;
    }

    private void OnDestroy()
    {
        GameField.CurrentPlant--;
    }

    #region interface
    public void Harvest()
    {
        if(!canHarvest) return;

        //randomly choose a fruit to drop
        var choseFruit = Random.Range(0, _localFruitList.Count);

        //assign the type to the object
        var _fruitPrefabs = _localFruitList[choseFruit];

        //random amount of drop
        var DropNum = Random.Range(GameField.MinDrop, GameField.MaxDrop);

        for(int i = 0; i < DropNum; i++)
        {
            Instantiate(_fruitPrefabs, transform.position, Quaternion.identity);
        }

        Destroy(gameObject);


        GameField.CurrentPlant--;
    }

    #endregion
}
