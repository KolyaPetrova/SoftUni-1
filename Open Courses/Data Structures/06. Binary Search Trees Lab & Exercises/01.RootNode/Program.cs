﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.RootNode
{
    public class Program
    {
        private static Dictionary<int, Tree<int>> tree = new Dictionary<int, Tree<int>>();

        public static void Main()
        {
            ReadTree();
            Tree<int> rootNode = GetRootNode();
            Console.WriteLine($"Root node: {rootNode.Value}");
        }

        private static Tree<int> GetRootNode()
        {
            return tree.Values.FirstOrDefault(x => x.Parent == null);
        }

        private static void ReadTree()
        {
            int numberOfNodes = int.Parse(Console.ReadLine());

            for (int i = 1; i < numberOfNodes; i++)
            {
                int[] nodes = Console.ReadLine()
                    .Split()
                    .Select(int.Parse)
                    .ToArray();

                AddEdge(nodes);
            }
        }

        private static void AddEdge(int[] nodes)
        {
            int parent = nodes[0];
            int child = nodes[1];

            Tree<int> parentNode = GetTreeNodeByValue(parent);
            Tree<int> childNode = GetTreeNodeByValue(child);

            parentNode.Children.Add(childNode);
            childNode.Parent = parentNode;
        }

        private static Tree<int> GetTreeNodeByValue(int value)
        {
            if (!tree.ContainsKey(value))
            {
                tree.Add(value, new Tree<int>(value));
            }

            return tree[value];
        }
    }
    public class Tree<T>
    {
        public T Value { get; set; }

        public List<Tree<T>> Children { get; set; }

        public Tree<T> Parent { get; set; }

        public Tree(T value, params Tree<T>[] children)
        {
            this.Value = value;
            this.Children = new List<Tree<T>>(children);
        }
    }
}
