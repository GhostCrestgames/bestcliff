using UnityEngine;

public class startervalleycreate : MonoBehaviour
{
    public int numberOfHuts = 8;

    Material wood;
    Material darkWood;
    Material roof;
    Material grass;
    Material stone;
    Material gold;
    Material jungleGreen;
    Material tradingBlue;
    Material tradingPurple;
    Material white;
    Material black;

    void Start()
    {
        CreateMaterials();
        CreateStarterValley();
    }

    void CreateMaterials()
    {
        wood = MakeMaterial("Warm Wood", new Color(0.38f, 0.18f, 0.07f));
        darkWood = MakeMaterial("Dark Wood", new Color(0.16f, 0.07f, 0.025f));
        roof = MakeMaterial("Leaf Roof", new Color(0.10f, 0.28f, 0.09f));

        grass = MakeMaterial("Jungle Green", new Color(0.16f, 0.48f, 0.18f));
        stone = MakeMaterial("Valley Stone", new Color(0.34f, 0.37f, 0.38f));

        gold = MakeMaterial("Jungle Coin Gold", new Color(1f, 0.62f, 0.05f));

        jungleGreen = MakeMaterial("Ferd Green", new Color(0.12f, 0.55f, 0.22f));

        tradingBlue = MakeMaterial("Trading Blue", new Color(0.05f, 0.45f, 0.9f));
        tradingPurple = MakeMaterial("Trading Purple", new Color(0.5f, 0.12f, 0.85f));

        white = MakeMaterial("White", new Color(0.9f, 0.9f, 0.9f));
        black = MakeMaterial("Black", new Color(0.03f, 0.03f, 0.03f));
    }

    Material MakeMaterial(string name, Color color)
    {
        Material mat = new Material(Shader.Find("Universal Render Pipeline/Lit"));
        mat.name = name;
        mat.color = color;
        return mat;
    }

    void CreateStarterValley()
    {
        GameObject valley = new GameObject("BEASTHAVEN STARTER VALLEY");

        CreateCenter(valley.transform);
        CreatePaths(valley.transform);
        CreateHuts(valley.transform);
        CreateFerdShop(valley.transform);
        CreateTradingTable(valley.transform);
        CreateNature(valley.transform);
    }

    void CreateCenter(Transform parent)
    {
        GameObject center = new GameObject("STARTER VALLEY CENTER");
        center.transform.parent = parent;

        CreateCylinder(
            "Stone Gathering Platform",
            center.transform,
            new Vector3(0, 0.2f, 0),
            new Vector3(12, 0.4f, 12),
            stone
        );

        CreateCylinder(
            "Center Grass",
            center.transform,
            new Vector3(0, 0.42f, 0),
            new Vector3(10, 0.15f, 10),
            grass
        );

        // Central glowing jungle coin monument
        CreateCylinder(
            "Coin Pedestal",
            center.transform,
            new Vector3(0, 1f, 0),
            new Vector3(2, 1.5f, 2),
            darkWood
        );

        CreateSphere(
            "JUNGLE COIN",
            center.transform,
            new Vector3(0, 3f, 0),
            new Vector3(2.3f, 2.3f, 0.55f),
            gold
        );

        CreateText(
            "BEASTHAVEN",
            center.transform,
            new Vector3(0, 4.7f, 0),
            1.1f
        );
    }

    void CreateHuts(Transform parent)
    {
        GameObject huts = new GameObject("PLAYER HUTS - 8");
        huts.transform.parent = parent;

        Color[] hutColors =
        {
            new Color(0.85f, 0.18f, 0.12f),
            new Color(0.10f, 0.42f, 0.9f),
            new Color(0.95f, 0.62f, 0.08f),
            new Color(0.38f, 0.12f, 0.65f),
            new Color(0.10f, 0.65f, 0.35f),
            new Color(0.85f, 0.25f, 0.55f),
            new Color(0.10f, 0.65f, 0.75f),
            new Color(0.72f, 0.35f, 0.10f)
        };

        float radius = 27f;

        for (int i = 0; i < numberOfHuts; i++)
        {
            float angle = i * Mathf.PI * 2f / numberOfHuts;

            Vector3 position = new Vector3(
                Mathf.Cos(angle) * radius,
                0,
                Mathf.Sin(angle) * radius
            );

            Material hutColor =
                MakeMaterial("Player " + (i + 1) + " Color", hutColors[i]);

            CreateHut(
                "PLAYER HUT " + (i + 1),
                huts.transform,
                position,
                i + 1,
                hutColor
            );
        }
    }

    void CreateHut(
        string name,
        Transform parent,
        Vector3 position,
        int playerNumber,
        Material accent)
    {
        GameObject hut = new GameObject(name);
        hut.transform.parent = parent;
        hut.transform.position = position;

        // Rotate hut toward center
        hut.transform.LookAt(new Vector3(0, 0, 0));

        // Floor
        CreateCube(
            "Wood Floor",
            hut.transform,
            new Vector3(0, 0.35f, 0),
            new Vector3(7, 0.5f, 6),
            wood
        );

        // Back wall
        CreateCube(
            "Back Wall",
            hut.transform,
            new Vector3(0, 2.6f, 2.8f),
            new Vector3(7, 4.5f, 0.35f),
            wood
        );

        // Side walls
        CreateCube(
            "Left Wall",
            hut.transform,
            new Vector3(-3.3f, 2.6f, 0),
            new Vector3(0.35f, 4.5f, 6),
            wood
        );

        CreateCube(
            "Right Wall",
            hut.transform,
            new Vector3(3.3f, 2.6f, 0),
            new Vector3(0.35f, 4.5f, 6),
            wood
        );

        // Front wall pieces leave doorway open
        CreateCube(
            "Front Left",
            hut.transform,
            new Vector3(-2.3f, 2.6f, -2.8f),
            new Vector3(2.4f, 4.5f, 0.35f),
            wood
        );

        CreateCube(
            "Front Right",
            hut.transform,
            new Vector3(2.3f, 2.6f, -2.8f),
            new Vector3(2.4f, 4.5f, 0.35f),
            wood
        );

        CreateCube(
            "Door Top",
            hut.transform,
            new Vector3(0, 4.3f, -2.8f),
            new Vector3(2.2f, 1.1f, 0.35f),
            accent
        );

        // Colored trim
        CreateCube(
            "Player Color Trim",
            hut.transform,
            new Vector3(0, 0.8f, -3.05f),
            new Vector3(6.8f, 0.35f, 0.25f),
            accent
        );

        // Roof
        CreateCylinder(
            "Jungle Roof",
            hut.transform,
            new Vector3(0, 5.25f, 0),
            new Vector3(5.2f, 1.3f, 5.2f),
            roof
        );

        // Porch posts
        CreateCylinder(
            "Left Porch Post",
            hut.transform,
            new Vector3(-3f, 2f, -3.4f),
            new Vector3(0.3f, 3.8f, 0.3f),
            darkWood
        );

        CreateCylinder(
            "Right Porch Post",
            hut.transform,
            new Vector3(3f, 2f, -3.4f),
            new Vector3(0.3f, 3.8f, 0.3f),
            darkWood
        );

        // Player marker
        CreateSphere(
            "Player Marker",
            hut.transform,
            new Vector3(0, 5.7f, -3.2f),
            new Vector3(0.7f, 0.7f, 0.35f),
            accent
        );

        CreateText(
            "PLAYER " + playerNumber,
            hut.transform,
            new Vector3(0, 4.8f, -3.1f),
            0.55f
        );
    }

    void CreateFerdShop(Transform parent)
    {
        GameObject shop = new GameObject("FERD - SHOP AND SELL");
        shop.transform.parent = parent;
        shop.transform.position = new Vector3(0, 0, 16);

        // Shop floor
        CreateCube(
            "Shop Floor",
            shop.transform,
            Vector3.zero,
            new Vector3(12, 0.5f, 8),
            darkWood
        );

        // Back wall
        CreateCube(
            "Shop Back Wall",
            shop.transform,
            new Vector3(0, 3, 3.5f),
            new Vector3(12, 6, 0.5f),
            wood
        );

        // Green roof
        CreateCube(
            "Ferd Roof",
            shop.transform,
            new Vector3(0, 6.2f, 0),
            new Vector3(13, 0.7f, 9),
            jungleGreen
        );

        // Counter
        CreateCube(
            "FERD SHOP COUNTER",
            shop.transform,
            new Vector3(0, 1.4f, -2.2f),
            new Vector3(9, 2.2f, 1.3f),
            darkWood
        );

        // Ferd placeholder
        CreateCylinder(
            "FERD",
            shop.transform,
            new Vector3(0, 2.4f, 0),
            new Vector3(1.2f, 2.5f, 1.2f),
            jungleGreen
        );

        CreateSphere(
            "Ferd Head",
            shop.transform,
            new Vector3(0, 4.3f, 0),
            new Vector3(1.5f, 1.5f, 1.5f),
            jungleGreen
        );

        CreateText(
            "FERD",
            shop.transform,
            new Vector3(0, 7f, 3.2f),
            1f
        );

        // Blueprint side
        CreateCube(
            "BLUEPRINT SHOP",
            shop.transform,
            new Vector3(-4.2f, 2.5f, -3.2f),
            new Vector3(3.2f, 3.5f, 0.4f),
            tradingBlue
        );

        CreateText(
            "BLUEPRINTS",
            shop.transform,
            new Vector3(-4.2f, 4.4f, -3.45f),
            0.45f
        );

        // Selling side
        CreateCube(
            "SELL ITEMS FOR JUNGLE COINS",
            shop.transform,
            new Vector3(4.2f, 2.5f, -3.2f),
            new Vector3(3.2f, 3.5f, 0.4f),
            gold
        );

        CreateText(
            "SELL ITEMS",
            shop.transform,
            new Vector3(4.2f, 4.4f, -3.45f),
            0.45f
        );

        // Coin decoration
        CreateSphere(
            "Jungle Coin Sign",
            shop.transform,
            new Vector3(4.2f, 2.7f, -3.6f),
            new Vector3(1.3f, 1.3f, 0.3f),
            gold
        );
    }

    void CreateTradingTable(Transform parent)
    {
        GameObject area = new GameObject("BEAST TRADING TABLE");
        area.transform.parent = parent;
        area.transform.position = new Vector3(-15, 0, -8);

        // Platform
        CreateCylinder(
            "Trading Platform",
            area.transform,
            Vector3.zero,
            new Vector3(8, 0.5f, 8),
            black
        );

        // Main table
        CreateCube(
            "Trading Table",
            area.transform,
            new Vector3(0, 1.5f, 0),
            new Vector3(7, 0.7f, 3.5f),
            darkWood
        );

        // Blue side
        CreateCube(
            "Player A Trade Zone",
            area.transform,
            new Vector3(-2.2f, 2f, 0),
            new Vector3(2.6f, 0.15f, 2.7f),
            tradingBlue
        );

        // Purple side
        CreateCube(
            "Player B Trade Zone",
            area.transform,
            new Vector3(2.2f, 2f, 0),
            new Vector3(2.6f, 0.15f, 2.7f),
            tradingPurple
        );

        // Center confirmation gem
        CreateSphere(
            "Trade Confirmation Gem",
            area.transform,
            new Vector3(0, 2.7f, 0),
            new Vector3(0.8f, 1.2f, 0.8f),
            gold
        );

        // Four pillars
        Vector3[] pillarPositions =
        {
            new Vector3(-4, 2, -3),
            new Vector3(4, 2, -3),
            new Vector3(-4, 2, 3),
            new Vector3(4, 2, 3)
        };

        foreach (Vector3 pos in pillarPositions)
        {
            CreateCylinder(
                "Trading Pillar",
                area.transform,
                pos,
                new Vector3(0.5f, 4, 0.5f),
                tradingPurple
            );

            CreateSphere(
                "Trading Light",
                area.transform,
                pos + Vector3.up * 2.4f,
                new Vector3(0.8f, 0.8f, 0.8f),
                tradingBlue
            );
        }

        CreateText(
            "BEAST TRADING",
            area.transform,
            new Vector3(0, 5.5f, 0),
            0.8f
        );
    }

    void CreatePaths(Transform parent)
    {
        GameObject paths = new GameObject("VALLEY PATHS");
        paths.transform.parent = parent;

        for (int i = 0; i < 8; i++)
        {
            float angle = i * 45f;

            GameObject path = CreateCube(
                "Path " + (i + 1),
                paths.transform,
                new Vector3(0, 0.08f, 0),
                new Vector3(3.2f, 0.12f, 23),
                stone
            );

            path.transform.rotation = Quaternion.Euler(0, angle, 0);
            path.transform.position =
                path.transform.forward * 11f;
        }
    }

    void CreateNature(Transform parent)
    {
        GameObject nature = new GameObject("JUNGLE NATURE");
        nature.transform.parent = parent;

        Random.InitState(88);

        // Trees
        for (int i = 0; i < 35; i++)
        {
            float angle = Random.Range(0f, 360f) * Mathf.Deg2Rad;
            float distance = Random.Range(33f, 48f);

            Vector3 pos = new Vector3(
                Mathf.Cos(angle) * distance,
                0,
                Mathf.Sin(angle) * distance
            );

            CreateTree(nature.transform, pos, i);
        }

        // Rocks
        for (int i = 0; i < 25; i++)
        {
            float angle = Random.Range(0f, 360f) * Mathf.Deg2Rad;
            float distance = Random.Range(12f, 45f);

            Vector3 pos = new Vector3(
                Mathf.Cos(angle) * distance,
                0.5f,
                Mathf.Sin(angle) * distance
            );

            float size = Random.Range(0.6f, 1.8f);

            CreateSphere(
                "Rock " + (i + 1),
                nature.transform,
                pos,
                new Vector3(size, size * 0.7f, size),
                stone
            );
        }
    }

    void CreateTree(Transform parent, Vector3 position, int number)
    {
        GameObject tree = new GameObject("Jungle Tree " + number);
        tree.transform.parent = parent;
        tree.transform.position = position;

        float height = Random.Range(4f, 7f);

        CreateCylinder(
            "Trunk",
            tree.transform,
            new Vector3(0, height / 2f, 0),
            new Vector3(0.7f, height, 0.7f),
            darkWood
        );

        CreateSphere(
            "Leaves 1",
            tree.transform,
            new Vector3(0, height, 0),
            new Vector3(4, 3, 4),
            jungleGreen
        );

        CreateSphere(
            "Leaves 2",
            tree.transform,
            new Vector3(1.5f, height + 0.5f, 0),
            new Vector3(3, 2.5f, 3),
            grass
        );
    }

    GameObject CreateCube(
        string name,
        Transform parent,
        Vector3 localPosition,
        Vector3 scale,
        Material material)
    {
        GameObject obj = GameObject.CreatePrimitive(PrimitiveType.Cube);
        obj.name = name;
        obj.transform.parent = parent;
        obj.transform.localPosition = localPosition;
        obj.transform.localScale = scale;

        obj.GetComponent<Renderer>().material = material;

        return obj;
    }

    GameObject CreateSphere(
        string name,
        Transform parent,
        Vector3 localPosition,
        Vector3 scale,
        Material material)
    {
        GameObject obj = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        obj.name = name;
        obj.transform.parent = parent;
        obj.transform.localPosition = localPosition;
        obj.transform.localScale = scale;

        obj.GetComponent<Renderer>().material = material;

        return obj;
    }

    GameObject CreateCylinder(
        string name,
        Transform parent,
        Vector3 localPosition,
        Vector3 scale,
        Material material)
    {
        GameObject obj = GameObject.CreatePrimitive(PrimitiveType.Cylinder);
        obj.name = name;
        obj.transform.parent = parent;
        obj.transform.localPosition = localPosition;
        obj.transform.localScale = scale;

        obj.GetComponent<Renderer>().material = material;

        return obj;
    }

    void CreateText(
        string words,
        Transform parent,
        Vector3 localPosition,
        float size)
    {
        GameObject textObject = new GameObject(words + " SIGN");
        textObject.transform.parent = parent;
        textObject.transform.localPosition = localPosition;

        TextMesh text = textObject.AddComponent<TextMesh>();

        text.text = words;
        text.fontSize = 64;
        text.characterSize = size;
        text.anchor = TextAnchor.MiddleCenter;
        text.alignment = TextAlignment.Center;
        text.color = Color.white;
    }
}