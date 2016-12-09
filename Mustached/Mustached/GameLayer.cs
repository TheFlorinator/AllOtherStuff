using System;
using System.Collections.Generic;
using CocosSharp;
using Microsoft.Xna.Framework;

namespace Mustached
{
    public class GameLayer : CCLayerColor
    {

        // Define a label variable
        CCLabel label;

        public GameLayer() : base(CCColor4B.Blue)
        {

            // create and initialize a Label
            label = new CCLabel("Hello CocosSharp", "Fonts/MarkerFelt", 22, CCLabelFormat.SpriteFont);
            var paddleSprite = new CCSprite("Paddle");
            paddleSprite.PositionX = 100;
            paddleSprite.PositionY = 100;
            AddChild(paddleSprite);
            // add the label as a child to this Layer
            AddChild(label);

        }

        protected override void AddedToScene()
        {
            base.AddedToScene();

            // Use the bounds to layout the positioning of our drawable assets
            CCRect bounds = VisibleBoundsWorldspace;
            
            // position the label on the center of the screen

            // Register for touch events
            var touchListener = new CCEventListenerTouchAllAtOnce();
            touchListener.OnTouchesEnded = OnTouchesEnded;
            AddEventListener(touchListener, this);
        }

        void OnTouchesEnded(List<CCTouch> touches, CCEvent touchEvent)
        {
            if (touches.Count > 0)
            {
                // Perform touch handling here
            }
        }
    }
}
