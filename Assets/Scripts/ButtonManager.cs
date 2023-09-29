using System.Collections;
using System.Collections.Generic;
using Firebase;
using Firebase.Analytics;
using Firebase.Firestore;
using UnityEngine;
using UnityEngine.UI;

public class ButtonManager : MonoBehaviour
{
    
    [SerializeField] private Button buttonToTrack;
    private string userPath;
    private Firebase.FirebaseApp app;
    private int clickCount = 0;
    // Start is called before the first frame update
    void Start()
    {
        string deviceID = SystemInfo.deviceUniqueIdentifier;
        userPath = "users/" + deviceID;

        string path = "users/" + deviceID;
        Firebase.FirebaseApp.CheckAndFixDependenciesAsync().ContinueWith(task => {
            var dependencyStatus = task.Result;
            if (dependencyStatus == Firebase.DependencyStatus.Available) {
                // Create and hold a reference to your FirebaseApp,
                // where app is a Firebase.FirebaseApp property of your application class.
                app = Firebase.FirebaseApp.DefaultInstance;
                FirebaseAnalytics.SetAnalyticsCollectionEnabled(true);
                // Set a flag here to indicate whether Firebase is ready to use by your app.
            } else {
                UnityEngine.Debug.LogError(System.String.Format(
                    "Could not resolve all Firebase dependencies: {0}", dependencyStatus));
                // Firebase Unity SDK is not safe to use here.
            }
        });
    }

    private void TrackButtonClick()
    {
        Debug.Log("Sending button click");
        FirebaseAnalytics.LogEvent("Button_Clicked", "Button_Name", buttonToTrack.name);
    }
    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnURLClick()
    {
        Application.OpenURL("https://google.com");
    }

    public void OnClickMe()
    {
        clickCount += 1;
        UserData userData = new UserData
        {
            UserID = userPath,
            ClickCount = clickCount 
        };
        var firestore = FirebaseFirestore.DefaultInstance;
        firestore.Document(userPath).SetAsync(userData, SetOptions.Overwrite);
    }
}
