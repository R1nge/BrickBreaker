using System;
using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;
using VContainer.Unity;

public class SceneSerivce : IInitializable
{
	private List<SceneType> _loadedScenes;
	private Dictionary<SceneType, string> _scenes;

	public SceneType CurrentScene { get; private set; }

	public void Initialize()
	{
		_scenes = new Dictionary<SceneType, string> { { SceneType.Boot, "Boot" }, { SceneType.Main, "Main" } };

		_loadedScenes = new List<SceneType>();
		CurrentScene = SceneType.Boot;
	}

	public event Action<SceneType> OnSceneLoaded;
	public event Action<SceneType> OnSceneUnloaded;

	public void LoadScene(SceneType sceneType, LoadSceneMode loadingMode)
	{
		if (_loadedScenes.Contains(sceneType))
		{
			Debug.LogWarning($"Scene {sceneType} already loaded");
			return;
		}

		_loadedScenes.Add(sceneType);
		CurrentScene = sceneType;
		SceneManager.LoadScene(_scenes[sceneType], loadingMode);
	}

	public async UniTask LoadSceneAsync(SceneType sceneType, LoadSceneMode loadingMode)
	{
		if (_loadedScenes.Contains(sceneType))
		{
			Debug.LogWarning($"Scene {sceneType} already loaded");
			return;
		}

		_loadedScenes.Add(sceneType);
		CurrentScene = sceneType;
		await SceneManager.LoadSceneAsync(_scenes[sceneType], loadingMode);
		OnSceneLoaded?.Invoke(sceneType);
	}

	public void UnloadScene(SceneType sceneType)
	{
		SceneManager.UnloadScene(_scenes[sceneType]);
		_loadedScenes.Remove(sceneType);
		OnSceneUnloaded?.Invoke(sceneType);
	}

	public async UniTask UnloadSceneAsync(SceneType sceneType)
	{
		await SceneManager.UnloadSceneAsync(_scenes[sceneType]);
		_loadedScenes.Remove(sceneType);
		OnSceneUnloaded?.Invoke(sceneType);
	}
}
