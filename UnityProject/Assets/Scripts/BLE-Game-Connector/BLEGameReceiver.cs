using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using UnityEngine;
using EEGControl;


public class BLEGameReceiver : MonoBehaviour
{
    private Thread _receiveThread;
    private UdpClient _client;

    public static int Port = 2000;//port must be defined in BLE (for sending)
    public static bool IsConnected, CanConnect;

    private void Start()
    {
        Init();
    }

    private void Update()
    {
        if (CanConnect && !IsConnected)
        {
            Init();
            CanConnect = false;
        }
        else if (CanConnect && IsConnected)
        {
            CloseConnection();
        }
    }

    private void Init()
    {
        _receiveThread = new Thread(ReceiveData) {IsBackground = true};
        _receiveThread.Start();
        IsConnected = true;
    }

    private void ReceiveData()
    {
        _client = new UdpClient(Port);

        while (IsConnected)
        {
            try
            {
                var ip = new IPEndPoint(IPAddress.Loopback, 0);
                var udpdata = _client.Receive(ref ip);
                var data = Encoding.UTF8.GetString(udpdata);

                TranslateData(data);
            }

            catch (Exception err)
            {
                print(err.ToString());
            }
        }
    }

	//Create the variables of the objects that you want to update from the BLE and drag it in the inspector
    //Example: public PlayerController PlayerController;
    private void TranslateData(string data)
    {
        string[] separators = { "[$]", "[$$]", "[$$$]", ",", ";", " " };

        var words = data.Split(separators, StringSplitOptions.RemoveEmptyEntries);

        Debug.Log(data);

        for (var i = 0; i < words.Length; i++)
        {
            //getting the values for the game variables that require to be updated -> this will change from game to game, you need
            //to add them manually here

            //* Update here your variable (see the example): 
            // if (words[i] == "BallSpeed")
            //   PlayerController.speed= float.Parse(words[i + 1]);	

            if (words[i] == "Delta")
                EEGVariableController.Delta = float.Parse(words[i + 1]);
            if (words[i] == "Theta")
                EEGVariableController.Theta = float.Parse(words[i + 1]);
            if (words[i] == "Alpha")
                EEGVariableController.Alpha = float.Parse(words[i + 1]);
            if (words[i] == "Beta")
                EEGVariableController.Beta = float.Parse(words[i + 1]);
            if (words[i] == "Gamma")
                EEGVariableController.Gamma = float.Parse(words[i + 1]);


        }
    }

    private void CloseConnection()
    {
        if (IsConnected)
        {
            _receiveThread.Abort();
            _client.Close();
            IsConnected = false;
            CanConnect = false;
        }
    }

    private void OnDisable()
    {
        CloseConnection();
    }

    private void OnApplicationQuit()
    {
        CloseConnection();
    }
}

