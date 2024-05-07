using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

[System.Serializable]
public class Item
{
    public int id;
    public Sprite skin;
    public int stars;
}

public class ShopScript : MonoBehaviour
{
    public GameObject shopItemPrefab;
    public Item[] items;
    public Transform wrapper;

    private static int selected;

    // Start is called before the first frame update
    void Start()
    {
        selected = PlayerPrefs.GetInt("skin", 0);

        GameObject.Find("stars").GetComponent<TextMeshProUGUI>().text = PlayerPrefs.GetInt("stars").ToString() + "x";
        int i = 0;
        foreach (Item item in items)
        {
            var shopItem = Instantiate(shopItemPrefab, wrapper);

            shopItem.name = i.ToString();
            shopItem.GetComponent<ShopItem>().skinId = i;
            shopItem.transform.Find("skin").GetComponent<Image>().sprite = item.skin;
            shopItem.transform.Find("locked/stars").GetComponent<TextMeshProUGUI>().text = item.stars.ToString();
            shopItem.transform.Find("selected").gameObject.SetActive(false);

            if (item.stars <= PlayerPrefs.GetInt("stars"))
            {
                shopItem.transform.Find("locked").gameObject.SetActive(false);
            } else
            {
                shopItem.transform.Find("select").gameObject.SetActive(false);
            }

            if (i == PlayerPrefs.GetInt("skin"))
            {
                // selected
                shopItem.transform.Find("select").gameObject.SetActive(false);
                shopItem.transform.Find("selected").gameObject.SetActive(true);
            }

            i++;
        }
    }

    public static void toggleSelection(int newId)
    {
        var oldItem = GameObject.Find(selected.ToString());
        oldItem.transform.Find("selected").gameObject.SetActive(false);
        oldItem.transform.Find("select").gameObject.SetActive(true);

        selected = newId;

        var newItem = GameObject.Find(selected.ToString());
        newItem.transform.Find("selected").gameObject.SetActive(true);
        newItem.transform.Find("select").gameObject.SetActive(false);

    }

    public void backToMainMenu()
    {
        SceneManager.LoadScene("Mainmenu");
    }
}
