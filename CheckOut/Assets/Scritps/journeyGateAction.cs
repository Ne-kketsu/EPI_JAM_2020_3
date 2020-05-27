using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class journeyGateAction : MonoBehaviour
{
    public Transform exitPos;
    public bool oneTimeUsage;
    public Color switchColor;
    private AudioSource effect;
    private Color initColor;

    private bool entered = false;
    private Shapes2D.Shape gateShape;


    // Start is called before the first frame update
    void Start()
    {
        gateShape = GetComponent<Shapes2D.Shape>();
        effect = GetComponent<AudioSource>();
        initColor = gateShape.settings.fillColor;
        entered = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.name == "Player") {
            other.GetComponent<playerAction>().freeze();
            other.GetComponent<Transform>().position = exitPos.position;
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

        public void switchCol()
    {
            gateShape.settings.fillColor = new Color(switchColor.r, switchColor.g, switchColor.b, 0.5f);
    }
        public void reset()
    {
        if (oneTimeUsage) {
            gateShape.settings.fillColor = new Color(initColor.r, initColor.g, initColor.b, 0.5f);
        }
        setGateState(false);
    }
}
