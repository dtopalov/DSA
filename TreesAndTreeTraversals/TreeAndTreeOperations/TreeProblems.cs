namespace TreeAndTreeOperations
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class TreeProblems
    {
        static void Main()
        {
            // Paste sample input
/* Example input:
7
2 4
3 2
5 0
3 5
5 6
5 1
*/
            int numberOfNodes = int.Parse(Console.ReadLine());

            TreeNode<int>[] values = new TreeNode<int>[numberOfNodes];

            for (int i = 0; i < numberOfNodes; i++)
            {
                values[i] = new TreeNode<int>(i);
            }

            for (int i = 0; i < numberOfNodes - 1; i++)
            {
                string edge = Console.ReadLine();
                string[] parentChildPair = edge.Split(' ');
                int parent = int.Parse(parentChildPair[0]);
                int child = int.Parse(parentChildPair[1]);

                values[parent].AddChild(values[child]);
            }

            // Problem 1a:
            var root = values.Where(x => !x.HasParent).FirstOrDefault();

            Console.WriteLine("Root: {0}", root.Value);

            // Problem 1b:
            var leaves = values.Where(x => x.ChildrenCount == 0).Select(x => x.Value);

            Console.WriteLine("Leafe nodes: {0}", string.Join(", ", leaves));

            // Problem 1c:

            var middleNodes = values.Where(x => x.HasParent && x.ChildrenCount > 0).Select(x => x.Value);

            Console.WriteLine("Middle nodes: {0}", string.Join(", ", middleNodes));

            // Problem 1d:
            Console.WriteLine("Longest path: {0}", FindLongestPath(root));

            // Problem 1e:
            int sum = 9;
            var allPathsWithSumS = GetAllPathsWithGivenSum(sum, values, root);
            Console.WriteLine();
            foreach (var path in allPathsWithSumS)
            {
                Console.WriteLine("Path in tree with sum {0} is: {1}", sum, path);
            }

            var subtreeSum = 6;
            var allSubTreesWithSumS = GetAllSubtreeWithGivenSum(subtreeSum, root);
            Console.WriteLine();
            foreach (var path in allSubTreesWithSumS)
            {
                Console.WriteLine("Subtree with sum {0} is: {1}", subtreeSum, path);
            }
        }

        public static IList<string> GetAllPathsWithGivenSum(int sum, TreeNode<int>[] values, TreeNode<int> root)
        {
            IList<string> allPaths = new List<string>();
            FindPathWithSum(sum, root.Value, allPaths, root.Value.ToString(), root, true);
            return allPaths;
        }

        private static void FindPathWithSum(
                        int targetSum,
                        int currentSum,
                        IList<string> paths,
                        string currentPath,
                        TreeNode<int> node,
                        bool searchOnlyFullPaths)
        {
            var sumFound = (currentSum == targetSum) && (!searchOnlyFullPaths || (node.Children.Count == 0));

            if (sumFound)
            {
                paths.Add(currentPath);
            }

            foreach (var childNode in node.Children)
            {
                var newSum = currentSum + childNode.Value;
                string newPath = currentPath + " " + childNode.Value;
                FindPathWithSum(targetSum, newSum, paths, newPath, childNode, searchOnlyFullPaths);
            }
        }

        private static IList<string> GetAllSubtreeWithGivenSum(int sum, TreeNode<int> root)
        {
            IList<string> allPaths = new List<string>();
            Queue<TreeNode<int>> queue = new Queue<TreeNode<int>>();
            queue.Enqueue(root);
            while (queue.Count != 0)
            {
                var node = queue.Dequeue();
                FindPathWithSum(sum, (dynamic)node.Value, allPaths, node.Value.ToString(), node, false);
                foreach (var childNode in node.Children)
                {
                    queue.Enqueue(childNode);
                }
            }

            return allPaths;

        }

        private static int FindLongestPath(TreeNode<int> root)
        {
            if (root.ChildrenCount == 0)
            {
                return 0;
            }

            int longestPath = 0;

            foreach (var child in root.Children)
            {
                longestPath = Math.Max(FindLongestPath(child), 0);
            }

            return longestPath + 1;
        }
    }
}
