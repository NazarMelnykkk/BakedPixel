using UnityEngine;

public class GlobalSceneTransformHolder : MonoBehaviour
{  
    void Start()
    {
        ProjectReferencesContainer.Instance.GlobalSceneTransformHolder = this;
    }
}
