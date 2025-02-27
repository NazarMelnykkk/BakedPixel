[System.Serializable]
public class SettingData
{
    public SoundsData SoundsData;
    public GraphicsData GraphicData;

    public SettingData()
    {
        SoundsData = new SoundsData();
        GraphicData = new GraphicsData();    
    }
}
