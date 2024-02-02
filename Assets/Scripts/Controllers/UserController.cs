using UnityEngine;
using System;

public class UserController : MonoBehaviour
{
    public static Action OnDataSaved;

    private User _user = new User();

    private void Awake()
    {
        _user = LoadUserData();
        string dataJson = JsonUtility.ToJson(_user);
        Debug.Log("Loaded user: " + dataJson);
    }

    public int GetSampleData()
    {
        return _user.SampleData;
    }

    public void SetSampleData(int sampleData)
    {
        _user.SampleData = sampleData;
        SaveUserData();
    }


    public void SaveUserData()
    {
        string dataJson = JsonUtility.ToJson(_user);
        PlayerPrefs.SetString("user_data", dataJson);
        Debug.Log("User data saved.");
        OnDataSaved?.Invoke();
    }

    public User LoadUserData()
    {
        if (PlayerPrefs.HasKey("user_data"))
        {
            string data = PlayerPrefs.GetString("user_data");
            User user = JsonUtility.FromJson<User>(data);
            return user;
        }
        else
        {
            User user = new User();
            return user;
        }
    }
}
