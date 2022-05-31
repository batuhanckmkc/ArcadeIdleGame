using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using TMPro;
public abstract class InventoryBase : MonoBehaviour
{
    #region SameFields

    [SerializeField] public List<GameObject> _inventoryList;

    [SerializeField] public GameObject Bag;
    [SerializeField] public AudioSource AudioSource;
    [SerializeField] public AudioClip BringSound;


    [SerializeField] public int MoneyValue;
    [SerializeField] public TextMeshProUGUI MoneyValueText;

    private Vector3 _randomBagPos;
    private Vector3 _bringPosY;

    #endregion

    #region Functions
    public virtual void CollectObject(GameObject collectableObject)
    {

        Transform collectableT = collectableObject.transform;
        AudioSource.PlayOneShot(BringSound);

        _inventoryList.Add(collectableObject);
        _randomBagPos.y += collectableT.localScale.y;

        collectableT.SetParent(Bag.transform);
        collectableT.DOLocalJump(_randomBagPos, 0.75f, 0, 1f);
        collectableT.localRotation = Quaternion.identity;
        collectableT.DOPunchScale(_randomBagPos, 0.1f, 3, 0.1f);
    }

    public virtual void BringObject(GameObject bringBox)
    {
        if (_inventoryList.Count > 0)
        {

            GameObject inventoryListElement = _inventoryList[_inventoryList.Count - 1];
            Transform inventoryListT = inventoryListElement.transform;
            Transform bringBoxT = bringBox.transform;

            MoneyValue += 25;
            AudioSource.PlayOneShot(BringSound);

            _randomBagPos.y -= inventoryListT.localScale.y;
            _bringPosY.y += inventoryListT.localScale.y;


            inventoryListT.rotation = bringBoxT.rotation;
            inventoryListT.DOJump(new Vector3(bringBoxT.position.x, _bringPosY.y - 0.5f, bringBoxT.position.z), 1f, 2, 1f);
            inventoryListT.DOPunchScale(_randomBagPos, 0.1f, 3, 0.1f);
            inventoryListT.parent = bringBoxT;


            _inventoryList.Remove(inventoryListElement);
        }
    }

    #endregion
}
