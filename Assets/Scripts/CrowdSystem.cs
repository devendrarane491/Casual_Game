using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrowdSystem : MonoBehaviour
{
    [Header("Elements")]
    [SerializeField] private Transform runnersTransform;
    [SerializeField] private GameObject runnerPrefab;

    [Header("Setting")]
    [SerializeField] private float radius;
    [SerializeField] private float angle;

    void Start()
    {
      
    }

    void Update()
    {
        PlaceRunner();
    }

    private void PlaceRunner()
    {
        // Loop through all child objects
        for (int i = 0; i < runnersTransform.childCount; i++)
        {
            Vector3 position = PlayerRunnerLocalPosition(i);
            runnersTransform.GetChild(i).localPosition = position;
        }
    }

    private Vector3 PlayerRunnerLocalPosition(int index)
    {
        float radian = index * angle * Mathf.Deg2Rad;
        float x = radius * Mathf.Sqrt(index) * Mathf.Cos(radian);
        float z = radius * Mathf.Sqrt(index) * Mathf.Sin(radian);
        return new Vector3(x, 0, z);
    }

    public float GetCRowdRadius()
    {
        return radius * Mathf.Sqrt(runnersTransform.childCount);
    }

    public void ApplyBonus(BonusType bonusType, int bonusAmount)
    {
        switch(bonusType)
        {
            case BonusType.Addition:
                AddRunners(bonusAmount); 
                break;

            case BonusType.Product:
                int runnerToAdd = (runnersTransform.childCount * bonusAmount) - runnersTransform.childCount;
                AddRunners(runnerToAdd);
                break;

            case BonusType.Difference:
                RemoveRunners(bonusAmount);
                break;

            case BonusType.Division:
                int runnerToRemove = runnersTransform.childCount - (runnersTransform.childCount / bonusAmount);
                RemoveRunners(runnerToRemove);
                break;
        }
    }

    private void AddRunners(int amount)
    {
        for (int i = 0; i < amount; i++)
            Instantiate(runnerPrefab, runnersTransform);
    }

    private void RemoveRunners(int amount)
    {
        if (amount > runnersTransform.childCount)
            amount = runnersTransform.childCount;
        int runnersAmount = runnersTransform.childCount;

        for (int i = runnersAmount - 1; i >= runnersAmount - amount; i--)
        {
            Transform runnerToDestroy = runnersTransform.GetChild(i);
            runnerToDestroy.SetParent(null);
            Destroy(runnerToDestroy.gameObject);
        }
    }
}
