using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class keyController : MonoBehaviour
{
    private Transform keysTransform;
    private int totalKeys = 0;
    private int unlockedKeys = 0;
    // Start is called before the first frame update
    void Start()
    {
        keysTransform = GetComponent<Transform>();
        totalKeys = keysTransform.childCount;
    }

    // Update is called once per frame
    void Update()
    {
        unlockedKeys = checkValidKeys();
    }

    private int checkValidKeys()
    {
        int _unlockedKeys = 0;
        for (int i = 0; i < totalKeys; i += 1) {
            if (keysTransform.GetChild(i).GetComponent<keyActions>().getGateState())
                _unlockedKeys += 1;
        }
        return (_unlockedKeys);
    }
    public bool getKeysState()
    {
        return ((totalKeys == unlockedKeys));
    }
    public void reset()
    {
        for (int i = 0; i < totalKeys; i += 1)
            keysTransform.GetChild(i).GetComponent<keyActions>().reset();
        unlockedKeys = 0;
    }
}
