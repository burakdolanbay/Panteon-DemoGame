using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class UIController : MonoBehaviour {

	// Use this for initialization
	
	public static UIController m;
	public Text totalEnergyText;
	
	void Start () {
		m=this;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void SetEnergy(int energyValue){
		totalEnergyText.text=energyValue.ToString();
	}
}
