using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace Hitbox.Engine
{
    public class LineSegment
    {
        private Vector2 m_Start;
        private Vector2 m_End;

        public LineSegment(Vector2 Start, Vector2 End)
        {
            m_Start = Start;
            m_End = End;
        }
        public LineSegment(LineSegment Ls, Vector2 TranslatePosition)
        {
            m_Start = Ls.Start+TranslatePosition;
            m_End = Ls.End+TranslatePosition;
        }

        public Vector2 Start
        {
            get { return m_Start; }
            set { m_Start = value; }
        }

        public Vector2 End
        {
            get { return m_End; }
            set { m_End = value; }
        }



        public bool CheckCrossing(LineSegment SegmentToCheck)
        {
            float Denominator = ((this.End.X - this.Start.X) * (SegmentToCheck.End.Y - SegmentToCheck.Start.Y)) -
                                ((this.End.Y - this.Start.Y) * (SegmentToCheck.End.X - SegmentToCheck.Start.X));
            float Numerator1 = ((this.Start.Y - SegmentToCheck.Start.Y) * (SegmentToCheck.End.X - SegmentToCheck.Start.X)) -
                               ((this.Start.X - SegmentToCheck.Start.X) * (SegmentToCheck.End.Y - SegmentToCheck.Start.Y));
            float Numerator2 = ((this.Start.Y - SegmentToCheck.Start.Y) * (this.End.X - this.Start.X)) -
                               ((this.Start.X - SegmentToCheck.Start.X) * (this.End.Y - this.Start.Y));


            if (Denominator == 0) return Numerator1 == 0 && Numerator2 == 0;

            float R = Numerator1/Denominator;
            float S = Numerator2/Denominator;

            return (R >= 0 && R <= 1) && (S >= 0 && S <= 1);

        }
    }
}

