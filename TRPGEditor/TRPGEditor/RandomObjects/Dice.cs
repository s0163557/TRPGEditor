using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TRPGEditor.RandomObjects
{
    internal class Dice : IRandomObject
    {
        // Грани и то что в них хранится.
        string[] edges;

        // В идеале добавить поле к кубику, в котором будет описываться его назначение.
        string description { get; set; }

        // Создаёт кубик с заданным количеством граней.
        public Dice(int numberOfEdges)
        {
            edges = new string[numberOfEdges];
            for (int i = 0; i < numberOfEdges; i++)
            {
                edges[i] = (i + 1).ToString();
            }
        }

        /// <summary>
        /// Возвращает случайное значение из кубика.
        /// </summary>
        /// <returns></returns>
        public string GetRandomValue()
        {
            Random random = new Random();
            return edges[random.Next(0, edges.Length)];
        }

        /// <summary>
        /// Изменяет значение грани в заданном номере грани.
        /// </summary>
        /// <param name="numberOfEdge"></param>
        /// <param name="newEdgeValue"></param>
        public void SetEdge(int numberOfEdge, string newEdgeValue)
        {
            edges[numberOfEdge] = newEdgeValue;
        }

        /// <summary>
        /// Возвращает количество граней в кубике.
        /// </summary>
        /// <returns></returns>
        public int GetEdgeCount()
        {
            return edges.Length;
        }

        /// <summary>
        /// Возвращает значение заданной грани в кубике.
        /// </summary>
        /// <param name="edgeNumber"></param>
        /// <returns></returns>
        public string GetEdge(int edgeNumber)
        { 
            return edges[edgeNumber];
        }
    }
}
