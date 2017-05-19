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
            
            while (i >= 0 && !new LineSegment(m_Hitbox[i], ThisPosition).CheckCrossing(SegmentToCheck))
            {
                i--;
            }
            return i >= 0;
        }
        public bool DetectCollisionHitboxHitbox(Hitbox HitboxToCheck, Vector2 HitboxToCheckPosition, Vector2 ThisPosition)
        {
            throw new NotImplementedException();
            /*
            int i = m_Hitbox.Length - 1;
            int j = HitboxToCheck.FullHitbox.Length - 1;
            if (j >= 0)
            {
                while (i > 0 && !m_Hitbox[i].CheckCrossing(HitboxToCheck.FullHitbox[j]))
                {
                    j--;
                    if (j < 0)
                    {
                        i--;
                        j = HitboxToCheck.FullHitbox.Length - 1;
                    }
                }
            }
            return i >= 0;*/
        }
    }
}
