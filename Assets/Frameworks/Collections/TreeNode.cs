using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Frameworks.Collections
{
    [Serializable]
    public class TreeNode : IEnumerable<TreeNode>
    {
        private readonly Queue<TreeNode> _nodeQueue = new();


        [field: SerializeField]
        public List<TreeNode> Children { get; protected set; }


        [field: SerializeField]
        public string Id { get; protected set; }


        public TreeNode this[string id]
        {
            get
            {
                using var enumerator = GetEnumerator();

                while (enumerator.MoveNext())
                {
                    if (enumerator.Current != null && enumerator.Current.Id == id)
                    {
                        return enumerator.Current;
                    }
                }

                enumerator.Reset();

                throw new Exception($"Не найдена нода с id: {id}");
            }
        }


        public void Setup(string id)
        {
            Id = id;
        }


        public TreeNode AddChild(TreeNode node)
        {
            Children.Add(node);

            return node;
        }


        public IEnumerator<TreeNode> GetEnumerator()
        {
            _nodeQueue.Clear();
            _nodeQueue.Enqueue(this);

            var visitedNodes = new HashSet<TreeNode>();

            while (_nodeQueue.Count > 0)
            {
                var node = _nodeQueue.Dequeue();

                foreach (var child in node.Children)
                {
                    yield return child;

                    if (visitedNodes.Contains(child))
                    {
                        continue;
                    }

                    _nodeQueue.Enqueue(child);
                    visitedNodes.Add(child);
                }
            }
        }


        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}