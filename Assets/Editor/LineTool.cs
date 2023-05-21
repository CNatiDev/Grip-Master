using UnityEngine;
using UnityEditor;

[InitializeOnLoad]
public class LineTool : EditorWindow
{
    private static Vector3 start;
    private static Vector3 end;
    private static bool drawing = false;
    private float lineThickness = 1f;
    private bool Edit = false;
    private static bool hasStartPoint = false; // Verifică dacă există un punct de start

    [MenuItem("Tools/Line Tool")]
    private static void Init()
    {
        LineTool window = GetWindow<LineTool>();
        window.titleContent = new GUIContent("Line Tool");
    }

    private void OnEnable()
    {
        SceneView.duringSceneGui += OnSceneGUI;
    }

    private void OnDisable()
    {
        SceneView.duringSceneGui -= OnSceneGUI;
    }

    private void OnSceneGUI(SceneView sceneView)
    {
        Event currentEvent = Event.current;
        switch (currentEvent.type)
        {
            case EventType.MouseDown:
                if (currentEvent.button == 0)
                {
                    if (!drawing)
                    {
                        if (!hasStartPoint)
                        {
                            start = HandleUtility.GUIPointToWorldRay(currentEvent.mousePosition).origin;
                            hasStartPoint = true;
                        }
                        else
                        {
                            end = HandleUtility.GUIPointToWorldRay(currentEvent.mousePosition).origin;
                            drawing = true;

                            // Adaugă punctele de control sau faceți orice altă acțiune dorită cu aceste puncte
                            AddControlPoint(start);
                            AddControlPoint(end);

                            // Desenați linia în scenă
                            DrawLine(start, end);
                        }
                    }
                }
                break;

            case EventType.MouseUp:
                if (currentEvent.button == 0 && drawing)
                {
                    // ...
                    drawing = false;
                }
                break;

            case EventType.MouseDrag:
                if (Edit && hasStartPoint)
                {
                    // Desenați linia temporar în timpul tragerii pentru a oferi feedback vizual în timp real
                    Vector3 currentEnd = HandleUtility.GUIPointToWorldRay(currentEvent.mousePosition).origin;
                    DrawLine(start, currentEnd);
                }
                break;
        }
    }

    private void AddControlPoint(Vector3 point)
    {
        // Adăugați punctul de control la traiectorie sau faceți orice altă acțiune dorită
    }

    private void DrawLine(Vector3 startPoint, Vector3 endPoint)
    {
        Handles.color = Color.green;
        Handles.DrawAAPolyLine(lineThickness, startPoint, endPoint);
    }

    private void GoToLinePosition()
    {
        SceneView sceneView = SceneView.lastActiveSceneView;
        if (sceneView != null)
        {
            Vector3 linePosition = (start + end) / 2f;
            sceneView.LookAt(linePosition);
        }
    }

    private void OnGUI()
    {
        GUILayout.BeginVertical(GUI.skin.box);

        lineThickness = EditorGUILayout.Slider("Line Thickness", lineThickness, 0.1f, 10f);

        if (GUILayout.Button(Edit ? "Edit" : "NoEdit", GUILayout.ExpandWidth(true), GUILayout.Height(40)))
        {
            Edit = !Edit; // Inversează valoarea booleană când butonul este apăsat
        }

        if (GUILayout.Button("Go to Line Position", GUILayout.ExpandWidth(true), GUILayout.Height(40)))
        {
            GoToLinePosition();
        }

        if (GUILayout.Button("+", GUILayout.ExpandWidth(true), GUILayout.Height(40)))
        {
            hasStartPoint = false; // Resetează punctul de start pentru a permite plasarea unui nou punct
        }

        GUILayout.EndVertical();
    }
}
