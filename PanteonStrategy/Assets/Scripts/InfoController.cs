using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class InfoController : MonoBehaviour
{

    public static InfoController m;
    public GameObject scrollBar;
    public GameObject infoPanel;
    public Text costText;
    public Text name;
    public Image image;
    public Button createSoldierButton;

    void Start()
    {
        m = this;
        infoPanel.SetActive(false);
    }

    public void SetBaracaInformation(Baraca baraca)
    {
        createSoldierButton.gameObject.SetActive(true);
        createSoldierButton.onClick.RemoveAllListeners();
        createSoldierButton.onClick.AddListener(baraca.CreateSoldier);
        costText.text=baraca.soldierCost.ToString();
        createSoldierButton.onClick.AddListener(new Military().SearchEmptyInCastle);
    }

    public void SetInfo(string name, Sprite image)
    {
        this.name.text = name;
        this.image.sprite = image;
        createSoldierButton.gameObject.SetActive(false);
    }

}
