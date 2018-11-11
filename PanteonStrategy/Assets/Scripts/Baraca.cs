
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;


public class Baraca : Build
{
    public Soldier prefab;
    public int soldierCost = 50;
    private List<Cordinat> baracaNeighbor = new List<Cordinat>();

    public new void Start()
    {
        base.Start();
        base.SetType(typeof(Baraca));
    }

    public override void BuildCreated()
    {
        InfoController.m.SetBaracaInformation(this);
    }
 // Soldier creation division only by Barack
    public void CreateSoldier()
    {
        if (GameController.m.totalEnergy < soldierCost)
        {
            AlertController.m.Open("Warning!!", "There's not enough energy to produce soldiers. You must build the power plant", "Create Central", BuildController.m.CreateFactory);
            return;
        }
        SearchEmptyNeighborsForSoldier();
        if (baracaNeighbor.Count == 0)
        {
            AlertController.m.Open("Warning!!", "In order to produce more troops, you must send troops to another location.!", "Anladım", null);
            return;
        }

        GameController.m.totalEnergy -= soldierCost;
        int rnd = Random.Range(0, baracaNeighbor.Count);
        Soldier soldier = Instantiate(prefab, GridController.m.GetGridPositionFromCordinat(baracaNeighbor[rnd])
                            , Quaternion.identity, GridController.m.transform);
        soldier.SetCordinat(baracaNeighbor[rnd]);

    }

// To search for free space around of Barack
    public void SearchEmptyNeighborsForSoldier()
    {
        baracaNeighbor.Clear();
        int neighborCount = 2 * (width + height) + 4;
        Cordinat tempCenter = new Cordinat(centerCordinat.x, centerCordinat.y);
        for (int i = 0; i <= neighborCount; i++)
        {
            Cordinat temp = new Cordinat(tempCenter.x - 2, tempCenter.y - 2);
            if (temp.x >= 0 && temp.y >= 0)
            {
                if (GridController.m.GetGridIsEmpty(temp))
                {
                    baracaNeighbor.Add(temp);
                }
            }
            if (i < 4)
                tempCenter.x++;
            else if (i < 8)
                tempCenter.y++;
            else if (i < 12)
                tempCenter.x--;
            else
                tempCenter.y--;
        }

    }
}
