﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Hitbox.Engine
{
    class GenericEntityWithHitbox : Entity
    {
        private Hitbox m_Hitbox;
        
        public GenericEntityWithHitbox(Texture2D[] EntityTextures, Vector2 StartPosition, Vector2 Size, Vector2 StartVelocity, Hitbox HB, double AnimationTimerStart = 0.0,
            double AnimationTimerDuration = 1000.0 /*millisecondes*/, bool AnimationLoop = true) : base(EntityTextures, StartPosition, Size, StartVelocity, AnimationTimerStart,
            AnimationTimerDuration, AnimationLoop)
        {
            m_Hitbox = HB;
        }

        public bool CheckIfHit(LineSegment SegmentToCheck)
        {
            return m_Hitbox.DetectCollisionSegmentHitbox(SegmentToCheck, Position);
        }
    }
}
