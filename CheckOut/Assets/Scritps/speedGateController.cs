using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class speedGateController : MonoBehaviour
{
    private Transform speedGateTransform;
    private int totalGates = 0;
    // private int usedGates = 0;
    // Start is called before the first frame update
    void Start()
    {
        speedGateTransform = GetComponent<Transform>();
        totalGates = speedGateTransform.childCount;
    }

    // Update is called once per frame
    void Update()
    {

    }

    // public bool getGatesState()
    // {

    // }
    public void reset()
    {
        for (int i = 0; i < totalGates; i += 1)
            speedGateTransform.GetChild(i).GetComponent<speedGateAction>().reset();
    }
}
