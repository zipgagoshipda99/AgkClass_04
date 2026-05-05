using System.Collections;
using System.Collections.Generic;
using System.Data.Common;
using System.Security;
using TMPro;
using Unity.VisualScripting.FullSerializer;
using UnityEngine;

public class percentageManager : swordManager
{
    public override void upgrdPressed()
    {
        percentageCalculate(); // 내가 원하는것 도 실행
        base.upgrdPressed(); //// 부모꺼도 실행하고

    }
    public void percentageCalculate()
    {
       
        if (money < upgradePrice)
        {
            moneynotenoughText.text = "돈이 부족합니다! :d";
            return;  // 여기서 멈추게 함
            //return 없으면 처음에 걍 upgradeammount==0 조건에 알맞아서 pricesUpdate() 함수땜에 -가 됨
        }

        if (upgradeAmmount > 0 && money >= upgradePrice)
        {
            pricesUpdate();//
            float chance = total_percentage / (1 + (upgradeAmmount * 0.1f));
            fail_percentage = total_percentage - chance;
            succ_percentage = chance;
            float randomRoll = Random.Range(0f, 100f);
            if (randomRoll <= succ_percentage)
                {
                   
                   succesorfailText.text = $"강화 성공 :3";
                   percentageText.text = $"성공률 : {chance:F2}%";
                   succStreak += 1;
                   succstreakText.text = $"success streak : X{succStreak}";
                   failstreakText.text ="";
                   failStreak = 0;
                   upgradeBool = true;
                Debug.Log($"업그레이드 횟수{upgradeAmmount}, 업그레이드 가격 {upgradePrice}, 판매 가격 {sellPrice}, 확률 {succ_percentage}, succ/fail여부 {upgradeBool}");
                }
            else if(randomRoll >= succ_percentage)
                {
                   succesorfailText.text = $"강화 실패 :(";
                   failStreak += 1;
                   failstreakText.text = $"fail streak : x{failStreak}";
                   succstreakText.text = "";
                   succStreak = 0;
                   upgradeBool = false;
                }
        }
        else if (upgradeAmmount == 0)

        {
            pricesUpdate();
            percentageText.text = $"성공률 : 100%";
            succesorfailText.text = $"강화 성공 :3";
            succStreak += 1;
            succstreakText.text = $"success streak: X{succStreak}";
            failstreakText.text ="";
            failStreak = 0;
            upgradeBool = true;
  
            Debug.Log("this is being used");
        }
        
    }
}
