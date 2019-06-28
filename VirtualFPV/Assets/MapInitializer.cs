using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mapbox.Unity.Map;

public class MapInitializer : MonoBehaviour
{
    ConfigFile cf;
    AbstractMap mapapi;

    int zoom;

    // Start is called before the first frame update
    void Start()
    {
        cf = ConfigFile.GetInstance();
        mapapi = gameObject.GetComponent<AbstractMap>();

        double latitude = cf.GetDoubleValue("Latitude");
        double longitude = cf.GetDoubleValue("Longitude");
        zoom = cf.GetIntValue("Zoom");
        float height = cf.GetFloatValue("Height");
        float ypos = cf.GetFloatValue("PositionY");

        mapapi.Terrain.SetExaggerationFactor(height);
        mapapi.Initialize(new Mapbox.Utils.Vector2d(latitude, longitude), zoom);
        Vector3 pos = transform.position;
        transform.position = new Vector3(pos.x, ypos, pos.z);
    }

    public void SetMapCenter(float latitude, float longitude)
    {
        mapapi.UpdateMap(new Mapbox.Utils.Vector2d(latitude, longitude), zoom);
    }

}

