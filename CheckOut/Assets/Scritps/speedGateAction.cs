using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class speedGateAction : MonoBehaviour
{
    public Vector2 forceValue;
    public bool oneTimeUsage;
    public Color switchColor;
    public float amount;

    public bool reverse;
    private AudioSource effect;
    private Color initColor;

    private bool entered = false;
    private Shapes2D.Shape gateShape;
    private Rigidbody2D playerRb;


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
        if (!getGateState()) {
            if (other.name == "Player") {
                increasePlayerSpeed(other, forceValue);
                effect.Play();
                if (oneTimeUsage) {
                    setGateState(true);
                    switchCol();
                }
            }
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

    private void increasePlayerSpeed(Collider2D other, Vector2 newForce)
    {
        playerRb = other.GetComponent<Rigidbody2D>();

        Vector2 reverseVelocity = (-3.0f * playerRb.velocity);

        if (reverse) {
            playerRb.AddForce(reverseVelocity, ForceMode2D.Impulse);
        } else
            playerRb.AddForce(playerRb.velocity, ForceMode2D.Impulse);
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
