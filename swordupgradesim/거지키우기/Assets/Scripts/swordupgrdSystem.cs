using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class swordupgradeSystem : swordUpgrade
{
    public void upgrdPressed()
    {
        Debug.Log("upgrdpressed함수 실행됨");
        upgradeBool = true;
        upgradeAmmount += 1;
        if (upgradeAmmount >= 0)
        {
            upgrade_amt_text.text = $"+{upgradeAmmount}";
        }
    }
}
