using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerAction : MonoBehaviour
{
    private Rigidbody2D rb;
    private bool isDead = false;
    private int keys = 0;
    public Transform Pos;
    private Vector3 initPos;
    // Start is called before the first frame update
    void Start()
    {
        initPos = new Vector3(Pos.position.x, Pos.position.y, Pos.position.z);
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void freeze()
    {
        rb.velocity = new Vector2(0.0f, 0.0f);
    }
    public int getKeys()
    {
        return keys;
    }
    public void addKey()
    {
        keys += 1;
    }
    public void reset()
    {
        freeze();
        Pos.position = initPos;
        isDead = false;
        keys = 0;
    }

    public bool getState()
    {
        return isDead;
    }

    public void setState(bool wasted)
    {
        isDead = wasted;
    }
}
