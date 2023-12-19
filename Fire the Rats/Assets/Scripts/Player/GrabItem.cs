using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class GrabItem : MonoBehaviour
{
    public KeyCode Grab;
    public KeyCode Throw;
    public Transform grabPos;
    public LayerMask layerMask;
    public Vector3 Direction { get; set; }
    public GameObject itemHold;
    private PlayerControl playerControl;
    public bool isHolding = false;

    private void Start()
    {playerControl = gameObject.GetComponent<PlayerControl>();}

    void Update()
    {
        if (UnityEngine.Input.GetKeyDown(Grab))
        {
            Collider2D grabItem = Physics2D.OverlapCircle(transform.position + Direction, 0.3f, layerMask);
            if (grabItem && grabItem.CompareTag("Item") && isHolding == false)
            {
                itemHold = grabItem.gameObject;
                isHolding = true;
                Debug.Log($"Player {playerControl.PlayerIndex} is holding {itemHold}");
                itemHold.transform.position = grabPos.position;
                itemHold.transform.SetParent(grabPos);
                itemHold.GetComponent<SpriteRenderer>().sortingOrder = 1;
                if (itemHold.GetComponent<Rigidbody2D>())
                {
                    itemHold.GetComponent<Rigidbody2D>().simulated = false;
                    itemHold.GetComponent<BoxCollider2D>().isTrigger = true;
                }
            }
            else if (itemHold && isHolding == true)
            {
                isHolding = false;
                itemHold.transform.position = transform.position + Direction/1.4f;
                itemHold.transform.SetParent(null);
                itemHold.GetComponent<SpriteRenderer>().sortingOrder = 0;
                if (itemHold.GetComponent<Rigidbody2D>())
                {
                    itemHold.GetComponent<Rigidbody2D>().simulated = true;
                    itemHold.GetComponent<BoxCollider2D>().isTrigger = false;
                }
                itemHold = null;
            }
        }
        if (itemHold)
        {
            if (UnityEngine.Input.GetKeyDown(Throw) && isHolding == true)
            {
                isHolding = false;
                Debug.Log($"Player {playerControl.PlayerIndex} want to THROW {itemHold}");
                playerControl.indicator.GetComponent<SpriteRenderer>().sprite = itemHold.GetComponent<SpriteRenderer>().sprite;
                playerControl.indicator.transform.GetComponent<SpriteRenderer>().enabled = true;
                playerControl.canMove = false;
            }
            if (UnityEngine.Input.GetKeyUp(Throw))
            {
                Debug.Log($"Player {playerControl.PlayerIndex} THREW {itemHold}");
                playerControl.indicator.transform.GetComponent<SpriteRenderer>().enabled = false;
                playerControl.canMove = true;
                StartCoroutine(ThrowItem(itemHold));
                itemHold = null;
            }
        }
        
    }

    IEnumerator ThrowItem(GameObject item)
    {
        Rigidbody2D itemRb = item.GetComponent<Rigidbody2D>();
        if (itemRb)
        {
            itemRb.simulated = true;
            item.GetComponent<BoxCollider2D>().isTrigger = false;
        }
        Vector3 startPoint = item.transform.position;
        Vector3 endPoint = transform.position + Direction * 5;
        item.transform.SetParent(null);
        item.GetComponent<SpriteRenderer>().sortingOrder = 0;
        float duration = 100f;
        for (int i = 0; i < duration; i++)
        {
            item.transform.position = Vector3.Lerp(startPoint, endPoint, i / duration);
            yield return null;
        }
    }
}
