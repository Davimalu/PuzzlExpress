using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopItem : MonoBehaviour
{
    public int skinId;

    public void selectSkin()
    {
        ShopScript.toggleSelection(skinId);

        PlayerPrefs.SetInt("skin", skinId);
    }
}
