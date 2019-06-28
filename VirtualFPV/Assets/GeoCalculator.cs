using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeoCalculator {

    //static Vector3 moereMountainPos = new Vector3(141.425995f, 0f, 43.122080f);
    static Vector3 referencePos;
    static Vector3 scale;
    static ConfigFile cf;

    GeoCalculator() { }
    ~GeoCalculator() { }

    public static Vector3 ToXYZ(float latitude, float longitude, float height)
    {
        if (cf == null)
        {
            cf = ConfigFile.GetInstance();

            float referenceLatitude = cf.GetFloatValue("Latitude");
            float referenceLongitude = cf.GetFloatValue("Longitude");
            referencePos = new Vector3(referenceLongitude, 0f, referenceLatitude);

            float sx = cf.GetFloatValue("ScaleX");
            float sy = cf.GetFloatValue("ScaleY");
            float sz = cf.GetFloatValue("ScaleZ");
            scale = new Vector3(sx, sy, sz);
        }

        float z = (latitude - referencePos.z) * scale.z;
        float x = (longitude - referencePos.x) * scale.x;
        float y = height / scale.y;

        return new Vector3(x, y, z);
    }

    public static void UpdateReferencePos(float latitude, float longitude)
    {
        referencePos = new Vector3(longitude, 0f, latitude);

        if (cf == null)
        {
            cf = ConfigFile.GetInstance();
            float sx = cf.GetFloatValue("ScaleX");
            float sy = cf.GetFloatValue("ScaleY");
            float sz = cf.GetFloatValue("ScaleZ");
            scale = new Vector3(sx, sy, sz);
        }

    }
}
