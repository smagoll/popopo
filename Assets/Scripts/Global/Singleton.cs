using UnityEngine;

public class Singleton<T> : MonoBehaviour where T : class, new()
{
    private static T instance = null;

	public static T Instance
	{
		get
		{
			if (instance == null)
			{
				instance = new();
			}
			return instance;
		}
	}
}