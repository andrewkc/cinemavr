using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Fusion;
public class SessionListEntry : MonoBehaviour
{
    NetworkRunner runnerinstance;
    public TextMeshProUGUI roomname, playeraccount;
    public Button button;

    private void Awake()
    {
        runnerinstance = gameObject.GetComponent<NetworkRunner>();
        if (runnerinstance == null)
        {
            runnerinstance = gameObject.AddComponent<NetworkRunner>();
        }
    }
    public void JoinRoom()
    {
        runnerinstance.StartGame(new StartGameArgs()
        {
            SessionName = roomname.text,
        }); ;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
