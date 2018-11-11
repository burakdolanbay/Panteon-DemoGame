using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Soldier : MonoBehaviour
{
    public string name;
    public Sprite img;
    public float speed;
    public int power;
    public int health;
    public Cordinat soldierCord;
    private SpriteRenderer spriteRenderer;
    bool isRun;
    private int pathIndex;
    private Vector2[] path;


    public GameObject pathicon;
    List<GameObject> pathobje = new List<GameObject>();
    public void SetCordinat(Cordinat cord)
    {
        soldierCord = cord;
        GridController.m.gridArray[soldierCord.x, soldierCord.y] = 1;
    }

    void Start()
    {
        speed = Random.Range(100, 500);
        power = Random.Range(100, 500);
        health = Random.Range(50, 100);
    }
    void Update()
    {
        if (Input.GetMouseButtonDown(1) && GameController.m.selectedSolider == this)
        {
            path = PathFinding.SearchPath(transform.localPosition, Input.mousePosition);
            if (path == null)
            {
                Debug.LogError("Wrong Target Selection!!");
                GridController.m.CloseTargetIcon();
                isRun = false;
                AlertController.m.Open("Warning","Department is currently full!.","Okay",null);
                return;
            }
            else
            {
                GridController.m.gridArray[soldierCord.x, soldierCord.y] = 0;
                isRun = true;
                pathIndex = 0;
            }
            DrawOnThePath();

        }

        if (isRun)
        {
            transform.localPosition = Vector2.MoveTowards(transform.localPosition, path[pathIndex], speed * Time.deltaTime);
            if (Vector2.Distance(transform.localPosition, path[pathIndex]) < 0.1f)
            {
                Destroy(pathobje[pathIndex]);
                pathIndex++;
                if (pathIndex == path.Length)
                {
                    GridController.m.CloseTargetIcon();
                    SetCordinat(GridController.m.GetCordinatFromWorldPosition(transform.position));
                    isRun = false;
                }
            }
        }
    }
    
//Draws the target path
    private void DrawOnThePath()
    {
        pathobje.ForEach(x => Destroy(x.gameObject));
        pathobje.Clear();
        for (int i = 0; i < path.Length; i++)
        {
            pathobje.Add(Instantiate(pathicon, path[i], Quaternion.identity));
        }
    }

    void OnMouseDown()
    {
        GameController.m.selectedSolider = this;
        InfoController.m.SetInfo("Name :" + name + "\nSpeed :" + speed + "\nPower :" + power + "\nHealth :" + health, img);
    }
}
