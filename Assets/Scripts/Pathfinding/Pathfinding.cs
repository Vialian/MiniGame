using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Pathfinding : MonoBehaviour
{

    //public Transform seeker, target;
    public UnitList[] units;
    public Transform seeker, target;
    Grid grid;
    Vector3 cachedSeekerPos, cachedTargetPos;


    private bool move = false, canStart = true;

    void Awake()
    {
        grid = GetComponent<Grid>();
    }

    void Start()
    {
        cachedSeekerPos = seeker.position;
        cachedTargetPos = target.position;
        FindPath(seeker.position, target.position);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
            move = true;

        if (!move && canStart)
        {
            if (cachedSeekerPos != seeker.position)
            {
                cachedSeekerPos = seeker.position;
                FindPath(seeker.position, target.position);
            }
            if (cachedTargetPos != target.position)
            {
                cachedTargetPos = target.position;
                FindPath(seeker.position, target.position);
            }
        }
        else
        {
            AnimatePath();
        }
    }

    void AnimatePath()
    {
        move = false;
        canStart = false;
        Vector3 currentPos = seeker.position;
        if (grid.path != null)
        {
            //Debug.Log("ANIMATING PATH");
            StartCoroutine(UpdatePosition(currentPos, grid.path[0], 0));
        }
    }

    IEnumerator UpdatePosition(Vector3 currentPos, Node n, int index)
    {
        //Debug.Log ("Started Coroutine...");
        float t = 0.0f;
        Vector3 correctedPathPos = new Vector3(n.worldPosition.x, 1, n.worldPosition.z);
        while (t < 1.0f)
        {
            t += Time.deltaTime + 5;
            seeker.position = Vector3.Lerp(currentPos, correctedPathPos, t);
            yield return null;
        }
        //Debug.Log ("Finished updating...");
        seeker.position = correctedPathPos;
        currentPos = correctedPathPos;

        index++;
        if (index < grid.path.Count)
            StartCoroutine(UpdatePosition(currentPos, grid.path[index], index));
        else
            canStart = true;
    }

    //void Awake()
    //{
    //    grid = GetComponent<Grid>();
    //}
    //void Update()
    //{
    //    FindPath(seeker.position, target.position);
    //}

    void FindPath(Vector3 startPos, Vector3 targetPos)
    {
        Node startNode = grid.NodeFromWorldPoint(startPos);
        Node targetNode = grid.NodeFromWorldPoint(targetPos);

        List<Node> openSet = new List<Node>();
        HashSet<Node> closedSet = new HashSet<Node>();
        openSet.Add(startNode);

        while (openSet.Count > 0)
        {
            Node node = openSet[0];
            for (int i = 1; i < openSet.Count; i++)
            {
                if (openSet[i].fCost < node.fCost || openSet[i].fCost == node.fCost)
                {
                    if (openSet[i].hCost < node.hCost)
                        node = openSet[i];
                }
            }

            openSet.Remove(node);
            closedSet.Add(node);

            if (node == targetNode)
            {
                RetracePath(startNode, targetNode);
                return;
            }

            foreach (Node neighbour in grid.GetNeighbours(node))
            {
                if (!neighbour.walkable || closedSet.Contains(neighbour))
                {
                    continue;
                }

                int newCostToNeighbour = node.gCost + GetDistance(node, neighbour);
                if (newCostToNeighbour < neighbour.gCost || !openSet.Contains(neighbour))
                {
                    neighbour.gCost = newCostToNeighbour;
                    neighbour.hCost = GetDistance(neighbour, targetNode);
                    neighbour.parent = node;

                    if (!openSet.Contains(neighbour))
                        openSet.Add(neighbour);
                }
            }
        }
    }

    void RetracePath(Node startNode, Node endNode)
    {

        List<Node> path = new List<Node>();
        Node currentNode = endNode;

        while (currentNode != startNode)
        {
            path.Add(currentNode);
            currentNode = currentNode.parent;
        }
        path.Reverse();

        grid.path = path;
    }

    int GetDistance(Node nodeA, Node nodeB)
    {
        int dstX = Mathf.Abs(nodeA.gridX - nodeB.gridX);
        int dstY = Mathf.Abs(nodeA.gridY - nodeB.gridY);

        if (dstX > dstY)
            return 14 * dstY + 10 * (dstX - dstY);
        return 14 * dstX + 10 * (dstY - dstX);
    }
}