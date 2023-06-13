using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class DeliveryResultUI : MonoBehaviour
{
    private const string POPUP = "Popup";

    [SerializeField] private Image backgroundImage;
    [SerializeField] private Image iconImage;
    [SerializeField] private TextMeshProUGUI messageText;
    [Space]
    [SerializeField] private Color successColour;
    [SerializeField] private Sprite successSprite;
    [Space]
    [SerializeField] private Color failedColour;
    [SerializeField] private Sprite failedSprite;

    private Animator animator;


    private void Awake()
    {
        animator = GetComponent<Animator>();
    }


    private void Start()
    {
        DeliveryManager.Instance.OnRecipeSuccess += DeliveryManager_OnRecipeSuccess;
        DeliveryManager.Instance.OnRecipeFailed += DeliveryManager_OnRecipeFailed;

        gameObject.SetActive(false);
    }


    private void DeliveryManager_OnRecipeSuccess(object sender, System.EventArgs e)
    {
        gameObject.SetActive(true);
        backgroundImage.color = successColour;
        iconImage.sprite = successSprite;
        messageText.text = "Delivery\nSuccess";
        animator.SetTrigger(POPUP);
    }


    private void DeliveryManager_OnRecipeFailed(object sender, System.EventArgs e)
    {
        gameObject.SetActive(true);
        backgroundImage.color = failedColour;
        iconImage.sprite = failedSprite;
        messageText.text = "Delivery\nFailed";
        animator.SetTrigger(POPUP);
    }
}