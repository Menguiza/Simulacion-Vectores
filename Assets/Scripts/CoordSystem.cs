using UnityEngine;

public class CoordSystem : MonoBehaviour
{
    [Header("Drawing")] 
    [SerializeField] float stepSize = 0.15f;
    [SerializeField] int totalSteps = 50;
    [SerializeField] bool drawXY = true, drawZX = true, drawYZ = true;
    [SerializeField] Transform objeto;

    [Header("Matrix Transform")] 
    [SerializeField] Vector3 position, rotation, scale = Vector3.one;

    //Variables de utilidad
    Matrix4x4 matriz;
    Vector3 ObjetoPosition;
    
    private void Start()
    {
        ObjetoPosition = objeto.position;
    }

    private void Update()
    {
        matriz = Matrix4x4.TRS(position, Quaternion.Euler(rotation), scale);
        UpateOtherObject();
        DrawBasis();
        DrawPlanes();
    }

    private void UpateOtherObject()
    {
        if (objeto == null) return;
        objeto.position = ObjetoPosition;
        objeto.position = matriz.MultiplyPoint3x4(objeto.position);
    }

    private void DrawPlanes()
    {
        Vector3 pos = matriz.GetColumn(3);
        Vector3 xAxis = matriz.GetColumn(0);
        Vector3 yAxis = matriz.GetColumn(1);
        Vector3 zAxis = matriz.GetColumn(2);
        if (drawXY) DrawGrid(pos, xAxis, yAxis, scale.x, scale.y);
        if (drawZX) DrawGrid(pos, zAxis, xAxis, scale.z, scale.x);
        if (drawYZ) DrawGrid(pos, yAxis, zAxis, scale.y, scale.z);
    }

    private void DrawGrid(Vector3 pos, Vector3 xAxis, Vector3 yAxis, float scaleX, float scaleY)
    {
        for (int i = 1; i <= totalSteps; ++i)
        {
            Debug.DrawRay(pos + xAxis * stepSize * i, yAxis.normalized * stepSize * totalSteps * Mathf.Abs(scaleY));
            Debug.DrawRay(pos + yAxis * stepSize * i, xAxis.normalized * stepSize * totalSteps * Mathf.Abs(scaleX));
        }
    }

    private void DrawBasis()
    {
        Vector3 pos = matriz.GetColumn(3);
        Debug.DrawRay(pos, matriz.GetColumn(0), Color.red);
        Debug.DrawRay(pos, matriz.GetColumn(1), Color.green);
        Debug.DrawRay(pos, matriz.GetColumn(2), Color.blue);
    }
}
