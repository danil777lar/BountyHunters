using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public static class NetTime
{
    public static bool isWorking = false;
    private static long startNetTicks = -1;
    private static long startSystemTicks;


    public static void Start(){
        if (startNetTicks == -1){
            UnityWebRequest request = UnityWebRequest.Get("www.google.com");
            request.SendWebRequest();
            while (!request.isDone && !request.isNetworkError){
                System.Threading.Thread.Sleep(1);
            }
            Debug.Log(""+request.isModifiable);
            if (!request.isNetworkError){
                isWorking = true;
                string dateString = request.GetResponseHeader("Date");
                System.DateTime dateTime;
                System.DateTime.TryParse(dateString, out dateTime);
                startNetTicks = dateTime.ToUniversalTime().Ticks;
                startSystemTicks = System.DateTime.Now.Ticks;
            }
        } 
    }

    public static System.DateTime Get(){
        long currentSystemTicks = System.DateTime.Now.Ticks;
        return new System.DateTime(startNetTicks+(currentSystemTicks-startSystemTicks));
    }
}
