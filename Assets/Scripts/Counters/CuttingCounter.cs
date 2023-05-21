using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CuttingCounter : BaseCounter
{
    [SerializeField]
    private KitchenObjectSO cutKitchenObjectSO;


    public override void Interact(Player player)
    {
        if (HasKitchenObject())
        {
            // There is already a kitchen object here
            if (player.HasKitchenObject() == false)
            {
                // Player has empty hands
                GetKitchenObject().SetKitchenObjectParent(player);
            }
        }
        else
        {
            // No kitchen object on counter
            if (player.HasKitchenObject())
            {
                // Player is carrying kitchen object
                player.GetKitchenObject().SetKitchenObjectParent(this);
            }
        }
    }


    public override void InteractAlternate(Player player)
    {
        if (HasKitchenObject())
        {
            GetKitchenObject().DestroySelf();

            KitchenObject.SpawnKitchenObject(cutKitchenObjectSO, this);
        }
    }
}
