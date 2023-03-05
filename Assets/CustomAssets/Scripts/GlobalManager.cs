using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GlobalManager : MonoBehaviour
{
    public static GlobalManager Instance { get; set; }

    public Button loadBalanceBtn;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else if (Instance != this)
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.G))
        {
            if (UIExtensionManager.Instance)
            {
                UIExtensionManager.Instance.mintBtn.onClick.AddListener(MintOnClick);
                UIExtensionManager.Instance.endPanel.SetActive(!UIExtensionManager.Instance.endPanel.activeSelf);
            }
        }
    }

    public void MintOnClick()
    {
        Debug.Log("Click On Mint");
    }
}
