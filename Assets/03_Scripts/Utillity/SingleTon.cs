using UnityEngine;

public class SingleTonToUnityObject<T> : MonoBehaviour where T : MonoBehaviour
{
	private static T instance;
	public static T Instance
	{
		get
		{
			if (instance == null)
			{
				instance = (T)FindAnyObjectByType(typeof(T));

				if (instance == null)
				{
					CreateInstance();
				}
			}
			return instance;
		}
	}

	public virtual void Awake()
	{
		RemoveDuplicates();
	}

	private static void CreateInstance()
	{
		instance = (T)FindAnyObjectByType(typeof(T));

		if (instance == null)
		{
			GameObject target = new GameObject();
			target.name = typeof(T).Name;
			instance = target.AddComponent<T>();
			DontDestroyOnLoad(target);
		}
	}

	private void RemoveDuplicates()
	{
		if (instance == null)
		{
			instance = this as T;
			DontDestroyOnLoad(gameObject);
		}
		else
		{
			Destroy(gameObject);
		}
	}
}

/// <summary>
/// 해당 싱글톤은 코드상에서 존재하는 싱글톤입니다.
/// 유니티상에서는 보여질 수 없습니다.
/// 
/// </summary>
/// <typeparam name="T"></typeparam>
public class SingleTonBase<T> where T : new()
{
	private static T instance;

	public static T Instance
	{
		get
		{
			if (instance == null)
			{
				instance = new T();
				return instance;
			}
			else return instance;
		}
	}
}
