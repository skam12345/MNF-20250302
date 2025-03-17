using UnityEngine;

/// <summary>
/// 해당 SingleTon은 Hierachy창에 어떤 오브젝트인지간에 AddComponent로 넣어져 있어야 제대로 작동합니다.
/// </summary>
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

	protected virtual void Awake()
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
/// 해당 싱글톤은 메모리상에 존재하는 싱글톤입니다.
/// 사용하려면 최초 1회 Instance를 입력해야합니다.
/// TestManager.Instance;
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
