using UnityEngine;

public class MakeGrid : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {

        GameObject baseHexagon = GameObject.Instantiate(GameObject.Find("baseHexagon"));
        Quaternion baseQuaternion = baseHexagon.transform.rotation;

        int width = 60;
        int height = 60;

        GameObject[][] tiles = new GameObject[width][];

        double xOffset = 2.26f;
        double zOffset = 1.16f;

        for (int col = 0; col < width; col++)
        {

            tiles[col] = new GameObject[height];

            for (int row = 0; row < height; row++)
            {

                tiles[col][row] = GameObject.Instantiate(baseHexagon);

                Vector3 nextPos = new Vector3();
                float oddOffset = col % 2 > 0 ? (float)zOffset : 0;

                nextPos.Set((float)xOffset * col, 0, oddOffset + ((float)zOffset * row * 2));
                tiles[col][row].transform.SetPositionAndRotation(nextPos, baseQuaternion);
                tiles[col][row].name = row.ToString() + ", " + col.ToString();

                Renderer rend = null;
                rend = tiles[col][row].GetComponent<Renderer>();
                rend.enabled = true;

                if (row % 2 != 0)
                {
                    Color oddCol = new Color();
                    oddCol.r = 1;
                    
                }

            }
        }

        Vector3 lineOffset = new Vector3();
        lineOffset.Set(0.0f, 2.0f, 0.0f);

        GameObject line = new GameObject("lineObject");

        LineRenderer lineTest = line.AddComponent<LineRenderer>();
        lineTest.startWidth = 2.0f;
        lineTest.endWidth = 2.0f;
        lineTest.material = new Material(Shader.Find("Standard"));
        lineTest.SetColors(Color.red, Color.blue);
        lineTest.SetPosition(0, tiles[20][20].transform.position + lineOffset);
        lineTest.SetPosition(1, tiles[24][24].transform.position + lineOffset);

        GameObject tmp = GameObject.Find("Tribeling");
        Vector3 Tribeling_Location = tiles[10][30].transform.position;
        tmp.gameObject.transform.position = Tribeling_Location;

        GameObject MainCamera = GameObject.Find("Geo Camera");
        Vector3 CameraOffset = new Vector3(0f, 6f, -30f);
        Vector3 Camera_Location = tiles[30][30].transform.position ;
        MainCamera.gameObject.transform.position = Camera_Location + CameraOffset;

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
