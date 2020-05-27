using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class deathGateAction : MonoBehaviour
{
    public Color switchColor;
    private bool entered;
    private Shapes2D.Shape gateShape;
    private AudioSource effect;


    // Start is called before the first frame update
    void Start()
    {
        gateShape = GetComponent<Shapes2D.Shape>();
        effect = GetComponent<AudioSource>();
        entered = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.name == "Player") {
            other.GetComponent<playerAction>().setState(true);
            effect.Play();
            setGateState(true);
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
}
