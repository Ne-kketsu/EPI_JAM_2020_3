using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bgAction : MonoBehaviour
{
    private Shapes2D.Shape bgShape;
    private Color initColor;
    private float initFillRotation;
    // Start is called before the first frame update
    void Start()
    {
        bgShape = GetComponent<Shapes2D.Shape>();
        initColor = bgShape.settings.fillColor2;
        initFillRotation = bgShape.settings.fillRotation;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void rotate(int r)
    {
        if (r < 0) {
            if (bgShape.settings.fillRotation < 0)
                bgShape.settings.fillRotation = 360;    
            bgShape.settings.fillRotation -= (1);
        }
        if (r > 0) {
            if (bgShape.settings.fillRotation > 360)
                bgShape.settings.fillRotation = 0;    
            bgShape.settings.fillRotation += (1);
        }
    }

    public void switchColor(Color sColor)
    {
        bgShape.settings.fillColor2 = new Color(sColor.r, sColor.g, sColor.b, 0.5f);
    }

    public void reset()
    {
        bgShape.settings.fillRotation = initFillRotation;
        bgShape.settings.fillColor2 = initColor;
    }
}
