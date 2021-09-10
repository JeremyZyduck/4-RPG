#region USING
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
#endregion
/*<SUMMARY>
 *A class for the scores, parent, and position of each node on the tilemap
<USE>
 *AStar
</USE>
</SUMMARY>*/
public class Node
    {
        public int G { get; set; }
        public int H { get; set; }
        public int F { get; set; }
        public Node Parent { get; set; }
        public Vector3Int Position { get; set; }

        public Node(Vector3Int position)
        {
            this.Position = position;
        }
    }
