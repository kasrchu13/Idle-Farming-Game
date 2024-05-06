using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

//assign to Canvas
public class CompositeUI : MonoBehaviour
{
    //Interactive UI
    [SerializeField] private RectTransform _inventoryMenu, _upgradeMenu;
    private bool _invMenuActivated = false;
    private bool _upgradeMenuActivated = false;
    private Vector2 _invClose = new Vector2(800, 0);
    private Vector2 _invOpen = new Vector2(400, 0);
    private Vector2 _upgradeClose = new Vector2(-800, 0);
    private Vector2 _upgradeOpen = new Vector2(-400, 0);

    //Display Only UI
    [SerializeField] private TextMeshProUGUI _coinText;
    [SerializeField] private TextMeshProUGUI _plantText;

    void Start()
    {
        _inventoryMenu.anchoredPosition = _invClose;
        _upgradeMenu.anchoredPosition = _upgradeClose;
    }
    void Update()
    {
        DisplayResource();
    }

    private void DisplayResource()
    {
        _coinText.text = DataManager.Instance.Currency.ToString();
        _plantText.text = $"{GameField.CurrentPlant} / {GameField.PlantLimit}";
    }

    public void UpgradeTabInteract()
    {
        if(!_upgradeMenuActivated) 
        {
            _upgradeMenu.anchoredPosition = _upgradeOpen; 
            _upgradeMenuActivated = true;
        } 
        else 
        {
            _upgradeMenu.anchoredPosition = _upgradeClose;
            _upgradeMenuActivated = false;
        }
        
    }

    public void InventoryTabInteract()
    {
        if(!_invMenuActivated)
        {
            _inventoryMenu.anchoredPosition = _invOpen;
            _invMenuActivated = true;
        }
        else
        {
            _inventoryMenu.anchoredPosition = _invClose;
            _invMenuActivated = false;
        }
    }
}
