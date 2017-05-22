using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace Hitbox.Engine
{
    class Hitbox
    {
        private LineSegment[] m_Hitbox;

        public Hitbox(LineSegment[] Hitbox)
        {
            m_Hitbox = Hitbox;
        }

        public LineSegment[] FullHitbox
        {
            get { return m_Hitbox; }
            set { m_Hitbox = value; }
        }

        public bool DetectCollisionSegmentHitbox(LineSegment SegmentToCheck, Vector2 ThisPosition)
        {
            int i = m_Hitbox.Length - 1;
            LineSegment toCheck = new LineSegment(new Vector2(), new Vector2());
            while (i >= 0 && !toCheck.Set(m_Hitbox[i].Start + ThisPosition, m_Hitbox[i].End + ThisPosition).CheckCrossing(SegmentToCheck))
            {
                i--;
            }
            return i >= 0;
        }


        private bool BoundingRectanglesCollision_Check1(LineSegment SegmentToCheck, Vector2 OldPosition, Vector2 NewPosition)
        {
            Rectangle BoundingRectangle = FindBoundingRectangleOfHitbox(OldPosition, NewPosition);
          /*  float st, et, fst = 0, fet = 1;
            float bmin = BoundingRectangle.min.x;
            float bmax = &box.max.x;
            float si = &start.x;
            float ei = &end.x;

            for (int i = 0; i < 3; i++)
            {
                if (*si < *ei)
                {
                    if (*si > *bmax || *ei < *bmin)
                        return false;
                    F32 di = *ei - *si;
                    st = (*si < *bmin) ? (*bmin - *si) / di : 0;
                    et = (*ei > *bmax) ? (*bmax - *si) / di : 1;
                }
                else
                {
                    if (*ei > *bmax || *si < *bmin)
                        return false;
                    F32 di = *ei - *si;
                    st = (*si > *bmax) ? (*bmax - *si) / di : 0;
                    et = (*ei < *bmin) ? (*bmin - *si) / di : 1;
                }

                if (st > fst) fst = st;
                if (et < fet) fet = et;
                if (fet < fst)
                    return false;
                bmin++; bmax++;
                si++; ei++;
            }

            *time = fst;
            return true;*/
            return true;
        }

        private Rectangle FindBoundingRectangleOfHitbox(Vector2 OldPosition, Vector2 NewPosition)
        {
            float xMin = Math.Min(m_Hitbox[0].Start.X, m_Hitbox[0].End.X);
            float xMax = Math.Max(m_Hitbox[0].Start.X, m_Hitbox[0].End.X);
            float yMin = Math.Min(m_Hitbox[0].Start.Y, m_Hitbox[0].End.Y);
            float yMax = Math.Min(m_Hitbox[0].Start.Y, m_Hitbox[0].End.Y);
            for (int i = 1; i < m_Hitbox.Length; i++)
            {
                if (m_Hitbox[i].Start.X < xMin)
                {
                    xMin = m_Hitbox[i].Start.X;
                }
                if (m_Hitbox[i].End.X < xMin)
                {
                    xMin = m_Hitbox[i].End.X;
                }
                if (m_Hitbox[i].Start.Y < yMin)
                {
                    yMin = m_Hitbox[i].Start.Y;
                }
                if (m_Hitbox[i].End.Y < yMin)
                {
                    yMin = m_Hitbox[i].End.Y;
                }
                if (m_Hitbox[i].Start.X > xMax)
                {
                    xMax = m_Hitbox[i].Start.X;
                }
                if (m_Hitbox[i].End.X > xMax)
                {
                    xMax = m_Hitbox[i].End.X;
                }
                if (m_Hitbox[i].Start.Y < yMax)
                {
                    yMax = m_Hitbox[i].Start.Y;
                }
                if (m_Hitbox[i].End.Y < yMax)
                {
                    yMax = m_Hitbox[i].End.Y;
                }
            }

            xMin += Math.Min(OldPosition.X, NewPosition.X);
            yMin += Math.Min(OldPosition.Y, NewPosition.Y);
            xMax += Math.Max(OldPosition.X, NewPosition.X);
            yMax += Math.Max(OldPosition.Y, NewPosition.Y);

            return new Rectangle((int)xMin, (int)yMin, (int)(xMax -xMin), (int)(yMax -yMin));
        }


        public bool DetectCollisionSegmentHitbox(LineSegment SegmentToCheck, Vector2 ThisPosition, Vector2 OldPosition)
        {
            int i = m_Hitbox.Length - 1;
            LineSegment toCheck = new LineSegment(new Vector2(), new Vector2());
            while (i >= 0 && !toCheck.Set(m_Hitbox[i].Start + ThisPosition, m_Hitbox[i].End + ThisPosition).CheckCrossing(SegmentToCheck))
            {
                i--;
            }
            return i >= 0;
        }
        public bool DetectCollisionHitboxHitbox(Hitbox HitboxToCheck, Vector2 HitboxToCheckPosition, Vector2 ThisPosition)
        {
            bool ret = false;
            LineSegment[] seg = HitboxToCheck.FullHitbox;
            LineSegment toCheck = new LineSegment(new Vector2(), new Vector2());
            int i = seg.Length - 1;
            while (i >= 0 && !ret)
            {
                ret = DetectCollisionSegmentHitbox(toCheck.Set(seg[i].Start + HitboxToCheckPosition, seg[i].End + HitboxToCheckPosition), ThisPosition);
                i--;
            }
            return ret;
        }
    }
}
