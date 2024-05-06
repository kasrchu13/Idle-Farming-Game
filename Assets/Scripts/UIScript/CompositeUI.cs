using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CompositeUI : MonoBehaviour
{
    [SerializeField] private RectTransform _inventoryMenu, _upgradeMenu;
    private bool _invMenuActivated = false;
    private bool _upgradeMenuActivated = false;
    private Vector2 _invClose = new Vector2(800, 0);
    private Vector2 _invOpen = new Vector2(400, 0);
    private Vector2 _upgradeClose = new Vector2(-800, 0);
    private Vector2 _upgradeOpen = new Vector2(-400, 0);

    void Start()
    {
        _inventoryMenu.anchoredPosition = _invClose;
        _upgradeMenu.anchoredPosition = _upgradeClose;
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
