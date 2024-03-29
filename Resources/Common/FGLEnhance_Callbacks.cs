using System;
using UnityEngine;
using System.Collections.Generic;

public class FGLEnhance_Callbacks : MonoBehaviour
{

    public static string CallbackObjectName;
    public static Action OnInterstitialCallback = null;
	public static Action<int> OnCurrencyReceivedCallback = null;
    public static Action<Enhance.RewardType, int> OnRewardGrantedCallback = null;
    public static Action OnRewardDeclinedCallback = null;
    public static Action OnRewardUnavailableCallback = null;
    public static Action OnLocalNotificationPermissionGrantedCallback = null;
    public static Action OnLocalNotificationPermissionRefused = null;
    public static Action OnPurchaseSuccessCallback = null;
    public static Action OnPurchaseFailedCallback = null;
    public static Action OnPurchasePendingCallback = null;
    public static Action OnConsumeSuccessCallback = null;
    public static Action OnConsumeFailedCallback = null;
    public static Action OnRestoreSuccessCallback = null;
    public static Action OnRestoreFailedCallback = null;
    public static Action<Dictionary<string, string>> OnAppConfigReceivedCallback = null;
    public static Action OnRestorePurchasesSuccessCallback = null;
    public static Action OnRestorePurchasesFailedCallback = null;
    public static Action OnOptInRequiredCallback = null;
    public static Action OnOptInNotRequiredCallback = null;
    public static Action OnDialogCompleteCallback = null;
    public static Action OnAttApprovedCallback = null;
    public static Action OnAttRejectedCallback = null;

    public static Action<string, string, string> OnReadyCallback = null;
    public static Action<string, string, string> OnCompleteCallback = null;
    public static Action<string, string, string> OnClickedCallback = null;
    public static Action<string, string, string> OnShowingCallback = null;
    public static Action<string, string, string> OnUnavailableCallback = null;
    public static Action<string, string, string> OnFailedToShowCallback = null;
    public static Action<string, string, string> OnLoadingCallback = null;

    void Awake()
    {
        DontDestroyOnLoad(this);
        CallbackObjectName = gameObject.name;
    }

    public void EnhanceOnInterstitialCompleted(string empty)
    {
        Debug.Log("[Enhance] EnhanceOnInterstitialCompleted");
        if (OnInterstitialCallback != null)
            OnInterstitialCallback();
    }

    public void EnhanceOnCurrencyReceived(string rewardAmount)
    {
        Debug.Log("[Enhance] OnCurrencyReceivedCallback");
        if (OnCurrencyReceivedCallback != null)
            OnCurrencyReceivedCallback(int.Parse(rewardAmount));
    }

    public void EnhanceOnCoinsRewardGranted(string rewardAmount)
    {
        Debug.Log(string.Format("[Enhance] EnhanceOnCoinsRewardGranted({0})", rewardAmount));
        if (OnRewardGrantedCallback != null)
            OnRewardGrantedCallback(Enhance.RewardType.COINS, int.Parse(rewardAmount));
    }

    public void EnhanceOnItemRewardGranted(string empty)
    {
        Debug.Log("[Enhance] EnhanceOnItemRewardGranted");
        if (OnRewardGrantedCallback != null)
            OnRewardGrantedCallback(Enhance.RewardType.ITEM, 0);
    }

    public void EnhanceOnRewardDeclined(string empty)
    {
        Debug.Log("[Enhance] EnhanceOnRewardDeclined");
        if (OnRewardDeclinedCallback != null)
            OnRewardDeclinedCallback();
    }

    public void EnhanceOnRewardUnavailable(string empty)
    {
        Debug.Log("[Enhance] EnhanceOnRewardUnavailable");
        if (OnRewardUnavailableCallback != null)
            OnRewardUnavailableCallback();
    }

    public void EnhanceOnLocalNotificationPermissionGranted(string empty)
    {
        Debug.Log("[Enhance] EnhanceOnLocalNotificationPermissionGranted");
        if (OnLocalNotificationPermissionGrantedCallback != null)
            OnLocalNotificationPermissionGrantedCallback();
    }

    public void EnhanceOnLocalNotificationPermissionRefused(string empty)
    {
        Debug.Log("[Enhance] EnhanceOnLocalNotificationPermissionRefused");
        if (OnLocalNotificationPermissionRefused != null)
            OnLocalNotificationPermissionRefused();
    }


    public void EnhanceOnPurchaseSuccess(string empty)
    {
        Debug.Log("[Enhance] EnhanceOnPurchaseSuccess");
        if (OnPurchaseSuccessCallback != null)
            OnPurchaseSuccessCallback();
    }

    public void EnhanceOnPurchaseFailed(string empty)
    {
        Debug.Log("[Enhance] EnhanceOnPurchaseFailed");
        if (OnPurchaseFailedCallback != null)
            OnPurchaseFailedCallback();
    }

    public void EnhanceOnPurchasePending(string empty)
    {
        Debug.Log("[Enhance] EnhanceOnPurchasePending");
        if (OnPurchasePendingCallback != null)
            OnPurchasePendingCallback();
    }

    public void EnhanceOnConsumeSuccess(string empty)
    {
        Debug.Log("[Enhance] EnhanceOnConsumeSuccess");
        if (OnConsumeSuccessCallback != null)
            OnConsumeSuccessCallback();
    }

    public void EnhanceOnConsumeFailed(string empty)
    {
        Debug.Log("[Enhance] EnhanceOnConsumeFailed");
        if (OnConsumeFailedCallback != null)
            OnConsumeFailedCallback();
    }

    public void EnhanceOnRestoreSuccess(string empty)
    {
        Debug.Log("[Enhance] EnhanceOnRestoreSuccess");
        if (OnRestoreSuccessCallback != null)
            OnRestoreSuccessCallback();
    }

    public void EnhanceOnRestoreFailed(string empty)
    {
        Debug.Log("[Enhance] EnhanceOnRestoreFailed");
        if (OnRestoreFailedCallback != null)
            OnRestoreFailedCallback();
    }

    public void EnhanceOnRestorePurchasesSuccess(string empty)
    {
        Debug.Log("[Enhance] EnhanceOnRestorePurchasesSuccess");
        if(OnRestorePurchasesSuccessCallback != null) OnRestorePurchasesSuccessCallback();
    }

    public void EnhanceOnRestorePurchasesFailed(string empty)
    {
        Debug.Log("[Enhance] EnhanceOnRestorePurchasesFailed");
        if(OnRestorePurchasesFailedCallback != null) OnRestorePurchasesFailedCallback();
    }

    public void EnhanceOnAppConfigReceived(string configString)
    {
        Debug.Log("[Enhance] EnhanceOnAppConfigReceived");
        string[] rows = configString.Split(new string[] { "{##}" }, StringSplitOptions.None);
        Dictionary<string, string> config = new Dictionary<string, string>();
        int i;

        for (i = 0; i < rows.Length; i++)
        {
            string[] entry = rows[i].Split(new string[] { "{;;}" }, StringSplitOptions.None);
            if (entry.Length >= 2)
            {
                config.Add(entry[0], entry[1]);
            }
        }

        if (OnAppConfigReceivedCallback != null)
            OnAppConfigReceivedCallback(config);
    }

    public void EnhanceOnUserOptInRequired(string empty)
    {
        Debug.Log("[Enhance] EnhanceOnUserOptInRequired");
        if(OnOptInRequiredCallback != null) OnOptInRequiredCallback();
    }

    public void EnhanceOnUserOptInNotRequired(string empty)
    {
        Debug.Log("[Enhance] EnhanceOnUserOptInNotRequired");
        if(OnOptInNotRequiredCallback != null) OnOptInNotRequiredCallback();
    }

    public void EnhanceOnDialogComplete(string empty)
    {
        Debug.Log("[Enhance] EnhanceOnDialogComplete");
        if(OnDialogCompleteCallback != null) OnDialogCompleteCallback();
    }
  
      public void EnhanceOnAppTrackingApproved(string empty)
    {
        Debug.Log("[Enhance] EnhanceOnAppTrackingApproved");
        if(OnAttApprovedCallback != null) OnAttApprovedCallback();
    }

    public void EnhanceOnAppTrackingRejected(string empty)
    {
        Debug.Log("[Enhance] EnhanceOnAppTrackingRejected");
        if(OnAttRejectedCallback != null) OnAttRejectedCallback();
    }

   public void EnhanceOnAdReady(string paramsString)
   {
       Debug.Log("[Enhance] EnhanceOnAdReady");
       string[] parameters = paramsString.Split(new string[] { "{;;}" }, StringSplitOptions.None);

       if (OnReadyCallback != null)
           OnReadyCallback(parameters[0], parameters[1], parameters[2]);
   }

   public void EnhanceOnAdClicked(string paramsString)
   {
       Debug.Log("[Enhance] EnhanceOnAdClicked");
       string[] parameters = paramsString.Split(new string[] { "{;;}" }, StringSplitOptions.None);

       if (OnClickedCallback!= null)
           OnClickedCallback(parameters[0], parameters[1], parameters[2]);
   }

   public void EnhanceOnAdComplete(string paramsString)
   {
       Debug.Log("[Enhance] EnhanceOnAdComplete");
       string[] parameters = paramsString.Split(new string[] { "{;;}" }, StringSplitOptions.None);

       if (OnCompleteCallback != null)
           OnCompleteCallback(parameters[0], parameters[1], parameters[2]);
   }

   public void EnhanceOnAdShowing(string paramsString)
   {
       Debug.Log("[Enhance] EnhanceOnAdShowing");
       string[] parameters = paramsString.Split(new string[] { "{;;}" }, StringSplitOptions.None);

       if (OnShowingCallback != null)
           OnShowingCallback(parameters[0], parameters[1], parameters[2]);
   }

   public void EnhanceOnAdUnavailable(string paramsString)
   {
       Debug.Log("[Enhance] EnhanceOnAdUnavailable");
       string[] parameters = paramsString.Split(new string[] { "{;;}" }, StringSplitOptions.None);

       if (OnUnavailableCallback != null)
           OnUnavailableCallback(parameters[0], parameters[1], parameters[2]);
   }

   public void EnhanceOnFailedToShow(string paramsString)
   {
       Debug.Log("[Enhance] EnhanceOnFailedToShow");
       string[] parameters = paramsString.Split(new string[] { "{;;}" }, StringSplitOptions.None);

       if (OnFailedToShowCallback != null)
           OnFailedToShowCallback(parameters[0], parameters[1], parameters[2]);
   }

   public void EnhanceOnLoading(string paramsString)
   {
       Debug.Log("[Enhance] EnhanceOnLoading");
       string[] parameters = paramsString.Split(new string[] { "{;;}" }, StringSplitOptions.None);

       if (OnLoadingCallback != null)
           OnLoadingCallback(parameters[0], parameters[1], parameters[2]);
   }
}
