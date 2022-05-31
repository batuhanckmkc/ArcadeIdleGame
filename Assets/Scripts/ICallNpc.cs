using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ICallNpc<T>
{
    GameObject AiWorker { get; set; }
    GameObject AiManager { get; set; }

    public void CallWorker();


    public void CallManager();

}
