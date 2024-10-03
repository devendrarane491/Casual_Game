using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public enum BonusType { Addition, Difference, Product, Division }

public class Doors : MonoBehaviour
{
    // Start is called before the first frame update  

    [Header("Elements")]
    [SerializeField] private SpriteRenderer rightDoorRenderer;
    [SerializeField] private SpriteRenderer leftDoorRenderer;
    [SerializeField] private TextMeshPro rightDoorText;
    [SerializeField] private TextMeshPro leftDoorText;
    [SerializeField] private Collider collider;

    [Header("Setting")]
    [SerializeField] private BonusType rightDoorBonusType;
    [SerializeField] private int rightDoorBonusAmount;

    [SerializeField] private BonusType leftDoorBonusType;
    [SerializeField] private int leftDoorBonusAmount;

    [SerializeField] private Color bonusColor;
    [SerializeField] private Color penaltyColor;
    void Start()
    {
        ConfigureDoors();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void ConfigureDoors()
    {
        //Right Door Configuration
        switch (rightDoorBonusType)
        {
            case BonusType.Addition:
                rightDoorRenderer.color = bonusColor;
                rightDoorText.text = "+" + rightDoorBonusAmount;
                break;

            case BonusType.Difference:
                rightDoorRenderer.color = penaltyColor;
                rightDoorText.text = "-" + rightDoorBonusAmount;
                break;

            case BonusType.Product:
                rightDoorRenderer.color = bonusColor;
                rightDoorText.text = "*" + rightDoorBonusAmount;
                break;

            case BonusType.Division:
                rightDoorRenderer.color = penaltyColor;
                rightDoorText.text = "/" + rightDoorBonusAmount;
                break;
        }

        //Left Door Configuration
        switch (leftDoorBonusType)
        {
            case BonusType.Addition:
                leftDoorRenderer.color = bonusColor;
                leftDoorText.text = "+" + leftDoorBonusAmount;
                break;

            case BonusType.Difference:
                leftDoorRenderer.color = penaltyColor;
                leftDoorText.text = "-" + leftDoorBonusAmount;
                break;

            case BonusType.Product:
                leftDoorRenderer.color = bonusColor;
                leftDoorText.text = "*" + leftDoorBonusAmount;
                break;

            case BonusType.Division:
                leftDoorRenderer.color = penaltyColor;
                leftDoorText.text = "/" + leftDoorBonusAmount;
                break;
        }
    }

    public int GetBonusAmount(float xPosition)
    {
        if (xPosition > 0)
            return rightDoorBonusAmount;
        else
        {
            return leftDoorBonusAmount;
        }
    }

    public BonusType GetBonusType(float xPosition)
    {
        if (xPosition > 0)
            return rightDoorBonusType;
        else
            return leftDoorBonusType;
    }

    public void DisableDoorCollider()
    {
        collider.enabled = false;
    }
}
