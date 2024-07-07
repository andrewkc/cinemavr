using Fusion;
using Fusion.Sockets;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NetworkManager : MonoBehaviour, INetworkRunnerCallbacks
{

    public GameObject playerPrefab;
    public static NetworkRunner Runner;
    private string lobbyname = ValorForm.text;

    private void Awake()
    {
        Runner = gameObject.GetComponent<NetworkRunner>();
        if (Runner == null)
        {
            Runner = gameObject.AddComponent<NetworkRunner>();
        }
        
    }

    private void Start()
    {
        // fixing the server to a perticular region
        //Runner.Spawn()
        //Runner.JoinSessionLobby(SessionLobby.Shared, lobbyname);
        Debug.Log(lobbyname);
        Debug.Log("AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAaa");
        Runner.StartGame(new StartGameArgs(){
            SessionName = lobbyname,
            GameMode=GameMode.Shared,
                 
        });
        //Debug.Log(ValorForm.text);
    }

    

    #region INetworkRunnerCallbacks
    public void OnPlayerJoined(NetworkRunner runner, PlayerRef player)
    {
        if(player== runner.LocalPlayer)
        {
            NetworkObject playerObj = runner.Spawn(playerPrefab, Vector3.zero);
            runner.SetPlayerObject(player, playerObj);
        }
        Debug.Log("<<<<<<<< A new player joined to the session >>>>>>>");
        Debug.Log("<<<<<<< IsMasterClient >>>>>>>>" + player.IsMasterClient);
        Debug.Log("<<<<<<< PlayerID >>>>>>>>" + player.PlayerId);
        Debug.Log("<<<<<<< IsRealPlayer >>>>>>>>" + player.IsRealPlayer);
    }

    public void OnPlayerLeft(NetworkRunner runner, PlayerRef player)
    {
        Debug.Log("<<<<<<<< A player left the session >>>>>>>");
        Debug.Log("<<<<<<< IsMasterClient >>>>>>>>" + player.IsMasterClient);
        Debug.Log("<<<<<<< PlayerID >>>>>>>>" + player.PlayerId);
        Debug.Log("<<<<<<< IsRealPlayer >>>>>>>>" + player.IsRealPlayer);
    }

    public void OnShutdown(NetworkRunner runner, ShutdownReason shutdownReason)
    {
        Debug.Log("<<<<<<< Runner Shutdown >>>>>>>>");

    }
    #endregion

    #region INetworkRunnerCallbacks (Unused)
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

    public void OnSessionListUpdated(NetworkRunner runner, List<SessionInfo> sessionList)
    {
        Debug.Log("XD");
    }


    public void OnUserSimulationMessage(NetworkRunner runner, SimulationMessagePtr message)
    {
    }
    #endregion

}
