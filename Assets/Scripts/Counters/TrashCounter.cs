using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class TrashCounter : BaseCounter
{
    public static event EventHandler OnAnyItemTrashed;


    public override void Interact(Player player)
    {
        if (player.HasKitchenObject())
        {
            player.GetKitchenObject().DestroySelf();
            OnAnyItemTrashed?.Invoke(this, EventArgs.Empty);
        }
    }
}