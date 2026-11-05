# Game development: Unity 6 + Blender + Azure

- `UnityProject/` – Unity 6 (6000.0 LTS) project: `PlayerController`, `AzureLeaderboard` (posts scores to an Azure Function).
- `Blender/export_fbx.py` – headless FBX export; place output in `UnityProject/Assets/Models/`.
  `blender -b scene.blend -P Blender/export_fbx.py -- UnityProject/Assets/Models/scene.fbx`
- `azure/azure-pipelines.yml` – builds WebGL and hosts it on Azure Storage static website.

Open `UnityProject/` in Unity Hub with Unity 6 to start.
