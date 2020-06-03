using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boardActions : MonoBehaviour
{
    public bool isActive = false;
    private bool isCompleted = false;
    private Transform boardTransform;

    private Vector3 target;
    private Quaternion initBoardRotation;
    private escapeGateAction escapeGateScript;
    private speedGateController speedGatesScript;
    private keyController keysScripts;
    private playerAction pScript;
    private bgAction bgScript;
    private levelSwitch cameraScript;


    // Start is called before the first frame update
    void Awake()
    {
        boardTransform = GetComponent<Transform>();
        initBoardRotation = boardTransform.rotation;
        escapeGateScript = boardTransform.Find("escapeGate").GetComponent<escapeGateAction>();
        speedGatesScript = boardTransform.Find("speedGates").GetComponent<speedGateController>();
        pScript = boardTransform.parent.Find("Player").GetComponent<playerAction>();
        keysScripts = boardTransform.Find("Keys").GetComponent<keyController>();
        bgScript = boardTransform.parent.Find("bg").GetComponent<bgAction>();
        cameraScript = Camera.main.GetComponent<levelSwitch>();
        target = GetComponent<Renderer>().bounds.center;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (!isCompleted && getActive()) {
            //Inputs
            if (Input.GetAxisRaw("Horizontal") > 0) {
                boardTransform.RotateAround(target, Vector3.back, 60 * Time.deltaTime);
                bgScript.rotate(1);
            }
            else if (Input.GetAxisRaw("Horizontal") < 0) {
                boardTransform.RotateAround(target, Vector3.forward, 60 * Time.deltaTime);
                bgScript.rotate(-1);
            }
            else if (Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.Return)) {
                pause();
            }

            //Events controller
            if (keysScripts.getKeysState())
                escapeGateScript.switchCol();
            //Level succeed
            if (escapeGateScript.getGateState()) {
                completed();
            }
            //Level failed
            if (pScript.getState()) {
                reset();
            }
        }
    }

    public void reset()
    {
            boardTransform.rotation = initBoardRotation;
            keysScripts.reset();
            pScript.reset();
            escapeGateScript.reset();
            speedGatesScript.reset();
            bgScript.reset();
    }

    public void setActive(bool active)
    {
        isActive = active;
    }

    public bool getActive()
    {
        return (isActive);
    }
    public void completed()
    {
        bgScript.switchColor(escapeGateScript.switchColor);
        setActive(false);
        isCompleted = true;
        cameraScript.nextLvl();
    }
    public void pause()
    {
        setActive(false);
        reset();
    }
    public bool getCompleted()
    {
        return isCompleted;
    }
}
