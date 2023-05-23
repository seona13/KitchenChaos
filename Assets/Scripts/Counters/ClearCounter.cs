using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClearCounter : BaseCounter
{
    [SerializeField]
    protected KitchenObjectSO kitchenObjectSO;


    public override void Interact(Player player)
    {
        if (HasKitchenObject())
        {
            // There is already a kitchen object here
            if (player.HasKitchenObject())
            {
                // Player is carrying something
                if (player.GetKitchenObject().TryGetPlate(out PlateKitchenObject plateKitchenObject))
                {
                    // Player is holding a plate
                    if (plateKitchenObject.TryAddIngredient(GetKitchenObject().GetKitchenObjectSO()))
                    {
                        GetKitchenObject().DestroySelf();
                    }
                }
                else
                {
                    // Player is holding something other than a plate
                    if (GetKitchenObject().TryGetPlate(out plateKitchenObject))
                    {
                        // Counter is holding a plate
                        if (plateKitchenObject.TryAddIngredient(player.GetKitchenObject().GetKitchenObjectSO()))
                        {
                            player.GetKitchenObject().DestroySelf();
                        }
                    }
                }
            }
            else
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
}
