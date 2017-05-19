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
