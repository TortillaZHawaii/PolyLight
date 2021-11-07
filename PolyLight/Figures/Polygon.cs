using PolyLight.Drawing;
using System;
using System.Collections.Generic;
using System.Drawing;

namespace PolyLight.Figures
{
    internal class Polygon
    {
        private readonly List<ColoredPoint> _points;
        private readonly Color _defaultColor;
        
        public Color? Color { get; private set; }
        public IReadOnlyList<ColoredPoint> ColoredPoints => _points;
        public IEnumerable<Point> Points
        {
            get
            {
                foreach(var point in _points)
                {
                    yield return point.Point;
                }
            }
        }

        public int VertexCount => _points.Count;
        public int EdgesCount => _points.Count;

        public DirectBitmap? Texture { get; set; }
        public DirectBitmap? HeightMap { get; set; }

        public Polygon(IEnumerable<Point> points, Color color)
        {
            // initialize points with colors
            _points = new List<ColoredPoint>();
            foreach(var point in points)
            {
                var coloredPoint = new ColoredPoint(point, color);
                _points.Add(coloredPoint);
            }

            // default color
            _defaultColor = color;
        }

        public (int edgeBefore, int edgeAfter) GetNeighborEdgesIndexes(int vertexNumber)
        {
            int edgeBefore = (vertexNumber + _points.Count - 1) % _points.Count;
            int edgeAfter = vertexNumber;

            return (edgeBefore, edgeAfter);
        }

        public (int vertexBefore, int vertexAfter) GetNeighborVerticesIndexes(int edgeNumber)
        {
            int vertexBefore = edgeNumber;
            int vertexAfter = (edgeNumber + 1) % _points.Count;

            return (vertexBefore, vertexAfter);
        }

        public (ColoredPoint vertexBefore, ColoredPoint vertexAfter) GetNeighborVertices(int edgeNumber)
        {
            var (indexBefore, indexAfter) = GetNeighborVerticesIndexes(edgeNumber);

            var pointBefore = _points[indexBefore];
            var pointAfter = _points[indexAfter];

            return (pointBefore, pointAfter);
        }

        public (Point before, Point after) GetNeighborPoints(Point point)
        {
            int index = _points.FindIndex(k => k.Point == point);

            if (index < 0)
            {
                throw new Exception("not found");
            }

            int indexBefore = (index + _points.Count - 1) % _points.Count;
            int indexAfter = (index + 1) % _points.Count;

            return (_points[indexBefore].Point, _points[indexAfter].Point);
        }

        public Point GetMidPoint()
        {
            return PointExtensions.GetMidPoint(_points.ToArray());
        }

        public void SetVertexColor(int vertexNumber, Color newColor)
        {
            Texture = HeightMap = null;
            Color = null;
            var coordinates = _points[vertexNumber].Point;
            _points[vertexNumber] = new ColoredPoint(coordinates, newColor);
        }

        public void ChangeColor(Color newColor)
        {
            Texture = HeightMap = null;
            Color = newColor;
        }

        public void RemoveVertex(int vertexNumber)
        {
            if(_points.Count > 3)
            { 
                _points.RemoveAt(vertexNumber);
            }
        }

        public void SplitEdge(int edgeNumber)
        {
            var (p1, p2) = GetNeighborVertices(edgeNumber);
            var edgePoint = PointExtensions.GetMidColoredPoint(p1, p2);

            InsertVertex(edgeNumber + 1, edgePoint);
        }

        public void InsertVertex(int edgeNumber, Point point)
        {
            var coloredPoint = new ColoredPoint(point, _defaultColor);
            InsertVertex(edgeNumber, coloredPoint);
        }

        public void InsertVertex(int edgeNumber, ColoredPoint point)
        {
            if (edgeNumber < 0) // first vertex
            {
                _points.Add(point);
            }
            else
            {
                _points.Insert(edgeNumber, point);
            }
        }

        public void MoveTo(int x, int y)
        {
            var middle = GetMidPoint();
            int dx = x - middle.X;
            int dy = y - middle.Y;

            Move(dx, dy);
        }

        public void Move(int dx, int dy)
        {
            for (int i = 0; i < _points.Count; ++i)
            {
                MoveVertex(i, dx, dy);
            }
        }

        public void MoveVertex(int vertexNumber, int dx, int dy)
        {
            var point = _points[vertexNumber];
            int x = point.X + dx;
            int y = point.Y + dy;

            MoveVertexTo(vertexNumber, x, y);
        }

        public void MoveVertexTo(int vertexNumber, int x, int y)
        {
            var color = _points[vertexNumber].Color;
            _points[vertexNumber] = new ColoredPoint(x, y, color);
        }
    }
}
