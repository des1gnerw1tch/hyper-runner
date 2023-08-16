using UnityEngine;
using UnityEngine.Animations;

public class LevelBuilderTrailRenderer : MonoBehaviour
{
    [SerializeField] private ParentConstraint trailParentConstraint;
    [SerializeField] private TrailRenderer trailRenderer;
    [SerializeField] private LineRenderer lineRenderer;

    private void Start()
    {
        trailParentConstraint.gameObject.SetActive(true);
        SetTrailFollowPlayer();
    }

    private void SetTrailFollowPlayer()
    {
        ConstraintSource source = new ConstraintSource();
        source.sourceTransform = GameObject.FindWithTag("Player").transform;
        source.weight = 1;
        trailParentConstraint.AddSource(source);
        trailParentConstraint.constraintActive = true;
    }

    private void Update()
    {
        int numVertices = trailRenderer.positionCount;
        
        Vector3[] v = new Vector3[numVertices];
        
        trailRenderer.GetPositions(v);
        
        lineRenderer.SetPositions(v);
        if (numVertices < 1)
        {
            return;
        }
        
        for (int i = numVertices; i < 10000; i++)
        {
            lineRenderer.SetPosition(i, lineRenderer.GetPosition(numVertices - 1));
        }
    }
}
