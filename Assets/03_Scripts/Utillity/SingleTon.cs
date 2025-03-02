using UnityEngine;

public class SingleTon<T> : MonoBehaviour where T : MonoBehaviour
{
    private static T instance;

    public static T Instance
    {
        get {  
            if( instance == null)
            {
                instance = FindObjectOfType<T>();
            }
            return instance;
        }
    }
}
