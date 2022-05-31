using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AiWorker : MonoBehaviour
{
    public const string PLAYER_TAG = "Player";

    [SerializeField] private Animator _aiAnim;
    
    private GameObject _player;
    private float _aiSpeed = 5f;

    private void Start()
    {
        _player = GameObject.FindGameObjectWithTag(PLAYER_TAG);
    }

    private void Update()
    {
        transform.LookAt(_player.transform);
        if (Vector3.Distance(transform.position, _player.transform.position) > 2f)
        {
            transform.position = Vector3.MoveTowards(transform.position, _player.transform.position, _aiSpeed * Time.deltaTime);
            _aiSpeed = 5f;
        }
        else if(Vector3.Distance(_player.transform.position, transform.position) < 5f)
        {
            _aiSpeed = 0f;
        }

        _aiAnim.SetFloat("Speed", _aiSpeed);
    }
}
