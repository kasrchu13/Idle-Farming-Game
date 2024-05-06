using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;


//assign to InventoryUI panel
public class InventoryDisplay : MonoBehaviour
{

    [SerializeField] private InventoryManager _InventoryManager;
    [SerializeField] private GameObject _slotPrefab;
    [SerializeField] private int _slotPerRow = 5;
    [SerializeField] private int _xStart = -220;
    [SerializeField] private int _yStart = 230;
    [SerializeField] private int _xSpacing = 100;
    [SerializeField] private int _ySpacing = 100;
    
    private void Start() {
        //assign slot in place
        SlotInitialize();
        CreateDisplay();
    }


    private void Update() {
        UpdateDisplay();
    }
    private void SlotInitialize()
    {
        for(int i = 0; i < _InventoryManager.Container.SlotList.Count; i++)
        {
            var slot = Instantiate(_slotPrefab, Vector2.zero, Quaternion.identity, transform);
            slot.GetComponent<RectTransform>().localPosition = GetLocalPos(i);
        }
    }

    private void CreateDisplay()
    {
        
    }
    private void UpdateDisplay()
    {
        
    }
    //input parameter represent i-th item
    private Vector2 GetLocalPos(int i)
    {
        int x = _xStart + _xSpacing * (i % _slotPerRow); 
        int y = _yStart - _ySpacing * (i / _slotPerRow); 
        return new Vector2(x, y); 
    }
}
