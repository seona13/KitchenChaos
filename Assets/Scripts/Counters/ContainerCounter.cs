using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ContainerCounter : BaseCounter
{
    public event EventHandler OnPlayerGrabbedObject;

    [SerializeField]
    protected KitchenObjectSO kitchenObjectSO;


    public override void Interact(Player player)
    {
        if (player.HasKitchenObject() == false)
        {
            // Player has empty hands; Spawn object and give to the player
            KitchenObject.SpawnKitchenObject(kitchenObjectSO, player);

            OnPlayerGrabbedObject?.Invoke(this, EventArgs.Empty);
        }
    }
}