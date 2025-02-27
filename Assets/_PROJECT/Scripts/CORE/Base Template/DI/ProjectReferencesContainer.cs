using UnityEngine;

public class ProjectReferencesContainer : MonoBehaviour
{
    public static ProjectReferencesContainer Instance;

    [field: SerializeField] public DataPersistenceHandlerBase DataPersistenceHandlerBase { get; private set; }
    [field: SerializeField] public AudioHandler AudioHandler { get; private set; }
    [field: SerializeField] public InputController InputController { get; private set; }
    [field: SerializeField] public SceneLoader SceneLoader { get; private set; }
    [field: SerializeField] public GraphicsHandler GraphicsHandler { get; private set; }
    [field: SerializeField] public GlobalDataBase GlobalDataBase { get; private set; }
    [field: SerializeField] public GlobalSceneTransformHolder GlobalSceneTransformHolder { get;  set; }

    private void Awake()
    {
        Application.targetFrameRate = 60;

        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
