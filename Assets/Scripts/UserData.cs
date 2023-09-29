using System.Collections;
using System.Collections.Generic;
using Firebase.Firestore;
using UnityEngine;
[FirestoreData] public struct UserData 
{
    [FirestoreProperty]
    
    public string UserID { get; set; }
    
    [FirestoreProperty]
    public int ClickCount { get; set; }
}
