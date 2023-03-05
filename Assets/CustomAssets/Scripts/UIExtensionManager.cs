using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIExtensionManager : MonoBehaviour
{
    [SerializeField] private GameObject endPanel;
    void Start()
    {
        
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            endPanel.SetActive(true);
        }
    }
}
