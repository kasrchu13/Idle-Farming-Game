using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[Serializable]
public class InventoryConstructor
{
    [SerializeField] private List<InventorySlot> _slotList;

    //getter 
    public List<InventorySlot> SlotList => _slotList;


    public InventoryConstructor(int size)
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
