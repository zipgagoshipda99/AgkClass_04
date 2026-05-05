using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Unity.PlasticSCM.Editor.WebApi;
using System.Diagnostics.Tracing;
using UnityEditor.Search;
using System.Data.Common;
using Unity.VisualScripting;

public class inventoryItem
{
    public SwordData swordData;
    public int upgradeAmmount;
    public inventoryItem(SwordData swData, int ammount)
    {
        swordData = swData;
        upgradeAmmount = ammount;
        
    } //constructer, has to be same name as the parent(aka class.), runs automatically when i use new
}

public class inventoryManager : shopManager
{
   public List<inventoryItem> inventoryList = new List<inventoryItem>();
   public const int maxInv = 10;

    public void store()
    
    {
        if (inventoryList.Count>= maxInv )
        {
            maxinvText.text = $"인벤토리 꽉차서 보관 불가능!!";
            Debug.Log("유저 인벤토리 꽉참");
        }
        else
        {
        inventoryList.Add(new inventoryItem(activeSword, upgradeAmmount));
        updateinventoryUI();
        // reset upgrade system
        upgradeAmmount = 0;
        upgradeAmmountText.text = $"+{upgradeAmmount}회";
        upgradePrice = 0;
        upgradepriceText.text = "강화 비용: 무료";
        sellPrice = 0;
        sellpriceText.text = $"판매 : {sellPrice}원";
        upgrdpriceLevel = 0;
        sellpriceLevel = 0;
        upgradeBool = true;
        }
    }
    public void setSwords()
    {
        if(activeSword == null)
        {
            activeSword = swordList[0];
        }
        defaultswordnameText.text = activeSword.swordName;
        defaultswordIcon.sprite = activeSword.icon;
        Debug.Log("set default sword");
        for (int i = 0; i<swordList.Count; i ++)
        {
            Image icon = shopMenu.transform.GetChild(i).GetComponent<Image>();
            TMP_Text nameText = shopMenu.transform.GetChild(i).Find("nameSword").GetComponent<TMP_Text>();
            TMP_Text priceText = shopMenu.transform.GetChild(i).Find("priceSword").GetComponent<TMP_Text>();
            //IMPORTANT!! Find() searches the direct children of whatever transform you call it on.
            
            icon.sprite = swordList[i].icon;
            nameText.text = (swordList[i].swordName);
            priceText.text = $"{swordList[i].cost}원";
            
        }

    }
    public void buySword(int index)
    {
        if (inventoryList.Count > maxInv)
        {
            maxinvText.text = "인벤토리 꽉차서 구매 불가능!!";
            return;
        }

        SwordData newSword = swordList[index];

       
        if (money < newSword.cost)
        {
            moneynotenoughText.text = "돈이 부족합니다! :d";
            return;
        }

       
        inventoryList.Add(new inventoryItem(newSword, upgradeAmmount));
        updateinventoryUI();

       
        money -= newSword.cost;
        moneyText.text = $"재산: {money}";

        
        activeSword = newSword;
        defaultswordnameText.text = activeSword.swordName;
        defaultswordIcon.sprite = activeSword.icon;

        
        upgradeAmmount = 0;
        upgradeAmmountText.text = $"+{upgradeAmmount}회";
        upgradePrice = 0;
        upgrdpriceLevel = 0;
        upgradepriceText.text = "강화 비용: 무료";
        sellPrice = 0;
        sellpriceLevel = 0;
        sellpriceText.text = $"판매 : {sellPrice}원";
        upgradeBool = true;
        percentageText.text = "성공률 100%";
        succesorfailText.text = "";

        Debug.Log($"검 구매 완료: {activeSword.swordName}, 남은 돈: {money}");

    }
    
    public void updateinventoryUI()
    {
        for(int i = 0; i < maxInv; i++) //max inv is 10 and i want it to run til 10 but i starts from 0 so 0~9 count its 10!! hehe dk what im saying here but yippie
        { //i == stored swords
            Image icon = inventoryshopMenu.transform.GetChild(i).GetComponent<Image>();
            TMP_Text nameText = inventoryshopMenu.transform.GetChild(i).Find("nameSword").GetComponent<TMP_Text>();
            TMP_Text levelText = inventoryshopMenu.transform.GetChild(i).Find("levelSword").GetComponent<TMP_Text>();
            if(i < inventoryList.Count)
            {
                icon.sprite = inventoryList[i].swordData.icon;
                icon.color = Color.white;//to make the sword icons show cause if its black it going to show as colored black
                nameText.text = inventoryList[i].swordData.swordName;
                levelText.text = $"레벨 : +{inventoryList[i].upgradeAmmount}";

            }
            else
            {
                icon.sprite = null;
                icon.color = Color.black;
                nameText.text = "없음";
                levelText.text ="레벨 : 없음";
            }
        }
       
    }
    public void gotoInventory()
    {
        easymodeCanvas.SetActive(false);
        inventoryCanvas.SetActive(true);
    }

}
