using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Assign to player
public class Interaction : MonoBehaviour
{
    
    private void OnTriggerEnter2D(Collider2D obj) 
    {
        ICollectable fruit = obj.GetComponent<ICollectable>();
        fruit?.Collect();

        IHarvest plant = obj.GetComponent<IHarvest>();
        plant?.Harvest();
    }
}
public interface ICollectable
{
    public void Collect();

}
public interface IHarvest
{
    public void Harvest();
}

