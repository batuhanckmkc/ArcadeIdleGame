using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class CollectBox : InventoryBase
{
    #region Fields


    #endregion

    #region Collect & Bring Functions


    public override void CollectObject(GameObject collectableObject)
    {
        collectableObject.GetComponent<MeshRenderer>().material.color = Color.red;
    }

    public override void BringObject(GameObject bringBox)
    {
        bringBox.GetComponent<MeshRenderer>().material.color = Color.yellow;
    }


    
    #endregion

}
