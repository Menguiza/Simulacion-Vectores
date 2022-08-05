using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class TestMyVector : MonoBehaviour
{
    public MyVector vector1, vector2;

    public float factor = 0f;
    
    void Update()
    {
        DrawVectors();
        MyVector lerp = DrawLerp();
        Diference(vector1 - lerp, lerp);
    }

    void DrawVectors()
    {
        vector1.Draw(Color.blue);
        vector2.Draw(Color.green); 
    }

    MyVector DrawLerp()
    {
        MyVector lerp = vector1.Lerp(vector2, factor);
        lerp.Draw(Color.red);
        return lerp;
    }
    
    void Diference(MyVector dif, MyVector lerp)
    {
        dif.Draw(lerp, Color.yellow);
    }
}
