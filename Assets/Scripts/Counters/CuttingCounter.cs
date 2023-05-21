using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CuttingCounter : BaseCounter
{
    [SerializeField]
    private CuttingRecipeSO[] cuttingRecipeSOArray;


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
                if (HasRecipeWithInput(player.GetKitchenObject().GetKitchenObjectSO()))
                {
                    // Carried kitchen object can be cut
                    player.GetKitchenObject().SetKitchenObjectParent(this);
                }
            }
        }
    }


    public override void InteractAlternate(Player player)
    {
        if (HasKitchenObject() && HasRecipeWithInput(GetKitchenObject().GetKitchenObjectSO()))
        {
            // There is a kitchen object here AND it can be cut

            // Get the appropriate output based on present object
            KitchenObjectSO outputKitchenObjectSO = GetOutputForInput(GetKitchenObject().GetKitchenObjectSO());

            // Remove the existing object
            GetKitchenObject().DestroySelf();

            // Spawn the new (sliced) object
            KitchenObject.SpawnKitchenObject(outputKitchenObjectSO, this);
        }
    }


    private bool HasRecipeWithInput(KitchenObjectSO inputKitchenObjectSO)
    {
        foreach (CuttingRecipeSO cuttingRecipeSO in cuttingRecipeSOArray)
        {
            if (cuttingRecipeSO.input == inputKitchenObjectSO)
            {
                return true;
            }
        }
        return false;
    }


    private KitchenObjectSO GetOutputForInput(KitchenObjectSO inputKitchenObjectSO)
    {
        foreach (CuttingRecipeSO cuttingRecipeSO in cuttingRecipeSOArray)
        {
            if (cuttingRecipeSO.input == inputKitchenObjectSO)
            {
                return cuttingRecipeSO.output;
            }
        }
        return null;
    }
}
