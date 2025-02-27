using UnityEngine;

public enum GraphicType
{
    QualityLevel = 0,
    VSync = 1,
    ScreenMode = 2,
    Resolution = 3,
}

public class GraphicsHandler : MonoBehaviour, IDataPersistence
{
    public int Quality { get; private set; }
    public int VSync { get; private set; }
    public int ScreenMode { get; private set; }
    public int Resolution { get; private set; }

    public void LoadData(GameData data)
    {
        if (data != null && data.SettingData.GraphicData != null)
        {
            var graphicsData = data.SettingData.GraphicData;

            SetGraphicsSetting(GraphicType.QualityLevel, graphicsData.Quality);
            SetGraphicsSetting(GraphicType.VSync, graphicsData.VSync);
            SetGraphicsSetting(GraphicType.ScreenMode, graphicsData.ScreenMode);
            SetGraphicsSetting(GraphicType.Resolution, graphicsData.Resolution);
        }
    }

    public void SaveData(GameData data)
    {
        if (data != null)
        {
            GraphicsData graphicsData = new GraphicsData();

            graphicsData.Quality = Quality;
            graphicsData.VSync = VSync;
            graphicsData.ScreenMode = ScreenMode;
            graphicsData.Resolution = Resolution;

            data.SettingData.GraphicData = graphicsData;
        }
    }

    public void SetGraphicsSetting(GraphicType type, int value , bool toSave = false)
    {
        GameData data = ProjectReferencesContainer.Instance.DataPersistenceHandlerBase.GameData;
        GraphicsData graphicsData = data.SettingData.GraphicData;

        switch (type)
        {
            case GraphicType.QualityLevel:
                Quality = value;
                QualitySettings.SetQualityLevel(value);

                if (toSave == true)
                {
                    graphicsData.Quality = value;
                }

                break;

            case GraphicType.ScreenMode:
                ScreenMode = value;
                FullScreenMode fullScreenMode = FullScreenMode.FullScreenWindow;

                switch (value)
                {
                    case 0:
                        fullScreenMode = FullScreenMode.FullScreenWindow;
                        break;
                    case 1:
                        fullScreenMode = FullScreenMode.MaximizedWindow;
                        break;
                    case 2:
                        fullScreenMode = FullScreenMode.Windowed;
                        break;
                }

                Screen.SetResolution(Screen.currentResolution.width, Screen.currentResolution.height, fullScreenMode);

                if (toSave == true)
                {
                    graphicsData.ScreenMode = value;
                }

                break;

            case GraphicType.Resolution:
                Resolution = value;
                var res = Screen.resolutions[value];
                Screen.SetResolution(res.width, res.height, FullScreenMode.FullScreenWindow, res.refreshRateRatio);

                if (toSave == true)
                {
                    graphicsData.Resolution = value;
                }

                break;

            case GraphicType.VSync:
                VSync = value;
                QualitySettings.vSyncCount = value;

                if (toSave == true)
                {
                    graphicsData.VSync = value;
                }

                break;
        }
    }
}
