﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityOSC;

public class OSCReceiver : MonoBehaviour {

    DataDistributer dataDistributer;
    private Queue queue;
    DummySender dummySender;

    static List<string> stat = new List<string>();
    System.IO.StreamWriter logWriter;

    void Start()
    {
        dummySender = GameObject.Find("/DummySender").GetComponent<DummySender>();

        dataDistributer = gameObject.GetComponent<DataDistributer>();

        queue = new Queue();
        queue = Queue.Synchronized(queue);

        OSCHandler.Instance.Init();
        // パケット受信時のイベントハンドラを登録
        OSCHandler.Instance.PacketReceivedEvent += OnPacketReceived;

        try
        {
            string projectFolder = System.IO.Directory.GetCurrentDirectory();
            logWriter = new System.IO.StreamWriter(
                projectFolder + "/logdata/gps_data_" + System.DateTime.Now.ToString("yyyyMMdd") + ".txt", true);
            stat.Add("OK");
        }
        catch (System.Exception e)
        {
            stat.Add("NG");
            stat.Add(e.Message);
        }
    }

    private void OnDestroy()
    {
        logWriter.Close();
    }

    public static List<string> SelfCheck()
    {
        return stat;
    }

    void OnPacketReceived(OSCServer server, OSCPacket packet)
    {
        // 来たパケットをキューに積んでおく
        queue.Enqueue(packet);
    }

    void Update()
    {
        while (0 < queue.Count)
        {
            OSCPacket packet = queue.Dequeue() as OSCPacket;
            if (packet.IsBundle())
            {
                // OSCBundleの場合
                OSCBundle bundle = packet as OSCBundle;
                foreach (OSCMessage msg in bundle.Data)
                {
                    // メッセージの中身にあわせた処理
                }
            }
            else
            {
                // OSCMessageの場合はそのまま変換
                OSCMessage msg = packet as OSCMessage;
                // メッセージの中身にあわせた処理
                //InfoWindow.Log("osc: " + msg.Address);

                if (msg.Address == "/data")
                {
                    if (msg.Data.Count >= 1)
                    {
                        dataDistributer.SetData(msg.Data[0].ToString());
                        logWriter.WriteLine(msg.Data[0].ToString());
                    }
                }
                else if (msg.Address == "/reset")
                {
                    dataDistributer.Reset();
                }
                else if (msg.Address == "/sim")
                {
                    if (msg.Data.Count >= 1)
                    {
                        dataDistributer.SetSimulationData(msg.Data[0].ToString());
                    }
                }
                else if (msg.Address == "/simclear")
                {
                    dataDistributer.ClearSimulationData();
                }

                // 展示用
                else if (msg.Address == "/start")
                {
                    Debug.Log("receive /start");
                    dummySender.RestartDemoMode();
                }

            }
        }
    }

}
