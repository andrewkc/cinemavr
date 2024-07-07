using System.Collections;
using System.Collections.Generic;
using Meta.XR.MRUtilityKit;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI; //

public class ConnectionManager : MonoBehaviour
{
        [SerializeField] public TMP_InputField inputField;
        public static ConnectionManager connectionManag;
   
    
    public void CreateRoom()
    {
        Debug.Log(inputField.text); //
        //Data.roomName = inputField.text;
        SceneManager.LoadScene("MultiPlayer");
        ValorForm.text = inputField.text;
        // NetworkManager.Instance.CreateSession(inputField.text);
        Debug.Log("ww1"); //
    }

    public void JoinRoom()
    {
        Debug.Log("ee0"); //
        SceneManager.LoadScene("MultiPlayer");
        ValorForm.text = inputField.text;
        //NetworkManager.Instance.JoinSession(inputField.text);
        Debug.Log("ee1"); //
    }
    //
    void Update()
    {
        if (Input.GetKey(KeyCode.Z)) {
            CreateRoom();
        }
    }
    //
}
