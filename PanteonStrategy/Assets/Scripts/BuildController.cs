using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildController : MonoBehaviour
{

    // Use this for initialization
    public Build buildPrefab;

    public Build tentPrefab;
    public Baraca baracaPrefab;
    public Factory factoryPrefab;

    public Military militaryPrefab;

    public static BuildController m;
    void Awake()
    {
        m = this;
    }
    void Start()
    {
    }
    public void CreateBaraca()
    {
        Vector2 createPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Baraca baraca = Instantiate(baracaPrefab, createPos, Quaternion.identity);
        baraca.gameObject.transform.parent = gameObject.transform;
        InfoController.m.scrollBar.SetActive(false);
    }

    public void CreateBuild()
    {
        Vector2 createPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Build build = Instantiate(tentPrefab, createPos, Quaternion.identity);
        build.gameObject.transform.parent = gameObject.transform;
        InfoController.m.scrollBar.SetActive(false);
    }

    public void CreateBuildTent()
    {
        Vector2 createPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Build build = Instantiate(buildPrefab, createPos, Quaternion.identity);
        build.gameObject.transform.parent = gameObject.transform;
        InfoController.m.scrollBar.SetActive(false);
    }
    public void CreateFactory()
    {
        Vector2 createPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Factory central = Instantiate(factoryPrefab, createPos, Quaternion.identity);
        central.gameObject.transform.parent = gameObject.transform;
        InfoController.m.scrollBar.SetActive(false);
    }

    public void CreateMilitary()
    {
        Vector2 createPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Military mily = Instantiate(militaryPrefab, createPos, Quaternion.identity);
        mily.gameObject.transform.parent = gameObject.transform;
        InfoController.m.scrollBar.SetActive(false);
    }
}
