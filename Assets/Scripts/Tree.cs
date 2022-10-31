using System.Collections.Generic;
using UnityEngine;

public class Tree : MonoBehaviour
{
    [SerializeField] private GameObject branchPrefab;
    [SerializeField] private int totalLevels = 3;
    [SerializeField] private float initialSize = 4f;
    [SerializeField, Range(0f, 1f)] private float reductionPerLevel = 0.1f;
    
    //Variables de Utilidad
    Queue<GameObject> myQueue = new Queue<GameObject>();
    private int currentLevel = 1;

    void Start()
    {
        GameObject rootBranch = Instantiate(branchPrefab, transform);
        ChangeBranchSize(rootBranch, initialSize);
        myQueue.Enqueue(rootBranch);
        GenerateTree();
    }

    private void GenerateTree()
    {
        if (currentLevel >= totalLevels)
        {
            return;
        }

        ++currentLevel;
        
        float newSize = Mathf.Max(initialSize - initialSize * reductionPerLevel * (currentLevel - 1), 0.1f);
        
        List<GameObject> branchesCreatedThisCycle = new List<GameObject>();
        
        while (myQueue.Count > 0)
        {
            GameObject rootBranch = myQueue.Dequeue();

            GameObject leftBranch = CreateBranch(rootBranch, Random.Range(5, 20));
            GameObject rightBranch = CreateBranch(rootBranch, -Random.Range(5, 25));

            ChangeBranchSize(leftBranch, newSize);
            ChangeBranchSize(rightBranch, newSize);

            branchesCreatedThisCycle.Add(leftBranch);
            branchesCreatedThisCycle.Add(rightBranch);
        }

        Debug.Log(currentLevel);
        
        foreach (var newBranches in branchesCreatedThisCycle)
        {
            myQueue.Enqueue(newBranches);
        }

        GenerateTree();
    }

    private GameObject CreateBranch(GameObject prevBranch, float relativeAngle)
    {
        GameObject newBranch = Instantiate(branchPrefab, transform);
        
        newBranch.transform.localPosition = prevBranch.transform.localPosition + prevBranch.transform.up * GetBranchLength(prevBranch);
        newBranch.transform.localRotation = prevBranch.transform.localRotation * Quaternion.Euler(0, 0, relativeAngle);
        
        return newBranch;
    }

    private void ChangeBranchSize(GameObject branchInstance, float newSize)
    {
        Transform square = branchInstance.transform.GetChild(0);
        Transform circle = branchInstance.transform.GetChild(1);
        
        Vector3 newSquareScale = square.transform.localScale;
        newSquareScale.y = newSize;
        square.transform.localScale = newSquareScale;
        
        Vector3 newSquarePosition = square.transform.localPosition;
        newSquarePosition.y = newSize / 2f;
        square.transform.localPosition = newSquarePosition;
        
        Vector3 newCirclePosition = circle.transform.localPosition;
        newCirclePosition.y = newSize;
        circle.transform.localPosition = newCirclePosition;
    }

    private float GetBranchLength(GameObject branchInstance)
    {
        return branchInstance.transform.GetChild(0).localScale.y;
    }
}
