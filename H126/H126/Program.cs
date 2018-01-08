using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace H126
{
    class Program
    {
        static void Main(string[] args)
        {
            string beginWord = "hit";
            string endWord = "cog";
            string[] wordList = { "hot", "dot", "dog", "lot", "log", "cog" };

            FindLadders(beginWord, endWord, wordList.ToList());
        }

        static public IList<IList<string>> FindLadders(string beginWord, string endWord, IList<string> wordList)
        {
            Node begin = new Node(beginWord);

            Node end = new Node(endWord);

            BFTree(begin, wordList);

            int wordsNum = wordList.Count();

            return null;
        }

        static public void BFTree(Node node, IList<string> wordList)
        {
            foreach (var word in wordList)
            {
                if (StringDiff(node.Word, word) == 1 && CheckAncestor(node, word))
                {
                    Node newChild = new Node(node, word);

                    node.Children.Add(newChild);

                    BFTree(newChild, wordList);
                }
            }
        }

        static public IList<string> TraceBFTree(Node node)
        {
            List<Node> sol = new List<Node>();

            
        }

        /// <summary>
        /// 比較兩個字串的不同
        /// </summary>
        /// <param name="s1"></param>
        /// <param name="s2"></param>
        /// <returns>回傳不同的自數，若長度不同回傳-1</returns>
        static public int StringDiff(string s1, string s2)
        {
            if (s1.Length != s2.Length)
            {
                return -1;
            }

            int len = s1.Length;

            int diffCount=0;

            for (int i = 0; i < len; i++)
            {
                if (s1[i] != s2[i])
                {
                    diffCount++;
                }
            }

            return diffCount;
        }

        /// <summary>
        /// 檢查有沒有使用過
        /// </summary>
        /// <param name="node"></param>
        /// <param name="word"></param>
        /// <returns></returns>
        static public bool CheckAncestor(Node node, string word)
        {
            while(node != null)
            {
                if (node.Word == word)
                {
                    return false;
                }

                node = node.Father;
            }

            return true;
        }
    }

    public class Node
    {
        public string Word { get; set; }

        public Node Father { get; set; }

        public List<Node> Children { get; set; }

        public Node(string word)
        {
            Word = word;

            Children = new List<Node>();
        }

        /// <summary>
        /// 建構式
        /// </summary>
        /// <param name="father"></param>
        /// <param name="word"></param>
        public Node(Node father, string word)
        {
            Word = word;

            Father = father;

            Children = new List<Node>();
        }
    }
}
