using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIExtensionManager : MonoBehaviour
{
    public static UIExtensionManager Instance { get; set; }
    public GameObject endPanel;
    public Button mintBtn;

    private void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        
    }

    void Update()
    {
        //if (Input.GetKeyDown(KeyCode.Space))
        //{
        //    endPanel.SetActive(true);
        //}
    }
}
