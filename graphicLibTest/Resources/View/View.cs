using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using OpenTK;
using System.Drawing;
using OpenTK.Graphics.OpenGL;

namespace graphicLibTest.Resources.View
{
    public enum TweenType
    {
        Instant,
        Linear,
        QuadraticInOut,
        CubicInOut,
        QuarticOut
    }
    class View
    {
        private Vector2 position;
        public double rotation;
        public double zoom;

        private Vector2 positionGoto, positionFrom;
        private TweenType tweenType;
        private int CurrentStep, tweenStep;

        public Vector2 Position
        {
            get
            {
                return this.position;
            }
        }
        public Vector2 PositionGoto
        {
            get { return positionGoto; }
        }

        public Vector2 ToWorld(Vector2 input)
        {
            input /= (float)zoom;
            Vector2 dX = new Vector2((float)Math.Cos(rotation), (float)Math.Sin(rotation));
            Vector2 dY = new Vector2((float)Math.Cos(rotation + MathHelper.PiOver2), (float)Math.Sin(rotation + MathHelper.PiOver2));

            return (this.position + dX * input.X + dY * input.Y);
        }

        public View(Vector2 startposition, double startZoom = 1.0, double startRotation = 0.0)
        {
            this.position = startposition;
            this.rotation = startRotation;
            this.zoom = startZoom;
        }

        public void Update()
        {
            if (CurrentStep < tweenStep)
            {
                CurrentStep++;

                switch (tweenType)
                {
                    case TweenType.Linear:
                        position = positionFrom + (positionGoto - positionFrom) * GetLinear((float)CurrentStep / tweenStep);
                        break;
                    case TweenType.QuadraticInOut:
                        position = positionFrom + (positionGoto - positionFrom) * GetQuadraticInOut((float)CurrentStep / tweenStep);
                        break;
                    case TweenType.CubicInOut:
                        position = positionFrom + (positionGoto - positionFrom) * GetCubicInOut((float)CurrentStep / tweenStep);
                        break;
                    case TweenType.QuarticOut:
                        position = positionFrom + (positionGoto - positionFrom) * GetQuarticOut((float)CurrentStep / tweenStep);
                        break;
                }
            }
            else
            {
                position = positionGoto;
            }
        }

        public void SetPosition(Vector2 newPosition)
        {
            this.position = newPosition;
            this.positionFrom = newPosition;
            this.positionGoto = newPosition;
            tweenType = TweenType.Instant;
            CurrentStep = 0;
            tweenStep = 0;
        }
        public void SetPosition(Vector2 newPosition, TweenType type, int numSteps)
        {
            this.positionFrom = position;
            this.position = newPosition;
            this.positionGoto = newPosition;
            tweenType = type;
            CurrentStep = 0;
            tweenStep = numSteps;
        }

        public float GetLinear(float t)
        {
            return t;
        }
        public float GetQuadraticInOut(float t)
        {
            return (t * t) / ((2 * t * t) - (2 * t) + 1);
        }
        public float GetCubicInOut(float t)
        {
            return (t * t * t) / ((3 * t * t) - (3 * t) + 1);
        }
        public float GetQuarticOut(float t)
        {
            return -((t - 1) * (t - 1) * (t - 1) * (t - 1)) + 1;
        }

        public void ApplyTransform()
        {
            Matrix4 transform = Matrix4.Identity;

            transform = Matrix4.Mult(transform, Matrix4.CreateTranslation(-position.X, -position.Y, 0));
            transform = Matrix4.Mult(transform, Matrix4.CreateRotationZ(-(float)rotation));
            transform = Matrix4.Mult(transform, Matrix4.CreateScale((float)zoom, (float)zoom, 1.0f));

            GL.MultMatrix(ref transform);
        }
    }
}
