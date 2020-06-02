using UnityEngine;


public class Singleton<T> : MonoBehaviour where T : MonoBehaviour
{
    private static T _instance;

    public static T Instance
    {
        get
        {
            _instance = Object.FindObjectOfType<T>();

            if (_instance == null)
            {
                var obj = new GameObject("[" + typeof(T).ToString().ToUpper() + "]");
                obj.AddComponent<T>();
                _instance = obj.GetComponent<T>();
            }

            return _instance;
        }
    }
}