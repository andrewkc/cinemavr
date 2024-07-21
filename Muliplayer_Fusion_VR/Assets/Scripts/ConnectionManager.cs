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
        [SerializeField] public TMP_InputField UserName;
    //public static ConnectionManager connectionManag;


    public void CreateRoom()
    {
        Debug.Log(inputField.text); //
        //Data.roomName = inputField.text;
        SceneManager.LoadSceneAsync("TestingOnline");
        ValorForm.text = inputField.text;
        ValorForm.username = UserName.text;
        // NetworkManager.Instance.CreateSession(inputField.text);
        Debug.Log("ww1"); //
    }

   
    //
    
    //
}
