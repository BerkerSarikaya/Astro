using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ElementScoreControl : MonoBehaviour
{
    public TMP_Text elementNumberCount;
    void Start()
    {
        elementNumberCount = GetComponent<TMP_Text>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
