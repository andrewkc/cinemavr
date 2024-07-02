using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ConnectionManager : MonoBehaviour
{
    [SerializeField] private TMP_InputField inputField;

    public void CreateRoom()
    {
        Debug.Log("ww0");
        NetworkManager.Instance.CreateSession(inputField.text);
        Debug.Log("ww1");
    }

    public void JoinRoom()
    {
        NetworkManager.Instance.JoinSession(inputField.text);

    }
}
