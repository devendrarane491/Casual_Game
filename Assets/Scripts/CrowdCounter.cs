using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CrowdCounter : MonoBehaviour
{
    // Start is called before the first frame update
    [Header("Elements")]
    [SerializeField] private TextMeshPro crowdCounterText;
    [SerializeField] private Transform runnersParent;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        crowdCounterText.text = runnersParent.childCount.ToString(); 
    }
}
