using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class InventorySlot
{
    //elements in a slot
    [SerializeField] private FruitType _fruitData;
    [SerializeField] private int _stacks;

    //getter
    public FruitType FruitData {get{return _fruitData;}}
    public int Stacks {get{return _stacks;}}

    //public InventorySlot(FruitType storedFruit, int storedAmount)
    //{
    //    _fruitData = storedFruit;
    //    _stacks = storedAmount;
    //}

    public InventorySlot()
    {
        ClearSlot();
    }

    public void ClearSlot()
    {
        _fruitData = null;
        _stacks = 0;
    }

    public void UpdateSlot(FruitType storedFruit, int changedAmount)
    {
        if(_fruitData == null) _fruitData = storedFruit;
        _stacks += changedAmount;
    }


    public bool StackFull()
    {
        return _stacks == FruitData.MaxStack;
    }
}
