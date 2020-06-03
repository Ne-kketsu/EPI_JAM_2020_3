using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class menuAction : MonoBehaviour
{
    private Transform boardTransform;

    private Vector3 target;
    private Quaternion initBoardRotation;
    private escapeGateAction escapeGateScript;
    private deathGateAction deathGateScript;
    private playerAction pScript;
    private bgAction bgScript;

    // Start is called before the first frame update
    void Start()
    {
        boardTransform = GetComponent<Transform>();
        initBoardRotation = boardTransform.rotation;
        pScript = boardTransform.parent.Find("Player").GetComponent<playerAction>();
        bgScript = boardTransform.parent.Find("bg").GetComponent<bgAction>();
        target = GetComponent<Renderer>().bounds.center;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetAxisRaw("Horizontal") > 0) {
            boardTransform.RotateAround(target, Vector3.back, 60 * Time.deltaTime);
            bgScript.rotate(1);
        }
        else if (Input.GetAxisRaw("Horizontal") < 0) {
            boardTransform.RotateAround(target, Vector3.forward, 60 * Time.deltaTime);
            bgScript.rotate(-1);
        }
        if (pScript.getState())
            reset();
    }

    public void reset()
    {
            boardTransform.rotation = initBoardRotation;
            pScript.reset();
            bgScript.reset();
    }
}
