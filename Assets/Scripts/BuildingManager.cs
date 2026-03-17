using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BuildingManager : MonoBehaviour
{
    [System.Serializable]
    public class BldingList
    {

    }

    
    


    


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
[System.Serializable]
public class BldingInfo
    {
        public enum BldingClass
        {
        Housing,
        Resource,
        Storage,
        Farm
        }

        public BldingClass bldClass;
        public int bldingLvl;
        public int unlockLevel;
        public int unlockCost;
        public float buildTime;
        public float prodTime;
        public GameObject product;
        public int prodNum;
    }