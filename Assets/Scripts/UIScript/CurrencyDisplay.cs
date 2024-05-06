using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
using UnityEngine.UI;

public class CurrencyDisplay : MonoBehaviour
{
    [SerializeField] private  TextMeshProUGUI _text;
    private void Update() {
        _text.text = DataManager.Instance.Currency.ToString();
    }
}
