using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Unity.PlasticSCM.Editor.WebApi;
using System.Diagnostics.Tracing;
using UnityEditor.Search;

public class shopManager : percentageManager
{
    public void gotoShop()
    {
        easymodeCanvas.SetActive(false);
        shopCanvas.SetActive(true);
    }
}