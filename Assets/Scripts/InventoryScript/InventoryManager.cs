using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    [SerializeField] private int _inventorySize;
    [SerializeField] protected InventoryConstructor _inventory;

    //getter
    public InventoryConstructor Inventory => _inventory;

    private void Awake() {
        _inventory = new InventoryConstructor(_inventorySize);
    }
}
