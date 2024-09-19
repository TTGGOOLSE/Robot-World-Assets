using UnityEngine;
using PlayFab;
using PlayFab.ClientModels;
using System.Collections.Generic;

public class TrustedUser : MonoBehaviour
{
    public string playFabTitleId = "YOUR_PLAYFAB_TITLE_ID"; // Replace with your PlayFab Title ID
    private string userId;
    private bool isAuthenticated = false;
    private bool isTrustedUser = false;

    void Start()
    {
        PlayFabSettings.TitleId = playFabTitleId;
        AuthenticateUser();
    }

    void AuthenticateUser()
    {
        var request = new LoginWithCustomIDRequest
        {
            CustomId = SystemInfo.deviceUniqueIdentifier,
            CreateAccount = true
        };

        PlayFabClientAPI.LoginWithCustomID(request, OnLoginSuccess, OnLoginFailure);
    }

    void OnLoginSuccess(LoginResult result)
    {
        isAuthenticated = true;
        userId = result.PlayFabId;
        CheckIfTrustedUser();
    }

    void OnLoginFailure(PlayFabError error)
    {
        Debug.LogError("Login failed: " + error.GenerateErrorReport());
    }

    void CheckIfTrustedUser()
    {
        if (isAuthenticated)
        {
            PlayFabClientAPI.GetUserData(new GetUserDataRequest()
            {
                PlayFabId = userId,
                Keys = null
            }, OnGetUserDataSuccess, OnGetUserDataFailure);
        }
    }

    void OnGetUserDataSuccess(GetUserDataResult result)
    {
        if (result.Data != null && result.Data.ContainsKey("TrustedUser"))
        {
            isTrustedUser = result.Data["TrustedUser"].Value == "true";
            Debug.Log("User is trusted: " + isTrustedUser);
        }
        else
        {
            Debug.Log("User is not trusted.");
        }
    }

    void OnGetUserDataFailure(PlayFabError error)
    {
        Debug.LogError("Failed to get user data: " + error.GenerateErrorReport());
    }

    public void AttemptVent()
    {
        if (isTrustedUser)
        {
            Vent();
        }
        else
        {
            Debug.Log("User is not trusted and cannot vent.");
        }
    }

    void Vent()
    {
        Debug.Log("Vent activated for trusted user.");
        // Implement your venting logic here
    }
}
