using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LumixEngine.Math
{
    public class Vec2<T>
    {
        /// <summary>
        /// The first component of the vector
        /// </summary>
        public T X { get; set; }

        /// <summary>
        /// The second component of the vector
        /// </summary>
        public T Y { get; set; }

        /// <summary>
        /// Creates a vec2
        /// </summary>
        /// <param name="x">1st component</param>
        /// <param name="y">2nd component</param>
        public Vec2(T x, T y)
        {
            X = x;
            Y = y;
        }
    }
}
