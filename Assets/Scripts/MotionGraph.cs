using System.Collections.Generic;
using UnityEngine;

public class MotionGraph : MonoBehaviour
{
    [SerializeField] int m_totalPoints = 20;
    [SerializeField] float m_separation = 1f, m_amplitude = 0.7f;
    [SerializeField] private GameObject m_Prefab;

    //Variable de utilidad
    private List<GameObject> newPoints = new List<GameObject>();
    
    private void Start()
    {
        for (int i = 0; i < m_totalPoints; i++)
        {
            GameObject newPoint = Instantiate(m_Prefab, transform);
            newPoints.Add(newPoint);
        }
    }
    private void Update()
    {
        for (int i = 0; i < m_totalPoints; i++)
        {
            GameObject newPoint = newPoints[i];
            float x = i * m_separation;
            float y = m_amplitude * Mathf.Sin(i + Time.time);
            newPoint.transform.localPosition = new Vector3(x, y);
        }
    }
}
