using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class ColliderBox : MonoBehaviour, ICallManagerUi
{
    public const string NPC_TAG = "Npc";

    [SerializeField] GameObject NpcPanel;
    public void ActivateNpcPanel()
    {
        NpcPanel.SetActive(true);
    }

    public void DeactivateNpcPanel()
    {
        NpcPanel.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(NPC_TAG))
        {
           ActivateNpcPanel();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag(NPC_TAG))
        {
            DeactivateNpcPanel();
        }
    }
}