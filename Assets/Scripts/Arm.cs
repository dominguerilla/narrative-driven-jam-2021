﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arm : MonoBehaviour
{
    [SerializeField] Transform heldItemPosition;
    [SerializeField] Vector3 offset;
    [SerializeField] Vector3 eulerOffset;

    ItemComponent heldItem;

    private void Awake()
    {
        if (!heldItemPosition)
        {
            heldItemPosition = transform;
        }
    }

    public Transform GetItemPosition()
    {
        return heldItemPosition;
    }

    public void Hold(ItemComponent item)
    {
        heldItem = item;
        item.Equip(this, heldItemPosition, offset, eulerOffset);
    }

    public void UseItem()
    {
        if (heldItem)
        {
            heldItem.Use();
        }
        else
        {
            Debug.LogError("Trying to use Item while Arm is empty!");
        }
    }

    public void Drop(Vector3 location)
    {
        if (heldItem)
        {
            heldItem.transform.position = location;
            heldItem.Dequip();
            heldItem = null;
        }
    }

    public void DropIfTemporary(Vector3 location)
    {
        if (heldItem && heldItem.isTemporary)
        {
            Drop(location);
        }
    }

    public bool IsHoldingItem()
    {
        return heldItem != null;
    }
}
