using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    /// <summary>
    /// Manager stores different inventory sources
    /// such as chest inventory, player inventory, etc.
    /// Can be treated as centralized inventory checker
    /// </summary>
    [SerializeField] protected InventoryContainer _container;
    //getter
    public InventoryContainer Container => _container;
}
