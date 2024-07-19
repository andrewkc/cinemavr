using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fusion;
using Fusion.Sockets;
using System;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEditor;

public class NetworkManager_singleplayer : MonoBehaviour, INetworkRunnerCallbacks
{
    public NetworkRunner runnerinstance;

    [SerializeField] public TMP_InputField lobbyname;
    //private string lobbyname = "def";
    public GameObject playerPrefab;
    public Transform sessionListContentParent;
    public GameObject sessionListEntryPrefab;
    public Dictionary<string, GameObject> sessionListUiDictionary = new Dictionary<string, GameObject>();

    public SceneAsset gameplayScene;
    

    private void Awake()
    {
        runnerinstance = gameObject.GetComponent<NetworkRunner>();
        if(runnerinstance == null)
        {
            runnerinstance = gameObject.AddComponent<NetworkRunner>();
        }
    }
    private void Start()
    {
        runnerinstance.JoinSessionLobby(SessionLobby.Shared, "default");
    }

    public void CreateSession()
    {
        runnerinstance.StartGame(new StartGameArgs()
        {
            GameMode = GameMode.Shared,
            SessionName = lobbyname.text,
        }); ;
    }
    public void OnSessionListUpdated(NetworkRunner runner, List<SessionInfo> sessionList)
    {
        Debug.Log("Actualizada la sesion");

        DeleteOldSessionsFromUI(sessionList);
        CompareLists(sessionList);
        
    }
   
    private void DeleteOldSessionsFromUI(List<SessionInfo> sessionList)
    {
        bool isContained = false;
        GameObject uiToDelete = null;
        foreach (KeyValuePair<string,GameObject> kvp in sessionListUiDictionary)
        {
            string sessionkey = kvp.Key;
            foreach (SessionInfo sessionInfo in sessionList)
            {
                if (sessionInfo.Name == sessionkey)
                {
                    isContained = true;
                    break;
                }
            }
               
            if (!isContained)
            {
                uiToDelete = kvp.Value;
                sessionListUiDictionary.Remove(sessionkey);
                Destroy(uiToDelete);
            }
        }
            
            
    }

    private void CompareLists(List<SessionInfo> sessionList)
    {
        foreach (SessionInfo session in sessionList)
        {
            if (sessionListUiDictionary.ContainsKey(session.Name))
            {
                UpdateEntryUIO(session);
            }
                
            else
            {
                CreateEntryUI(session);
            }
                
        }
            

    }

    private void UpdateEntryUIO(SessionInfo session)
    {
        sessionListUiDictionary.TryGetValue(session.Name, out GameObject newEntry);

        SessionListEntry entryScript = newEntry.GetComponent<SessionListEntry>();

       
        entryScript.roomname.text = session.Name;
        entryScript.playeraccount.text = session.PlayerCount.ToString() + "/" + session.MaxPlayers.ToString();
        entryScript.button.interactable = session.IsOpen;

        newEntry.SetActive(session.IsVisible);
    }

    private void CreateEntryUI(SessionInfo session)
    {
        GameObject newEntry = GameObject.Instantiate(sessionListEntryPrefab);
        newEntry.transform.parent = sessionListContentParent;
        SessionListEntry entryScript = newEntry.GetComponent<SessionListEntry>();
        sessionListUiDictionary.Add(session.Name, newEntry);
        entryScript.roomname.text = session.Name;
        entryScript.playeraccount.text = session.PlayerCount.ToString()+"/"+session.MaxPlayers.ToString();
        entryScript.button.interactable = session.IsOpen;

        newEntry.SetActive(session.IsVisible);
    }
    public void OnPlayerJoined(NetworkRunner runner, PlayerRef player)
    {
        if(player== runnerinstance.LocalPlayer)
        {
            SceneManager.LoadScene(gameplayScene.name);
        }
    }


    public void OnConnectedToServer(NetworkRunner runner)
    {
        
    }

    public void OnConnectFailed(NetworkRunner runner, NetAddress remoteAddress, NetConnectFailedReason reason)
    {
    }

    public void OnConnectRequest(NetworkRunner runner, NetworkRunnerCallbackArgs.ConnectRequest request, byte[] token)
    {
    }

    public void OnCustomAuthenticationResponse(NetworkRunner runner, Dictionary<string, object> data)
    {
    }

    public void OnDisconnectedFromServer(NetworkRunner runner, NetDisconnectReason reason)
    {
    }

    public void OnHostMigration(NetworkRunner runner, HostMigrationToken hostMigrationToken)
    {
    }

    public void OnInput(NetworkRunner runner, NetworkInput input)
    {
    }

    public void OnInputMissing(NetworkRunner runner, PlayerRef player, NetworkInput input)
    {
    }

    public void OnObjectEnterAOI(NetworkRunner runner, NetworkObject obj, PlayerRef player)
    {
    }

    public void OnObjectExitAOI(NetworkRunner runner, NetworkObject obj, PlayerRef player)
    {
    }

    
    public void OnPlayerLeft(NetworkRunner runner, PlayerRef player)
    {
    }

    public void OnReliableDataProgress(NetworkRunner runner, PlayerRef player, ReliableKey key, float progress)
    {
    }

    public void OnReliableDataReceived(NetworkRunner runner, PlayerRef player, ReliableKey key, ArraySegment<byte> data)
    {
    }

    public void OnSceneLoadDone(NetworkRunner runner)
    {
    }

    public void OnSceneLoadStart(NetworkRunner runner)
    {
    }

  

    public void OnShutdown(NetworkRunner runner, ShutdownReason shutdownReason)
    {
    }

    public void OnUserSimulationMessage(NetworkRunner runner, SimulationMessagePtr message)
    {
    }

    
}
