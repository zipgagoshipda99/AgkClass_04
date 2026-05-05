using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Unity.PlasticSCM.Editor.WebApi;
using System.Diagnostics.Tracing;
using UnityEditor.Search;

public class swordManager : defaultVariables
{
    public int upgrdpriceLevel = 0;
    public float sellpriceLevel = 0;
    //main sword icon 
    public List<SwordData> swordList = new List<SwordData>();
    public int pricesUpdate()
    {
        money = money - upgradePrice;
        upgrdpriceLevel += 1;
        sellpriceLevel += (2.5f + upgradeAmmount);
        upgradePrice = activeSword.cost * upgrdpriceLevel;
        sellPrice = (int)(activeSword.cost * sellpriceLevel);
        //(int) is a cast. cast is just forcing one type to become another type!
        //cast == sytax btw
        moneyText.text = $"재산: {money}";
        upgradepriceText.text = $"강화 비용: {upgradePrice}원";
        sellpriceText.text = $"판매 : {sellPrice}원";
        return upgradePrice;

    }
    public void sell()
    {
        money = money + sellPrice;
        moneyText.text = $"재산: {money}";
        upgradeAmmount = 0;
        upgradeAmmountText.text = $"+{upgradeAmmount}회";
        upgradePrice = 0;
        upgrdpriceLevel = 0;
        upgradepriceText.text = $"강화 비용: 무료";
        sellPrice = 0;
        sellpriceLevel = 0;
        sellpriceText.text = $"판매 : {sellPrice}원";
        percentageText.text = $"성공률 100%";
        
        Debug.Log($"업그레이드 횟수{upgradeAmmount}, 업그레이드 가격 {upgradePrice}, 판매 가격 {sellPrice}");
    }

    public virtual void upgrdPressed()
    {
        
        Debug.Log("upgrdpressed함수 실행됨");                         
        if (upgradeBool == true && money >= upgradePrice)
            upgradeAmmount += 1;        
        if (upgradeAmmount >= 0)
        {
            upgradeAmmountText.text = $"+{upgradeAmmount}회";
        }
        
    }



    void Start()
    {
    }
}