using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class keyActions : MonoBehaviour
{
    public Color switchColor;
    private Color initColor;
    private bool entered;
    private Shapes2D.Shape gateShape;
    private AudioSource effect;


    // Start is called before the first frame update
    void Start()
    {
        gateShape = GetComponent<Shapes2D.Shape>();
        initColor = gateShape.settings.fillColor;
        effect = GetComponent<AudioSource>();
        entered = false;
    }

    // Update is called once per frame
    void Update()
    {
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.name == "Player" && !getGateState()) {
            setGateState(true);
            other.GetComponent<playerAction>().addKey();
            gateShape.settings.fillColor = new Color(switchColor.r, switchColor.g, switchColor.b, 1);
            effect.Play();
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
    public void reset()
    {
        gateShape.settings.fillColor = new Color(initColor.r, initColor.g, initColor.b, 1);
        setGateState(false);
    }
}
