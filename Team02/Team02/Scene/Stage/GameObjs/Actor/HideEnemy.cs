using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InfinityGame.Element;
using InfinityGame.GameGraphics;
using InfinityGame.Stage.StageObject;
using InfinityGame.Device;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

using Team02.Scene.Stage.GameObjs.API;

namespace Team02.Scene.Stage.GameObjs.Actor
{
    public class HideEnemy : Enemy
    {
        private SImage face;
        private bool showFace = false;
        private Color defaultColor = Color.White;
        private bool changeColor = false;
        private int stabilityTime = 0;
        private int stabilityTarget = 60;
        private float stabilitySpeed = 0.2f;

        public int StabilityTime { get => stabilityTime; set => SetStabilityTime(value); }

        public HideEnemy(BaseDisplay aParent, string aName) : base(aParent, aName)
        {
            CrimpGroup = "";
            DefaultMovePri = 9;
        }

        public HideEnemy(MapCreator mapCreator, Dictionary<string, object> args) : base(mapCreator, args)
        {
            CrimpGroup = "";
            DefaultMovePri = 9;
        }

        protected override void SetGra(Vector2 value)
        {
            gra = Vector2.Zero;
        }

        private void SetStabilityTime(int value)
        {
            stabilityTime = Math.Min(value, stabilityTarget);
            if (stabilityTime == stabilityTarget - 1)
                Stability();
        }

        public override void Initialize()
        {
            Gra = Vector2.Zero;
            _Damage = null;
            _Damage += ShowFace;
            _Damage += ShowDamageBar;
            base.Initialize();
            EnableChange = false;//CharaクラスでこれをTrueに設定しているため、base.Initialize()の後にもう一度設定する
        }

        public override void ResetGra()
        {
            Gra = Vector2.Zero;
        }

        protected override void SetImage()
        {
            ImageName = "Block.png";
            Motion.Images[Direction.Right][MotionState.Normal] = ImageName;
            Motion.Images[Direction.Right][MotionState.Fall] = ImageName;
            Motion.Images[Direction.Right][MotionState.Jump] = ImageName;
            Motion.Images[Direction.Right][MotionState.Walk] = ImageName;
            Motion.Images[Direction.Right][MotionState.Float] = ImageName;
            Motion.Images[Direction.Left][MotionState.Normal] = ImageName;
            Motion.Images[Direction.Left][MotionState.Fall] = ImageName;
            Motion.Images[Direction.Left][MotionState.Jump] = ImageName;
            Motion.Images[Direction.Left][MotionState.Walk] = ImageName;
            Motion.Images[Direction.Left][MotionState.Float] = ImageName;
            
        }

        private void ShowFace()
        {
            showFace = true;
            defaultColor = Color.Red;
            Color = Color.Red;
        }

        private void ShowDamageBar()
        {
            HpUI.Visible = true;
            _Damage -= ShowDamageBar;
        }

        public override void Update(GameTime gameTime)
        {
            changeColor = false;
            base.Update(gameTime);
        }

        public override void AfterUpdate(GameTime gameTime)
        {
            if (!changeColor)
                Color = defaultColor;
            if ((Coordinate - LastCoordinate).LengthSquared() <= stabilitySpeed * stabilitySpeed)
                StabilityTime++;
            else
                StabilityTime = 0;
            base.AfterUpdate(gameTime);
        }

        public override void CalCollision(StageObj obj)
        {
            {
                if (!(obj is Hero) && obj is IForce f && (f.Speed - Speed).LengthSquared() >= DamageSpeed * DamageSpeed)
                    Hp -= 50;
            }
            if (obj is Hero /*h && CheckIForceOn(h)*/)
            {
                changeColor = true;
                Color = Color.Red;
            }
            base.CalCollision(obj);
        }

        private void Stability()
        {
            Speed = Vector2.Zero;
            Forces.Clear();
            //Forces["strut"] = -Gra * 0.95f;
        }

        public override void Draw2(GameTime gameTime)
        {
            base.Draw2(gameTime);
            if (face != null && showFace)
            {
                Vector2 checkLocation = DrawLocation.ToVector2() + 2 * (RenderCoo_Offset * Stage.CameraScale);
                Vector2 checkSize = size.ToVector2() + RenderSize_Offset;
                if (checkLocation.X <= Stage.StageScene.Size.Width && checkLocation.Y <= Stage.StageScene.Size.Height)
                {
                    if (checkLocation.X >= -checkSize.X * Stage.CameraScale && checkLocation.Y >= -checkSize.Y * Stage.CameraScale)
                    {
                        Rectangle renderR = RenderRect;
                        if (renderR == default(Rectangle))
                            renderR = new Rectangle(Point.Zero, image.Size.ToPoint());
                        spriteBatch.Draw(face.ImageT[iTIndex], new Rectangle(DrawLocation/* + (renderCoo_Offset * stage.CameraScale).ToPoint()*/, ((Size.ToVector2() + RenderSize_Offset) * Stage.CameraScale).ToPoint()), renderR, Color * refract, Rotation, ((Origin - RenderCoo_Offset) / (Size.ToVector2() + RenderSize_Offset)) * image.Size.ToVector2(), SpriteEffects.None, 1f);
                    }
                }
            }
        }
    }
}
