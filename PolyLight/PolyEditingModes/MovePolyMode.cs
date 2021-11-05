﻿using PolyLight.Drawing;
using PolyLight.Drawing.Render;
using PolyLight.Figures;
using PolyLight.Utilities;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PolyLight.PolyEditingModes
{
    internal class MovePolyMode : EditingMode
    {
        private Polygon? _selectedPoly;
        private int _selectedVertex = -1;

        public MovePolyMode(EditRenderer renderer) : base(renderer)
        {
        }

        public override void HandleMouseDown(MouseEventArgs e)
        {
            if(_selectedPoly == null)
            {
                if(IsVertexHitAndSet(e.Location))
                {
                    return;
                }

                if(IsMidPolyHitAndSet(e.Location))
                {
                    return;
                }
            }
        }

        public override void HandleMouseMove(MouseEventArgs e)
        {
            if(_selectedPoly != null)
            {
                if(_selectedVertex != -1)
                {
                    _selectedPoly.MoveVertexTo(_selectedVertex, e.X, e.Y);
                }
                else
                {
                    _selectedPoly.MoveTo(e.X, e.Y);
                }
            }
        }

        public override void HandleMouseUp(MouseEventArgs e)
        {
            if(_selectedPoly != null)
            {
                _selectedPoly = null;
                _selectedVertex = -1;
            }
        }

        private bool IsVertexHitAndSet(Point point)
        {
            var hit = HitboxDetector.DetectHitOnVertex(point, _renderer.Polygons);

            if (hit != null)
            {
                _selectedPoly = hit.Value.hitPolygon;
                _selectedVertex = hit.Value.vertexIndex;
                return true;
            }

            return false;
        }

        private bool IsMidPolyHitAndSet(Point point)
        {
            var hit = HitboxDetector.DetectHitOnMiddleOfPolygon(point, _renderer.Polygons);

            if (hit != null)
            {
                _selectedPoly = hit;
                _selectedVertex = -1;
                return true;
            }

            return false;
        }
    }
}
