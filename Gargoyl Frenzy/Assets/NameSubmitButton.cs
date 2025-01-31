using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NameSubmitButton : MonoBehaviour
{
    [SerializeField] InputField inputField;
    [SerializeField]GameObject NamePanel;
    private void Update()
    {
            if (PlayFabManager.Instance.Name != null) NamePanel.SetActive(false);      
    }
    public void EnterClick()
    {
        PlayFabManager.Instance.SetName(inputField.text);
    }

}
