using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class PlayerController : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _moneyValueText;
    [SerializeField] private InventoryBase inventoryBase;
    void Start()
    {

    }

   
    void Update()
    {
        _moneyValueText.text = inventoryBase.MoneyValue.ToString();
    }

}
