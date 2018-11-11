using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public static GameController m;
    public Soldier selectedSolider;

	public int totalEnergy=100;

    void Awake()
    {
        m = this;
    }


//To increase score by coroutine
    void Start(){
        StartCoroutine(UpdateEnergyValue());
    }

    IEnumerator UpdateEnergyValue(){
        while(true){
            yield return new WaitForSeconds(1);
            UIController.m.SetEnergy(totalEnergy);
        }
    }
}
