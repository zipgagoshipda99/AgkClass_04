using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class defaultVariables : MonoBehaviour
{

    public bool upgradeBool = true;
    public bool isFlickering = false;
    public int upgradePrice = 0;
    public int upgradePercent = 0;
    public int upgradeAmmount = 0;
    public int sellPrice = 0;
    public int money = 1000;
    public float total_percentage = 100;
    public float succ_percentage = 0;  
    public float fail_percentage = 0;
    public int succStreak = 0;
    public int failStreak = 0;
    public SwordData activeSword;
    public TextMeshProUGUI upgradeAmmountText;
    public TextMeshProUGUI percentageText;
    public TextMeshProUGUI succesorfailText;
    public TextMeshProUGUI succstreakText;
    public TextMeshProUGUI failstreakText;
    public TextMeshProUGUI upgradepriceText;
    public TextMeshProUGUI sellpriceText;
    public TextMeshProUGUI moneyText;
    public TextMeshProUGUI moneynotenoughText;
    public TextMeshProUGUI defaultswordnameText;
    public Image defaultswordIcon;
    public TextMeshProUGUI maxinvText;

    public GameObject easymodeCanvas;
    public GameObject shopCanvas;
    public GameObject shopMenu;

    public GameObject inventoryCanvas;
    public GameObject inventoryshopMenu;

    

}
