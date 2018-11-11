using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Factory : Build
{
    float timer;
    public int energy=5;
    public bool isRun;

    public new void Start()
    {
        base.Start();
    }
    public new void Update()
    {
        base.Update();
        if (!isRun)
            return;
        timer += Time.deltaTime;
        if (timer > 1)
        {
            GameController.m.totalEnergy += energy;
            timer = 0;
        }
    }

    public override void BuildCreated()
    {
        InfoController.m.SetInfo(name+"\n Energy Production by second :"+energy,img);
        isRun = true;
    }
}
