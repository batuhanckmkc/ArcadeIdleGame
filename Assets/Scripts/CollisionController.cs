using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;

public class CollisionController : InventoryBase, ICallNpc<GameObject>
{
    [SerializeField] List<GameObject> AiPrefabs;
    [SerializeField] private ColliderBox colliderBox;

    [SerializeField] private GameObject _aiWorker;
    [SerializeField] private GameObject _aiManager;

    public GameObject AiWorker { get { return _aiWorker; } set { _aiWorker = value; } }
    public GameObject AiManager { get { return _aiManager; } set { _aiManager = value; } }

    public const string COLLECTABLE_TAG = "Collectable";
    public const string BRINGBOX_TAG = "BringBox";
    public const string NPC_TAG = "Npc";
    public const string AI_WORKER_TAG = "AiWorker";



    private Coroutine _delayCoroutine;
    private WaitForSeconds _delayTime = new WaitForSeconds(0.1f);

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(COLLECTABLE_TAG))
        {
            other.gameObject.GetComponent<BoxCollider>().enabled = false;
            CollectObject(other.gameObject);
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag(BRINGBOX_TAG))
        {
            if(_delayCoroutine == null)
            {
                _delayCoroutine = StartCoroutine(DelayCoroutine(other.gameObject));
            }
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag(BRINGBOX_TAG))
        {
            if (_delayCoroutine != null)
            {
                StopCoroutine(_delayCoroutine);
                _delayCoroutine = null;
            }
        }
    }

    IEnumerator DelayCoroutine(GameObject other)
    {
        while (true)
        {
            yield return _delayTime;
            BringObject(other);
        }
        
    }

    public void CallWorker()
    {
        AiPrefabs.Add(Instantiate(AiWorker, transform.position, Quaternion.identity));
        MoneyValue -= 25;
    }
    public void CallManager()
    {
        AiPrefabs.Add(Instantiate(AiManager, transform.position, Quaternion.identity));
        MoneyValue -= 50;
    }
}
