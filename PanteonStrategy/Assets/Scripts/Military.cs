using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Military : Build
{
    public List<Cordinat> inCastle = new List<Cordinat>();
    public new void Start()
    {

        base.Start();

    }

    public new void OnMouseDown()
    {
        base.OnMouseDown();
        SearchEmptyInCastle();



    }

//Creation of the empty space of the castle
    public void SearchEmptyInCastle()
    {
        if (centerCordinat != null)
        {
            inCastle.Clear();
            inCastle.Add(centerCordinat);


            GridController.m.gridArray[centerCordinat.x, centerCordinat.y] = 0;
            Cordinat tempCenter = new Cordinat(centerCordinat.x, centerCordinat.y);

            for (int i = 0; i < 9; i++)
            {
                Cordinat temp = new Cordinat(tempCenter.x - 1, tempCenter.y - 1);
                if (temp.x >= 0 && temp.y >= 0)
                {
                    inCastle.Add(temp);
                    GridController.m.gridArray[temp.x, temp.y] = 0;
                    Debug.Log(temp.x + "x" + temp.y + "=" + GridController.m.gridArray[temp.x, temp.y]);
                }

                if (i < 2)
                {
                    tempCenter.x++;
                    if (i == 1)
                    {
                        GridController.m.gridArray[temp.x, temp.y - 1] = 0;
                    }
                }
                else if (i < 4)
                {
                    tempCenter.y++;
                    if (i == 3)
                    {
                        GridController.m.gridArray[temp.x + 1, temp.y] = 0;
                    }
                }

                else if (i < 6)
                {
                    tempCenter.x--;
                    if (i == 5)
                        GridController.m.gridArray[temp.x, temp.y + 1] = 0;
                }
                else
                {
                    tempCenter.y--;

                    if (i == 7)
                        GridController.m.gridArray[temp.x - 1, temp.y] = 0;
                }



            }
        }
    }

}

