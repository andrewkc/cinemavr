using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using PlayFab;
using PlayFab.ClientModels;

public class AuthHandler : MonoBehaviour
{
    const string TITLE_ID = "94004";
    [SerializeField] GameObject registerTab, loginTab;

    #region Register
    [Header("Register UI:")]
    [SerializeField] TMP_InputField registerEmail;
    [SerializeField] TMP_InputField registerUsername;
    [SerializeField] TMP_InputField registerPassword;
    [SerializeField] GameObject checkRegister;

    public void OnRegisterPressed() 
    {
        Debug.Log("Step 1");
        Register(registerEmail.text, registerUsername.text, registerPassword.text);
    }

    private void Register(string email, string username, string password)
    {
        password = Encrypt(password);
        var registerRequest = new RegisterPlayFabUserRequest {
            Email = email,
            Username = username,
            DisplayName = username,
            Password = password
        };
        PlayFabSettings.staticSettings.TitleId = TITLE_ID;
        PlayFabClientAPI.RegisterPlayFabUser(registerRequest, OnRegisterRequestSuccess, PlayFabFailure);
        Debug.Log(email + " " + username + " " + password);
    }
    private void OnRegisterRequestSuccess(RegisterPlayFabUserResult result) {
        Debug.Log("User Registered");
        checkLogin.SetActive(false);
        checkRegister.SetActive(true);  
    }

    public void RegisterTab() {
        registerTab.SetActive(true);
        loginTab.SetActive(false);
    }
    #endregion

    #region Login
    [Header("Login UI:")]
    [SerializeField] TMP_InputField loginUsername;
    [SerializeField] TMP_InputField loginPassword;
    [SerializeField] GameObject checkLogin;

    public void OnLoginPressed()
    {
	   Debug.Log("Step 2");
        Login(loginUsername.text, loginPassword.text);
    }

    private void Login(string username, string password)
    {
        password = Encrypt(password);
        var loginRequest = new LoginWithPlayFabRequest {
            TitleId = TITLE_ID,
            Password = password,
            Username = username
        };
        PlayFabSettings.staticSettings.TitleId = TITLE_ID;
        PlayFabClientAPI.LoginWithPlayFab(loginRequest, OnLoginRequestSuccess, PlayFabFailure);
        Debug.Log(username + " " + password);
    }
    private void OnLoginRequestSuccess(LoginResult result) {
        Debug.Log("User Logged");
        checkLogin.SetActive(true);
        checkRegister.SetActive(false);   
    }
    
    public void LoginTab() {
        registerTab.SetActive(false);
        loginTab.SetActive(true);
    }
    #endregion

    void Start() 
    {
        checkLogin.SetActive(false);
        checkRegister.SetActive(false);
        Debug.Log("Hello World");
    }
    private string Encrypt(string pw) 
    {
        System.Security.Cryptography.MD5CryptoServiceProvider x = new System.Security.Cryptography.MD5CryptoServiceProvider();
        byte[] epw = System.Text.Encoding.UTF8.GetBytes(pw);
        epw = x.ComputeHash(epw);
        System.Text.StringBuilder s = new System.Text.StringBuilder();
        foreach (byte b in epw) {
            s.Append(b.ToString("x2").ToLower());
        }
        return s.ToString();
    }
    private void PlayFabFailure(PlayFabError error)
    {
        Debug.Log(error.Error + " : " + error.GenerateErrorReport());
    }
}
