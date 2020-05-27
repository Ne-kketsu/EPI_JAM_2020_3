using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class levelSwitch : MonoBehaviour
{
    public bool _switch = false;
    public Transform [] boardsTargets;
    public float smoothSpeed;
    public Vector3 offset;
    private int level = 0;
    // Start is called before the first frame update
    void Awake()
    {
        setBoardActive(true);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (_switch) {
            Vector3 desiredPosition = boardsTargets[level].position + offset;
            Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);

            transform.position = smoothedPosition;
            _switch = false;
        }
        if (Input.GetKeyDown(KeyCode.Escape)) {
            prevLvl();
            // setBoardActive(true);
        }
        if (Input.GetKeyDown(KeyCode.Return)) {
            nextLvl();
            // setBoardActive(true);
        }
        Switch();
    }

    private void setBoardActive(bool active)
    {
        boardsTargets[level].Find("gameBoard").GetComponent<boardActions>().setActive(active);
        // Debug.Log(level);
    }
    private bool getBoardActive(int board)
    {
        return boardsTargets[board].Find("gameBoard").GetComponent<boardActions>().getActive();
    }
    public void Switch()
    {
        if (!_switch) {
            _switch = true;
        }
        setBoardActive(true);
    }
    public void nextLvl()
    {
        if (level < boardsTargets.Length - 1)
            level += 1; 
    }
    public void prevLvl()
    {
        if (level > 0)
            level -= 1;
    }
}
