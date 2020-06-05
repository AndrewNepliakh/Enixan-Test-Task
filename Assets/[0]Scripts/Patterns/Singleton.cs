using UnityEngine;


public class Singleton<T> : MonoBehaviour where T : MonoBehaviour
{
    private static T _instance;

    public static T Instance
    {
        get
        {
            _instance = FindObjectOfType<T>();

            if (_instance == null)
            {
                var obj = new GameObject("[" + typeof(T).ToString().ToUpper() + "]");
                obj.transform.SetSiblingIndex(0);
                obj.AddComponent<T>();
                _instance = obj.GetComponent<T>();
            }

            return _instance;
        }
    }
}