using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[CreateAssetMenu]
public class InventoryContainer : ScriptableObject
{
    [SerializeField] private List<InventorySlot> _slotList;

    //getter 
    public List<InventorySlot> SlotList => _slotList;


    public InventoryContainer(int size)
    {
        _slotList = new List<InventorySlot>(size);

        for (int i = 0; i < size; i++)
        {
            _slotList.Add(new InventorySlot());
        }   
    }

    public void AddToInventory(FruitType fruitData, int storedAmount)
    {
        //get the available slot to add
        var ValidSlot = FindAvailableSlot(fruitData);
        //update on the found slot
        ValidSlot.UpdateSlot(fruitData, storedAmount);
    }

    //control the logic of finding a valid slot to store the item, 
    public InventorySlot FindAvailableSlot(FruitType storedFruit)
    {
        //find the slot with same type
        InventorySlot validSlot;
        validSlot = _slotList.FirstOrDefault(item => item.FruitData == storedFruit && !item.StackFull());

        //if no slot with same type, find free slot;
        if(validSlot == null) validSlot = _slotList.First(item => item.FruitData == null);
        return validSlot;
    }
}

[Serializable]
public class InventorySlot
{
    //elements in a slot
    [SerializeField] private FruitType _fruitData;
    [SerializeField] private int _stacks;

    //getter
    public FruitType FruitData {get{return _fruitData;}}
    public int Stacks {get{return _stacks;}}

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
