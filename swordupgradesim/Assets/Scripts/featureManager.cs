using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;


public class featureManager : inventoryManager
{
    public void goback()
    {
        easymodeCanvas.SetActive(true);
        shopCanvas.SetActive(false);
        inventoryCanvas.SetActive(false);
    }

    public void rainbowText()
    {
         if (isFlickering == true)
            {
                float plrfpsTime = Time.time; 
                moneynotenoughText.color = Color.HSVToRGB((plrfpsTime % 1f), 1f, 1f);
            }
    }
    // Start is called before the first frame update

    public IEnumerator showthenHide() 
    //IEnumerator =  just a special method type that can pause itself mid-execution. Normal methods run all at once, IEnumerator can stop and wait.
    //StartCorountine() = StartCoroutine — tells Unity to run that special pauseable method. You can't just call an
    // invoke == finding the method directly as a string not referencing it!
    {
        moneynotenoughText.gameObject.SetActive(true);
        isFlickering = true;
        yield return new WaitForSeconds(3f);
        isFlickering = false;
        moneynotenoughText.gameObject.SetActive(false);
        //TMP_Text is a component not a GameObject itself. So you need .gameObject to get the GameObject it's attached to.

    }
    public override void upgrdPressed()
    {
        base.upgrdPressed(); //percentage manager 함수 parent
        if (money < upgradePrice)
        {
            StopAllCoroutines();
            StartCoroutine(showthenHide());
        }
    }
    
    // Update is called once per frame
    void Start()
    {
        setSwords();
        moneyText.text = $"{money}원";
    }
    void Update()
    {
        rainbowText();
    }
}
