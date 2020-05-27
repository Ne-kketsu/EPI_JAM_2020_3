using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class escapeGateAction : MonoBehaviour
{
    public Color switchColor;
    private Color initColor;
    private bool entered;
    private AudioSource effect;
    private Shapes2D.Shape gateShape;
    public int locker = 1;
    private bool locked = true;


    // Start is called before the first frame update
    void Start()
    {
        gateShape = GetComponent<Shapes2D.Shape>();
        initColor = gateShape.settings.fillColor;
        entered = false;
        effect = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.name == "Player") {
            int pKeys = other.GetComponent<playerAction>().getKeys();
            setGateState(unlock(pKeys));
        }
    }

    public bool getGateState()
    {
        return entered;
    }
    public void setGateState(bool state)
    {
        entered = state;
    }
    public bool unlock(int keys)
    {
        if (keys >= locker) {
            effect.Play();
            locked = false;
        }
        return (!locked);
    }
    public void switchCol()
    {
            gateShape.settings.fillColor = new Color(switchColor.r, switchColor.g, switchColor.b, 0.5f);
    }
    public void reset()
    {
        gateShape.settings.fillColor = new Color(initColor.r, initColor.g, initColor.b, 0.5f);
        setGateState(false);
    }
}
